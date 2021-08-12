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
    public partial class Funcionario : Form
    {

        FuncionarioCRUD funcionario;

        string diretorio_imagem;
        string pcd;
        string exame_admissional;
        private bool tem_foto = false;
        private string intervalo;
        private string Nome_Pessoa_Logada;
        private string RG_Logado;
        bool professor;

        public Funcionario(string Pessoa_Logada, string rg_Logado)
        {
            InitializeComponent();
            Nome_Pessoa_Logada = Pessoa_Logada;
            RG_Logado = rg_Logado;
            funcionario = new FuncionarioCRUD(Pessoa_Logada);
        }

        private void Funcao_novoRegistro_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Funcao_novoRegistro_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Funcao_novoRegistro.Checked == true)
            {
                BTcarregar_foto.Enabled = true;
                Bdeletar.Enabled = false;
                Batualizar.Enabled = false;
                Bbuscar.Enabled = false;
                Bcadastrar.Enabled = true;
                TBmotivo_ocorrencia.Enabled = false;
                TBquem_ocorrencia.Enabled = false;
                richTextBox1.Enabled = false;
                BTadicionar_ocorrencia.Enabled = false;

                TBsenha.Enabled = true;
                TBlogin.Enabled = true;
                TBnome.Enabled = true;
                TBtelefone.Enabled = true;
                TBcarteira_de_trabalho.Enabled = true;
                TBemail.Enabled = true;
                TBcpf.Enabled = true;
                CBSiglaEstado.Enabled = true;
                TBpis.Enabled = true;
                TBendereco.Enabled = true;
                TBnumero.Enabled = true;
                TBcep.Enabled = true;
                TBcomplemento.Enabled = true;
                TBsalario.Enabled = true;
                TBbeneficio.Enabled = true;
                TBvalor_beneficio.Enabled = true;
                BTadicionar_beneficio.Enabled = true;
                BTcarregar_foto.Enabled = true;
                dateTimePicker1.Enabled = true;
                TBagencia.Enabled = true;
                TBnumero_da_conta.Enabled = true;
                TBbanco.Enabled = true;
                TBfuncao_do_funcionario.Enabled = true;
                TBsetor.Enabled = true;
                CBdia.Enabled = true;
                CBinicioE.Enabled = true;
                CBintervalo_termino.Enabled = true;
                CBintervalo_inicio.Enabled = true;

                CBterminoE.Enabled = true;
                BTadicionar_horario.Enabled = true;
                funcionario.limpar_ocorrencia_nao_salva();
                funcionario.remover_beneficios("ss", "ss");
                funcionario.remover_expediente("ss");


                BTadicionar_ocorrencia.Enabled = false;
                TBmotivo_ocorrencia.Enabled = false;
                TBquem_ocorrencia.Enabled = false;
            }
        }

        private void Funcao_atualizarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_atualizarRegistro.Checked == true)
            {
                BTcarregar_foto.Enabled = false;
                TBmotivo_ocorrencia.Enabled = true;
                TBquem_ocorrencia.Enabled = true;
                richTextBox1.Enabled = true;
                BTadicionar_ocorrencia.Enabled = true;
                Bdeletar.Enabled = false;
                Bcadastrar.Enabled = false;
                TBrg.Enabled = true;
                Batualizar.Enabled = true;
                Bbuscar.Enabled = true;
                TBnome.Enabled = true;
                TBtelefone.Enabled = true;
                TBcarteira_de_trabalho.Enabled = true;
                TBemail.Enabled = true;
                TBcpf.Enabled = true;

                TBsenha.Enabled = true;
                TBlogin.Enabled = true;
                CBSiglaEstado.Enabled = true;
                TBpis.Enabled = true;
                TBendereco.Enabled = true;
                TBnumero.Enabled = true;
                TBcep.Enabled = true;
                TBcomplemento.Enabled = true;
                TBsalario.Enabled = true;
                TBbeneficio.Enabled = true;
                TBvalor_beneficio.Enabled = true;
                BTadicionar_beneficio.Enabled = true;
                BTcarregar_foto.Enabled = true;
                dateTimePicker1.Enabled = true;
                TBagencia.Enabled = true;
                TBnumero_da_conta.Enabled = true;
                TBbanco.Enabled = true;
                TBfuncao_do_funcionario.Enabled = true;
                TBsetor.Enabled = true;
                CBdia.Enabled = true;
                CBinicioE.Enabled = true;
                CBintervalo_termino.Enabled = true;
                CBintervalo_inicio.Enabled = true;

                CBterminoE.Enabled = true;
                BTadicionar_horario.Enabled = true;
                CBpcd.Enabled = true;
                CBexame_admissional.Enabled = true;
                CBpcd.Enabled = true;
                CBexame_admissional.Enabled = true;
                richTextBox1.Enabled = true;
                funcionario.limpar_ocorrencia_nao_salva();
                funcionario.remover_beneficios("ss", "ss");
                funcionario.remover_expediente("ss");


                BTadicionar_ocorrencia.Enabled = true;
                TBmotivo_ocorrencia.Enabled = true;
                TBquem_ocorrencia.Enabled = true;
            }
        }

        private void Funcao_apagarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_apagarRegistro.Checked == true)
            {

                BTcarregar_foto.Enabled = false;
                Bdeletar.Enabled = true;
                Bcadastrar.Enabled = false;
                TBrg.Enabled = true;
                Batualizar.Enabled = false;
                Bbuscar.Enabled = true;

                TBsenha.Enabled = false;
                TBlogin.Enabled = false;
                TBnome.Enabled = false;
                TBtelefone.Enabled = false;
                TBcarteira_de_trabalho.Enabled = false;
                TBemail.Enabled = false;
                TBcpf.Enabled = false;
                CBSiglaEstado.Enabled = false;
                TBpis.Enabled = false;
                TBendereco.Enabled = false;
                TBnumero.Enabled = false;
                TBcep.Enabled = false;
                TBcomplemento.Enabled = false;
                TBsalario.Enabled = false;
                TBbeneficio.Enabled = false;
                TBvalor_beneficio.Enabled = false;
                BTadicionar_beneficio.Enabled = false;
                BTcarregar_foto.Enabled = false;
                dateTimePicker1.Enabled = false;
                TBagencia.Enabled = false;
                TBnumero_da_conta.Enabled = false;
                TBbanco.Enabled = false;
                TBfuncao_do_funcionario.Enabled = false;
                TBsetor.Enabled = false;
                CBdia.Enabled = false;
                CBinicioE.Enabled = false;
                CBintervalo_termino.Enabled = false;
                CBintervalo_inicio.Enabled = false;

                CBterminoE.Enabled = false;
                BTadicionar_horario.Enabled = false;
                CBpcd.Enabled = false;
                CBexame_admissional.Enabled = false;
                richTextBox1.Enabled = false;
                funcionario.limpar_ocorrencia_nao_salva();
                funcionario.remover_beneficios("ss", "ss");
                funcionario.remover_expediente("ss");


                BTadicionar_ocorrencia.Enabled = false;
                TBmotivo_ocorrencia.Enabled = false;
                TBquem_ocorrencia.Enabled = false;


                TBnome.Text = null;
                TBtelefone.Text = null;
                TBcarteira_de_trabalho.Text = null;
                TBemail.Text = null;
                TBcpf.Text = null;

                CBSiglaEstado.Text = null;
                TBpis.Text = null;
                TBendereco.Text = null;
                TBnumero.Text = null;
                TBcep.Text = null;
                TBcomplemento.Text = null;
                TBsalario.Text = null;
                TBbeneficio.Text = null;
                TBvalor_beneficio.Text = null;
                dateTimePicker1.Text = null;
                TBagencia.Text = null;
                TBnumero_da_conta.Text = null;
                TBbanco.Text = null;
                TBfuncao_do_funcionario.Text = null;
                TBsetor.Text = null;
                CBdia.Text = null;
                CBinicioE.Text = null;
                CBintervalo_termino.Text = null;
                CBintervalo_inicio.Text = null;

                CBterminoE.Text = null;
                CBpcd.Text = null;
                CBexame_admissional.Text = null;
                richTextBox1.Text = null;



                TBmotivo_ocorrencia.Text = null;
                TBquem_ocorrencia.Text = null;


            }
        }

        private void CBprofessor_a_parte_CheckedChanged(object sender, EventArgs e)
        {
          //  if (CBprofessor.Checked == true)
           // {
                TBfuncao_do_funcionario.Text = "Professor";
                TBfuncao_do_funcionario.Enabled = false;
           // }
          //  else
           // {
                TBfuncao_do_funcionario.Text = "";
                TBfuncao_do_funcionario.Enabled = true;
           // }
        }

        private void CBprofessor_a_parte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (TBrg.TextLength)
                {
                    case 2:
                        TBrg.Text = TBrg.Text + ".";
                        TBrg.SelectionStart = 3;
                        break;
                    case 6:
                        TBrg.Text = TBrg.Text + ".";
                        TBrg.SelectionStart = 7;
                        break;

                    case 10:
                        TBrg.Text = TBrg.Text + "-";
                        TBrg.SelectionStart = 11;
                        break;

                }
            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            //string sexo;
            //if (CBmasculino.Checked == true)
            //{
            //    sexo = "M";
            //}
            //else
            //{
            //    sexo = "F";
            //}
            string[] nascimento_vetor = dateTimePicker1.Text.Split('/');
            string nascimento = nascimento_vetor[2] + "-" + nascimento_vetor[1] + "-" + nascimento_vetor[0];
            if (TBrg.Text.Length > 5 && TBrg.Text != null && TBrg.Text != "")
            {
                funcionario.setar_parte1(TBnome.Text, TBcpf.Text, pcd, TBcarteira_de_trabalho.Text, CBSiglaEstado.Text, TBtelefone.Text, TBemail.Text, TBrg.Text, TBendereco.Text, TBnumero.Text, TBcep.Text, TBcomplemento.Text, nascimento, TBfuncao_do_funcionario.Text, TBsetor.Text, sexo);

                try
                {
                    funcionario.Checagem("BUSCAR");
                    // puxar as informações DA TABELA FUNCINOARIO
                    TBnome.Text = funcionario.get_Nome;
                    TBcpf.Text = funcionario.get_CPF;
                    try
                    {
                        pictureBox1.Load(@"C:\\Foto\\" + TBrg.Text + ".jpg");
                    }
                    catch { MessageBox.Show("Foto não encontrada"); }
                    pcd = funcionario.get_PCD;
                    if (pcd == "SIM")
                    {
                        CBpcd.Checked = true;
                    }
                    else
                    {
                        CBpcd.Checked = false;
                    }
                    TBcarteira_de_trabalho.Text = funcionario.get_n_carteira;
                    CBSiglaEstado.Text = funcionario.get_sigla;
                    TBtelefone.Text = funcionario.get_telefones;
                    TBemail.Text = funcionario.get_email;
                    TBrg.Text = funcionario.get_rg;
                    TBendereco.Text = funcionario.get_endereco;
                    TBnumero.Text = funcionario.get_numero_endereco;
                    TBcep.Text = funcionario.get_cep;
                    TBcomplemento.Text = funcionario.get_complemento;
                    dateTimePicker1.Text = funcionario.get_nascimento;
                    TBfuncao_do_funcionario.Text = funcionario.get_funcao;
                    TBsetor.Text = funcionario.get_setor;
                    sexo = funcionario.get_sexo;
                    if (sexo == "M")
                    {
                        CBmasculino.Checked = true;
                        CBfeminino.Checked = false;

                    }
                    else
                    {
                        CBmasculino.Checked = false;
                        CBfeminino.Checked = true;
                    }

                    // puxar as informações DA TABELA FUNCINOARIO FINANCA

                    TBsalario.Text = funcionario.get_salario;
                    TBagencia.Text = funcionario.get_agencia;
                    TBpis.Text = funcionario.get_pis;
                    TBbanco.Text = funcionario.get_banco;
                    TBnumero_da_conta.Text = funcionario.get_n_conta;

                    // puxar as informações DA TABELA LOGIN 
                    TBlogin.Text = funcionario.get_login;
                    TBsenha.Text = funcionario.get_senha;

                    //puxar os beneficios
                    int contador_beneficios = funcionario.get_contador_beneficios;
                    listBox_beneficios.Items.Clear();
                    for (int i = 0; i < contador_beneficios; i++)
                    {
                        string beneficio = funcionario.get_beneficios_descricao(i);
                        string valor = funcionario.get_beneficios_valor(i);
                        string formatado = "Beneficio: " + beneficio + "," + " valor: " + valor;
                        listBox_beneficios.Items.Add(formatado);
                    }

                    int contador_expediente = funcionario.get_contador_expediente;
                    listBox_expediente.Items.Clear();
                    for (int i = 0; i < contador_expediente; i++)
                    {
                        string dia = funcionario.get_expediente_dia(i);
                        string entrada = funcionario.get_expediente_entrada(i);
                        string inicio_intervalo = funcionario.get_expediente_inicio_intervalo(i);
                        string termino_intervalo = funcionario.get_expediente_termino_intervalo(i);
                        string saida = funcionario.get_expediente_termino(i);
                        string expediente = dia + " entrada às: " + entrada + ", intervalo das: " + inicio_intervalo + " às " + termino_intervalo + ", fim do expediente às: " + saida;
                        listBox_expediente.Items.Add(expediente);

                        CBdia.Text = null;
                    }

                }
                catch(Exception k)
                {
                    erro("Busca", k.ToString());
                }

            }

            else
            {
                MessageBox.Show("Insira o RG do funcionario.");
            }
        }
        private void erro(string parte, string error)
        {
            MessageBox.Show("Ocorreu um erro na " + parte + " pelo seguinte motivo: " + error); 
        }
        string sexo;
        private void Bcadastrar_Click(object sender, EventArgs e)
        {
           
            string nascimento = dateTimePicker1.Text;
            if (CBmasculino.Checked == true)
            {
                sexo = "M";
            }
            else if (CBfeminino.Checked == true)
            {
                sexo = "F";
            }
            else
            {
                sexo = null;
            }

            //if (CBprofessor.Checked == true)
            //{
            //    professor = true;
            //}
            //else
            //{
            //    professor = false;
            //}

            string[] date = nascimento.Split('/');
            nascimento = date[2] + "-" + date[1] + "-" + date[0];

            bool resultado = false;
            // resultado = verificar_campos();
            // if (resultado == true)
            //{

            try
            {
                funcionario.setar_parte1(TBnome.Text, TBcpf.Text, pcd, TBcarteira_de_trabalho.Text, CBSiglaEstado.Text, TBtelefone.Text, TBemail.Text, TBrg.Text, TBendereco.Text, TBnumero.Text, TBcep.Text, TBcomplemento.Text, nascimento, TBfuncao_do_funcionario.Text, TBsetor.Text, sexo);
                funcionario.setar_parte2(TBpis.Text, TBagencia.Text, TBnumero_da_conta.Text, TBbanco.Text, TBsalario.Text);
                funcionario.setar_parte3(TBlogin.Text, TBsenha.Text);
                
                funcionario.Checagem("CADASTRAR");
            }
            catch
            {
                MessageBox.Show("Algo deu errado, verifique se os campos estão corretamente preenchidos e tente novamente.");
            }
            sexo = null;
            //  }
            // else
            // {
            //      MessageBox.Show("Há campos que não foram preenchidos.");
            //  }
        }

        private void Batualizar_Click(object sender, EventArgs e)
        {

            //bool resultado = false;
            //  resultado = verificar_campos();
            //  if (resultado == true)
            //  {
            try
            {


                string sexo;
                if (CBmasculino.Checked == true)
                {
                    sexo = "M";
                }
                else
                {
                    sexo = "F";
                }

                //if (CBprofessor.Checked == true)
                //{
                //    professor = true;
                //}
                //else
                //{
                //    professor = false;
                //}
                string[] nascimento_vetor = dateTimePicker1.Text.Split('/');
                string nascimento = nascimento_vetor[2] + "-" + nascimento_vetor[1] + "-" + nascimento_vetor[0];

                funcionario.setar_parte1(TBnome.Text, TBcpf.Text, pcd, TBcarteira_de_trabalho.Text, CBSiglaEstado.Text, TBtelefone.Text, TBemail.Text, TBrg.Text, TBendereco.Text, TBnumero.Text, TBcep.Text, TBcomplemento.Text, nascimento, TBfuncao_do_funcionario.Text, TBsetor.Text, sexo);
                funcionario.setar_parte2(TBpis.Text, TBagencia.Text, TBnumero_da_conta.Text, TBbanco.Text, TBsalario.Text);
                funcionario.setar_parte3(TBlogin.Text, TBsenha.Text);
                funcionario.Checagem("ATUALIZAR");



            }
            catch
            {
                MessageBox.Show("Algo deu errado, verifique se os campos estão corretamente preenchidos e tente novamente.");
            }
            //  }
            // else
            // {
            //MessageBox.Show("Há campos que não foram preenchidos.");
            // }
        }

        private void Bdeletar_Click(object sender, EventArgs e)
        {
            string sexo;
            if (CBmasculino.Checked == true)
            {
                sexo = "M";
            }
            else
            {
                sexo = "F";
            }

            //if (CBprofessor.Checked == true)
            //{
            //    professor = true;
            //}
            //else
            //{
            //    professor = false;
            //}

            string[] nascimento_vetor = dateTimePicker1.Text.Split('/');
            string nascimento = nascimento_vetor[2] + "-" + nascimento_vetor[1] + "-" + nascimento_vetor[0];
            try
            {
                funcionario.setar_parte1(TBnome.Text, TBcpf.Text, pcd, TBcarteira_de_trabalho.Text, CBSiglaEstado.Text, TBtelefone.Text, TBemail.Text, TBrg.Text, TBendereco.Text, TBnumero.Text, TBcep.Text, TBcomplemento.Text, nascimento, TBfuncao_do_funcionario.Text, TBsetor.Text, sexo);
                funcionario.setar_parte2(TBpis.Text, TBagencia.Text, TBnumero_da_conta.Text, TBbanco.Text, TBsalario.Text);
                funcionario.setar_parte3(TBlogin.Text, TBsenha.Text);
                funcionario.Checagem("DELETAR");
            }
            catch
            { }
        }

        private void TBtelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (TBtelefone.TextLength)
                {
                    case 0:
                        TBtelefone.Text = TBtelefone.Text + "(";
                        TBtelefone.SelectionStart = 1;
                        break;
                    case 3:
                        TBtelefone.Text = TBtelefone.Text + ")";
                        TBtelefone.SelectionStart = 4;
                        break;

                    case 9:
                        TBtelefone.Text = TBtelefone.Text + "-";
                        TBtelefone.SelectionStart = 10;
                        break;

                }
            }
            else
            {
                TBtelefone.Text = null;
            }
        }

        private void TBcpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                if (TBcpf.Text.Length <= 14)
                {
                    switch (TBcpf.TextLength)
                    {
                        case 3:
                            TBcpf.Text = TBcpf.Text + ".";
                            TBcpf.SelectionStart = 4;
                            break;
                        case 7:
                            TBcpf.Text = TBcpf.Text + ".";
                            TBcpf.SelectionStart = 8;
                            break;

                        case 11:
                            TBcpf.Text = TBcpf.Text + ".";
                            TBcpf.SelectionStart = 12;
                            break;

                    }

                }
            }
            else
            {
                TBcpf.Text = null;
            }
        }

        private void CBpcd_CheckedChanged(object sender, EventArgs e)
        {
            if (CBpcd.Checked == true)
            {
                pcd = "SIM";
            }
            else
            {
                pcd = "NAO";
            }
        }

        private void TBcep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {

                switch (TBcep.TextLength)
                {
                    case 5:
                        TBcep.Text = TBcep.Text + "-";
                        TBcep.SelectionStart = 6;
                        break;


                }


            }
            else
            {
                TBcep.Text = null;
            }
        }

        private void CBSiglaEstado_TextChanged(object sender, EventArgs e)
        {
            if (CBSiglaEstado.Text.Length == 2)
            {
                string upper = CBSiglaEstado.Text.ToUpper();
                CBSiglaEstado.Text = upper;
                int contador = 0;
                foreach (string a in CBSiglaEstado.Items)
                {
                    contador += 1;
                    if (CBSiglaEstado.Text == a)
                    {
                        break;
                    }
                    else if (contador == 27)
                    {
                        CBSiglaEstado.Text = null;
                    }
                }
            }
        }

        private void BTadicionar_beneficio_Click(object sender, EventArgs e)
        {
            funcionario.adicionar_beneficios(TBbeneficio.Text, TBvalor_beneficio.Text);

            string beneficio = "Beneficio: " + TBbeneficio.Text + "," + " valor: " + TBvalor_beneficio.Text;
            listBox_beneficios.Items.Add(beneficio);
            TBbeneficio.Text = null;
            TBvalor_beneficio.Text = null;
        }

        private void BTadicionar_horario_Click(object sender, EventArgs e)
        {
            funcionario.adicionar_expediente(CBdia.Text, CBinicioE.Text, CBintervalo_inicio.Text, CBintervalo_termino.Text, CBterminoE.Text);

            string expediente = CBdia.Text + " entrada às: " + CBinicioE.Text + ", intervalo das: " + CBintervalo_inicio.Text + " às " + CBintervalo_termino.Text + ", fim do expediente às: " + CBterminoE.Text;
            listBox_expediente.Items.Add(expediente);

            CBdia.Text = null;
        }

        private void listBox_beneficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox_expediente_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void BTadicionar_ocorrencia_Click(object sender, EventArgs e)
        {
            //string texto = DateTime.Now.ToShortDateString();
            //texto = texto + " - registrado por: " + TBquem_ocorrencia.Text + ", motivo: " + TBmotivo_ocorrencia.Text + ". Descrição: ";
            //richTextBox1.Text = texto;
            if (TBmotivo_ocorrencia.Text.Length > 3 && TBquem_ocorrencia.Text.Length > 4 && richTextBox1.Text.Length > 5)
            {
                // funcionario.ocorrencia_funcionario(TBmotivo_ocorrencia.Text, TBquem_ocorrencia.Text, richTextBox1.Text);
            }
        }


        // VOIDS SEM ELEMENTOS VISUAIS
        

        ~Funcionario()
        {
            MessageBox.Show("Os valores não salvos foram descartados");
        }

        private void BTcarregar_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg";//|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string diretorio_imagem = dialog.FileName.ToString();
                    pictureBox1.ImageLocation = diretorio_imagem;
                    funcionario.diretorio_imagem(diretorio_imagem);
                   // pictureBox1.Dispose();
                }
            }
            catch
            {
                funcionario.setar_foto_false();
                MessageBox.Show("Ocorreu algum erro, verifique a extensão do arquivo ou selecione outro!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home(Nome_Pessoa_Logada, RG_Logado);
            this.Close();           
            home.Show();
        }

        private void TBrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {

                switch (TBrg.TextLength)
                {
                    case 2:
                        TBrg.Text = TBrg.Text + ".";
                        TBrg.SelectionStart = 3;
                        break;
                    case 6:
                        TBrg.Text = TBrg.Text + ".";
                        TBrg.SelectionStart = 7;
                        break;

                    case 10:
                        TBrg.Text = TBrg.Text + "-";
                        TBrg.SelectionStart = 11;
                        break;

                }
            }
        }

        private void CBterminoE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBintervalo_termino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void CBintervalo_inicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBinicioE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBdia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void TBnumero_da_conta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {


            }
            else
            {
                TBnumero_da_conta.Text = null;
            } 
        }

        private void TBagencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {


            }
            else
            {
                TBnumero_da_conta.Text = null;
            } 
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void Funcionario_Load(object sender, EventArgs e)
        {

        }

        private void CBexame_admissional_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBinicioE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBinicioE.Text.Length)
                {
                    case 2:
                        CBinicioE.Text = CBinicioE.Text + ":";
                        CBinicioE.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBinicioE.Text = null;
            }
        }

        private void CBterminoE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBterminoE.Text.Length)
                {
                    case 2:
                        CBterminoE.Text = CBterminoE.Text + ":";
                        CBterminoE.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBterminoE.Text = null;
            }
        }

        private void CBintervalo_inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBintervalo_inicio.Text.Length)
                {
                    case 2:
                        CBintervalo_inicio.Text = CBintervalo_inicio.Text + ":";
                        CBintervalo_inicio.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBintervalo_inicio.Text = null;
            }
        }

        private void CBintervalo_termino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (CBintervalo_termino.Text.Length)
                {
                    case 2:
                        CBintervalo_termino.Text = CBintervalo_termino.Text + ":";
                        CBintervalo_termino.SelectionStart = 4;
                        break;
                }
            }
            else
            {
                CBintervalo_termino.Text = null;
            }
        }

        private void listBox_beneficios_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                funcionario.remover_beneficios("", "");
                int retirar = listBox_beneficios.Items.Count;

                listBox_beneficios.Items.RemoveAt(retirar - 1);
            }
            catch { }
        }

        private void listBox_expediente_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                funcionario.remover_expediente("");
                int retirar = listBox_expediente.Items.Count;

                listBox_expediente.Items.RemoveAt(retirar - 1);
            }
            catch { }
        }
    }
}
