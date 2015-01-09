using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

namespace BDrevesa {

    public partial class BDrevesaUI : Form {
        private BDrevo<int> _bDrevo;

        public BDrevesaUI() {
            InitializeComponent();
        }

        private void BtnSpremeniClick(object sender, EventArgs e) {
            if (_bDrevo == null) {
                _bDrevo = new BDrevo<int>((int) nudStopnja.Value);
            }

            _bDrevo.Vstavi((int) nudDodaj.Value);
            IzrisiDrevo();
        }

        private void NudStopnjaValueChanged(object sender, EventArgs e) {
            _bDrevo = _bDrevo.SpremeniStopnjo((int) nudStopnja.Value, cbVrstniRed.Checked);
            IzrisiDrevo();
        }

        private void IzrisiDrevo(bool oznaciNajdeno = false) {
            string drevo = _bDrevo.Izrisi(oznaciNajdeno);
            try {
                File.WriteAllText("btree.gv", drevo);
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

            _bDrevo = new BDrevo<int>((int) nudStopnja.Value);
            string[] vnosi = File.ReadAllText(ofd.FileName).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string vnos in vnosi) {
                int intVnos;
                if (!int.TryParse(vnos, out intVnos)) {
                    continue;
                }

                _bDrevo.Vstavi(intVnos);
            }
            IzrisiDrevo();
        }

        private void BtnIsciClick(object sender, EventArgs e) {
            if (_bDrevo == null) {
                MessageBox.Show("Ničesar ni v drevesu.");
                return;
            }

            bool najdeno = _bDrevo.Isci((int) nudIsci.Value);

            if (najdeno) {
                IzrisiDrevo(true);
            }
            else{
                MessageBox.Show("Vrednost NI bila najdena.");
            }
        }
    }

}