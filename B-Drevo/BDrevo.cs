using System;
using System.Linq;
using System.Text;

namespace BDrevesa {

    public class BDrevo {
        private readonly int _stopnja;
        private readonly int _min;
        private readonly int _max;

        /// <summary>Koren</summary>
        private Vozlisce _t;

        public BDrevo(int stopnja) {
            _stopnja = stopnja;
            _min = stopnja - 1;
            _max = 2 * stopnja - 1;
            Ustvari();
        }

        private void Ustvari() {
            _t = new Vozlisce(_stopnja);

        }

        public int? Isci(Vozlisce x, int kljuc) {
            int i = 0;
            while (i <= x.N && kljuc > x.Kljuc[i]) {
                i++;
            }

            if (i <= x.N && kljuc == x.Kljuc[i]) {
                return kljuc;
            }

            return x.JeList
                       ? null
                       : Isci(x.Sin[i], kljuc);
        }

        public void Vstavi(int kljuc) {
            Vozlisce r = _t;
            if (r.N == _max) {
                Vozlisce s = new Vozlisce(_stopnja, false);
                _t = s;
                s.N = 0;
                s.Sin[1] = r;

                RazdeliVozlisce(s, 1, r);
                VstaviNepolno(s, kljuc);
            }
            else {
                VstaviNepolno(r, kljuc);
            }
        }

        private void VstaviNepolno(Vozlisce x, int kljuc) {
            int i = x.N;

            if (x.JeList) {
                while (i >= 1 && kljuc < x.Kljuc[i]) {
                    x.Kljuc[i + 1] = x.Kljuc[i];
                    i = i - 1;
                }
                x.Kljuc[i + 1] = kljuc;
                x.N += 1;
            }
            else {
                while (i >= 1 && kljuc < x.Kljuc[i]) {
                    i--;
                }
                i++;

                if (x.Sin[i].N == _max) {
                    RazdeliVozlisce(x, i, x.Sin[i]);

                    if (kljuc > x.Kljuc[i]) {
                        i++;
                    }
                }

                VstaviNepolno(x.Sin[i], kljuc);
            }
        }

        private void RazdeliVozlisce(Vozlisce x, int i, Vozlisce y) {
            Vozlisce z = new Vozlisce(_stopnja, false) {
                JeList = y.JeList,
                N = _min
            };

            for (int j = 0; j < _min; j++) {
                z.Kljuc[j] = y.Kljuc[j + _stopnja];
            }

            if (!y.JeList) {
                for (int j = 1; j < _stopnja; j++) {
                    z.Sin[j] = y.Sin[j + _stopnja];
                }
            }

            y.N = _stopnja - 1;

            for (int j = x.N+1; j > i+1; j--) {
                x.Sin[j + 1] = x.Sin[j];
            }

            x.Sin[i + 1] = z;

            for (int j = x.N; j > i; j--) {
                x.Kljuc[j + 1] = x.Kljuc[j];
            }

            x.Kljuc[i] = y.Kljuc[_stopnja];
            x.N = x.N + 1;
        }

        public string Izrisi() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph btree {");
            sb.AppendLine("\tnode [shape=record];");

            IzrisiVozlisce(_t, sb, 0);

            sb.Append("}");
            return sb.ToString();
        }

        private void IzrisiVozlisce(Vozlisce vozlisce, StringBuilder sb, int idx) {
            string[] kljuci = new string[vozlisce.N];
            for (int i = 0; i < vozlisce.N; i++) {
                kljuci[i] = string.Format("<f{0}> {1}", i, vozlisce.Kljuc[i]);
            }

            sb.AppendFormat("\t{0} [label=\"{1}\"]{2}", idx, string.Join("|", kljuci), Environment.NewLine);

            int stSinov = vozlisce.StSinov;
            for (int i = 0; i < stSinov; i++) {
                int novIdx = idx + i + 1;
                sb.AppendFormat("\t{0}:f{1} -> {2};{3}", idx, i, novIdx, Environment.NewLine);
                IzrisiVozlisce(vozlisce.Sin[i], sb, novIdx);
            }
        }
    }

    public class Vozlisce {

        public Vozlisce(int stopnja, bool jeList = true) {
            Kljuc = new int[stopnja];
            Sin = new Vozlisce[stopnja + 1];
            N = 0;
            JeList = jeList;
        }

        ///<summary>Trenutno število kljucev</summary>
        public int N { get; internal set; }

        ///<summary>Dediči, vozlišča spodaj</summary>
        public Vozlisce[] Sin { get; private set; }

        /// <summary>Vrednosti vozlišča</summary>
        public int[] Kljuc { get; private set; }

        public bool JeList { get; internal set; }

        public int StSinov {
            get { return Sin.Count(s => s != null); }
        }
    }

}