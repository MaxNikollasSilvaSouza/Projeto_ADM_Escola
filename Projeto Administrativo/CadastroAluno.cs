using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Projeto_Administrativo
{
    public partial class CadastroAluno : Form
    {
        bool liberar_atualizar_e_cadastrar = false;

        private string tipo_de_aula;

        private string sexo;
       
        
        string fp_dinheiro= "";
        string fp_boleto = "";
        string fp_transferencia = "";
        
        private string forma_pagamento;
       
        string diretorio_imagem_aluno;
       
        string diretorio_imagem_responsavel;
        AlunoCRUD CRUDaluno;
        public CadastroAluno()
        {
            InitializeComponent();
           
            CRUDaluno = new AlunoCRUD();
        }

        private void button2_Click(object sender, EventArgs e)
        {           
                listBox1.Items.Add(CBdia.Text + ", das " + TBaluno_inicio.Text + " às " + TBaluno_termino.Text);

                CRUDaluno.setar_horarios_de_aula(CBdia.Text, TBaluno_inicio.Text, TBaluno_termino.Text);
                CBdia.Text = null; 
        }

        private void TBcarregar_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    diretorio_imagem_aluno = dialog.FileName.ToString();
                    pictureBox1.ImageLocation = diretorio_imagem_aluno;
                    CRUDaluno.aluno_salvar_byte_da_imagem(diretorio_imagem_aluno);
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu algum erro, verifique a extensão do arquivo ou selecione outro!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    diretorio_imagem_responsavel = dialog.FileName.ToString();
                    pictureBox2.ImageLocation = diretorio_imagem_responsavel;
                    CRUDaluno.responsavel_salvar_byte_da_imagem(diretorio_imagem_responsavel);
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu algum erro, verifique a extensão do arquivo ou selecione outro!");
            }
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            int retirar = listBox1.Items.Count;
            if (retirar > 0)
            {
                listBox1.Items.RemoveAt(retirar - 1);


                CRUDaluno.setar_horarios_de_aula("remove", "remove", "remove");
            }
           
        }

        private void Bdeletar_Click(object sender, EventArgs e)
        {
            try
            {
                CRUDaluno.apagar_registro(TBaluno_rg.Text);
            }
            catch
            {
                MessageBox.Show("Por favor, insira o RG do aluno.");
            }
        }

        private void Bcadastrar_Click(object sender, EventArgs e)
        {
            //Aqui é caso ele seja maior de idade
            if (CBmenor_de_idade.Checked == false)
            {
                try
                {

                    liberar_atualizar_e_cadastrar = verificacao_para_atualizar_e_cadastrar();

                    if (liberar_atualizar_e_cadastrar == true)
                    {
                        //aqui ele formata a data pra ser aceita no banco de dados
                        string[] formata = dateTimePicker1.Text.Split('/');
                        string quando_comecou_as_aulas = formata[2] + "-" + formata[1] + "-" + formata[0];
                        //aqui ele seta o aluno na classe
                        CRUDaluno.aluno_setar(TBaluno_rg.Text, TBaluno_nome.Text, Convert.ToInt32(TBaluno_cpf.Text), TBaluno_telefone.Text, TBaluno_email.Text, quando_comecou_as_aulas, tipo_de_aula, Convert.ToInt32(TBlimite_pagamento.Text), forma_pagamento, TBmensalidade.Text, TBaluno_endereco.Text, Convert.ToInt32(TBaluno_numero.Text), TBaluno_cep.Text, TBaluno_complemento.Text, sexo);
                       
                        //cadastra o aluno
                        CRUDaluno.aluno_atualizar();

                        //esses "ss" são um código pra resetar o contador da outra classe
                        CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");

                        liberar_atualizar_e_cadastrar = false;

                    }
                }
                catch
                {
                    MessageBox.Show("Algum campo deve estar preenchido errado");
                }
            }

            //aqui é se ele for menor de idade
            else
            {
                try
                {
                    //Aqui ocorre a verificação pra ver se tudo esta preenchido
                    liberar_atualizar_e_cadastrar = verificacao_para_atualizar_e_cadastrar();

                    if (liberar_atualizar_e_cadastrar == true)
                    {
                        //aqui ele formata a data pra ser aceita no banco de dados
                        string[] formata = dateTimePicker1.Text.Split('/');
                        string quando_comecou_as_aulas = formata[2] + "-" + formata[1] + "-" + formata[0];

                        //aqui ele seta o responsavel
                        CRUDaluno.responsavel_setar(TBresponsavel_nome.Text, CBparentesco.Text, TBresponsavel_telefone.Text, Convert.ToInt32(TBresponsavel_cpf.Text), TBresponsavel_email.Text,
                                                           TBresponsavel_rg.Text, TBresponsavel_endereco.Text, Convert.ToInt32(TBresponsavel_numero.Text), TBresponsavel_cep.Text, TBresponsavel_complemento.Text);

                        //aqui ele seta o aluno
                        CRUDaluno.aluno_setar(TBaluno_rg.Text, TBaluno_nome.Text, Convert.ToInt32(TBaluno_cpf.Text), TBaluno_telefone.Text, TBaluno_email.Text,
                        quando_comecou_as_aulas, tipo_de_aula, Convert.ToInt32(TBlimite_pagamento.Text), forma_pagamento, TBmensalidade.Text, TBaluno_endereco.Text, Convert.ToInt32(TBaluno_numero.Text),
                        TBaluno_cep.Text, TBaluno_complemento.Text, sexo);

                        //aqui ele cadastra o responsavel e depois o aluno
                        CRUDaluno.responsavel_atualizar();
                        CRUDaluno.aluno_atualizar();

                        //esses "ss" são um código pra resetar o contador da outra classe
                        CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");
                       
                        liberar_atualizar_e_cadastrar = false;
                    }
                   
                }
                catch
                {
                }
            }
        }

        private void Batualizar_Click(object sender, EventArgs e)
        {
            //Aqui é caso ele seja maior de idade
            if (CBmenor_de_idade.Checked == false)
            {
                try
                {

                    liberar_atualizar_e_cadastrar = verificacao_para_atualizar_e_cadastrar();

                    if (liberar_atualizar_e_cadastrar == true)
                    {
                        //aqui ele formata a data pra ser aceita no banco de dados
                        string[] formata = dateTimePicker1.Text.Split('/');
                        string quando_comecou_as_aulas = formata[2] + "-" + formata[1] + "-" + formata[0];
                        //aqui ele seta o aluno na classe
                        CRUDaluno.aluno_setar(TBaluno_rg.Text, TBaluno_nome.Text, Convert.ToInt32(TBaluno_cpf.Text), TBaluno_telefone.Text, TBaluno_email.Text, quando_comecou_as_aulas, tipo_de_aula, Convert.ToInt32(TBlimite_pagamento.Text), forma_pagamento, TBmensalidade.Text, TBaluno_endereco.Text, Convert.ToInt32(TBaluno_numero.Text), TBaluno_cep.Text, TBaluno_complemento.Text, sexo);

                        //cadastra o aluno
                        CRUDaluno.aluno_cadastrar();

                        //esses "ss" são um código pra resetar o contador da outra classe
                        CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");

                        liberar_atualizar_e_cadastrar = false;

                    }
                }
                catch
                {
                    MessageBox.Show("Algum campo deve estar preenchido errado");
                }
            }

            //aqui é se ele for menor de idade
            else
            {
                try
                {
                    //Aqui ocorre a verificação pra ver se tudo esta preenchido
                    liberar_atualizar_e_cadastrar = verificacao_para_atualizar_e_cadastrar();

                    if (liberar_atualizar_e_cadastrar == true)
                    {
                        //aqui ele formata a data pra ser aceita no banco de dados
                        string[] formata = dateTimePicker1.Text.Split('/');
                        string quando_comecou_as_aulas = formata[2] + "-" + formata[1] + "-" + formata[0];

                        //aqui ele seta o responsavel
                        CRUDaluno.responsavel_setar(TBresponsavel_nome.Text, CBparentesco.Text, TBresponsavel_telefone.Text, Convert.ToInt32(TBresponsavel_cpf.Text), TBresponsavel_email.Text,
                                                           TBresponsavel_rg.Text, TBresponsavel_endereco.Text, Convert.ToInt32(TBresponsavel_numero.Text), TBresponsavel_cep.Text, TBresponsavel_complemento.Text);

                        //aqui ele seta o aluno
                        CRUDaluno.aluno_setar(TBaluno_rg.Text, TBaluno_nome.Text, Convert.ToInt32(TBaluno_cpf.Text), TBaluno_telefone.Text, TBaluno_email.Text,
                        quando_comecou_as_aulas, tipo_de_aula, Convert.ToInt32(TBlimite_pagamento.Text), forma_pagamento, TBmensalidade.Text, TBaluno_endereco.Text, Convert.ToInt32(TBaluno_numero.Text),
                        TBaluno_cep.Text, TBaluno_complemento.Text, sexo);

                        //aqui ele cadastra o responsavel e depois o aluno
                        CRUDaluno.responsavel_cadastrar();
                        CRUDaluno.aluno_cadastrar();

                        //esses "ss" são um código pra resetar o contador da outra classe
                        CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");

                        liberar_atualizar_e_cadastrar = false;
                    }

                }
                catch
                {
                }
            }
        }

        //Esse void esta sendo usado pelo botao atualizar e cadastrar para fazer as barreiras e setar na classe AlunoCRUD
        private bool verificacao_para_atualizar_e_cadastrar()
        {
          
            //Aqui faz o cadastro do aluno (maior de idade)
            try
            {
                if (CBmenor_de_idade.Checked == false && CBgrupo.Checked == true || CBmenor_de_idade.Checked == false && CBparticular.Checked == true)
                {
                
                        if (CBdinheiro.Checked == true || CBboleto.Checked == true || CBtransferencia.Checked == true)
                        {
                            
                                if (TBaluno_nome.TextLength > 4 && TBaluno_rg.TextLength > 4 && TBaluno_cpf.TextLength > 4 && TBaluno_telefone.TextLength > 4 && TBaluno_email.TextLength > 4 && TBlimite_pagamento.TextLength > 0 && TBmensalidade.TextLength > 1 && TBaluno_endereco.TextLength > 2 && TBaluno_numero.TextLength > 0 && TBaluno_cep.TextLength > 2 && sexo != "" && listBox1.Items.Count > 0)
                                {
                                    forma_pagamento = fp_dinheiro + ";" + fp_boleto + ";" + fp_transferencia;
                                    liberar_atualizar_e_cadastrar = true;
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, verifique se os campos do aluno estão corretamente preenchidos/selecionados e tente novamente.");
                                    liberar_atualizar_e_cadastrar = false;
                                }
                            
                        }
                        else
                        {
                            MessageBox.Show("Por favor, verifique se os campos do aluno estão corretamente preenchidos/selecionados e tente novamente.");
                            liberar_atualizar_e_cadastrar = false;
                        }
               
                }

                //Aqui faz o cadastro do aluno e do responsavel(menor de idade)
                else if (CBmenor_de_idade.Checked == true && CBgrupo.Checked == true || CBmenor_de_idade.Checked == false && CBparticular.Checked == true)
                {
                
                        if (CBdinheiro.Checked == true || CBboleto.Checked == true || CBtransferencia.Checked == true)
                        {
                            if (TBaluno_nome.TextLength > 4 && TBaluno_rg.TextLength > 4 && TBaluno_cpf.TextLength > 4 && TBaluno_telefone.TextLength > 4 && TBaluno_email.TextLength > 4 && TBlimite_pagamento.TextLength > 0 && TBmensalidade.TextLength > 1 && TBaluno_endereco.TextLength > 2 && TBaluno_numero.TextLength > 0 && TBaluno_cep.TextLength > 2 && sexo != ""
                                && TBresponsavel_nome.TextLength > 2 && CBparentesco.Text.Length > 2 && TBresponsavel_telefone.TextLength > 4 && TBresponsavel_cpf.TextLength > 4 && TBresponsavel_email.TextLength > 4 && TBresponsavel_rg.TextLength > 4 && TBresponsavel_endereco.TextLength > 4 && TBresponsavel_numero.TextLength > 0 && TBresponsavel_cep.TextLength > 4 && listBox1.Items.Count > 0)
                            {
                                forma_pagamento = fp_dinheiro + ";" + fp_boleto + ";" + fp_transferencia;
                                liberar_atualizar_e_cadastrar = true;
                            }
                            else
                            {
                                MessageBox.Show("Por favor, verifique se os campos do aluno estão corretamente preenchidos/selecionados e tente novamente.");
                                liberar_atualizar_e_cadastrar = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, verifique se os campos do aluno estão corretamente preenchidos/selecionados e tente novamente.");
                            liberar_atualizar_e_cadastrar = false;
                        }                
                }
            }
            catch
            {
                MessageBox.Show("Por favor, verifique se os campos estão corretamente preenchidos/selecionados e tente novamente.");
                liberar_atualizar_e_cadastrar = false;
            }

            return liberar_atualizar_e_cadastrar;
        }

        //Define o sexo do aluno como sendo "feminino" ou null (de acordo com o cheked do checkedBox)
        private void CBfeminino_CheckedChanged(object sender, EventArgs e)
        {
            CBmasculino.Checked = false;
            if (CBfeminino.Checked == true)
            {
                this.sexo = "Feminino";
            }
            else
            {
                this.sexo = "";
            }
        }

        //Define o sexo do aluno como sendo "masculino" ou null (de acordo com o cheked do checkedBox)
        private void CBmasculino_CheckedChanged(object sender, EventArgs e)
        {
            CBfeminino.Checked = false;
            if (CBmasculino.Checked == true)
            {
                this.sexo = "Masculino";
            }
            else
            {
                this.sexo = "";
            }
        }

        //Busca as informações do aluno
        private void Bbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Busca as informações na classe de conexão com o banco e o retorno é mandado para o void "carregar_informações_do_aluno"
                CRUDaluno.Buscar_informacoes(TBaluno_rg.Text);
            }
            catch
            {
                MessageBox.Show("Por favor, insira o RG do aluno.");
            }
        }


        //Esse void aqui em baixo vai carregar as informações do aluno (Vai contar com alguns outros pra mudar checked box)
        public void carregar_informacoes_do_aluno(string rg, string nome, int cpf, string telefone, string email, string inicio_aulas, string tipo_aula, int limite_pagamento, string forma_pagamento_dinheiro, string forma_pagamento_boleto, string forma_pagamento_transferencia, string mensalidade, string endereco, int numero_casa, string cep, string complemento, string sexo, byte[] foto)
        {
            TBaluno_rg.Text = rg; TBaluno_nome.Text = nome; TBaluno_cpf.Text = cpf.ToString(); TBaluno_telefone.Text = telefone.ToString(); TBaluno_email.Text = email; dateTimePicker1.Value = Convert.ToDateTime(inicio_aulas); 
            tipu_de_aula(tipo_aula); TBlimite_pagamento.Text = limite_pagamento.ToString(); tipu_de_pagamento(forma_pagamento_dinheiro, forma_pagamento_boleto, forma_pagamento_transferencia); TBmensalidade.Text = mensalidade;
            TBaluno_endereco.Text = endereco; TBaluno_numero.Text = numero_casa.ToString(); TBaluno_cep.Text = cep.ToString(); TBaluno_complemento.Text = complemento; sexu(sexo);
          
            MemoryStream byte_para_imagem = new MemoryStream(foto);
            Image imagem_convertida = Image.FromStream(byte_para_imagem);
            pictureBox1.Image = imagem_convertida;

            //Natham, aqui faltou só o comando pra adicionar os horarios no listbox, tanto é que eu nem passei o parâmetro;
        }

        //Void usado pelo "Carregar infoemações do aluno" usado pra definir o sexo
        private void sexu(string sexo)
        {
            if (sexo == "Masculino")
            {
                CBmasculino.Checked = true;
            }
            else
            {
                CBfeminino.Checked = true;
            }
        }
        //Void usado pelo "Carregar infoemações do aluno" usado pra definir o tipo de aula
        private void tipu_de_aula(string tipo)
        {
            if (tipo == "Grupo")
            {
                CBgrupo.Checked = true;
            }
            else
            {
                CBparticular.Checked = true;
            }
        }

        //Void usado pelo "Carregar infoemações do aluno" usado pra definir o tipo de pagamento
        private void tipu_de_pagamento(string dinheiro, string boleto, string transferencia)
        {
            if (dinheiro == "Dinheiro")
            {
                CBdinheiro.Checked = true;
            }
            if (boleto == "Boleto")
            {
                CBboleto.Checked = true;
            }
            if (transferencia == "Transferência")
            {
                CBtransferencia.Checked = true;
            }
        }

        //Carrega as informações do responsavel no form
        public void carregar_informacoes_do_responsavel(string nome, string grau_parentesco, string telefone, int cpf, string email, string rg, string endereco, int numero, string cep, string complemento, byte[] foto)
        {
            TBresponsavel_nome.Text = nome; CBparentesco.Text = grau_parentesco; TBresponsavel_telefone.Text = telefone; TBresponsavel_cpf.Text = cpf.ToString(); TBresponsavel_email.Text = email; TBresponsavel_rg.Text = rg;
           TBresponsavel_endereco.Text = endereco; TBresponsavel_numero.Text = numero.ToString(); TBresponsavel_cep.Text = cep.ToString(); TBresponsavel_complemento.Text = complemento;
          
            MemoryStream byte_para_imagem = new MemoryStream(foto);
           Image imagem_convertida = Image.FromStream(byte_para_imagem);
           pictureBox2.Image = imagem_convertida;
        }

        //O checkedBox "dinheiro"... Para definir uma das formas de pagamento na hora de cadastrar ou atualizar (vai concatenar)
        private void CBdinheiro_CheckedChanged(object sender, EventArgs e)
        {
            if (CBdinheiro.Checked == true)
            {
                this.fp_dinheiro = "Dinheiro";
            }
            else
            {
                this.fp_dinheiro = "";
            }
        }

        //O checkedBox "boleto"... Para definir uma das formas de pagamento na hora de cadastrar ou atualizar (vai concatenar)
        private void CBboleto_CheckedChanged(object sender, EventArgs e)
        {
            if (CBboleto.Checked == true)
            {
                this.fp_boleto = "Boleto";
            }
            else
            {
                this.fp_boleto = "";
            }
        }

        //O checkedBox "transferencia"... Para definir uma das formas de pagamento na hora de cadastrar ou atualizar (vai concatenar)
        private void CBtransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (CBtransferencia.Checked == true)
            {
                this.fp_transferencia = "Transferência";
            }
            else
            {
                this.fp_transferencia = "";
            }
        }
       
        //O checkedBox que define o tipo de aula(nesse caso, particular)
        private void CBparticular_CheckedChanged(object sender, EventArgs e)
        {
            if (CBparticular.Checked == true)
            {
                CBgrupo.Checked = false;
                tipo_de_aula = "Particular";
            }
            else if (CBparticular.Checked == false)
            {
                CBgrupo.Checked = false;
                tipo_de_aula = "";
            }
        }

        //O checkedBox que define o tipo de aula(nesse caso, grupo)
        private void CBgrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (CBgrupo.Checked == true)
            {
                CBparticular.Checked = false;
                tipo_de_aula = "Grupo";
            }
            else if (CBgrupo.Checked == false)
            {
                CBparticular.Checked = false;
                tipo_de_aula = "";
            }
        }

        //Função para habilitar e desabilitar o campo do responsavel de acordo com a mudança do checkedBox "Menor de idade"
        private void CBmenor_de_idade_CheckedChanged(object sender, EventArgs e)
        {
            if (CBmenor_de_idade.Checked == true)
            {
                TBresponsavel_nome.Enabled = true;
                TBresponsavel_telefone.Enabled = true;
                CBparentesco.Enabled = true;
                TBresponsavel_cpf.Enabled = true;
                TBresponsavel_email.Enabled = true;
                TBresponsavel_rg.Enabled = true;
                TBresponsavel_endereco.Enabled = true;
                TBresponsavel_numero.Enabled = true;
                TBresponsavel_cep.Enabled = true;
                TBresponsavel_complemento.Enabled = true;
                BTcarregar_imagem_responsavel.Enabled = true;
            }

            else
            {
                TBresponsavel_nome.Enabled = false;
                TBresponsavel_telefone.Enabled = false;
                CBparentesco.Enabled = false;
                TBresponsavel_cpf.Enabled = false;
                TBresponsavel_email.Enabled = false;
                TBresponsavel_rg.Enabled = false;
                TBresponsavel_endereco.Enabled = false;
                TBresponsavel_numero.Enabled = false;
                TBresponsavel_cep.Enabled = false;
                TBresponsavel_complemento.Enabled = false;
                BTcarregar_imagem_responsavel.Enabled = false;

                TBresponsavel_nome.Text = null;
                TBresponsavel_telefone.Text = null;
                CBparentesco.Text = null;
                TBresponsavel_cpf.Text = null;
                TBresponsavel_email.Text = null;
                TBresponsavel_rg.Text = null;
                TBresponsavel_endereco.Text = null;
                TBresponsavel_numero.Text = null;
                TBresponsavel_cep.Text = null;
                TBresponsavel_complemento.Text = null;
                BTcarregar_imagem_responsavel.Text = null;
                pictureBox2.Image = null;
                BTcarregar_imagem_responsavel.Text = "Carregar foto";

                CRUDaluno.responsavel_salvar_byte_da_imagem(null);
            }
        }

        private void Funcao_novoRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_novoRegistro.Checked == true)
            {
                Bbuscar.Enabled = false;
                Batualizar.Enabled = false;
                Bdeletar.Enabled = false;

                Bcadastrar.Enabled = true;
            }
        }

        private void Funcao_atualizarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_atualizarRegistro.Checked == true)
            {
                Bcadastrar.Enabled = false;
                Bdeletar.Enabled = false;

                Bbuscar.Enabled = true;
                Batualizar.Enabled = true;
            }
        }

        private void Funcao_apagarRegistro_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_apagarRegistro.Checked == true)
            {
                Batualizar.Enabled = false;
                Bcadastrar.Enabled = false;

                Bdeletar.Enabled = true;
                Bbuscar.Enabled = true;
            }
        }

        

      

        
    }
}
