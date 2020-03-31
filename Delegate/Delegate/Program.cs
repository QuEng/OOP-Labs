using System;

namespace Delegate {
    class Program {
        delegate void _delegate(int one, int two, string three);
        static void Main(string[] args) {
            SecondTask();
            Console.ReadLine();
        }

        static void FirstTask() {
            _delegate dl = new _delegate(Delegate.FirstMethod);
            dl += Delegate.SecondMethod;
            dl += Delegate.FirstMethod;
            dl += Delegate.FirstMethod;
            dl += Delegate.FirstMethod;
            dl(5, 25, "monday");
        }

        static void SecondTask() {
            ClassCounter counter = new ClassCounter(); 

            counter.onCount += Handler_I.Message;
            counter.onCount += Handler_II.Message;
            counter.onCount += Handler_III.Message;

            counter.Count();
        }
    }
}
