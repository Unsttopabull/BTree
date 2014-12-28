using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

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
            if (_bDrevo == null) {
                _bDrevo = new BDrevo((int) nudStopnja.Value);
            }

            int intVnos;
            if (!int.TryParse(text, out intVnos)) {
                MessageBox.Show("Ni veljavno število.");
                return;
            }

            _bDrevo.Vstavi(intVnos);

            IzrisiDrevo();
        }

        private void IzrisiDrevo() {
            string drevo = _bDrevo.Izrisi();
            try {
                var startQuery = new GetStartProcessQuery();
                var infoQuery = new GetProcessStartInfoQuery();
                var registerLayout = new RegisterLayoutPluginCommand(infoQuery, startQuery);

                var wrapper = new GraphGeneration(startQuery, infoQuery, registerLayout);
                byte[] png = wrapper.GenerateGraph(drevo, Enums.GraphReturnType.Png);

                pbDrevo.Image = Image.FromStream(new MemoryStream(png));
            }
            catch (Exception) {
                MessageBox.Show("Napaka med generiranjem slike drevesa");
            }
        }

        private void SpremeniStopnjo(decimal value) {
            _bDrevo = _bDrevo.SpremeniStopnjo((int) value);
            IzrisiDrevo();
        }

        private void BtnNaloziClick(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                Multiselect = false,
                CheckFileExists = true,
                FileName = "vhod.txt",
                Filter = "Tekstovna datoteka (*.txt)|*.txt|Vse datoteke (*.*)|*.*",
                Title = "Izberite datoteko z drevesom",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (ofd.ShowDialog() != DialogResult.OK) {
                return;
            }

            _bDrevo = new BDrevo((int) nudStopnja.Value);
            string[] vnosi = File.ReadAllText(ofd.FileName).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string vnos in vnosi) {
                int intVnos;
                if (!int.TryParse(vnos, out intVnos)) {
                    continue;
                }

                char c = (char) intVnos;
                _bDrevo.Vstavi(intVnos);
            }

            IzrisiDrevo();
        }
    }

}