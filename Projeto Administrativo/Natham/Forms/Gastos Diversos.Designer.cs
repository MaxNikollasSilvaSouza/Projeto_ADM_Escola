namespace Projeto_Administrativo
{
    partial class Gastos_Diversos
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
            this.button1 = new System.Windows.Forms.Button();
            this.CB1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Txdesc = new System.Windows.Forms.TextBox();
            this.TxGasto = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(391, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 48;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CB1
            // 
            this.CB1.FormattingEnabled = true;
            this.CB1.Items.AddRange(new object[] {
            "Inserir",
            "Deletar",
            "Modificar"});
            this.CB1.Location = new System.Drawing.Point(39, 13);
            this.CB1.Name = "CB1";
            this.CB1.Size = new System.Drawing.Size(72, 21);
            this.CB1.TabIndex = 47;
            this.CB1.SelectedValueChanged += new System.EventHandler(this.CB1_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Txdesc);
            this.panel1.Controls.Add(this.TxGasto);
            this.panel1.Controls.Add(this.Confirm);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(39, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 133);
            this.panel1.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Descrição:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Preço:";
            // 
            // Txdesc
            // 
            this.Txdesc.Location = new System.Drawing.Point(76, 70);
            this.Txdesc.Name = "Txdesc";
            this.Txdesc.Size = new System.Drawing.Size(146, 20);
            this.Txdesc.TabIndex = 38;
            // 
            // TxGasto
            // 
            this.TxGasto.Location = new System.Drawing.Point(76, 29);
            this.TxGasto.Name = "TxGasto";
            this.TxGasto.Size = new System.Drawing.Size(100, 20);
            this.TxGasto.TabIndex = 37;
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.Transparent;
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm.ForeColor = System.Drawing.Color.Black;
            this.Confirm.Location = new System.Drawing.Point(265, 70);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(76, 29);
            this.Confirm.TabIndex = 36;
            this.Confirm.Text = "Confirmar";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(254, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 35;
            this.dateTimePicker1.Value = new System.DateTime(2020, 5, 12, 0, 0, 0, 0);
            // 
            // DG1
            // 
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Location = new System.Drawing.Point(39, 179);
            this.DG1.Name = "DG1";
            this.DG1.Size = new System.Drawing.Size(343, 95);
            this.DG1.TabIndex = 45;
            this.DG1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG1_CellClick);
            // 
            // Gastos_Diversos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DG1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Gastos_Diversos";
            this.Text = "Gastos_Diversos";
            this.Load += new System.EventHandler(this.Gastos_Diversos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CB1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txdesc;
        private System.Windows.Forms.TextBox TxGasto;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView DG1;
    }
}