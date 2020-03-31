using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate {
    class ClassCounter {
        public delegate void MethodContainer();

        public  event MethodContainer onCount;


        public void Count() {
            for (int i = 0; i < 100; i++) {
                if (i == 71) {
                    onCount();
                }
            }
        }
    }
}
