namespace Projeto_Administrativo
{
    partial class Escala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Escala));
            this.ListAluno = new System.Windows.Forms.ListBox();
            this.ListProfessor = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CBfim = new System.Windows.Forms.ComboBox();
            this.Lfim = new System.Windows.Forms.Label();
            this.CBinicio = new System.Windows.Forms.ComboBox();
            this.Linicio = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ListAluno
            // 
            this.ListAluno.FormattingEnabled = true;
            this.ListAluno.Location = new System.Drawing.Point(124, 64);
            this.ListAluno.Name = "ListAluno";
            this.ListAluno.Size = new System.Drawing.Size(122, 134);
            this.ListAluno.TabIndex = 0;
            this.ListAluno.SelectedIndexChanged += new System.EventHandler(this.ListAluno_SelectedIndexChanged);
            // 
            // ListProfessor
            // 
            this.ListProfessor.FormattingEnabled = true;
            this.ListProfessor.Location = new System.Drawing.Point(422, 64);
            this.ListProfessor.Name = "ListProfessor";
            this.ListProfessor.Size = new System.Drawing.Size(122, 134);
            this.ListProfessor.TabIndex = 1;
            this.ListProfessor.SelectedIndexChanged += new System.EventHandler(this.ListProfessor_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(291, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(27, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dados aluno selecionado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(203, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Definir sala:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(31, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "RG:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(58, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(121, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(31, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tipo de aula:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(295, 228);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(28, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(34, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Voltar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Segunda-feira",
            "Terça-feira",
            "Quarta-feira",
            "Quinta-feira",
            "Sexta-feira",
            "Sábado",
            "Domingo"});
            this.comboBox1.Location = new System.Drawing.Point(291, 258);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Segunda-feira";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(206, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Definir dia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label8.Location = new System.Drawing.Point(457, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Definir horario:";
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
            this.CBfim.Location = new System.Drawing.Point(511, 291);
            this.CBfim.MaxLength = 5;
            this.CBfim.Name = "CBfim";
            this.CBfim.Size = new System.Drawing.Size(71, 21);
            this.CBfim.TabIndex = 502;
            this.CBfim.Text = "00:00";
            // 
            // Lfim
            // 
            this.Lfim.AutoSize = true;
            this.Lfim.BackColor = System.Drawing.Color.Transparent;
            this.Lfim.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Lfim.Location = new System.Drawing.Point(457, 291);
            this.Lfim.Name = "Lfim";
            this.Lfim.Size = new System.Drawing.Size(35, 16);
            this.Lfim.TabIndex = 501;
            this.Lfim.Text = "Fim:";
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
            this.CBinicio.Location = new System.Drawing.Point(511, 258);
            this.CBinicio.MaxLength = 5;
            this.CBinicio.Name = "CBinicio";
            this.CBinicio.Size = new System.Drawing.Size(71, 21);
            this.CBinicio.TabIndex = 500;
            this.CBinicio.Text = "00:00";
            // 
            // Linicio
            // 
            this.Linicio.AutoSize = true;
            this.Linicio.BackColor = System.Drawing.Color.Transparent;
            this.Linicio.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Linicio.Location = new System.Drawing.Point(457, 260);
            this.Linicio.Name = "Linicio";
            this.Linicio.Size = new System.Drawing.Size(48, 16);
            this.Linicio.TabIndex = 499;
            this.Linicio.Text = "Inicio:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "INSERIR",
            "DELETAR"});
            this.comboBox2.Location = new System.Drawing.Point(274, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 503;
            this.comboBox2.Text = "INSERIR";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 355);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 219);
            this.dataGridView1.TabIndex = 504;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(156, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 505;
            this.label9.Text = "Aluno";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(457, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 506;
            this.label10.Text = "Professor";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 334);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 20);
            this.textBox2.TabIndex = 507;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(12, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 16);
            this.label11.TabIndex = 508;
            this.label11.Text = "Nome aluno:";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(430, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 509;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Escala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(679, 586);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.CBfim);
            this.Controls.Add(this.Lfim);
            this.Controls.Add(this.CBinicio);
            this.Controls.Add(this.Linicio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListProfessor);
            this.Controls.Add(this.ListAluno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Escala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escala";
            this.Load += new System.EventHandler(this.Escala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListAluno;
        private System.Windows.Forms.ListBox ListProfessor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CBfim;
        private System.Windows.Forms.Label Lfim;
        private System.Windows.Forms.ComboBox CBinicio;
        private System.Windows.Forms.Label Linicio;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}