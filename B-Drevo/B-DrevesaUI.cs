using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BDrevesa {

    public partial class BDrevesaUI : Form {
        private BDrevo _bDrevo;

        public BDrevesaUI() {
            InitializeComponent();
        }

        private void BtnSpremeniClick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbDodaj.Text)) {
                SpremeniStopnjo(nudStopnja.Value);
            }
            else {
                Dodaj(tbDodaj.Text);
            }
        }

        private void Dodaj(string text) {
            
        }

        private void SpremeniStopnjo(decimal value) {
            
        }

        private void BtnNaloziClick(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = false,
                CheckFileExists = true,
                Filter = "Tekstovna datoteka (*.txt)|*.txt|Vse datoteke (*.*)|*.*",
                Title = "Izberite datoteko z drevesom",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (ofd.ShowDialog() != DialogResult.OK) {
                MessageBox.Show("Niste izbrai datoteke");
                return;
            }

            _bDrevo = new BDrevo((int) nudStopnja.Value);
            string[] vnosi = File.ReadAllText(ofd.FileName).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string vnos in vnosi) {
                int intVnos;
                if (!int.TryParse(vnos, out intVnos)) {
                    continue;
                }

                _bDrevo.Vstavi(intVnos);
            }

            string izrisi = _bDrevo.Izrisi();
            File.WriteAllText("drevo.gv", izrisi);
        }
    }

}