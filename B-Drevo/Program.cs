using System;
using System.IO;
using System.Windows.Forms;

namespace BDrevesa {
    class Program {

        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BDrevesaUI());
        }
    }
}
