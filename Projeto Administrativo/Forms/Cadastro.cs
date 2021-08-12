using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Projeto_Administrativo
{
    public partial class Cadastro : Form
    {
        private string RG_Logado;
        private string Nome_Pessoa_Logada;
        private bool tem_foto = false;
        //Image image;
        private bool tudo_ok = false;
        string tipo_de_aula = "";
        string Sexo;

        AlunoCRUD CRUDaluno;
        public Cadastro(string quem_esta_logado,string rg_logado)
        {
            InitializeComponent();
            this.RG_Logado = rg_logado;
            this.Nome_Pessoa_Logada = quem_esta_logado;
            CRUDaluno = new AlunoCRUD(Nome_Pessoa_Logada);
            background = pictureBox1.BackgroundImage;
            
        }

        //FUNÇÃO DE ALTERAÇÃO DE INTENÇÃO

        private void Funcao_deletar_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_deletar.Checked == true)
            {
                BTaluno_carregar_foto.Enabled = false;
                CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");
                pictureBox1.Image = null;
                BTbuscar.Enabled = true;
                BTcadastrar.Enabled = false;
                BTatualizar.Enabled = false;
                BTdeletar.Enabled = true;
                CB_Grupo.Checked = false;
                CB_Particular.Checked = false;
                CBmasculino.Checked = false;
                CBfeminino.Checked = false;

              
                TBaluno_nome.Text = null;
                TBaluno_telefone.Text = null;
                TBaluno_email.Text = null;
                TBlimite_pagamento.Text = null;
                TBaluno_endereco.Text = null;
                TBaluno_cpf.Text = null;
                TBaluno_numero.Text = null;
                TBaluno_cep.Text = null;
                TBaluno_complemento.Text = null;

                TBmensalidade.Text = null;



                TBaluno_nome.Enabled = false;
                TBaluno_telefone.Enabled = false;
                TBaluno_email.Enabled = false;
                TBlimite_pagamento.Enabled = false;
                TBaluno_endereco.Enabled = false;
                TBaluno_cpf.Enabled = false;
                TBaluno_numero.Enabled = false;
                TBaluno_cep.Enabled = false;
                TBaluno_complemento.Enabled = false;

                TBmensalidade.Enabled = false;
                CB_Grupo.Enabled = false;
                CB_Particular.Enabled = false;

                CBmasculino.Enabled = false;
                CBfeminino.Enabled = false;

                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                BTaluno_carregar_foto.Enabled = false;
                CBmenor_de_idade.Enabled = false;


                TBresponsavel_nome.Text = null;
                TBresponsavel_telefone.Text = null;
                TBresponsavel_email.Text = null;
                TBresponsavel_endereco.Text = null;
                TBresponsavel_cep.Text = null;
                TBresponsavel_cpf.Text = null;
                TBresponsavel_rg.Text = null;
                CBparentesco.Text = null;
                TBresponsavel_numero.Text = null;
                TBresponsavel_complemento.Text = null;

                TBresponsavel_nome.Enabled = false;
                TBresponsavel_telefone.Enabled = false;
                TBresponsavel_email.Enabled = false;
                TBresponsavel_endereco.Enabled = false;
                TBresponsavel_cep.Enabled = false;
                TBresponsavel_cpf.Enabled = false;
                TBresponsavel_rg.Enabled = false;
                CBparentesco.Enabled = false;
                TBresponsavel_numero.Enabled = false;
                TBresponsavel_complemento.Enabled = false;

            }
        }

        private void Funcao_registrarNovo_CheckedChanged(object sender, EventArgs e)
        {
            if (Funcao_registrarNovo.Checked == true)
            {
                
                BTaluno_carregar_foto.Enabled = true;
                BTcadastrar.Enabled = true;
                BTbuscar.Enabled = false;
                BTatualizar.Enabled = false;
                BTdeletar.Enabled = false;
                pictureBox1.Image = null;
                CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");

               
                TBaluno_nome.Text = null;
                TBaluno_telefone.Text = null;
                TBaluno_email.Text = null;
                TBlimite_pagamento.Text = null;
                TBaluno_endereco.Text = null;
                TBaluno_cpf.Text = null;
                TBaluno_numero.Text = null;
                TBaluno_cep.Text = null;
                TBaluno_complemento.Text = null;

                TBmensalidade.Text = null;
                CB_Grupo.Checked = false;
                CB_Particular.Checked = false;
                CBmasculino.Checked = false;
                CBfeminino.Checked = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                BTaluno_carregar_foto.Enabled = true;



                TBaluno_rg.Enabled = true;
                TBaluno_nome.Enabled = true;
                TBaluno_telefone.Enabled = true;
                TBaluno_email.Enabled = true;
                TBlimite_pagamento.Enabled = true;
                TBaluno_endereco.Enabled = true;
                TBaluno_cpf.Enabled = true;
                TBaluno_numero.Enabled = true;
                TBaluno_cep.Enabled = true;
                TBaluno_complemento.Enabled = true;

                TBmensalidade.Enabled = true;
                CB_Grupo.Enabled = true;
                CB_Particular.Enabled = true;
                CBmasculino.Enabled = true;
                CBfeminino.Enabled = true;

                CBmenor_de_idade.Enabled = true;


                TBresponsavel_nome.Text = null;
                TBresponsavel_telefone.Text = null;
                TBresponsavel_email.Text = null;
                TBresponsavel_endereco.Text = null;
                TBresponsavel_cep.Text = null;
                TBresponsavel_cpf.Text = null;
                TBresponsavel_rg.Text = null;
                CBparentesco.Text = null;
                TBresponsavel_numero.Text = null;
                TBresponsavel_complemento.Text = null;




            }
        }

        private void Funcao_atualizar_CheckedChanged(object sender, EventArgs e)
        {

            if (Funcao_atualizar.Enabled == true)
            {
                BTaluno_carregar_foto.Enabled = false;
                CRUDaluno.setar_horarios_de_aula("ss", "ss", "ss");
                pictureBox1.Image = null;
                BTbuscar.Enabled = true;
                BTcadastrar.Enabled = false;
                BTatualizar.Enabled = true;
                BTdeletar.Enabled = false;
                CB_Grupo.Checked = false;
                CB_Particular.Checked = false;
                CBmasculino.Checked = false;
                CBfeminino.Checked = false;

               
                TBaluno_nome.Text = null;
                TBaluno_telefone.Text = null;
                TBaluno_email.Text = null;
                TBlimite_pagamento.Text = null;
                TBaluno_endereco.Text = null;
                TBaluno_cpf.Text = null;
                TBaluno_numero.Text = null;
                TBaluno_cep.Text = null;
                TBaluno_complemento.Text = null;

                TBmensalidade.Text = null;



                TBaluno_rg.Enabled = true;
                TBaluno_nome.Enabled = true;
                TBaluno_telefone.Enabled = true;
                TBaluno_email.Enabled = true;
                TBlimite_pagamento.Enabled = true;
                TBaluno_endereco.Enabled = true;
                TBaluno_cpf.Enabled = true;
                TBaluno_numero.Enabled = true;
                TBaluno_cep.Enabled = true;
                TBaluno_complemento.Enabled = true;

                TBmensalidade.Enabled = true;
                CB_Grupo.Enabled = true;
                CB_Particular.Enabled = true;
                CBmasculino.Enabled = true;
                CBfeminino.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            
                CBmenor_de_idade.Enabled = true;


                TBresponsavel_nome.Text = null;
                TBresponsavel_telefone.Text = null;
                TBresponsavel_email.Text = null;
                TBresponsavel_endereco.Text = null;
                TBresponsavel_cep.Text = null;
                TBresponsavel_cpf.Text = null;
                TBresponsavel_rg.Text = null;
                CBparentesco.Text = null;
                TBresponsavel_numero.Text = null;
                TBresponsavel_complemento.Text = null;
            }
        }






        private void Cadastro_Load(object sender, EventArgs e)
        {

        }


        //CHECKEDBOX

        private void MenorDeIdade_CheckedChanged(object sender, EventArgs e)
        {
            if (CBmenor_de_idade.Checked == true)
            {

                TBresponsavel_nome.Enabled = true;
                TBresponsavel_telefone.Enabled = true;
                TBresponsavel_email.Enabled = true;
                TBresponsavel_endereco.Enabled = true;
                TBresponsavel_cpf.Enabled = true;
                TBresponsavel_rg.Enabled = true;
                TBresponsavel_numero.Enabled = true;
                TBresponsavel_cep.Enabled = true;
                TBresponsavel_complemento.Enabled = true;
                CBparentesco.Enabled = true;
               

            }

            else
            {

                TBresponsavel_nome.Enabled = false;
                TBresponsavel_telefone.Enabled = false;
                TBresponsavel_email.Enabled = false;
                TBresponsavel_endereco.Enabled = false;
                TBresponsavel_cpf.Enabled = false;
                TBresponsavel_rg.Enabled = false;
                TBresponsavel_numero.Enabled = false;
                TBresponsavel_cep.Enabled = false;
                TBresponsavel_complemento.Enabled = false;
                CBparentesco.Enabled = false;

               
                TBresponsavel_nome.Text = null;
                TBresponsavel_telefone.Text = null;
                TBresponsavel_email.Text = null;
                TBresponsavel_endereco.Text = null;
                TBresponsavel_cpf.Text = null;
                TBresponsavel_rg.Text = null;
                TBresponsavel_numero.Text = null;
                TBresponsavel_cep.Text = null;
                TBresponsavel_complemento.Text = null;
                CBparentesco.Text = null;
                

            }
        }

        private void CB_Particular_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Particular.Checked == true)
            {
                CB_Grupo.Checked = false;
                tipo_de_aula = "Particular";
            }
            else if (CB_Particular.Checked == false)
            {
                tipo_de_aula = "";
            }
        }

        private void CB_Grupo_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Grupo.Checked == true)
            {
                CB_Particular.Checked = false;
                tipo_de_aula = "Grupo";
            }
            else if (CB_Grupo.Checked == false)
            {
                tipo_de_aula = "";
            }

        }



        private void CBmasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (CBmasculino.Checked == true)
            {
                this.Sexo = "M";
                CBfeminino.Checked = false;
            }
            else if (CBmasculino.Checked == false)
            {
                this.Sexo = "";
            }
        }

        private void CBfeminino_CheckedChanged(object sender, EventArgs e)
        {
            if (CBfeminino.Checked == true)
            {
                this.Sexo = "F";
                CBmasculino.Checked = false;
            }
            else if (CBfeminino.Checked == false)
            {
                this.Sexo = "";
            }
        }



        // VOID DE ENVIO 

        private void BTcadastrar_Click(object sender, EventArgs e)
        {
            bool prossiga = tudo_preenchido();

            if (prossiga == true)
            {
                tudo_ok = false;

                try
                {
                    if (CBmenor_de_idade.Checked == false)
                    {
                        string[] inicio_vetor = dateTimePicker1.Text.Split('/');
                        string inicio_aulas = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];

                        string[] nascimento_vetor = dateTimePicker2.Text.Split('/');
                        string nascimento = nascimento_vetor[2] + "-" + nascimento_vetor[1] + "-" + nascimento_vetor[0];

                        CRUDaluno.aluno_setar(TBaluno_nome.Text, TBaluno_cpf.Text, TBaluno_telefone.Text, TBaluno_rg.Text, TBaluno_email.Text, inicio_aulas, TBaluno_endereco.Text, TBaluno_cep.Text, TBaluno_numero.Text, TBaluno_complemento.Text, this.Sexo, TBlimite_pagamento.Text, nascimento, tipo_de_aula, TBmensalidade.Text);

                        if (tem_foto == true)
                        {
                            CRUDaluno.foto_tem("sim");
                        }
                        else { CRUDaluno.foto_tem("nao"); }
                        //CRUDaluno.aluno_cadastrar("nao");
                        CRUDaluno.Checagem("CADASTRAR", "nao");

                    }

                    else
                    {
                        string[] inicio_vetor = dateTimePicker1.Text.Split('/');
                        string inicio_aulas = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];

                        string[] nascimento_vetor = dateTimePicker2.Text.Split('/');
                        string nascimento = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];



                        CRUDaluno.aluno_setar(TBaluno_nome.Text, TBaluno_cpf.Text, TBaluno_rg.Text, TBaluno_rg.Text, TBaluno_email.Text, inicio_aulas, TBaluno_endereco.Text, TBaluno_cep.Text, TBaluno_numero.Text, TBaluno_complemento.Text, this.Sexo, TBlimite_pagamento.Text, nascimento, tipo_de_aula, TBmensalidade.Text);


                        CRUDaluno.responsavel_setar(TBresponsavel_nome.Text, TBresponsavel_cpf.Text, TBresponsavel_rg.Text, TBresponsavel_telefone.Text, TBresponsavel_email.Text, CBparentesco.Text, TBresponsavel_endereco.Text, TBresponsavel_numero.Text, TBresponsavel_cep.Text, TBresponsavel_complemento.Text, TBlimite_pagamento.Text, TBmensalidade.Text);

                        CRUDaluno.foto_tem("sim");
                        // CRUDaluno.responsavel_cadastrar();
                        CRUDaluno.Checagem("CADASTRAR", "sim");

                    }

                }
                catch { }
            }

        }

        private void BTaluno_carregar_foto_Click(object sender, EventArgs e)
        {
            
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg";//|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    tem_foto = true;
                    string diretorio_imagem = dialog.FileName.ToString();
                    pictureBox1.ImageLocation = diretorio_imagem;
                    CRUDaluno.diretorio_imagem(diretorio_imagem);
                   // pictureBox1.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu algum erro, verifique a extensão do arquivo ou selecione outro!");
            }
        }

        

        private void BTatualizar_Click(object sender, EventArgs e)
        {
            bool prossiga = tudo_preenchido();
            if (prossiga == true)
            {
                try
                {
                    if (CBmenor_de_idade.Checked == false)
                    {
                        string[] inicio_vetor = dateTimePicker1.Text.Split('/');
                        string inicio_aulas = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];

                        string[] nascimento_vetor = dateTimePicker2.Text.Split('/');
                        string nascimento = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];



                        CRUDaluno.aluno_setar(TBaluno_nome.Text, TBaluno_cpf.Text, TBaluno_telefone.Text, TBaluno_rg.Text, TBaluno_email.Text, inicio_aulas, TBaluno_endereco.Text, TBaluno_cep.Text, TBaluno_numero.Text, TBaluno_complemento.Text, this.Sexo, TBlimite_pagamento.Text, nascimento, tipo_de_aula, TBmensalidade.Text);



                        //CRUDaluno.aluno_atualizar("nao");
                        CRUDaluno.Checagem("ATUALIZAR", "nao");

                    }

                    else
                    {
                        string[] inicio_vetor = dateTimePicker1.Text.Split('/');
                        string inicio_aulas = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];

                        string[] nascimento_vetor = dateTimePicker2.Text.Split('/');
                        string nascimento = inicio_vetor[2] + "-" + inicio_vetor[1] + "-" + inicio_vetor[0];



                        CRUDaluno.aluno_setar(TBaluno_nome.Text, TBaluno_cpf.Text, TBaluno_rg.Text, TBaluno_rg.Text, TBaluno_email.Text, inicio_aulas, TBaluno_endereco.Text, TBaluno_cep.Text, TBaluno_numero.Text, TBaluno_complemento.Text, this.Sexo, TBlimite_pagamento.Text, nascimento, tipo_de_aula, TBmensalidade.Text);


                        CRUDaluno.responsavel_setar(TBresponsavel_nome.Text, TBresponsavel_cpf.Text, TBresponsavel_rg.Text, TBresponsavel_telefone.Text, TBresponsavel_email.Text, CBparentesco.Text, TBresponsavel_endereco.Text, TBresponsavel_numero.Text, TBresponsavel_cep.Text, TBresponsavel_complemento.Text, TBlimite_pagamento.Text, TBmensalidade.Text);
                        // CRUDaluno.responsavel_atualizar();
                        CRUDaluno.Checagem("ATUALIZAR", "sim");
                    }

                    //MessageBox.Show("Informações atualizadas!");
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Alguma informação ou campo está faltando ser preenchido, devido a isso não foi possível prosseguir!");
            }
        }

        //VOID DE RECEBIMENTO
        public void carregar_informacoes_do_aluno(string rg, string nome, string cpf, string telefone, string email,
                    string dia_de_inicio_aulas, string tipo_de_aula, string limite_pagamento, string mensalidade, string endereco, string numero,
                    string cep, string complemento, string sexo, byte[] fotto, string nascimento)
        {
            try
            {
                TBaluno_rg.Text = rg; TBaluno_nome.Text = nome; TBaluno_cpf.Text = cpf; TBaluno_telefone.Text = telefone; TBaluno_email.Text = email;
                dateTimePicker1.Value = Convert.ToDateTime(dia_de_inicio_aulas); tipu_de_aula(tipo_de_aula); TBlimite_pagamento.Text = limite_pagamento; TBmensalidade.Text = mensalidade;
                TBaluno_endereco.Text = endereco; TBaluno_numero.Text = numero; TBaluno_cep.Text = cep; TBaluno_complemento.Text = complemento; sexu(sexo); dateTimePicker2.Text = nascimento;

                //var ms = new MemoryStream();

                //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //var bytes = ms.ToArray();
                // var imageMemoryStream = new MemoryStream(fotto);
                //Image imgFromStream = Image.FromStream(imageMemoryStream);

                // pictureBox1.Image = imgFromStream;
            }
            catch
            {
            }

        }

        public void carregar_informacoes_do_responsavel(string nome, string parentesco, string telefone, string cpf, string
               email, string rg, string endereco, string numero, string cep, string complemento)
        {
            try
            {
                TBresponsavel_nome.Text = nome; CBparentesco.Text = parentesco; TBresponsavel_telefone.Text = telefone; TBresponsavel_cpf.Text = cpf;
                TBresponsavel_email.Text = email; TBresponsavel_rg.Text = rg; TBresponsavel_endereco.Text = endereco; TBresponsavel_numero.Text = numero;
                TBresponsavel_cep.Text = cep; TBresponsavel_complemento.Text = complemento;

                //var ms = new MemoryStream();


                //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //var bytes = ms.ToArray();
                // var imageMemoryStream = new MemoryStream(fotto);
                //Image imgFromStream = Image.FromStream(imageMemoryStream);

                // pictureBox2.Image = imgFromStream;
            }
            catch
            {

            }
        }


        //VOID DE CHECAGEM / MUDANÇA INTERNA

        private void sexu(string sexo)
        {
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
        }

        private void tipu_de_aula(string typo)
        {
            if (typo == "Grupo")
            {
                CB_Grupo.Checked = true;
                CB_Particular.Checked = false;
            }
            else
            {
                CB_Particular.Checked = true;
                CB_Grupo.Checked = false;
            }
        }

        private bool tudo_preenchido()
        {
            if (CBmenor_de_idade.Checked == false)
            {
                //CHECAGEM DOS CAMPOS DO ALUNO

                //Checagem dos TextBox e variáveis (variavel como Sexo por exemplo)
                if (TBaluno_rg.Text.Length > 5 && TBmensalidade.Text.Length > 2 && TBaluno_cep.Text.Length > 3 && TBaluno_cpf.Text.Length > 5 && TBaluno_email.Text.Length > 5 && TBaluno_endereco.Text.Length > 5 && TBaluno_nome.Text.Length > 5 && TBaluno_numero.Text.Length > 0 && TBaluno_telefone.Text.Length > 6 && TBlimite_pagamento.Text.Length > 0 && Sexo != "")
                {
                    //Checagem dos CheckedBox do tipo de aula e quantidade de aulas
                    if (CB_Grupo.Checked == true || CB_Particular.Checked == true)
                    {
                        tudo_ok = true;

                    }
                }
            }
            else
            {
                //CHECAGEM DOS CAMPOS DO ALUNO E FUNCIONÁRIO

                //Checagem dos TextBox e variáveis (variavel como Sexo por exemplo)
                if (TBaluno_rg.Text.Length > 5 && TBmensalidade.Text.Length > 2 && TBaluno_cep.Text.Length > 5 && TBaluno_cpf.Text.Length > 5 && TBaluno_email.Text.Length > 5 && TBaluno_endereco.Text.Length > 5 && TBaluno_nome.Text.Length > 5 && TBaluno_numero.Text.Length > 0 && TBaluno_telefone.Text.Length > 5 && TBlimite_pagamento.Text.Length > 0 && Sexo != "")
                {
                    //Checagem dos CheckedBox do tipo de aula e quantidade de aulas
                    if (CB_Grupo.Checked == true || CB_Particular.Checked == true)
                    {
                        if (TBresponsavel_cep.Text.Length > 5 && TBresponsavel_cpf.Text.Length > 5 && TBresponsavel_email.Text.Length > 5 && TBresponsavel_endereco.Text.Length > 5 && TBresponsavel_nome.Text.Length > 5 && TBresponsavel_numero.Text.Length > 0 && TBresponsavel_rg.Text.Length > 5 && TBresponsavel_telefone.Text.Length > 5 && CBparentesco.Text.Length > 1)
                        {
                            tudo_ok = true;
                        }

                    }
                }
            }


            return tudo_ok;
        }
       
        private Image background;
        private void BTdeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBaluno_rg.Text.Length > 5)
                {
                    
                    CRUDaluno.setar_responsavel_e_aluno_rgs(TBaluno_rg.Text);
                    CRUDaluno.Checagem("DELETAR", "");
                   // string nomi = CRUDaluno.GetNomeFoto();
                    string nomi = CRUDaluno.get_aluno_rg;
                    pictureBox1.Dispose();
                    pictureBox1.Image = background;
                    if (File.Exists(@"C:\\Foto\\" + nomi+".jpg"))
                    {
                        File.Delete(@"C:\\Foto\\" + nomi+".jpg");
                    }
                    pictureBox1.Show();
                }

            }
            catch
            {
                MessageBox.Show("Algo deu errado, confira se o RG do aluno está preenchido ou se esse registro realmente existe!");
            }
        }

        private void BTbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBaluno_rg.Text.Length > 3)
                {
                    CRUDaluno.setar_responsavel_e_aluno_rgs(TBaluno_rg.Text);
                    CRUDaluno.Checagem("BUSCAR", "");

                    if (CRUDaluno.get_aluno_nome != null && CRUDaluno.get_aluno_nome != "")
                    {
                        try
                        {
                            Image imagem = Bitmap.FromFile(@"C:\\Foto\\" + CRUDaluno.get_aluno_rg + ".jpg");
                            pictureBox1.Image = imagem;
                        }
                        catch
                        {
                            MessageBox.Show("Foto não encontrada");
                            pictureBox1.Dispose();
                        }
                        TBaluno_nome.Text = CRUDaluno.get_aluno_nome;
                        TBaluno_telefone.Text = CRUDaluno.get_aluno_telefone;
                        TBaluno_cpf.Text = CRUDaluno.get_aluno_cpf;
                        TBaluno_email.Text = CRUDaluno.get_aluno_email;
                        dateTimePicker1.Text = CRUDaluno.get_dia_de_inicio_aulas;
                        dateTimePicker2.Text = CRUDaluno.get_Aluno_nascimento;
                        if (CRUDaluno.get_tipo_de_aula == "Particular")
                        {
                            CB_Grupo.Checked = false;
                            CB_Particular.Checked = true;
                        }
                        else
                        {
                            CB_Particular.Checked = false;
                            CB_Grupo.Checked = true;
                        }
                        TBmensalidade.Text = CRUDaluno.get_mensalidade;
                        TBlimite_pagamento.Text = CRUDaluno.get_limite_pagamento;
                        TBaluno_endereco.Text = CRUDaluno.get_aluno_endereco;
                        TBaluno_numero.Text = CRUDaluno.get_aluno_numero;
                        TBaluno_cep.Text = CRUDaluno.get_aluno_cep;
                        TBaluno_complemento.Text = CRUDaluno.get_aluno_complemento;
                        if (CRUDaluno.get_aluno_sexo == "F")
                        {
                            CBmasculino.Checked = false;
                            CBfeminino.Checked = true;
                        }
                        else
                        {
                            CBfeminino.Checked = false;
                            CBmasculino.Checked = true;
                        }

                        if (CRUDaluno.get_responsavel_rg != null && CRUDaluno.get_responsavel_rg != "")
                        {
                            TBresponsavel_nome.Text = CRUDaluno.get_responsavel_nome;
                            TBresponsavel_telefone.Text = CRUDaluno.get_responsavel_telefone;
                            TBresponsavel_cpf.Text = CRUDaluno.get_responsavel_cpf;
                            CBparentesco.Text = CRUDaluno.get_responsavel_parentesco;
                            TBresponsavel_email.Text = CRUDaluno.get_responsavel_email;
                            TBresponsavel_rg.Text = CRUDaluno.get_responsavel_rg;
                            TBresponsavel_endereco.Text = CRUDaluno.get_responsavel_endereco;
                            TBresponsavel_numero.Text = CRUDaluno.get_responsavel_numero;
                            TBresponsavel_cep.Text = CRUDaluno.get_responsavel_cep;
                            TBresponsavel_complemento.Text = CRUDaluno.get_responsavel_complemento;
                            if (Funcao_deletar.Checked == false)
                            {
                                habilitar_responsavel();
                            }
                            else
                            {
                                TBaluno_nome.Enabled = false;
                                TBaluno_telefone.Enabled = false;
                                TBaluno_email.Enabled = false;
                                TBlimite_pagamento.Enabled = false;
                                TBaluno_endereco.Enabled = false;
                                TBaluno_cpf.Enabled = false;
                                TBaluno_numero.Enabled = false;
                                TBaluno_cep.Enabled = false;
                                TBaluno_complemento.Enabled = false;

                                TBmensalidade.Enabled = false;
                                CB_Grupo.Enabled = false;
                                CB_Particular.Enabled = false;

                                CBmasculino.Enabled = false;
                                CBfeminino.Enabled = false;

                                dateTimePicker1.Enabled = false;
                                dateTimePicker2.Enabled = false;
                                BTaluno_carregar_foto.Enabled = false;
                                CBmenor_de_idade.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível encontrar o aluno.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Devido a algum erro não foi possível carregar as informações ou esse número de RG não está cadastrado.");
            }
        }

        private void habilitar_responsavel()
        {
            TBresponsavel_nome.Enabled = true;
            TBresponsavel_telefone.Enabled = true;
            TBresponsavel_email.Enabled = true;
            TBresponsavel_endereco.Enabled = true;
            TBresponsavel_cpf.Enabled = true;
            TBresponsavel_rg.Enabled = true;
            TBresponsavel_numero.Enabled = true;
            TBresponsavel_cep.Enabled = true;
            TBresponsavel_complemento.Enabled = true;
            CBparentesco.Enabled = true;
           
        }

        private void TBaluno_telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (TBaluno_telefone.TextLength)
                {
                    case 0:
                        TBaluno_telefone.Text = TBaluno_telefone.Text + "(";
                        TBaluno_telefone.SelectionStart = 1;
                        break;
                    case 3:
                        TBaluno_telefone.Text = TBaluno_telefone.Text + ")";
                        TBaluno_telefone.SelectionStart = 4;
                        break;

                    case 9:
                        TBaluno_telefone.Text = TBaluno_telefone.Text + "-";
                        TBaluno_telefone.SelectionStart = 10;
                        break;

                }
            }
            else
            {
                TBaluno_telefone.Text = null;
            }
        }

        private void TBaluno_rg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {
                
                switch (TBaluno_rg.TextLength)
                {
                    case 2:
                        TBaluno_rg.Text = TBaluno_rg.Text + ".";
                        TBaluno_rg.SelectionStart = 3;
                        break;
                    case 6:
                        TBaluno_rg.Text = TBaluno_rg.Text + ".";
                        TBaluno_rg.SelectionStart = 7;
                        break;

                    case 10:
                        TBaluno_rg.Text = TBaluno_rg.Text + "-";
                        TBaluno_rg.SelectionStart = 11;
                        break;

                }
            }
        }

        private void TBresponsavel_telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (TBresponsavel_telefone.TextLength)
                {
                    case 0:
                        TBresponsavel_telefone.Text = TBresponsavel_telefone.Text + "(";
                        TBresponsavel_telefone.SelectionStart = 1;
                        break;
                    case 3:
                        TBresponsavel_telefone.Text = TBresponsavel_telefone.Text + ")";
                        TBresponsavel_telefone.SelectionStart = 4;
                        break;

                    case 9:
                        TBresponsavel_telefone.Text = TBresponsavel_telefone.Text + "-";
                        TBresponsavel_telefone.SelectionStart = 10;
                        break;

                }
            }
            else
            {
                TBresponsavel_telefone.Text = null;
            }
        }

        private void TBaluno_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                if (TBaluno_cpf.Text.Length <= 14)
                {
                    switch (TBaluno_cpf.TextLength)
                    {
                        case 3:
                            TBaluno_cpf.Text = TBaluno_cpf.Text + ".";
                            TBaluno_cpf.SelectionStart = 4;
                            break;
                        case 7:
                            TBaluno_cpf.Text = TBaluno_cpf.Text + ".";
                            TBaluno_cpf.SelectionStart = 8;
                            break;

                        case 11:
                            TBaluno_cpf.Text = TBaluno_cpf.Text + ".";
                            TBaluno_cpf.SelectionStart = 12;
                            break;

                    }

                }
            }
            else
            {
                TBaluno_cpf.Text = null;
            }
        }

        private void TBresponsavel_rg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) == true)
            {
                switch (TBresponsavel_rg.TextLength)
                {
                    case 2:
                        TBresponsavel_rg.Text = TBresponsavel_rg.Text + ".";
                        TBresponsavel_rg.SelectionStart = 3;
                        break;
                    case 6:
                        TBresponsavel_rg.Text = TBresponsavel_rg.Text + ".";
                        TBresponsavel_rg.SelectionStart = 7;
                        break;

                    case 10:
                        TBresponsavel_rg.Text = TBresponsavel_rg.Text + "-";
                        TBresponsavel_rg.SelectionStart = 11;
                        break;

                }
            }

        }

        private void TBresponsavel_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {

                if (TBresponsavel_cpf.Text.Length <= 14)
                {

                    switch (TBresponsavel_cpf.TextLength)
                    {
                        case 3:
                            TBresponsavel_cpf.Text = TBresponsavel_cpf.Text + ".";
                            TBresponsavel_cpf.SelectionStart = 4;
                            break;
                        case 7:
                            TBresponsavel_cpf.Text = TBresponsavel_cpf.Text + ".";
                            TBresponsavel_cpf.SelectionStart = 8;
                            break;

                        case 11:
                            TBresponsavel_cpf.Text = TBresponsavel_cpf.Text + ".";
                            TBresponsavel_cpf.SelectionStart = 12;
                            break;

                    }
                 }

                


            }
            else
            {
                TBresponsavel_cpf.Text = null;
            }
        }



        private void TBlimite_pagamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int verificar = Convert.ToInt32(TBlimite_pagamento.Text);
                if (verificar > 31 || verificar == 0)
                {
                    TBlimite_pagamento.Text = null;
                }
               
            }
            catch
            {
                TBlimite_pagamento.Text = null;
            }
        }

        private void TBaluno_cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {

                switch (TBaluno_cep.TextLength)
                {
                    case 5:
                        TBaluno_cep.Text = TBaluno_cep.Text + "-";
                        TBaluno_cep.SelectionStart = 6;
                        break;
                    

                }


            }
            else
            {
                TBaluno_cep.Text = null;
            }
        }

        private void TBresponsavel_cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {

                switch (TBresponsavel_cep.TextLength)
                {
                    case 5:
                        TBresponsavel_cep.Text = TBresponsavel_cep.Text + "-";
                        TBresponsavel_cep.SelectionStart = 6;
                        break;


                }


            }
        }

        private void TBaluno_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
                
               
            }
            else
            {
                TBaluno_numero.Text = null;
            }
        }

        private void TBresponsavel_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true)
            {
               

            }
            else
            {
                TBresponsavel_numero.Text = null;
               
            }
        }

        private void TBaluno_numero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt32(TBaluno_numero.Text);
            }
            catch { TBaluno_numero.Text = null; }
        }

        private void TBresponsavel_numero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt32(TBresponsavel_numero.Text);
            }
            catch { TBresponsavel_numero.Text = null; }
        }

        

       

        //private void TBmensalidade_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsNumber(e.KeyChar) == true)
        //    {

        //        switch (TBmensalidade.TextLength)
        //        {
        //            case 5:
        //                TBmensalidade.Text = TBmensalidade.Text + "-";
        //                TBmensalidade.SelectionStart = 6;
        //                break;


        //        }


        //    }
        //}

        public void Jogar_RG_no_TB(string rg)
        {
            TBaluno_rg.Text = rg;
        }

        private void BTprocurar_por_nome_Click(object sender, EventArgs e)
        {
            BuscarPorNome Bnome = new BuscarPorNome(Nome_Pessoa_Logada);
          // this.Close();
            Bnome.Show();

           // pictureBox1.Load(@"C:\\Foto\\Teste");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home home = new Home(Nome_Pessoa_Logada, RG_Logado);
            this.Close();
            
            home.Show();
        }

        private void listBox_expediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUDaluno.setar_horarios_de_aula("remove", "remove", "remove");
          //  int retirar = listBox_horario.Items.Count;

           // listBox_horario.Items.RemoveAt(retirar - 1);
        }

        private void BTadicionar_horario_Click(object sender, EventArgs e)
        {
            //string expediente = CBdia.Text + " das: " + CBinicio.Text + " às " + CBtermino.Text;
           // CRUDaluno.setar_horarios_de_aula(CBdia.Text, CBinicio.Text, CBtermino.Text);
           // listBox_horario.Items.Add(expediente);

         //   CBdia.Text = null;
        }

       
        

       

        

        

        



        

       

    }
}

