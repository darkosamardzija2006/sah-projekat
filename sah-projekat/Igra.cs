using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah_projekat
{
    class Igra
    {
        List<Figura> crnefigure = new List<Figura>();
        List<Figura> belefigure = new List<Figura>();
         int potez = 1;
        public int Potez { get { return potez; } }

        int[,] tabla = new int[9, 9];
        public Igra()
        {
            
            tabla[1, 5] = 2; crnefigure.Add(new Kralj(5, 1, false));
            tabla[1, 1] = 2; crnefigure.Add(new Top(1, 1, false));
            tabla[1, 2] = 2; crnefigure.Add(new Konj(2, 1, false));
            tabla[1, 3] = 2; crnefigure.Add(new Lovac(3, 1, false));
            tabla[1, 4] = 2; crnefigure.Add(new Dama(4, 1, false));
            tabla[1, 8] = 2; crnefigure.Add(new Top(8, 1, false));
            tabla[1, 7] = 2; crnefigure.Add(new Konj(7, 1, false));
            tabla[1, 6] = 2; crnefigure.Add(new Lovac(6, 1, false));
            tabla[8, 5] = 1; belefigure.Add(new Kralj(5, 8, true));
            tabla[8, 1] = 1; belefigure.Add(new Top(1, 8, true));
            tabla[8, 2] = 1; belefigure.Add(new Konj(2, 8, true));
            tabla[8, 3] = 1; belefigure.Add(new Lovac(3, 8, true));
            tabla[8, 4] = 1; belefigure.Add(new Dama(4, 8, true));
            tabla[8, 8] = 1; belefigure.Add(new Top(8, 8, true));
            tabla[8, 7] = 1; belefigure.Add(new Konj(7, 8, true));
            tabla[8, 6] = 1; belefigure.Add(new Lovac(6, 8, true));
            for (int i = 1; i < 9; i++)
            {
                tabla[2, i] = 2; crnefigure.Add(new Pijun(i, 2, false));
                tabla[7, i] = 1; belefigure.Add(new Pijun(i, 7, true));
            }
        }
        public int DuzinaB { get { return belefigure.Count; } }
        public int DuzinaC { get { return crnefigure.Count; } }
        public int this[int x, int y]
        {
            get { return tabla[x, y]; }
        }
        public void Provera()
        {

            int x = 0, y = 0;
            if (potez % 2 == 0)
            {
                
                foreach (Figura F in crnefigure)
                {
                    F.PravaPoljaX.Clear();
                    F.PravaPoljaY.Clear();
                    for (int i = 0; i < F.Duzina; i++)
                    {
                        F.Postavi(ref x, ref y, i);
                        if (tabla[y, x] != 2)
                            if (ProveriPomeraj(F, x, y) == true)
                            {
                                F.PravaPoljaX.Add(x);
                                F.PravaPoljaY.Add(y);
                            }
                    }
                }
            }
            else
            {
                foreach (Figura F in belefigure)
                {
                    F.PravaPoljaY.Clear();
                    F.PravaPoljaX.Clear();
                    for (int i = 0; i < F.Duzina; i++)
                    {
                        F.Postavi(ref x, ref y, i);
                        if (tabla[y, x] != 1)
                            if (ProveriPomeraj(F, x, y) == true)
                            {
                                F.PravaPoljaX.Add(x);
                                F.PravaPoljaY.Add(y);
                            }
                    }
                }
            }

        }
        public bool ProveraKraj() { if (belefigure[0] is Kralj && crnefigure[0] is Kralj) return false; return true; }
       /* public bool sah()
        {
            int x, y;
            if (potez % 2 == 1)
            {
                x = belefigure[0].X; y = belefigure[1].Y;
                foreach (Figura F in crnefigure)
                {
                    for (int i = 0; i < F.PravaDuzina; i++)
                        if (F.PravaPoljaX[i] == x && F.PravaPoljaY[i] == y) return true;
                }

            }
            else
            {
                x = crnefigure[0].X; y = crnefigure[1].Y;
                foreach (Figura F in belefigure)
                {
                    for (int i = 0; i < F.PravaDuzina; i++)
                        if (F.PravaPoljaX[i] == x && F.PravaPoljaY[i] == y) return true;
                }
            }
            return false;

        }*/
        public bool ProveriPomeraj(Figura F, int x, int y)
        {
           
            if (F is Konj) return true;
            if (F is Pijun)
            {
                if (F.X != x) { if (tabla[y, x] != 0) return true; else return false; }
                if (tabla[y, x] != 0) return false;
                if (F.Y - y == 2) { if (tabla[y + 1, F.X] == 0) return true; else return false; }
                if (F.Y - y == -2) { if (tabla[y - 1, F.X] == 0) return true; else return false; }
                return true;
            }
            else
            {
                int udaljenost = Math.Max(Math.Abs(x - F.X), Math.Abs(y - F.Y));
                int novox = F.X, novoy = F.Y;
                int Pomx = F.X - x; Pomx /= udaljenost;
                int Pomy = F.Y - y; Pomy /= udaljenost;
                for (int i = 1; i < udaljenost; i++)
                {
                    novox -= Pomx;
                    novoy -= Pomy;
                    if (tabla[novoy, novox] != 0) return false;
                }
                return true;
            }
        }
        public int VratiIndeks(int x, int y)
        {
            if (potez % 2 == 1) for (int i = 0; i < belefigure.Count; i++) { if (belefigure[i].X == x && belefigure[i].Y == y) return i; }
             for (int i = 0; i < crnefigure.Count; i++) { if (crnefigure[i].X == x && crnefigure[i].Y == y) return i; }
            return -1;
        }
        public bool MogucPotez(int Indeksf,int x, int y)
        {
            Figura F;
            if (potez % 2 == 1) F = belefigure[Indeksf];
            else F = crnefigure[Indeksf];
           
            for(int i=0;i<F.PravaDuzina;i++)
            {
                if (F.PravaPoljaX[i] == x && F.PravaPoljaY[i] == y) return true;
            }
            if (F is Kralj)//Rokada
            {
                if (F.X - x == 2||F.X-x==-2)
                {
                    if (F.Boja)
                    {
                        foreach(Figura f in belefigure) 
                        {
                            if(f is Top&&(!f.Pomerena&&Math.Abs(f.X-x)<=2)) { if (x > F.X && tabla[F.Y,x-1]!=0) return false;return true; }

                        }
                        return false;
                    }
                    else
                    {
                        foreach (Figura f in crnefigure)
                        {
                            if (f is Top && (!f.Pomerena && Math.Abs(f.X - x) <=2)) { if (x > F.X && tabla[F.Y, x - 1] != 0) return false; return true; }

                        }
                        return false;

                    }
                }
                
            }
            return false;
        }
        public Figura VratiFiguru(int Indeksf,int boja) 
        {
            Figura F=null ;
            if (boja == 1) F = belefigure[Indeksf];
            else F = crnefigure[Indeksf];
            return F;
        }
        public void Pomeri(Figura F, int x, int y)
        {
           
            Figura F2 = null;
            if (tabla[y, x] != 0)
            {
                if (potez % 2 == 1) 
                {
                    foreach (Figura f in crnefigure)  if (f.X == x && f.Y == y)  F2 = f; 
                    crnefigure.Remove(F2); 
                }
                else
                {
                    foreach (Figura f in belefigure) if (f.X == x && f.Y == y)  F2 = f; 
                    belefigure.Remove(F2); }
                }
            
             tabla[F.Y, F.X] =0 ;
            if (potez % 2 == 1) tabla[y, x] = 1;
            else tabla[y, x] = 2;
            
            if (F is Kralj)//Rokada
            {
                    if (F.X - x == 2) 
                    {
                        if (F.Boja)
                        {
                            foreach (Figura f in belefigure)
                            {
                                if (f is Top && f.X - x == -2) { tabla[F.Y, f.X] = 0; f.Pomeri(x + 1, y); tabla[F.Y, f.X] = 1; }

                            }
                        
                        }
                        else
                        {
                            foreach (Figura f in crnefigure)
                            {
                                if (f is Top && f.X - x == -2) { tabla[F.Y, f.X] = 0;f.Pomeri(x + 1, y); tabla[F.Y, f.X] = 1; }

                            }
                        

                        }
                    }
                    if (F.X - x == -2)
                    {
                        if (F.Boja)
                        {
                            foreach (Figura f in belefigure)
                            {
                                if (f is Top && f.X - x == 1) { tabla[F.Y, f.X] = 0; f.Pomeri(x - 1, y); tabla[F.Y, f.X] = 1; }

                            }

                        }
                        else
                        {
                            foreach (Figura f in crnefigure)
                            {
                                if (f is Top && f.X - x == 1) { tabla[F.Y, f.X] = 0; f.Pomeri(x - 1, y); tabla[F.Y, f.X] = 2; }

                            }


                        }
                    }
                

            }
            F.Pomeri(x, y);
            if (F is Pijun)
            {
                if (y == 1)
                {
                    int a, b;
                    a = F.X; b = F.Y;
                    belefigure.Remove(F);
                    belefigure.Add(new Dama(a, b, true));//recimo da svi oce damu
                }
                else if (y == 8)
                {
                    int a, b;
                    a = F.X; b = F.Y;
                    crnefigure.Remove(F);
                    crnefigure.Add(new Dama(a, b, false));
                }
            }

            potez++;
        }
       /* public bool Mat() 
        {
            if(!sah()) return false;
            if (potez % 2 == 1) 
            {
                for()
            }

        }*/
    }
}
