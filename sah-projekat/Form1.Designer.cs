namespace sah_projekat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Tabla = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.vreme1 = new System.Windows.Forms.Label();
            this.vreme2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Listaslika = new System.Windows.Forms.ImageList(this.components);
            this.figurice = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.figurice)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabla
            // 
            this.Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla.Location = new System.Drawing.Point(339, 0);
            this.Tabla.Name = "Tabla";
            this.Tabla.Size = new System.Drawing.Size(603, 603);
            this.Tabla.TabIndex = 0;
            this.Tabla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellClick);
            this.Tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellContentClick);
            this.Tabla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tabla_CellMouseClick);
            this.Tabla.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tabla_CellMouseDown);
            this.Tabla.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_CellContentClick);
            this.Tabla.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tabla_CellMouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // vreme1
            // 
            this.vreme1.AutoSize = true;
            this.vreme1.Location = new System.Drawing.Point(95, 68);
            this.vreme1.Name = "vreme1";
            this.vreme1.Size = new System.Drawing.Size(49, 13);
            this.vreme1.TabIndex = 1;
            this.vreme1.Text = "00:05:00";
            // 
            // vreme2
            // 
            this.vreme2.AutoSize = true;
            this.vreme2.Location = new System.Drawing.Point(1074, 74);
            this.vreme2.Name = "vreme2";
            this.vreme2.Size = new System.Drawing.Size(49, 13);
            this.vreme2.TabIndex = 2;
            this.vreme2.Text = "00:05:00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "startproba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Listaslika
            // 
            this.Listaslika.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listaslika.ImageStream")));
            this.Listaslika.TransparentColor = System.Drawing.Color.Transparent;
            this.Listaslika.Images.SetKeyName(0, "beladama.jpg");
            this.Listaslika.Images.SetKeyName(1, "belikonj.jpg");
            this.Listaslika.Images.SetKeyName(2, "belikralj.jpg");
            this.Listaslika.Images.SetKeyName(3, "belilovac.jpg");
            this.Listaslika.Images.SetKeyName(4, "belipijun.jpg");
            this.Listaslika.Images.SetKeyName(5, "belitop.jpg");
            this.Listaslika.Images.SetKeyName(6, "crnadama.jpg");
            this.Listaslika.Images.SetKeyName(7, "crnikonj.jpg");
            this.Listaslika.Images.SetKeyName(8, "crnikralj.jpg");
            this.Listaslika.Images.SetKeyName(9, "crnilovac.jpg");
            this.Listaslika.Images.SetKeyName(10, "crnipijun.jpg");
            this.Listaslika.Images.SetKeyName(11, "crnitop.jpg");
            this.Listaslika.Images.SetKeyName(12, "crna.jpg");
            this.Listaslika.Images.SetKeyName(13, "bela.jpg");
            // 
            // figurice
            // 
            this.figurice.BackColor = System.Drawing.Color.Transparent;
            this.figurice.Location = new System.Drawing.Point(12, 340);
            this.figurice.Name = "figurice";
            this.figurice.Size = new System.Drawing.Size(296, 263);
            this.figurice.TabIndex = 4;
            this.figurice.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(948, 131);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(472, 411);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 749);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.figurice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vreme2);
            this.Controls.Add(this.vreme1);
            this.Controls.Add(this.Tabla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.figurice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Tabla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label vreme1;
        private System.Windows.Forms.Label vreme2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox figurice;
        public System.Windows.Forms.ImageList Listaslika;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

