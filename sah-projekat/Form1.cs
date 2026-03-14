using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace sah_projekat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Igra igra=new Igra();
        
        bool selektovano=false;
        int SelIndeks;
        string s;
        private void Form1_Load(object sender, EventArgs e)
        {
            Tabla.ColumnCount = 8;
            Tabla.RowCount = 9;
            for (int i = 0; i < 8; i++)
            {
                Tabla.Columns[i].Width = 75;
            }
            for (int i = 0; i < 9; i++)
            {
                Tabla.Rows[i].Height = 75;
            }
            Tabla.RowHeadersVisible = false;
            Tabla.ColumnHeadersVisible = false;
            Tabla.AllowUserToAddRows = false;
            Tabla.AllowUserToDeleteRows = false;
            Tabla.AllowUserToOrderColumns = false;
            Tabla.AllowUserToResizeColumns = false;
            Tabla.AllowUserToResizeRows = false;
            for(int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tabla.Rows[i].Cells[j].Value = "";
                    if ((i + j) % 2 == 0)
                    {
                        Tabla.Rows[i].Cells[j] = new DataGridViewImageCell { Value = Listaslika.Images[13] };
                        Tabla.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                    else
                    { Tabla.Rows[i].Cells[j] = new DataGridViewImageCell { Value = Listaslika.Images[12] }; Tabla.Rows[i].Cells[j].Style.BackColor = Color.Black; }
                    Tabla.Rows[i].Cells[j].ReadOnly = true;
                }
            }
            //slike();
            CrtajTablu();
            igra.Provera();

        }
        private void slike()//trerba srediti
        {
            //bele figure
            Tabla.Rows[0].Cells[0] = new DataGridViewImageCell { Value = Listaslika.Images[11] }; //top
            Tabla.Rows[0].Cells[1] = new DataGridViewImageCell { Value = Listaslika.Images[7] }; //konj
            Tabla.Rows[0].Cells[2] = new DataGridViewImageCell { Value = Listaslika.Images[9] }; //lovac
            Tabla.Rows[0].Cells[3] = new DataGridViewImageCell { Value = Listaslika.Images[6] }; //dama
            Tabla.Rows[0].Cells[4] = new DataGridViewImageCell { Value = Listaslika.Images[8] }; //kralj
            Tabla.Rows[0].Cells[5] = new DataGridViewImageCell { Value = Listaslika.Images[9] }; //lovac
            Tabla.Rows[0].Cells[6] = new DataGridViewImageCell { Value = Listaslika.Images[7] }; //konj
            Tabla.Rows[0].Cells[7] = new DataGridViewImageCell { Value = Listaslika.Images[11] }; //top
            for (int i = 0; i < 8; i++)
            {
                Tabla.Rows[1].Cells[i] = new DataGridViewImageCell { Value = Listaslika.Images[10] }; //pijuni
            }
            //crne figure
            Tabla.Rows[7].Cells[0] = new DataGridViewImageCell { Value = Listaslika.Images[5] }; //top
            Tabla.Rows[7].Cells[1] = new DataGridViewImageCell { Value = Listaslika.Images[1] }; //konj
            Tabla.Rows[7].Cells[2] = new DataGridViewImageCell { Value = Listaslika.Images[3] }; //lovac
            Tabla.Rows[7].Cells[3] = new DataGridViewImageCell { Value = Listaslika.Images[0] }; //dama
            Tabla.Rows[7].Cells[4] = new DataGridViewImageCell { Value = Listaslika.Images[2] }; //kralj
            Tabla.Rows[7].Cells[5] = new DataGridViewImageCell { Value = Listaslika.Images[3] }; //lovac
            Tabla.Rows[7].Cells[6] = new DataGridViewImageCell { Value = Listaslika.Images[1] }; //konj
            Tabla.Rows[7].Cells[7] = new DataGridViewImageCell { Value = Listaslika.Images[5] }; //top
            for (int i = 0; i < 8; i++)
            {
                Tabla.Rows[6].Cells[i] = new DataGridViewImageCell { Value = Listaslika.Images[4] }; //pijun
            }
            
        }
        int Stotinke1 = 30000;
        int Stotinke2 = 30000;
        private void PrikaziVreme1()
        {
            if (Stotinke1 >= 0)
            {
                int t = Stotinke1;
                int stotinke = t % 100;
                t /= 100;
                int sekunde = t % 60;
                t /= 60;
                int minuti = t;
                vreme1.Text = string.Format("{0:00}:{1:00}:{2:00}", minuti, sekunde, stotinke);
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Vreme prvog igraca je isteklo");
                
            }
        }
        private void PrikaziVreme2()
        {
            if (Stotinke2 >= 0)
            {
                int t = Stotinke2;
                int stotinke = t % 100;
                t /= 100;
                int sekunde = t % 60;
                t /= 60;
                int minuti = t;
                vreme2.Text = string.Format("{0:00}:{1:00}:{2:00}", minuti, sekunde, stotinke);
            }
            else 
            {
                timer2.Stop();
                MessageBox.Show("Vreme drugog igraca je isteklo");
            }
        }

        public void izbrisisliku(int x, int y)
        {
            if ((x + y) % 2 == 0)
            {
                Tabla.Rows[y].Cells[x] = new DataGridViewImageCell { Value = Listaslika.Images[13] };
                Tabla.Rows[y].Cells[x].Style.BackColor = Color.White;
            }
            else
            {
                Tabla.Rows[y].Cells[x] = new DataGridViewImageCell { Value = Listaslika.Images[12] };
                Tabla.Rows[y].Cells[x].Style.BackColor = Color.Black;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Stotinke1--;
            PrikaziVreme1();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Stotinke2--;
            PrikaziVreme2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
           
        }
        DataGridViewCell trenutnoselektovana = null;
       /*private void ResetujBojuPrethodneCeleije()
        {
            if (trenutnoselektovana != null)
            {
                trenutnoselektovana.Style.BackColor = trenutnoselektovana.OwningRow.DefaultCellStyle.BackColor;
                trenutnoselektovana = null;
            }
        }*/
        private void Tabla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           int x = e.ColumnIndex + 1;
            int y = e.RowIndex + 1;

            if (x > 0 && y > 0 && x < 9 && y < 9)
            {
                /* //MessageBox.Show("cgdagadg"+x+" "+y);
                 DataGridViewCell selektovana = Tabla.Rows[x - 1].Cells[y - 1];
                 if (selektovana is DataGridViewImageCell && selektovana.Value != null)
                 {
                     ResetujBojuPrethodneCeleije();
                     selektovana.Style.BackColor = Color.Yellow;
                     trenutnoselektovana = selektovana;
                 }
                 else if (trenutnoselektovana != null)
                 {
                     ResetujBojuPrethodneCeleije();
                 }*/
                 
                if (igra[y, x] % 2 == igra.Potez % 2&&!selektovano&&igra[y, x]!=0)
                {
                    //MessageBox.Show("cgdagadg" + x + " " + y);
                    SelIndeks = igra.VratiIndeks(x, y);
                    selektovano = true;
                   // Figura F = null;
                   // F = igra.VratiFiguru(SelIndeks, igra.Potez%2);
                   // for (int i = 0; i < F.PravaDuzina; i++) s += F.PravaPoljaY[i] + " " + F.PravaPoljaX[i] + "\n";
                    //richTextBox1.Text = s;
                }

                else if (selektovano)
                {
                    if (!igra.MogucPotez(SelIndeks, x, y))
                        selektovano = false;
                    else
                    {
                        //MessageBox.Show("agdagadg");
                        if (igra.Potez % 2 == 1) { timer1.Stop(); timer2.Start(); }
                        else { timer2.Stop(); timer1.Start(); }
                        Figura F = null;
                        F= igra.VratiFiguru(SelIndeks,igra.Potez%2);
                        //izbrisisliku(F.X - 1, F.Y - 1);
                        igra.Pomeri(F, x, y);
                        // izbrisisliku(x-1, y-1);
                        CrtajTablu();
                       // CrtajSliku(F);


                        selektovano = false;
                        igra.Provera();
                        /* if (igra.Mat() == true)
                         { 
                             if (igra.Potez % 2 == 1) MessageBox.Show("Pobedio je beli");
                             else MessageBox.Show("Pobedio je crni");
                         }*/
                        if (igra.ProveraKraj())
                        {
                            if (igra.Potez % 2 == 1) { s = "Pobedio je crni"; timer1.Stop(); }
                            else { s = "Pobedio je beli"; }
                             Form2 form= new Form2(s);
                            form.Show();
                            this.Hide();
                        }

                    }
                }
            }
            //else MessageBox.Show("bgdagadg");

        }
       
        void CrtajSliku(Figura F) 
        {
            int a=0;
            if (F is Kralj) a = 2;
            else if (F is Dama) a = 0;
            else if (F is Konj) a = 1;
            else if (F is Lovac) a = 3;
            else if (F is Pijun) a = 4;
            else if (F is Top) a = 5;
            if (!F.Boja) a += 6;
            Tabla.Rows[F.Y-1].Cells[F.X-1] = new DataGridViewImageCell { Value = Listaslika.Images[a] };


        }
        void CrtajTablu()
        {
            Figura F = null;
            for (int i = 0; i < 8;i++) 
                for(int j = 0; j < 8;j++)
                    izbrisisliku(i,j);
            for (int i = 0; i <igra.DuzinaB ; i++)
            {
               
                F = igra.VratiFiguru(i,1); 
                CrtajSliku(F); 
            }
            for (int i = 0; i < igra.DuzinaC; i++)
            {
               
                F = igra.VratiFiguru(i, 0);
                CrtajSliku(F);
            }
        }
        private void Tabla_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        private void Tabla_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        
        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if (Tabla.Rows[1].Cells[1] == null)
            // Tabla.Rows[3].Cells[3] = Tabla.Rows[1].Cells[1];
            //int x = e.ColumnIndex + 1;
           // int y = e.RowIndex + 1;
            
        }

        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            
        }
    }
}
