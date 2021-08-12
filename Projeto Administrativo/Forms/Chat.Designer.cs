namespace Projeto_Administrativo
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.label1 = new System.Windows.Forms.Label();
            this.TB_assunto = new System.Windows.Forms.TextBox();
            this.Dia = new System.Windows.Forms.Label();
            this.Mes = new System.Windows.Forms.Label();
            this.Ano = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Mensagem = new System.Windows.Forms.RichTextBox();
            this.TB_direcionamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Bresponder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assunto:";
            // 
            // TB_assunto
            // 
            this.TB_assunto.Location = new System.Drawing.Point(76, 87);
            this.TB_assunto.MaxLength = 25;
            this.TB_assunto.Name = "TB_assunto";
            this.TB_assunto.Size = new System.Drawing.Size(455, 20);
            this.TB_assunto.TabIndex = 1;
            // 
            // Dia
            // 
            this.Dia.AutoSize = true;
            this.Dia.BackColor = System.Drawing.Color.Transparent;
            this.Dia.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Dia.Location = new System.Drawing.Point(10, 9);
            this.Dia.Name = "Dia";
            this.Dia.Size = new System.Drawing.Size(16, 16);
            this.Dia.TabIndex = 2;
            this.Dia.Text = "0";
            // 
            // Mes
            // 
            this.Mes.AutoSize = true;
            this.Mes.BackColor = System.Drawing.Color.Transparent;
            this.Mes.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Mes.Location = new System.Drawing.Point(70, 9);
            this.Mes.Name = "Mes";
            this.Mes.Size = new System.Drawing.Size(16, 16);
            this.Mes.TabIndex = 3;
            this.Mes.Text = "0";
            // 
            // Ano
            // 
            this.Ano.AutoSize = true;
            this.Ano.BackColor = System.Drawing.Color.Transparent;
            this.Ano.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Ano.Location = new System.Drawing.Point(126, 9);
            this.Ano.Name = "Ano";
            this.Ano.Size = new System.Drawing.Size(16, 16);
            this.Ano.TabIndex = 4;
            this.Ano.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(52, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(108, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mensagem:";
            // 
            // Mensagem
            // 
            this.Mensagem.Location = new System.Drawing.Point(93, 138);
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.Size = new System.Drawing.Size(438, 96);
            this.Mensagem.TabIndex = 9;
            this.Mensagem.Text = "";
            // 
            // TB_direcionamento
            // 
            this.TB_direcionamento.Location = new System.Drawing.Point(76, 51);
            this.TB_direcionamento.MaxLength = 25;
            this.TB_direcionamento.Name = "TB_direcionamento";
            this.TB_direcionamento.Size = new System.Drawing.Size(252, 20);
            this.TB_direcionamento.TabIndex = 11;
            this.TB_direcionamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_direcionamento_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Para:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Yu Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(334, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "(Apenas RG ou setor)";
            // 
            // Bresponder
            // 
            this.Bresponder.BackColor = System.Drawing.Color.Transparent;
            this.Bresponder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bresponder.Location = new System.Drawing.Point(177, 4);
            this.Bresponder.Name = "Bresponder";
            this.Bresponder.Size = new System.Drawing.Size(75, 23);
            this.Bresponder.TabIndex = 13;
            this.Bresponder.Text = "Enviar";
            this.Bresponder.UseVisualStyleBackColor = false;
            this.Bresponder.Click += new System.EventHandler(this.Bresponder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(518, 150);
            this.dataGridView1.TabIndex = 14;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::Projeto_Administrativo.Properties.Resources.Fundo_do_TCC;
            this.ClientSize = new System.Drawing.Size(541, 440);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Bresponder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_direcionamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Mensagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Ano);
            this.Controls.Add(this.Mes);
            this.Controls.Add(this.Dia);
            this.Controls.Add(this.TB_assunto);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_assunto;
        private System.Windows.Forms.Label Dia;
        private System.Windows.Forms.Label Mes;
        private System.Windows.Forms.Label Ano;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox Mensagem;
        private System.Windows.Forms.TextBox TB_direcionamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Bresponder;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}