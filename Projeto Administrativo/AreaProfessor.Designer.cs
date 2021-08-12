namespace Projeto_Administrativo
{
    partial class AreaProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaProfessor));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBfim = new System.Windows.Forms.ComboBox();
            this.Lfim = new System.Windows.Forms.Label();
            this.Nnota = new System.Windows.Forms.NumericUpDown();
            this.CBinicio = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BTatualizar = new System.Windows.Forms.Button();
            this.BTsalvar = new System.Windows.Forms.Button();
            this.Ldata = new System.Windows.Forms.Label();
            this.RBnao = new System.Windows.Forms.RadioButton();
            this.RBsim = new System.Windows.Forms.RadioButton();
            this.Lpresente = new System.Windows.Forms.Label();
            this.Lnota = new System.Windows.Forms.Label();
            this.Lav = new System.Windows.Forms.Label();
            this.TBav = new System.Windows.Forms.TextBox();
            this.Linicio = new System.Windows.Forms.Label();
            this.TBaluno_rg = new System.Windows.Forms.TextBox();
            this.Lnome = new System.Windows.Forms.Label();
            this.TBgrupo = new System.Windows.Forms.TextBox();
            this.Lgrupo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TBfgrupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBfhorario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBfaluno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBfnota = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Refresh = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nnota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBfim);
            this.panel1.Controls.Add(this.Lfim);
            this.panel1.Controls.Add(this.Nnota);
            this.panel1.Controls.Add(this.CBinicio);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.BTatualizar);
            this.panel1.Controls.Add(this.BTsalvar);
            this.panel1.Controls.Add(this.Ldata);
            this.panel1.Controls.Add(this.RBnao);
            this.panel1.Controls.Add(this.RBsim);
            this.panel1.Controls.Add(this.Lpresente);
            this.panel1.Controls.Add(this.Lnota);
            this.panel1.Controls.Add(this.Lav);
            this.panel1.Controls.Add(this.TBav);
            this.panel1.Controls.Add(this.Linicio);
            this.panel1.Controls.Add(this.TBaluno_rg);
            this.panel1.Controls.Add(this.Lnome);
            this.panel1.Controls.Add(this.TBgrupo);
            this.panel1.Controls.Add(this.Lgrupo);
            this.panel1.Location = new System.Drawing.Point(13, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 340);
            this.panel1.TabIndex = 3;
            // 
            // CBfim
            // 
            this.CBfim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CBfim.FormattingEnabled = true;
            this.CBfim.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.CBfim.Location = new System.Drawing.Point(92, 162);
            this.CBfim.MaxLength = 5;
            this.CBfim.Name = "CBfim";
            this.CBfim.Size = new System.Drawing.Size(71, 21);
            this.CBfim.TabIndex = 498;
            this.CBfim.Text = "00:00";
            this.CBfim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBfim_KeyPress);
            // 
            // Lfim
            // 
            this.Lfim.AutoSize = true;
            this.Lfim.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lfim.Location = new System.Drawing.Point(89, 138);
            this.Lfim.Name = "Lfim";
            this.Lfim.Size = new System.Drawing.Size(35, 16);
            this.Lfim.TabIndex = 497;
            this.Lfim.Text = "Fim:";
            // 
            // Nnota
            // 
            this.Nnota.DecimalPlaces = 1;
            this.Nnota.Location = new System.Drawing.Point(71, 225);
            this.Nnota.Name = "Nnota";
            this.Nnota.Size = new System.Drawing.Size(120, 20);
            this.Nnota.TabIndex = 16;
            // 
            // CBinicio
            // 
            this.CBinicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CBinicio.FormattingEnabled = true;
            this.CBinicio.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.CBinicio.Location = new System.Drawing.Point(10, 162);
            this.CBinicio.MaxLength = 5;
            this.CBinicio.Name = "CBinicio";
            this.CBinicio.Size = new System.Drawing.Size(71, 21);
            this.CBinicio.TabIndex = 496;
            this.CBinicio.Text = "00:00";
            this.CBinicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBinicio_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(57, 111);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // BTatualizar
            // 
            this.BTatualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTatualizar.Location = new System.Drawing.Point(178, 60);
            this.BTatualizar.Name = "BTatualizar";
            this.BTatualizar.Size = new System.Drawing.Size(75, 23);
            this.BTatualizar.TabIndex = 14;
            this.BTatualizar.Text = "Atualizar";
            this.BTatualizar.UseVisualStyleBackColor = true;
            this.BTatualizar.Click += new System.EventHandler(this.BTatualizar_Click);
            // 
            // BTsalvar
            // 
            this.BTsalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTsalvar.Location = new System.Drawing.Point(178, 29);
            this.BTsalvar.Name = "BTsalvar";
            this.BTsalvar.Size = new System.Drawing.Size(75, 23);
            this.BTsalvar.TabIndex = 14;
            this.BTsalvar.Text = "Salvar";
            this.BTsalvar.UseVisualStyleBackColor = true;
            this.BTsalvar.Click += new System.EventHandler(this.BTsalvar_Click);
            // 
            // Ldata
            // 
            this.Ldata.AutoSize = true;
            this.Ldata.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Ldata.Location = new System.Drawing.Point(8, 111);
            this.Ldata.Name = "Ldata";
            this.Ldata.Size = new System.Drawing.Size(43, 16);
            this.Ldata.TabIndex = 17;
            this.Ldata.Text = "Data:";
            // 
            // RBnao
            // 
            this.RBnao.AutoSize = true;
            this.RBnao.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.RBnao.Location = new System.Drawing.Point(139, 268);
            this.RBnao.Name = "RBnao";
            this.RBnao.Size = new System.Drawing.Size(52, 20);
            this.RBnao.TabIndex = 19;
            this.RBnao.TabStop = true;
            this.RBnao.Text = "Não";
            this.RBnao.UseVisualStyleBackColor = true;
            // 
            // RBsim
            // 
            this.RBsim.AutoSize = true;
            this.RBsim.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.RBsim.Location = new System.Drawing.Point(83, 268);
            this.RBsim.Name = "RBsim";
            this.RBsim.Size = new System.Drawing.Size(50, 20);
            this.RBsim.TabIndex = 18;
            this.RBsim.TabStop = true;
            this.RBsim.Text = "Sim";
            this.RBsim.UseVisualStyleBackColor = true;
            // 
            // Lpresente
            // 
            this.Lpresente.AutoSize = true;
            this.Lpresente.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lpresente.Location = new System.Drawing.Point(8, 270);
            this.Lpresente.Name = "Lpresente";
            this.Lpresente.Size = new System.Drawing.Size(70, 16);
            this.Lpresente.TabIndex = 17;
            this.Lpresente.Text = "Presente:";
            // 
            // Lnota
            // 
            this.Lnota.AutoSize = true;
            this.Lnota.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lnota.Location = new System.Drawing.Point(8, 225);
            this.Lnota.Name = "Lnota";
            this.Lnota.Size = new System.Drawing.Size(43, 16);
            this.Lnota.TabIndex = 15;
            this.Lnota.Text = "Nota:";
            // 
            // Lav
            // 
            this.Lav.AutoSize = true;
            this.Lav.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lav.Location = new System.Drawing.Point(8, 191);
            this.Lav.Name = "Lav";
            this.Lav.Size = new System.Drawing.Size(57, 16);
            this.Lav.TabIndex = 13;
            this.Lav.Text = "AV N°:";
            // 
            // TBav
            // 
            this.TBav.Location = new System.Drawing.Point(71, 189);
            this.TBav.Name = "TBav";
            this.TBav.Size = new System.Drawing.Size(100, 20);
            this.TBav.TabIndex = 12;
            // 
            // Linicio
            // 
            this.Linicio.AutoSize = true;
            this.Linicio.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Linicio.Location = new System.Drawing.Point(8, 138);
            this.Linicio.Name = "Linicio";
            this.Linicio.Size = new System.Drawing.Size(48, 16);
            this.Linicio.TabIndex = 3;
            this.Linicio.Text = "Inicio:";
            // 
            // TBaluno_rg
            // 
            this.TBaluno_rg.Location = new System.Drawing.Point(6, 32);
            this.TBaluno_rg.MaxLength = 12;
            this.TBaluno_rg.Name = "TBaluno_rg";
            this.TBaluno_rg.Size = new System.Drawing.Size(147, 20);
            this.TBaluno_rg.TabIndex = 4;
            this.TBaluno_rg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBaluno_rg_KeyPress);
            // 
            // Lnome
            // 
            this.Lnome.AutoSize = true;
            this.Lnome.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lnome.Location = new System.Drawing.Point(8, 16);
            this.Lnome.Name = "Lnome";
            this.Lnome.Size = new System.Drawing.Size(95, 16);
            this.Lnome.TabIndex = 5;
            this.Lnome.Text = "RG do aluno: ";
            // 
            // TBgrupo
            // 
            this.TBgrupo.Location = new System.Drawing.Point(6, 76);
            this.TBgrupo.Name = "TBgrupo";
            this.TBgrupo.Size = new System.Drawing.Size(147, 20);
            this.TBgrupo.TabIndex = 6;
            // 
            // Lgrupo
            // 
            this.Lgrupo.AutoSize = true;
            this.Lgrupo.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lgrupo.Location = new System.Drawing.Point(7, 60);
            this.Lgrupo.Name = "Lgrupo";
            this.Lgrupo.Size = new System.Drawing.Size(51, 16);
            this.Lgrupo.TabIndex = 7;
            this.Lgrupo.Text = "Grupo:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(415, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(454, 304);
            this.dataGridView1.TabIndex = 4;
            // 
            // TBfgrupo
            // 
            this.TBfgrupo.Location = new System.Drawing.Point(492, 53);
            this.TBfgrupo.Name = "TBfgrupo";
            this.TBfgrupo.Size = new System.Drawing.Size(100, 20);
            this.TBfgrupo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(412, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(412, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Horário:";
            // 
            // TBfhorario
            // 
            this.TBfhorario.Location = new System.Drawing.Point(492, 79);
            this.TBfhorario.Name = "TBfhorario";
            this.TBfhorario.Size = new System.Drawing.Size(100, 20);
            this.TBfhorario.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(412, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Aluno:";
            // 
            // TBfaluno
            // 
            this.TBfaluno.Location = new System.Drawing.Point(492, 116);
            this.TBfaluno.MaxLength = 12;
            this.TBfaluno.Name = "TBfaluno";
            this.TBfaluno.Size = new System.Drawing.Size(100, 20);
            this.TBfaluno.TabIndex = 9;
            this.TBfaluno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBfaluno_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(412, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Notas:";
            // 
            // TBfnota
            // 
            this.TBfnota.Location = new System.Drawing.Point(492, 148);
            this.TBfnota.Name = "TBfnota";
            this.TBfnota.Size = new System.Drawing.Size(100, 20);
            this.TBfnota.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label11.Location = new System.Drawing.Point(411, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Filtros de pesquisa:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label13.Location = new System.Drawing.Point(80, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 19);
            this.label13.TabIndex = 14;
            this.label13.Text = "Cadastrar ou atualizar";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(13, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(34, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Voltar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Refresh
            // 
            this.Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refresh.Location = new System.Drawing.Point(678, 145);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 16;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "REMARCACAO",
            "NOTAS",
            "PRESENCA",
            "ESCALA"});
            this.listBox1.Location = new System.Drawing.Point(19, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(91, 56);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // AreaProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_Administrativo.Properties.Resources.Fundo_do_TCC;
            this.ClientSize = new System.Drawing.Size(884, 490);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBfnota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBfaluno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBfhorario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBfgrupo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AreaProfessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área Professor";
            this.Load += new System.EventHandler(this.AreaProfessor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nnota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Ldata;
        private System.Windows.Forms.RadioButton RBnao;
        private System.Windows.Forms.RadioButton RBsim;
        private System.Windows.Forms.Label Lpresente;
        private System.Windows.Forms.Label Lnota;
        private System.Windows.Forms.Label Lav;
        private System.Windows.Forms.TextBox TBav;
        private System.Windows.Forms.Label Linicio;
        private System.Windows.Forms.TextBox TBaluno_rg;
        private System.Windows.Forms.Label Lnome;
        private System.Windows.Forms.TextBox TBgrupo;
        private System.Windows.Forms.Label Lgrupo;
        private System.Windows.Forms.TextBox TBfgrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBfhorario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBfaluno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBfnota;
        private System.Windows.Forms.Button BTatualizar;
        private System.Windows.Forms.Button BTsalvar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown Nnota;
        private System.Windows.Forms.ComboBox CBinicio;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox CBfim;
        private System.Windows.Forms.Label Lfim;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ListBox listBox1;
    }
}