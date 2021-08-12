using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
//falta concluir o cadastro na escala e update tbm
namespace Projeto_Administrativo
{
    public class AlunoCRUD
    {
        
        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);
        private static Timer _timer = new Timer();
        
        static AlunoCRUD()
        {
            _timer.Tick +=new EventHandler(_timer_Tick);
        }

        private static void _timer_Tick(object sender, EventArgs e)
        {

        }

        public static void BlockInput(int ms)
        {
            BlockInput(true);
        }

        //Conexao # ta dando erro
        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao; 
        private MySqlDataAdapter adapter;


        private string Nome_Pessoa_Logada;
        private string Data_Pessoa_logada = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        //Aluno
        //private string id_aluno = "default";
        private string Imagem_Diretorio;
        private bool tem_foto = false;
        private string aluno_rg;
        private string aluno_nome;
        private string aluno_cpf;
        private string aluno_telefone;
        private string aluno_email;
        private string dia_de_inicio_aulas;
        private string tipo_de_aula;
        private string aluno_sexo;
        private string limite_pagamento;     
        private string Aluno_nascimento;
        private string mensalidade;
        private string aluno_endereco;
        private string aluno_numero;
        private string aluno_cep; 
        private string aluno_complemento;
        private String[] dias_de_aula = new String[50];
        private String[] horario_de_inicio_da_aula = new String[50];
        private String[] horario_de_fim_da_aula = new String[50];
        private int Contador_vetores;

        private string checagem_aluno;
        private bool aluno_ja_cadastrado = false;
        private string Diretorio_salvar;
        
        //responsavel
       // private string id_responsavel = "default";
        private string responsavel_nome;
        private string responsavel_cpf;
        private string responsavel_rg;        
        private string responsavel_telefone;       
        private string responsavel_email;
        private string responsavel_parentesco;        
        private string responsavel_endereco;
        private string responsavel_numero;
        private string responsavel_cep;
        private string responsavel_complemento;        
        
        private string checagem_responsavel;
        private bool responsavel_ja_cadastrado = false;

        //TBaluno_rg.Text, TBaluno_nome.Text, Convert.ToInt32(TBaluno_cpf.Text), TBaluno_telefone.Text, TBaluno_email.Text, inicio_aulas, nascimento,
                 //            this.tipo_de_aula, Convert.ToInt32(TBlimite_pagamento.Text), TB_Valor_da_mensalidade.Text, TBaluno_endereco.Text, Convert.ToInt32(TBaluno_numero.Text),
                  //           TBaluno_cep.Text, TBaluno_complemento.Text, this.Sexo);

        public AlunoCRUD(string quem_esta_logado) { conexao = new MySqlConnection(local_conexao); this.Nome_Pessoa_Logada = quem_esta_logado; }

                                                                                                    
        public void aluno_setar(string nnome, string ccpf, string ttelefone, string rrg,    string eemail, string ddia_de_inicio_aulas, string eendereco, string ccep, string nnumero,  string ccomplemento, string sexo, string llimite_pagamento, string ddia_de_nascimento, string tipu_de_aula, 
            string mmensalidade )
        {
            this.aluno_rg = rrg; this.aluno_nome = nnome; this.aluno_cpf = ccpf; this.aluno_telefone = ttelefone; this.aluno_email = eemail; this.dia_de_inicio_aulas = ddia_de_inicio_aulas; this.Aluno_nascimento = ddia_de_nascimento;
            this.tipo_de_aula = tipu_de_aula; this.limite_pagamento = llimite_pagamento; 
            this.mensalidade = mmensalidade; this.aluno_endereco = eendereco; this.aluno_numero = nnumero; this.aluno_cep = ccep; this.aluno_complemento = ccomplemento; this.aluno_sexo = sexo;

        }
                                                                  
        public void responsavel_setar(string nnome, string ccpf, string rrg, string ttelefone, string eemail, string pparentesco, string eendereco, string nnumero, string ccep,  string ccomplemento, string ddia_pagamento, string mmensalidade)
        {
            this.responsavel_nome = nnome; this.responsavel_parentesco = pparentesco; this.responsavel_telefone = ttelefone; this.responsavel_cpf = ccpf; this.responsavel_email = eemail;
            this.responsavel_rg = rrg; this.responsavel_endereco = eendereco; this.responsavel_numero = nnumero; this.responsavel_cep = ccep; this.responsavel_complemento = ccomplemento; this.limite_pagamento = ddia_pagamento; this.mensalidade = mmensalidade;
        }

        public void setar_responsavel_e_aluno_rgs(string rg_aluno)
        {
            this.aluno_rg = rg_aluno;
            
        }
        private void erro(string e)
        {
            System.Windows.Forms.MessageBox.Show("Devido a algum erro não foi possível efetuar o registro! \n" + e);
        }
        //CADASTRO OK
        //Salvar responsavel e aluno, eu arrumei... so revisar
       private void responsavel_cadastrar()
        {
            //responsavelcol
            string mensagem = "INSERT INTO responsavel (nome_responsavel, cpf, rg, telefones, email, parentesco, endereco, numero_endereco, cep, complemento, dia_pagamento, mensalidade, quem_registro, quando_registro)values(@nome_responsavel, @cpf, @rg, @telefones, @email, @parentesco, @endereco, @numero_endereco, @cep, @complemento, @dia_pagamento, @mensalidade, @quem_registro, @quando_registro)";
            try
            {
                conexao.Close();
            }
            catch { }
           conexao.Open();
            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
            try
            {

                //conectar com o banco
               


                //executar comando
                //executar 1 por 1 para identificar o erro... proxima vez que for mexer

                cmd.Parameters.AddWithValue("@nome_responsavel", this.responsavel_nome);
                cmd.Parameters.AddWithValue("@cpf", this.responsavel_cpf);
                cmd.Parameters.AddWithValue("@rg", this.responsavel_rg);
                cmd.Parameters.AddWithValue("@telefones", this.responsavel_telefone);
                cmd.Parameters.AddWithValue("@email", this.responsavel_email);
                cmd.Parameters.AddWithValue("@parentesco", this.responsavel_parentesco);
                cmd.Parameters.AddWithValue("@endereco",this.responsavel_endereco);
                cmd.Parameters.AddWithValue("@numero_endereco",this.responsavel_numero);
                cmd.Parameters.AddWithValue("@cep",this.responsavel_cep);
                cmd.Parameters.AddWithValue("@complemento",this.responsavel_complemento);
                cmd.Parameters.AddWithValue("@dia_pagamento", this.limite_pagamento);
                cmd.Parameters.AddWithValue("@mensalidade", this.mensalidade);
                cmd.Parameters.AddWithValue("@quem_registro", this.Nome_Pessoa_Logada);
                cmd.Parameters.AddWithValue("@quando_registro", this.Data_Pessoa_logada);
                cmd.ExecuteNonQuery();
                conexao.Close();
                //desconectar
                
               
               
                System.Windows.Forms.MessageBox.Show("registrado com sucesso!");

            }
            catch (Exception e)
            {
                erro(e.ToString());
            }



        }
       private void aluno_cadastrar(string tem_responsavel)
        {
            if (tem_foto == true)
            {
                Mover_foto(Imagem_Diretorio, this.aluno_rg);
                tem_foto = false;
            }
            if (tem_responsavel == "nao")
            {
                
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                string mensagem = "INSERT INTO aluno(nome_aluno, cpf, telefones, rg,email, aulas_inicio, endereco, cep,numero_endereco,complemento, sexo, dia_pagamento, nascimento,tipo_aula, mensalidade, quem_registro, quando_registro)values(@nome_aluno, @cpf, @telefones, @rg, @email,@aulas_inicio,@endereco,@cep,@numero_endereco,@complemento, @sexo, @dia_pagamento, @nascimento, @tipo_aula, @mensalidade, @quem_registro, @quando_registro)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {

                   
                    
                    


             
            

                    // cmd.Parameters.AddWithValue("@id_aluno", this.id_aluno);
                    cmd.Parameters.AddWithValue("@nome_aluno", this.aluno_nome);
                    cmd.Parameters.AddWithValue("@cpf", this.aluno_cpf);
                    cmd.Parameters.AddWithValue("@telefones", this.aluno_telefone);
                    cmd.Parameters.AddWithValue("@rg", this.aluno_rg);
                    cmd.Parameters.AddWithValue("@email", this.aluno_email);
                    cmd.Parameters.AddWithValue("@aulas_inicio", this.dia_de_inicio_aulas);
                    cmd.Parameters.AddWithValue("@endereco", this.aluno_endereco);
                    cmd.Parameters.AddWithValue("@cep", this.aluno_cep);
                    cmd.Parameters.AddWithValue("@numero_endereco", this.aluno_numero);
                    cmd.Parameters.AddWithValue("@complemento", this.aluno_complemento);
                  //  cmd.Parameters.AddWithValue("@foto", this.Diretorio_salvar);
                    cmd.Parameters.AddWithValue("@sexo", this.aluno_sexo);
                    cmd.Parameters.AddWithValue("@dia_pagamento", this.limite_pagamento);
                    cmd.Parameters.AddWithValue("@nascimento", this.Aluno_nascimento);
                    cmd.Parameters.AddWithValue("@tipo_aula", this.tipo_de_aula);
                    cmd.Parameters.AddWithValue("@mensalidade", this.mensalidade);
                    cmd.Parameters.AddWithValue("@quem_registro", this.Nome_Pessoa_Logada);
                    cmd.Parameters.AddWithValue("@quando_registro", this.Data_Pessoa_logada);
                    


                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();
                   
                    System.Windows.Forms.MessageBox.Show("registrado com sucesso!");

                }
                catch (Exception e)
                {
                    erro(e.ToString());
                }

            }

            else if (tem_responsavel == "sim")
            {

                
                string mensagem = "INSERT INTO aluno(nome_aluno, cpf, telefones, rg,email, aulas_inicio, endereco, cep,numero_endereco,complemento, sexo, nascimento,tipo_aula,responsavel_rg, quem_registro, quando_registro)values(@nome_aluno, @cpf, @telefones, @rg, @email,@aulas_inicio,@endereco,@cep,@numero_endereco,@complemento, @sexo, @nascimento, @tipo_aula,@responsavel_rg, @quem_registro, @quando_registro)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    //conectar com o banco
                    conexao.Open();


                    //executar comando
                    //executar 1 por 1 para identificar o erro... proxima vez que for mexer

                    // cmd.Parameters.AddWithValue("@id_aluno", this.id_aluno);
                    cmd.Parameters.AddWithValue("@nome_aluno", this.aluno_nome);
                    cmd.Parameters.AddWithValue("@cpf", this.aluno_cpf);
                    cmd.Parameters.AddWithValue("@telefones", this.aluno_telefone);
                    cmd.Parameters.AddWithValue("@rg", this.aluno_rg);
                    cmd.Parameters.AddWithValue("@email", this.aluno_email);
                    cmd.Parameters.AddWithValue("@aulas_inicio", this.dia_de_inicio_aulas);
                    cmd.Parameters.AddWithValue("@endereco", this.aluno_endereco);
                    cmd.Parameters.AddWithValue("@cep", this.aluno_cep);
                    cmd.Parameters.AddWithValue("@numero_endereco", this.aluno_numero);
                    cmd.Parameters.AddWithValue("@complemento", this.aluno_complemento);
                    //cmd.Parameters.AddWithValue("@foto", this.Diretorio_salvar);
                    cmd.Parameters.AddWithValue("@sexo", this.aluno_sexo);
                    //cmd.Parameters.AddWithValue("@dia_pagamento", this.limite_pagamento);
                    cmd.Parameters.AddWithValue("@nascimento", this.Aluno_nascimento);
                    cmd.Parameters.AddWithValue("@tipo_aula", this.tipo_de_aula);
                    cmd.Parameters.AddWithValue("@responsavel_rg", this.responsavel_rg);
                    cmd.Parameters.AddWithValue("@quem_registro", this.Nome_Pessoa_Logada);
                    cmd.Parameters.AddWithValue("@quando_registro", this.Data_Pessoa_logada);
                    
                   

                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();
                    
                    System.Windows.Forms.MessageBox.Show("registrado com sucesso!");

                }
                catch (Exception e)
                {
                    erro(e.ToString());
                }

            }

           //
            

        }
        
        //APAGAR REGISTRO OK
        //acho que está certo 
       private void apagar_registro(string aluno_rg, string responsavel_rg)
        {

            if (responsavel_rg != null && responsavel_rg != "")
            {              
                try
                {
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    //conectar com o banco
                    conexao.Open();

                    string mensagem = "DELETE FROM aluno WHERE rg = '" + aluno_rg + "'";
                    MySqlCommand delete = new MySqlCommand(mensagem, conexao);
                    delete.ExecuteNonQuery();

                    mensagem = "DELETE FROM responsavel WHERE aluno_rg = '" + responsavel_rg + "'";
                    delete = new MySqlCommand(mensagem, conexao);
                    delete.ExecuteNonQuery();

                    mensagem = "DELETE FROM escala WHERE rg = '" + aluno_rg + "'";
                    delete = new MySqlCommand(mensagem, conexao);
                    delete.ExecuteNonQuery();

                    //desconectar
                    conexao.Close();
                    System.Windows.Forms.MessageBox.Show("Registro excluido com sucesso!");

                }
                catch (Exception e)
                {
                    conexao.Close();
                    erro(e.ToString());
                }
            }

           else 
            {
                try
                {
                string mensagem = "DELETE FROM aluno WHERE rg = '" + aluno_rg + "'";

                MySqlCommand delete = new MySqlCommand(mensagem, conexao);

                try
                {
                    conexao.Close();
                }
                catch { }
                    //conectar com o banco
                    conexao.Open();
                    delete.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();
                    System.Windows.Forms.MessageBox.Show("Registro excluido com sucesso!");

                }
                catch (Exception e)
                {
                    conexao.Close();
                    erro(e.ToString());
                }
            }



        }

        //Esse void foi a unica forma que eu encontrei de enviar cada casa do vetor do form pra essa classe (definir horarios de aula)
        
        //ATUALIZAR
        //precisa arrumar o comando de update, fora isso, irá atualizar todos os campos
        private void aluno_atualizar(string tem_responsavel)
        {
            if (tem_responsavel == "nao")
            {
                
                //TESTAR CÓDIGO
                string mensagem = "UPDATE aluno SET telefones = '" + aluno_telefone + "',email = '" + aluno_email + "', aulas_inicio = '" + dia_de_inicio_aulas + "', endereco = '" + aluno_endereco + "', cep ='" + aluno_cep + "',numero_endereco = '" + aluno_numero + "',complemento = '" + aluno_complemento + "', dia_pagamento = '" + limite_pagamento + "', nascimento = '" + Aluno_nascimento + "',tipo_aula = '" + tipo_de_aula + "', mensalidade = '" + mensalidade + "', quem_atualizou = '" + Nome_Pessoa_Logada + "', quando_atualizou = '" + Data_Pessoa_logada + "' WHERE rg = '" + aluno_rg + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {
                    BlockInput(true);
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    
                        conexao.Open();
                    


                    //executar comando                    
                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();
                    
                    BlockInput(false);
                    System.Windows.Forms.MessageBox.Show("Atualizado com sucesso!");
                    
                }
                catch (Exception e)
                {
                    BlockInput(false);
                    erro(e.ToString());
                }

            }

            else if (tem_responsavel == "sim")
            {
                if (tem_foto == true)
                {
                    Mover_foto(Imagem_Diretorio, this.aluno_nome);
                    tem_foto = false;
                }
                string mensagem = "UPDATE aluno SET telefones = '" + aluno_telefone + "',email = '" + aluno_email + "', aulas_inicio = '" + dia_de_inicio_aulas + "', endereco = '" + aluno_endereco + "', cep ='" + aluno_cep + "',numero_endereco = '" + aluno_numero + "',complemento = '" + aluno_complemento + "', nascimento = '" + Aluno_nascimento + "',tipo_aula = '" + tipo_de_aula + "' WHERE responsavel_rg = '" + responsavel_rg+ "'";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {
                    BlockInput(true);
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    //conectar com o banco
                    conexao.Open();


                    //executar comando
                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();
                    
                    BlockInput(false);
                    System.Windows.Forms.MessageBox.Show("registrado com sucesso!");

                }
                catch (Exception e)
                {

                    BlockInput(false);
                    erro(e.ToString());
                }
                
            }
        }//OK, EXPERIENCIA

        private void responsavel_atualizar()
        {            
            
                try
                {
                    string mensagem = "UPDATE responsavel SET telefones='" + responsavel_telefone + "', email='" + responsavel_email + "', parentesco = '" + responsavel_parentesco + "',endereco='" + responsavel_endereco + "', numero_endereco='" + responsavel_numero + "', cep= '" + responsavel_cep + "', complemento='" + responsavel_complemento + "',dia_pagamento='" + limite_pagamento + "', quem_atualizou = '" + Nome_Pessoa_Logada + "', quando_atualizou = '" + Data_Pessoa_logada + "' WHERE rg = '" + responsavel_rg + "'";
                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);

                    BlockInput(true);
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();
                    //desconectar

                    BlockInput(false);

                    System.Windows.Forms.MessageBox.Show("registrado com sucesso!");

                }
                catch (Exception e)
                {
                    BlockInput(false);
                    erro(e.ToString());
                }

            
           

        }//OK, EXPERIENCIA


        //PEGAR AS INFORMAÇÕES DO BD E MOSTRAR NO FORM
        //Aqui ele deve carregar e mudar todos os valores no "aluno_setar" e "responsavel_setar"
        //e depois cair no void carregar informações (embaixo)
        private void Buscar_informacoes(string rg)
        {           
            try
            {
                BlockInput(true);         

                string mensagem = "SELECT nome_aluno, cpf, telefones, rg, email, aulas_inicio, endereco, cep, numero_endereco,complemento, sexo, dia_pagamento, nascimento,tipo_aula, mensalidade, responsavel_rg  FROM aluno WHERE rg = '" + rg + "'";          
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {
                    conexao.Close();
                }
                catch { }
                //Aqui ele faz um SELECT e joga para o DataTable as informações do aluno           
            conexao.Open();
          //  comando.Connection = conexao;
            DataTable tabela_retorno = new DataTable();
            cmd.ExecuteNonQuery();
            //Aqui ele adapta o comando no DataTable (joga as informações que não tinham onde ficar na tablea pra a gente poder usar)
            adapter = new MySqlDataAdapter(cmd);
          
            adapter.Fill(tabela_retorno);
            conexao.Close();

            //Seta as informações do aluno
            aluno_setar(tabela_retorno.Rows[0][0].ToString(), tabela_retorno.Rows[0][1].ToString(), tabela_retorno.Rows[0][2].ToString(), tabela_retorno.Rows[0][3].ToString(), tabela_retorno.Rows[0][4].ToString(), tabela_retorno.Rows[0][5].ToString(), tabela_retorno.Rows[0][6].ToString(), tabela_retorno.Rows[0][7].ToString(), tabela_retorno.Rows[0][8].ToString(), tabela_retorno.Rows[0][9].ToString(), tabela_retorno.Rows[0][10].ToString(), tabela_retorno.Rows[0][11].ToString(), tabela_retorno.Rows[0][12].ToString(), tabela_retorno.Rows[0][13].ToString(), tabela_retorno.Rows[0][14].ToString());
            
            string pegar_responsavel = tabela_retorno.Rows[0][15].ToString();//vai ser a ultima célula do dataTable.Mas não esqueça que ta faltando um campo no BD então as numerações vão mudar

            if (pegar_responsavel != null && pegar_responsavel != "")
            {
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();

                mensagem = "SELECT nome_responsavel, responsavel.cpf, responsavel.rg, responsavel.telefones, responsavel.email, responsavel.parentesco, responsavel.endereco, responsavel.numero_endereco, responsavel.cep, responsavel.complemento, responsavel.dia_pagamento, responsavel.mensalidade  FROM responsavel, aluno WHERE aluno.responsavel_rg = '" + pegar_responsavel + "'";


                MySqlCommand cmd2 = new MySqlCommand(mensagem, conexao);
                cmd2.ExecuteNonQuery();
                conexao.Close();
                DataTable tabela_retorno2 = new DataTable();
                adapter = new MySqlDataAdapter(cmd2);
                adapter.Fill(tabela_retorno2);
                
               
                responsavel_setar(tabela_retorno2.Rows[0][0].ToString(), tabela_retorno2.Rows[0][1].ToString(), tabela_retorno2.Rows[0][2].ToString(), tabela_retorno2.Rows[0][3].ToString(), tabela_retorno2.Rows[0][4].ToString(), tabela_retorno2.Rows[0][5].ToString(), tabela_retorno2.Rows[0][6].ToString(), tabela_retorno2.Rows[0][7].ToString(), tabela_retorno2.Rows[0][8].ToString(), tabela_retorno2.Rows[0][9].ToString(), tabela_retorno2.Rows[0][10].ToString(), tabela_retorno2.Rows[0][11].ToString());
                
                //Agora falta fazer no form ele pegar os gets... e nao esquece de colocar um if pra "caso a variavel responsavel != null" ele pega e caso nao for ele deixa
                BlockInput(false);
            }

          
            BlockInput(false);
            }
            catch
            {
                BlockInput(false);              
            }
            

        }//OK EXPERIENCIA MAS FALTA ARRUMAR

        //esse void retorna as informações pro void do form "carregar_informações_do_aluno" e depois se o rg do responsavel
        // nao for nulo, ele cai no void carregar informações do responsavel no form

        public string get_aluno_rg { get { return aluno_rg; } }
        public string get_aluno_nome { get { return aluno_nome; } }
        public string get_aluno_cpf { get { return aluno_cpf; } }
        public string get_aluno_telefone { get { return aluno_telefone; } }
        public string get_aluno_email { get { return aluno_email; } }
        public string get_dia_de_inicio_aulas { get { return dia_de_inicio_aulas; } }
        public string get_tipo_de_aula { get { return tipo_de_aula; } }
        public string get_limite_pagamento { get { return limite_pagamento; } }
        public string get_mensalidade { get { return mensalidade; } }
        public string get_aluno_endereco { get { return aluno_endereco; } }
        public string get_aluno_numero { get { return aluno_numero; } }
        public string get_aluno_cep { get { return aluno_cep; } }
        public string get_aluno_complemento { get { return aluno_complemento; } }
        public string get_aluno_sexo { get { return aluno_sexo; } }   
        public string get_Aluno_nascimento { get { return Aluno_nascimento; } }        

        //esse void será ativado de acordo com a condição do de cima
       public string get_responsavel_nome { get { return responsavel_nome; } }
       public string get_responsavel_parentesco { get { return responsavel_parentesco; } }
       public string get_responsavel_telefone { get { return responsavel_telefone; } }
       public string get_responsavel_cpf { get { return responsavel_cpf; } }
       public string get_responsavel_email{ get { return responsavel_email; } }
       public string get_responsavel_rg { get { return responsavel_rg ; } }
       public string get_responsavel_endereco{ get { return responsavel_endereco; } }
       public string get_responsavel_numero{ get { return responsavel_numero; } }
       public string get_responsavel_cep { get { return responsavel_cep; } }
       public string get_responsavel_complemento { get { return responsavel_complemento; } }
       
           

        //VOID DE SETAR DADOS ESPECÍFICOS OK
        //manda informações mais complexas e já salva nessa classe
        public void setar_horarios_de_aula(string dia, string inicio, string termino)
        {
            //esse "ss" é pra quando a pessoa cadastrar, limpar todos os vetores.
            if (dia == "ss" && inicio == "ss" && termino == "ss")
            {
                Contador_vetores = 0;
                for (int i = 0; i < 50; i++)
                {
                    dias_de_aula[i] = null;
                    horario_de_inicio_da_aula[i] = null;
                    horario_de_fim_da_aula[i] = null;
                }
            }
            //aqui remove a ultima casa adicionada no vetor (caso a pessa tenha adicionado errado ou queira escolher outro dia)
            else if (dia == "remove" && inicio == "remove" && termino == "remove")
            {
                Contador_vetores -= 1;

                dias_de_aula[Contador_vetores] = null;
                horario_de_inicio_da_aula[Contador_vetores] = null;
                horario_de_fim_da_aula[Contador_vetores] = null;
            }
            //aqui adiciona os dias que o aluno que fazer aula
            else
            {
                dias_de_aula[Contador_vetores] = dia;
                horario_de_inicio_da_aula[Contador_vetores] = inicio;
                horario_de_fim_da_aula[Contador_vetores] = termino;

                Contador_vetores += 1;
            }
        }
        
        public void diretorio_imagem(string diretorio)
        {
            this.Imagem_Diretorio = diretorio;
            
        }
        public void foto_tem(string confirma)
        {
            if (confirma == "sim")
            {
                tem_foto = true;
            }
            else
            {
                tem_foto = false;
            }
        }


                private void Mover_foto(string diretorio_imagem, string rg)
                {
                    
                    try
                    {
                        //depois precisa arrumar pra ele salvar sem extensão e renomear (colocando extensao)
                        // ou se ele conseguir mudar a extensão quando mover, melhor ainda
                        if (!Directory.Exists(@"C:\\Foto"))
                        {
                            Directory.CreateDirectory(@"C:\\Foto");
                        }
                        if(File.Exists(@"C:\\Foto\\" + rg+".jpg"))
                        {
                            File.Delete(@"C:\\Foto\\" + rg+".jpg");
                        
                        }
                        File.Move(diretorio_imagem, @"C:\\Foto\\" + rg + ".jpg");
                        this.Diretorio_salvar = "C:\\Foto\\" + rg + ".jpg";
                        
                       
                    }
                    
                    catch(Exception e)
                    {
                        this.tem_foto = false;
                        File.Delete(@"C:\\Foto\\" + rg + ".jpg");
                        erro(e.ToString());
                    }
                }

        
          
        

        

        //Aqui precisa fazer as funções pra inserir as informações em tabelas adicionais como a do financeiro pra mensalidade.
        //Após isso é so chamar esse void dentro da função atualizar e cadastrar


        public void Checagem(string desejado, string local_responsavel)
        {
            BlockInput(true);
            try
            {
                string verifica = "SELECT rg FROM aluno WHERE rg = '" + aluno_rg + "'";
                MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                BlockInput(true);
                //conectar com o banco
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();


                //executar comando                
                cmd.ExecuteNonQuery();

                conexao.Close();

                adapter = new MySqlDataAdapter(cmd);
                DataTable tabela_retorno = new DataTable();
                adapter.Fill(tabela_retorno);
                try
                {
                    checagem_aluno = tabela_retorno.Rows[0][0].ToString();
                }
                catch { }
                if (checagem_aluno != "" && checagem_aluno != null)
                {
                    aluno_ja_cadastrado = true;
                }
                else
                {
                    aluno_ja_cadastrado = false;
                }
            }
            catch { }

            if (local_responsavel == "sim")
            {
                
                try
                {
                    string verifica = "SELECT rg FROM responsavel WHERE rg = '" + responsavel_rg + "'";
                    MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                    BlockInput(true);
                    //conectar com o banco
                    conexao.Open();


                    //executar comando                
                    cmd.ExecuteNonQuery();

                    conexao.Close();
                    adapter = new MySqlDataAdapter(cmd);
                    DataTable tabela_retorno = new DataTable();
                    adapter.Fill(tabela_retorno);
                    try
                    {
                        checagem_responsavel = tabela_retorno.Rows[0][0].ToString();
                    }

                    catch { }
                    if (checagem_responsavel != "" && checagem_responsavel != null)
                    {
                        responsavel_ja_cadastrado = true;
                    }
                    else
                    {
                        responsavel_ja_cadastrado = false;
                    }
                }

                catch { }
            }
        
                if (desejado == "CADASTRAR")
                {
                    if (aluno_ja_cadastrado == false)
                    {
                        if (local_responsavel == "sim")
                        {
                            responsavel_cadastrar();
                            aluno_cadastrar("sim");
                        }
                        else
                        {
                            aluno_cadastrar("nao");
                        }

                    }
                    else { MessageBox.Show("Aluno já cadastrado"); foto_tem("nao"); }
                    aluno_ja_cadastrado = false;
                    responsavel_ja_cadastrado = false;
                    checagem_aluno = null;
                    checagem_responsavel = null;
                }

                else if (desejado == "ATUALIZAR")
                {
                    if (aluno_ja_cadastrado == true)
                    {
                        if (local_responsavel == "sim")
                        {
                            if (responsavel_ja_cadastrado == true)
                            {
                                responsavel_atualizar();
                                aluno_atualizar("sim");
                            }
                            else
                            {
                                responsavel_cadastrar();
                                aluno_atualizar("sim");
                                //////////////////
                                string mensagem = "UPDATE aluno SET mensalidade = 'null', responsavel_rg = '" + responsavel_rg + "' WHERE rg = '" + aluno_rg+ "'";
                                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                                try
                                {
                                    conexao.Close();
                                }
                                catch { }
                                //conectar com o banco
                                conexao.Open();

                                //executar comando
                                cmd.ExecuteNonQuery();
                                //desconectar
                                conexao.Close();
                               

                                //////////////////
                            }
                        }
                        else
                        {
                            aluno_atualizar("nao");
                        }
                    }
                    else { MessageBox.Show("Aluno não está cadastrado"); }


                }

                else if (desejado == "DELETAR")
                {
                    try
                    {
                        string verifica = "SELECT rg, responsavel_rg, nome_aluno FROM aluno WHERE rg = '" + aluno_rg + "'";
                        MySqlCommand cmd = new MySqlCommand(verifica, conexao);
                        BlockInput(true);
                        //conectar com o banco
                        try
                        {
                            conexao.Close();
                        }
                        catch { }
                        conexao.Open();


                        //executar comando                
                        cmd.ExecuteNonQuery();

                        conexao.Close();
                        adapter = new MySqlDataAdapter(cmd);
                        DataTable tabela_retorno = new DataTable();
                        adapter.Fill(tabela_retorno);
                        try
                        {
                            this.aluno_rg = tabela_retorno.Rows[0][0].ToString();
                            this.responsavel_rg = tabela_retorno.Rows[0][1].ToString();
                            this.nome_da_foto_que_nao_apagou = tabela_retorno.Rows[0][2].ToString();
                            
                        }
                        catch { }
                        apagar_registro(aluno_rg, responsavel_rg);

                    }
                    catch { MessageBox.Show("Este registro não foi excluído porque ele não existe."); }
                }

                else if (desejado == "BUSCAR")
                {
                    Buscar_informacoes(this.aluno_rg);
                }
                BlockInput(false);
            
        }

        private string nome_da_foto_que_nao_apagou;
        public string GetNomeFoto()
        {
            return nome_da_foto_que_nao_apagou;
        }
       
        
        
    }

}
