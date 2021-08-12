namespace Projeto_Administrativo
{
    partial class Pagamento_Funcionário
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
            this.CB4 = new System.Windows.Forms.ComboBox();
            this.CB3 = new System.Windows.Forms.ComboBox();
            this.CB2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CB1 = new System.Windows.Forms.ComboBox();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // CB4
            // 
            this.CB4.FormattingEnabled = true;
            this.CB4.Items.AddRange(new object[] {
            "PAGO",
            "EM ANDAMENTO"});
            this.CB4.Location = new System.Drawing.Point(228, 154);
            this.CB4.Name = "CB4";
            this.CB4.Size = new System.Drawing.Size(94, 21);
            this.CB4.TabIndex = 37;
            this.CB4.Text = "PAGO";
            this.CB4.SelectedIndexChanged += new System.EventHandler(this.CB4_SelectedIndexChanged);
            // 
            // CB3
            // 
            this.CB3.FormattingEnabled = true;
            this.CB3.Items.AddRange(new object[] {
            "Funcionários",
            "Pagamentos dos funcionários"});
            this.CB3.Location = new System.Drawing.Point(47, 154);
            this.CB3.Name = "CB3";
            this.CB3.Size = new System.Drawing.Size(135, 21);
            this.CB3.TabIndex = 36;
            this.CB3.Text = "Funcionários";
            this.CB3.SelectedIndexChanged += new System.EventHandler(this.CB3_SelectedIndexChanged);
            // 
            // CB2
            // 
            this.CB2.FormattingEnabled = true;
            this.CB2.Items.AddRange(new object[] {
            "Inserir",
            "Deletar",
            "Modificar"});
            this.CB2.Location = new System.Drawing.Point(80, 12);
            this.CB2.Name = "CB2";
            this.CB2.Size = new System.Drawing.Size(72, 21);
            this.CB2.TabIndex = 35;
            this.CB2.Text = "Inserir";
            this.CB2.SelectedValueChanged += new System.EventHandler(this.CB2_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Confirm);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.CB1);
            this.panel1.Location = new System.Drawing.Point(80, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 117);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(127, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Situação:";
            // 
            // Confirm
            // 
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm.Location = new System.Drawing.Point(120, 65);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(76, 29);
            this.Confirm.TabIndex = 27;
            this.Confirm.Text = "Confirmar";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 26;
            this.dateTimePicker1.Value = new System.DateTime(2020, 5, 12, 0, 0, 0, 0);
            // 
            // CB1
            // 
            this.CB1.FormattingEnabled = true;
            this.CB1.Items.AddRange(new object[] {
            "PAGO",
            "EM ANDAMENTO"});
            this.CB1.Location = new System.Drawing.Point(200, 16);
            this.CB1.Name = "CB1";
            this.CB1.Size = new System.Drawing.Size(94, 21);
            this.CB1.TabIndex = 24;
            this.CB1.Text = "PAGO";
            // 
            // DG1
            // 
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(38, 181);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(412, 95);
            this.DG1.TabIndex = 33;
            this.DG1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG1_CellClick);
            // 
            // Pagamento_Funcionário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 288);
            this.Controls.Add(this.CB4);
            this.Controls.Add(this.CB3);
            this.Controls.Add(this.CB2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DG1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Pagamento_Funcionário";
            this.Text = "Pagamento_Funcionário";
            this.Load += new System.EventHandler(this.Pagamento_Funcionário_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB4;
        private System.Windows.Forms.ComboBox CB3;
        private System.Windows.Forms.ComboBox CB2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox CB1;
        private System.Windows.Forms.DataGridView DG1;
    }
}