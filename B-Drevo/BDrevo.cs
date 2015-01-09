using System;
using System.Collections.Generic;
using System.Text;

namespace BDrevesa {

    public class BDrevo<TValue> where TValue : IComparable<TValue> {
        private readonly int _stopnja;
        private readonly int _min;
        private readonly int _max;
        private readonly LinkedList<TValue> _redVstavljanja;

        private Vozlisce<TValue> _koren;
        private Vozlisce<TValue> _najdenoVozlisce;

        public BDrevo(int stopnja) {
            if (stopnja < 2) {
                throw new ArgumentException("Stopnja mora bit večja ali enaka 2", "stopnja");
            }

            _stopnja = stopnja;
            _min = stopnja - 1;
            _max = 2 * stopnja - 1;
            _koren = new Vozlisce<TValue>(_stopnja);
            _redVstavljanja = new LinkedList<TValue>();
        }

        public BDrevo<TValue> SpremeniStopnjo(int novaStopnja, bool ohraniVrstniRed) {
            BDrevo<TValue> drevo = new BDrevo<TValue>(novaStopnja);

            if (ohraniVrstniRed) {
                foreach (TValue kljuc in _redVstavljanja) {
                    drevo.Vstavi(kljuc);
                }
            }
            else {
                VstaviVrednostiVozlisca(_koren, drevo);
            }

            return drevo;
        }

        private void VstaviVrednostiVozlisca(Vozlisce<TValue> vozlisce, BDrevo<TValue> drevo) {
            for (int i = 0; i < vozlisce.N; i++) {
                drevo.Vstavi(vozlisce.Kljuci[i]);
            }

            if (vozlisce.JeList) {
                return;
            }

            for (int i = 0; i < vozlisce.StSinov; i++) {
                VstaviVrednostiVozlisca(vozlisce.Sinovi[i], drevo);
            }
        }

        public bool Isci(TValue kljuc) {
            return Isci(_koren, kljuc);
        }

        private bool Isci(Vozlisce<TValue> x, TValue kljuc) {
            int i = 0;
            while (i < x.N && kljuc.CompareTo(x.Kljuci[i]) > 0) {
                i++;
            }

            if (i < x.N && kljuc.CompareTo(x.Kljuci[i]) == 0) {
                _najdenoVozlisce = x;
                return true;
            }

            return !x.JeList && Isci(x.Sinovi[i], kljuc);
        }

        public void Vstavi(TValue kljuc) {
            Vozlisce<TValue> r = _koren;
            if (r.N == _max) {
                Vozlisce<TValue> s = new Vozlisce<TValue>(_stopnja, false);
                _koren = s;
                s.N = 0;
                s.Sinovi[0] = r;

                RazdeliVozlisce(s, 0, r);
                VstaviNepolno(s, kljuc);
            }
            else {
                VstaviNepolno(r, kljuc);
            }

            _redVstavljanja.AddLast(kljuc);
        }

        private void VstaviNepolno(Vozlisce<TValue> x, TValue kljuc) {
            int i = x.N;

            if (x.JeList) {
                while (i > 0 && kljuc.CompareTo(x.Kljuci[i - 1]) < 0) {
                    x.Kljuci[i] = x.Kljuci[i - 1];
                    i--;
                }
                x.Kljuci[i] = kljuc;
                x.N += 1;
            }
            else {
                while (i > 0 && kljuc.CompareTo(x.Kljuci[i - 1]) < 0) {
                    i--;
                }
                i++;

                if (x.Sinovi[i - 1].N == _max) {
                    RazdeliVozlisce(x, i - 1, x.Sinovi[i - 1]);

                    if (kljuc.CompareTo(x.Kljuci[i - 1]) > 0) {
                        i++;
                    }
                }

                VstaviNepolno(x.Sinovi[i - 1], kljuc);
            }
        }

        private void RazdeliVozlisce(Vozlisce<TValue> x, int i, Vozlisce<TValue> y) {
            Vozlisce<TValue> z = new Vozlisce<TValue>(_stopnja, false) {
                JeList = y.JeList,
                N = _min
            };

            for (int j = 0; j < _min; j++) {
                z.Kljuci[j] = y.Kljuci[j + _stopnja];
            }

            if (!y.JeList) {
                for (int j = 0; j < _stopnja; j++) {
                    z.Sinovi[j] = y.Sinovi[j + _stopnja];
                }
            }

            y.N = _min; //stopnja - 1

            for (int j = x.N+1; j >= i + 1; j--) {
                x.Sinovi[j] = x.Sinovi[j - 1];
            }

            x.Sinovi[i + 1] = z;

            for (int j = x.N; j > i; j--) {
                x.Kljuci[j] = x.Kljuci[j - 1];
            }

            x.Kljuci[i] = y.Kljuci[_stopnja - 1];
            x.N = x.N + 1;
        }

        public string Izrisi(bool oznaciNajdeno = false) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph BDrevo {");
            sb.AppendLine("\tnode [shape=record];");
            sb.AppendLine("\tsplines=\"line\";");

            IzrisiVozlisce(_koren, sb, 0, oznaciNajdeno);

            sb.Append("}");
            return sb.ToString();
        }

        private int IzrisiVozlisce(Vozlisce<TValue> vozlisce, StringBuilder sb, int idxVozlisca, bool oznaciNajdeno) {
            string[] kljuci = new string[vozlisce.N];
            string[] povezave = new string[vozlisce.N + 1];

            for (int i = 0; i < vozlisce.N; i++) {
                kljuci[i] = string.Format("<f{0}> {1}", i, vozlisce.Kljuci[i]);
                povezave[i] = string.Format("<p{0}> ", i);
            }
            povezave[vozlisce.N] = string.Format("<p{0}>", vozlisce.N);

            string odebelitev = null;
            if (oznaciNajdeno && _najdenoVozlisce != null && _najdenoVozlisce == vozlisce) {
                odebelitev = ";penwidth=2";
            }

            sb.AppendFormat("\t{0} [label=\"{{{{{1}}}|{{{2}}}}}\"{3}]{4}", idxVozlisca, string.Join("|", kljuci), string.Join("|", povezave), odebelitev, Environment.NewLine);

            if (vozlisce.JeList) {
                return 0;
            }

            int stSinov = vozlisce.StSinov;

            int currIdx = idxVozlisca;
            for (int sinSt = 0; sinSt < stSinov; sinSt++) {
                int idxSina = idxVozlisca + sinSt + 1;
                sb.AppendFormat("\t{0}:p{1}:s -> {2}:n;{3}", currIdx, sinSt, idxSina, Environment.NewLine);

                idxVozlisca += IzrisiVozlisce(vozlisce.Sinovi[sinSt], sb, idxSina, oznaciNajdeno);
            }
            return stSinov;
        }
    }

    public class Vozlisce<TValue> where TValue : IComparable<TValue> {
        public Vozlisce(int stopnja, bool jeList = true) {
            int max = 2 * stopnja - 1;
            Kljuci = new TValue[max];
            Sinovi = new Vozlisce<TValue>[max + 1];
            N = 0;
            JeList = jeList;
        }

        ///<summary>Trenutno število kljucev</summary>
        public int N { get; internal set; }

        ///<summary>Dediči, vozlišča spodaj</summary>
        public Vozlisce<TValue>[] Sinovi { get; private set; }

        /// <summary>Vrednosti vozlišča</summary>
        public TValue[] Kljuci { get; private set; }

        public bool JeList { get; internal set; }

        public int StSinov {
            get { return N + 1; }
        }
    }

}