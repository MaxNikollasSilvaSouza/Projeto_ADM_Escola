using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Administrativo
{
    public partial class Gastos_Diversos : Form
    {
        GastosDiversos gasto;
        private string RG;
        public Gastos_Diversos(string rgg, string pessoa_logada )
        {
            InitializeComponent();
            RG = rgg;

        }

        private void CB1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CB1.SelectedItem == "Inserir")
            {
                TxGasto.Enabled = true;
                Txdesc.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else if (CB1.SelectedItem == "Deletar")
            {
                TxGasto.Enabled = false;
                Txdesc.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else if (CB1.SelectedItem == "Modificar")
            {
                TxGasto.Enabled = true;
                Txdesc.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                string preco = TxGasto.Text;
                string descricao = Txdesc.Text;
                string data = dateTimePicker1.Text;
                string[] date = data.Split('/');
                data = date[2] + "-" + date[1] + "-" + date[0];
                gasto = new GastosDiversos();

                if (CB1.SelectedItem == "Inserir")
                {
                    //esse vai ser o rg q vai ta armazenado em uma variavel
                    //q quando o usuario fizer login, la ira armazernar para
                    //quando ele for fazer um registro, pegar o rg dele nesta variavel
                    //*mexer futuramente*
                    
                    gasto.DeclararGasto(data, descricao, preco, this.RG);
                }
                else if (CB1.SelectedItem == "Modificar")
                {
                    string id = gasto.id;
                    gasto.atualizar(id, data, descricao, preco);
                }
                else if (CB1.SelectedItem == "Deletar")
                {
                    string id = gasto.id;
                    gasto.deletar(id);
                }
                DG1.DataSource = gasto.MostrarGasto();
            }
            catch
            {
                MessageBox.Show("Verifique se os campos foram preechidos corretamente!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gasto = new GastosDiversos();
            DG1.DataSource = gasto.MostrarGasto();
            DG1.ClearSelection();
        }

        private void DG1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gasto = new GastosDiversos();
                gasto.id = DG1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch
            {
            }
        }

        private void Gastos_Diversos_Load(object sender, EventArgs e)
        {
            CB1.Text = "Inserir";
            gasto = new GastosDiversos();
            DG1.DataSource = gasto.MostrarGasto();
            DG1.ClearSelection();
        }
    }
}
