using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Шифрование
{
    internal class Deffi
    {
        public double WithoutScammer(int G, int XA, int XB, int P)
        {
            double ya;
            ya = Math.Pow(G, XA) % P;
            //YA.Text = ya.ToString();
            double yb;
            yb = Math.Pow(G, XB) % P;
            //YB.Text = yb.ToString();
            double ka;
            ka = Math.Pow(yb, XA) % P;
            //KA.Text = ka.ToString();
            double kb;
            kb = Math.Pow(ya, XB) % P;
            //KB.Text = kb.ToString();

            //Console.WriteLine();
            //Console.WriteLine(ka);
            //Console.WriteLine(kb);

            if (ka != kb)
            {
                ka = -1;
            }

            return ka;
        }

        public double[] WithScammer(int G, int XA, int XB, int XZ, int P)
        {
            double ya;
            ya = Math.Pow(G, XA) % P;
            //YA.Text = ya.ToString();
            double yb;
            yb = Math.Pow(G, XB) % P;
            //YB.Text = yb.ToString();
            double yz;
            yz = Math.Pow(G, XZ) % P;
            //YZ.Text = yz.ToString();

            double ka;
            ka = Math.Pow(yz, XA) % P;
            //KA1.Text = ka.ToString();
            double kb;
            kb = Math.Pow(yz, XB) % P;
            //KB1.Text = kb.ToString();
            double kza;
            kza = Math.Pow(ya, XZ) % P;
            //KZA.Text = kza.ToString();
            double kzb;
            kzb = Math.Pow(yb, XZ) % P;
            //KZB.Text = kzb.ToString();

            //Console.WriteLine();
            //Console.WriteLine(ka);
            //Console.WriteLine(kza);

            //Console.WriteLine();
            //Console.WriteLine(kb);
            //Console.WriteLine(kzb);

            if (ka != kza)
            {
                ka = -1;
            }

            if (kb != kzb)
            {
                kb = -1;
            }

            double[] k = new double[2] { ka, kb };

            return k;
        }
    }
}
