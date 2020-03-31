using System;

namespace Functions {
    class Program {
        delegate int _delegate(int one, bool two);
        static void Main(string[] args) {
            newClass obj = new newClass();
            _delegate dl = new _delegate(obj.GetNumber);

            dl += (one, two) => {
                int result = two ? (one * 2) / 2 : (one / 2) /2;
                Console.WriteLine(result);
                return result;
            };

            dl += (one, two) => (two ? one * 2 : one / 2) * 10;

            Console.WriteLine("Enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter \"true\" of \"false\": \n(Without \"\")");
            bool multiplyOrDivide = bool.Parse(Console.ReadLine());

            Console.WriteLine(dl(number, multiplyOrDivide));

            Console.ReadLine();
        }
    }
}
