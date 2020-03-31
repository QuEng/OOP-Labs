using System;

namespace Functions {
    class newClass {
        public int GetNumber(int number, bool multiplyOrDivide) {
            int result = multiplyOrDivide ? number * 2 : number / 2;
            Console.WriteLine(result);
            return result;
        }
    }
}
