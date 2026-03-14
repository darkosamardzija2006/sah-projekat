using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah_projekat
{
    public abstract class Figura
    {
        protected int x, y;
        protected List<int> PoljaX = new List<int>();
        protected List<int> PoljaY = new List<int>();
        public List<int> PravaPoljaX = new List<int>();
        public List<int> PravaPoljaY = new List<int>();
        protected bool beli;
        public Figura(int x, int y, bool beo)
        {
            this.x = x;
            this.y = y;
            beli = beo;
            PopuniPolja();
        }
        public bool Boja { get { return beli; } }
        protected bool pomerena = false;
        public bool Pomerena { get {  return pomerena; } }
        public void Pomeri(int x, int y)
        {
            this.x = x;
            this.y = y;
            PoljaY.Clear();
            PoljaX.Clear();
            pomerena = true;
            PopuniPolja();
            
        }
        public int Duzina { get { return PoljaX.Count; } }
        public int PravaDuzina { get { return PravaPoljaX.Count; } }
        public void Postavi(ref int x, ref int y, int i)
        {
            x = PoljaX[i];
            y = PoljaY[i];
        }
        public abstract void PopuniPolja();
        public int X { get { return x; } }
        public int Y { get { return y; } }
        
    }
    public class Pijun : Figura
    {
        public Pijun(int x, int y, bool beo)
            : base(x, y, beo) { }
        public override void PopuniPolja()
        {
            if (!beli)
            {
                PoljaY.Add(y + 1);
                PoljaX.Add(x);
                if (x < 8) { PoljaY.Add(y + 1); PoljaX.Add(x + 1); }
                if (x > 1) { PoljaY.Add(y + 1); PoljaX.Add(x - 1); }
                if (!pomerena) { PoljaY.Add(y + 2); PoljaX.Add(x); }

            }
            else
            {
                PoljaY.Add(y - 1);
                PoljaX.Add(x);
                if (x < 8) { PoljaY.Add(y - 1); PoljaX.Add(x + 1); }
                if (x > 1) { PoljaY.Add(y - 1); PoljaX.Add(x - 1); }
                if (!pomerena) { PoljaY.Add(y - 2); PoljaX.Add(x); }

            }
        }
    }
    public class Top : Figura
    {
        public Top(int x, int y, bool beo)
            : base(x, y, beo) { }
        public override void PopuniPolja()
        {
            int a = x, b = y;
            while (a > 1) { a--; PoljaY.Add(b); PoljaX.Add(a); }
            a = x;
            while (a < 8) { a++; PoljaY.Add(b); PoljaX.Add(a); }
            a = x;
            while (b > 1) { b--; PoljaY.Add(b); PoljaX.Add(a); }
            b = y;
            while (b < 8) { b++; PoljaY.Add(b); PoljaX.Add(a); }
        }

    }
    public class Lovac : Figura
    {
        public Lovac(int x, int y, bool beo)
            : base(x, y, beo) { }
        public override void PopuniPolja()
        {
            int a = x, b = y;
            while (a > 1 && b > 1) { a--; b--; PoljaY.Add(b); PoljaX.Add(a); }
            a = x; b = y;
            while (a < 8 && b < 8) { a++; b++; PoljaY.Add(b); PoljaX.Add(a); }
            a = x; b = y;
            while (b > 1 && a < 8) { b--; a++; PoljaY.Add(b); PoljaX.Add(a); }
            b = y;a = x;
            while (b < 8 && a > 1) { b++; a--; PoljaY.Add(b); PoljaX.Add(a); }

        }
    }
    public class Konj : Figura
    {
        public Konj(int x, int y, bool beo)
            : base(x, y, beo) { }
        protected int[] pomx = { 2, 2, -2, -2, 1, -1, -1, 1 };
        protected int[] pomy = { 1, -1, 1, -1, 2, 2, -2, -2 };
        public override void PopuniPolja()
        {
            for (int i = 0; i < 8; i++)
            {
                int a = x + pomx[i], b = y + pomy[i];
                if ((a > 0 && a < 9) && (b > 0 && b < 9)) { PoljaY.Add(b); PoljaX.Add(a); }
            }
        }
    }
    public class Dama : Figura
    {
        public Dama(int x, int y, bool beo)
            : base(x, y, beo) { }
        public override void PopuniPolja()
        {
            int a = x, b = y;
            while (a > 1) { a--; PoljaY.Add(b); PoljaX.Add(a); }
            a = x;
            while (a < 8) { a++; PoljaY.Add(b); PoljaX.Add(a); }
            a = x;
            while (b > 1) { b--; PoljaY.Add(b); PoljaX.Add(a); }
            b = y;
            while (b < 8) { b++; PoljaY.Add(b); PoljaX.Add(a); }
            a = x; b = y;
            while (a > 1 && b > 1) { a--; b--; PoljaY.Add(b); PoljaX.Add(a); }
            a = x; b = y;
            while (a < 8 && b < 8) { a++; b++; PoljaY.Add(b); PoljaX.Add(a); }
            a = x; b = y;
            while (b > 1 && a < 8) { b--; a++; PoljaY.Add(b); PoljaX.Add(a); }
            b = y;a = x;
            while (b < 8 && a > 1) { b++; a--; PoljaY.Add(b); PoljaX.Add(a); }
        }

    }
    public class Kralj : Figura
    {
        protected int[] pomx = { 1, 1, -1, -1, 1, -1, 0, 0 };
        protected int[] pomy = { 1, -1, 1, -1, 0, 0, 1, -1 };
        public Kralj(int x, int y, bool beo)
            : base(x, y, beo) { }
        public override void PopuniPolja()
        {
            for (int i = 0; i < 8; i++)
            {
                int a = x + pomx[i], b = y + pomy[i];
                if ((a > 0 && a < 9) && (b > 0 && b < 9)) { PoljaY.Add(b); PoljaX.Add(a); }
            }
            if(!pomerena)
            {
                    PoljaY.Add(y); PoljaX.Add(x - 2);
                    PoljaY.Add(y); PoljaX.Add(x + 2);
                
            }
        }
    }
}
