using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.Logger
{
    public class Observer<T>(Action<T> action) : IObserver<T>
    {
        private Action<T> _nextAction = action;

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(T value)
        {
            _nextAction(value);
        }

    }
}
