﻿using DesignModel.FactoryPattern_工厂模式_;

namespace DesignModel
{
    internal class Program
    {
        #region 0

        /*
        开闭原则：对修改关闭，对拓展开放。
        单一职责：就一个类而言，应该仅有一个引起它变化点原因。
        里氏替换：任何出现基类的地方，子类一定可以替换。
        依赖倒转：抽象不应该依赖于细节，细节依赖于抽象。
        接口隔离：类之间依赖应该建立与最小接口上。
        迪米特法则： 一个实体应该尽量少于其他实体发生作用。（如果两个类不直接通信，那么这两个类就不应该直接发生作用。）
        合成复用：尽量使用合成/聚合的方式，而不是使用继承。

        2.建造者模式(Builder)：将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
        3.工厂模式(Factory):定义一个创建对象的接口，让子类决定实例化哪个类。使一个类的实例化延迟到子类。

        1.抽象工厂(Abstract Factory)：提供一个创建一系列相关的或者相互依赖的对象的接口，而无需指定他们具体的类。
        2.策略模式(Strategy)：定义了算法家族，分别封装起来，让它们之间可以互相替换。此模式让算法的变化，不会影响到使用算法的客户。
        3.装饰器模式(Decorator)：动态的给一个对象添加额外的职责，装饰器模式比子类更加灵活
        4.代理模式(Proxy)：为其他对象提供一种代理以控制对这个对象的访问
        5.原型模式(Prototype)：用原型实例指定创建对象的种类，并通过拷贝这些原形创建新的对象
        6.模板方法(TempleteMethod)：定义操作中一个算法的骨架，将一些步骤延迟到子类中，模板方法使得子类不改变一个算法得结构即可重新定义某些方法的特定步骤
        7.外观模式(Facade)：为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层接口这个接口使子系统更加容易使用。
        8.0 建造者模式(Builder)：将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
        8.1 建造者模式：使用多个简单的对象一步一步构建成一个复杂的对象。

        9.观察者模式(Observer/Subscrbe)：定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个对象。此主题对象发生变化时会通知所有观察者对象，使他们自动更新自己
        10.状态模式(State)：一个对象的内在状态改变时允许改变其行为，这个对象看起来是改变了其类
        10.1 状态模式：类的行为是基于它的状态改变的。
        11.适配器模式(Adapter)：将一个接口转换为客户希望的另一个接口使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。
        12.备忘录模式(Momento)：在不破坏封装的前提下捕获一个对象内部状态，并在对象内部之外进行保存，这样以后可将该对象恢复到原先保存的状态。
        13.组合模式(Composite)：将对象组合成树形结构以表示‘部分-整体’的层次结构。组合模式使得单个对象和组合对象使用具有一致性。
        14.迭代器模式(Iterator)：提供一种方法顺序访问一个聚合对象中各个元素，而又不暴露对象的内部表示。
        15.单例模式(Singleton)：保证一个类只有一个实例，并提供一个访问它的全局访问点。
        16.桥接模式(Bridge)：将抽象部分与它的实现部分分离，使它们都可以独立变化。
        17.命令模式(Command)：将请求封装成一个对象从而是你可用不同的请求对客户进行参数化，对请求排队或记录请求日志，以及支持可撤销的操作。
        18.责任链模式(Chain of Responsibility)：使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。将对象连成一条链，沿着这条链传递请求，直到有一个对象处理它为止。
        19.中介者模式(Mediator)：使用一个中介对象来封装一系列的对象交互。中介者使对象不需要显示地相互引用。从而使其耦合松散，并可以独立的改变他们之间的交互。
        20.享元模式(flyweight)：运用共享技术有效的支持大量细粒度的对象交互。
        21.解释器模式(Interpreter)：定义一种语言，定义它的文法的一种表示，并定义一个解释器这个解释器使用该表示来解释语言中的句子。
        22.访问者模式(Visitor)：作用于某对象结构中的各元素的操作。它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作。

         */

        #endregion

        #region 1
        /*
            工厂模式(Factory):定义一个创建对象的接口，让子类决定实例化哪个类。使一个类的实例化延迟到子类。
            原型模式(Prototype)：用原型实例指定创建对象的种类，并通过拷贝这些原形创建新的对象。
            单例模式(Singleton)：保证一个类只有一个实例，并提供一个访问它的全局访问点。
            建造者模式(Builder)：将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
            抽象工厂(Abstract Factory)：提供一个创建一系列相关的或者相互依赖的对象的接口，而无需指定他们具体的类。

            享元模式(flyweight)：运用共享技术有效的支持大量细粒度的对象交互。
            外观模式(Facade)：为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层接口这个接口使子系统更加容易使用。
            组合模式(Composite)：将对象组合成树形结构以表示‘部分-整体’的层次结构。组合模式使得单个对象和组合对象使用具有一致性
            适配器模式(Adapter)：将一个接口转换为客户希望的另一个接口使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。
            代理模式(Proxy)：为其他对象提供一种代理以控制对这个对象的访问。
            装饰器模式(Decorator)：动态的给一个对象添加额外的职责，装饰器模式比子类更加灵活。
            桥接模式(Bridge)：将抽象部分与它的实现部分分离，使它们都可以独立变化。

            状态模式(State)：一个对象的内在状态改变时允许改变其行为，这个对象看起来是改变了其类。
            责任链模式(Chain of Responsibility)：使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。将对象连成一条链，沿着这条链传递请求，直到有一个对象处理它为止。
            中介者模式(Mediator)：使用一个中介对象来封装一系列的对象交互。中介者使对象不需要显示地相互引用。从而使其耦合松散，并可以独立的改变他们之间的交互。
            模板方法(TempleteMethod)：定义操作中一个算法的骨架，将一些步骤延迟到子类中，模板方法使得子类不改变一个算法得结构即可重新定义某些方法的特定步骤。        
            访问者模式(Visitor)：作用于某对象结构中的各元素的操作。它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作。

            解释器模式(Interpreter)：定义一种语言，定义它的文法的一种表示，并定义一个解释器这个解释器使用该表示来解释语言中的句子。
            备忘录模式(Momento)：在不破坏封装的前提下捕获一个对象内部状态，并在对象内部之外进行保存，这样以后可将该对象恢复到原先保存的状态。
            观察者模式(Observer/Subscrbe)：定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个对象。此主题对象发生变化时会通知所有观察者对象，使他们自动更新自己
            策略模式(Strategy)：定义了算法家族，分别封装起来，让它们之间可以互相替换。此模式让算法的变化，不会影响到使用算法的客户。
            命令模式(Command)：将请求封装成一个对象从而使你可用不同的请求对客户进行参数化，对请求排队或记录请求日志，以及支持可撤销的操作。
            迭代器模式(Iterator)：提供一种方法顺序访问一个聚合对象中各个元素，而又不暴露对象的内部表示。
         */
        #endregion

        static void Main(string[] args)
        {
            PatternGame.Run();


            FactoryPatternDemo.A();
            //Console.WriteLine("Hello World!");
            //ClainOfResponsibilityDemo.main();
            //Console.ReadLine();

            //ConcurrentDictionary<int,string> keyValuePairs= new ConcurrentDictionary<int,string>();
        }
    }
}
