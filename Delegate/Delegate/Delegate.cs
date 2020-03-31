using System;

namespace Delegate {
    class Delegate {
        public static void FirstMethod(int one, int two, string three) =>
            Console.WriteLine($"FirstMethod({one}, {two}, {three})");

        public static void SecondMethod(int one, int two, string three) =>
            Console.WriteLine($"SecondMethod({one}, {two}, {three})");
    }
}
