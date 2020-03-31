using System;
using System.Threading;
using System.Windows.Forms;

namespace Threading {
    public partial class Threading : Form
    {
        private readonly Thread _thread = new Thread(CalculateSumEvenNumbers);
        public Threading() {
            InitializeComponent();
            _thread.Name = "Петро";
            _thread.Priority = ThreadPriority.Normal;
        }

        private void button1_Click(object sender, EventArgs e) {
            _thread.Start();
            button1.Enabled = false;
        }
        private static void CalculateSumEvenNumbers()
        {
            var sum = 0;
            for (var i = 100; i < 150; i++) {
                if (i % 2 == 0) {
                    sum += i;
                    MessageBox.Show(sum.ToString());
                    Thread.Sleep(TimeSpan.FromMilliseconds(2500));
                }
            }

            //MessageBox.Show(Enumerable.Range(100, 49).Where(number => number % 2 == 0).Sum().ToString());
        }

        private static void ParameterizedCalculateSumEvenNumbers(object obj) => CalculateSumEvenNumbers();

        private void button2_Click(object sender, EventArgs e) => CalculateSumEvenNumbers();

        private void button3_Click(object sender, EventArgs e) {
            if (_thread.IsAlive) _thread.Abort();
        }

        private void button4_Click(object sender, EventArgs e) {
            Thread thread = new Thread(new ParameterizedThreadStart(ParameterizedCalculateSumEvenNumbers));
            thread.Start(true);
        }
    }
}
