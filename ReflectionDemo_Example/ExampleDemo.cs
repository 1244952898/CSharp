using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionDemo_Example
{
    class ExampleDemo
    {
        public static void MainDemo()
        {
            ExampleDemo ex = new ExampleDemo();
            ex.HookUpDelegate();
        }

        private void HookUpDelegate()
        {
            // Load an assembly, for example using the Assembly.Load
            // method. In this case, the executing assembly is loaded, to
            // keep the demonstration simple.
            //
            Assembly assem = typeof(Example).Assembly;
            // Get the type that is to be loaded, and create an instance 
            // of it. Activator.CreateInstance has other overloads, if
            // the type lacks a default constructor. The new instance
            // is stored as type Object, to maintain the fiction that 
            // nothing is known about the assembly. (Note that you can
            // get the types in an assembly without knowing their names
            // in advance.)
            //
            Type tExForm = assem.GetType("ExampleForm");
            Object obj = Activator.CreateInstance(tExForm);

            // Get an EventInfo representing the Click event, and get the
            // type of delegate that handles the event.
            //
            EventInfo eventInfo = tExForm.GetEvent("Click");
            Type tdelegate = eventInfo.EventHandlerType;

            // If you already have a method with the correct signature,
            // you can simply get a MethodInfo for it. 
            //
            MethodInfo miHandler =
                typeof(Example).GetMethod("LuckyHandler",
                    BindingFlags.NonPublic | BindingFlags.Instance);

            // Create an instance of the delegate. Using the overloads
            // of CreateDelegate that take MethodInfo is recommended.
            //
            Delegate dDelegate = Delegate.CreateDelegate(tdelegate, this, miHandler);

            // Get the "add" accessor of the event and invoke it late-
            // bound, passing in the delegate instance. This is equivalent
            // to using the += operator in C#, or AddHandler in Visual
            // Basic. The instance on which the "add" accessor is invoked
            // is the form; the arguments must be passed as an array.
            //
            MethodInfo addMethodInfo = eventInfo.GetAddMethod();
            Object[] addHandlerArgs = { dDelegate };
            addMethodInfo.Invoke(obj, addHandlerArgs);

            // Event handler methods can also be generated at run time,
            // using lightweight dynamic methods and Reflection.Emit. 
            // To construct an event handler, you need the return type
            // and parameter types of the delegate. These can be obtained
            // by examining the delegate's Invoke method. 
            //
            // It is not necessary to name dynamic methods, so the empty 
            // string can be used. The last argument associates the 
            // dynamic method with the current type, giving the delegate
            // access to all the public and private members of Example,
            // as if it were an instance method.
            //
            Type returnType = GetDelegateReturnType(tdelegate);
            if (returnType != typeof(void))
                throw new ApplicationException("Delegate has a return type.");
            DynamicMethod handler =
                new DynamicMethod("",
                    null,
                    GetDelegateParameterTypes(tdelegate),
                    typeof(Example));

            // Generate a method body. This method loads a string, calls 
            // the Show method overload that takes a string, pops the 
            // return value off the stack (because the handler has no
            // return type), and returns.
            //
            var ilgen = handler.GetILGenerator();
            Type[] showParameters = { typeof(String) };
            MethodInfo simpleShow =
                typeof(MessageBox).GetMethod("Show", showParameters);
            ilgen.Emit(OpCodes.Ldstr,
                "This event handler was constructed at run time.");
            ilgen.Emit(OpCodes.Call, simpleShow);
            ilgen.Emit(OpCodes.Pop);
            ilgen.Emit(OpCodes.Ret);

            // Complete the dynamic method by calling its CreateDelegate
            // method. Use the "add" accessor to add the delegate to
            // the invocation list for the event.
            //
            Delegate dEmitted = handler.CreateDelegate(tdelegate);
            handler.Invoke(obj, new Object[] { dEmitted });

            // Show the form. Clicking on the form causes the two
            // delegates to be invoked.
            //
            Application.Run((Form)obj);

        }

        private Type GetDelegateReturnType(Type tDelegate)
        {
            if (tDelegate.BaseType!=typeof(MulticastDelegate))
            {
                throw new ApplicationException("Not a delegate.");
            }

            MethodInfo invoke = tDelegate.GetMethod("Invoke");
            if (invoke == null)
                throw new ApplicationException("Not a delegate.");
            return invoke.ReturnType;
        }

        private Type[] GetDelegateParameterTypes(Type d)
        {
            if (d.BaseType != typeof(MulticastDelegate))
                throw new ApplicationException("Not a delegate.");

            MethodInfo invoke = d.GetMethod("Invoke");
            if (invoke == null)
                throw new ApplicationException("Not a delegate.");

            ParameterInfo[] parameters = invoke.GetParameters();
            Type[] typeParameters = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                typeParameters[i] = parameters[i].ParameterType;
            }
            return typeParameters;
        }
    }
}
