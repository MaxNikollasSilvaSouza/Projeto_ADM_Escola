
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

namespace Projeto_Administrativo
{
    public class FuncionarioCRUD 
    {


        [DllImport("user32.dll")]
        static extern bool BlockInput(bool fBlockIt);
        private static Timer _timer = new Timer();

        static FuncionarioCRUD()
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

         private string Nome_Pessoa_Logada;
        private string Data_Pessoa_logada = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

        private string local_conexao = "server=localhost;user=root;database=mydb";
        MySqlConnection conexao;
        private MySqlDataAdapter adapter;

        private bool tem_foto = false;
        private string Imagem_Diretorio;
        private string quando_atualizou;
        private string quem_atualizou;
        private string quem_registro;
        private string quando_registro;
        private string sexo;
        private string nome;
        private string pcd;
        private string carteira_de_trabalho;
        private string sigla;
        private string telefone;
        private string cpf;
        private string pis;
        private string email;
        private string rg;
    
        private string endereco;
        private string numero;
        private string cep;
        private string complemento;
        private string nascimento;
        private string agencia;
        private string n_conta;
        private string banco;
        private string funcao;
        private string setor;
        private string usuario;
        private string senha;
    
   
        private string salario;        
        

        private String[] motivo = new String[50];
        private String[] quem_fez_ocorrencia = new String[50];
        private String[] descricao = new String[50];

        private String[] beneficio = new String[50];
        private String[] valor_beneficio = new String[50];

        private String[] dia_semana = new String[50];
        private String[] inicio_expediente = new String[50];                 
        private String[] termino_expediente = new String[50];
        private String[] inicio_intervalo = new String[50];
        private String[] termino_intervalo = new String[50];

        int contador_expediente = 0;       
        private int contador_ocorrencia = 0;
        private int contador_beneficio = 0;

        bool nova_ocorrencia = false;


        public FuncionarioCRUD(string quem_esta_logado)
        {
            conexao = new MySqlConnection(local_conexao);
            this.Nome_Pessoa_Logada = quem_esta_logado;
        }

        public void setar_foto_false()
        {
            tem_foto = false;
        }
        public void diretorio_imagem(string diretorio)
        {
            this.Imagem_Diretorio = diretorio;
            this.tem_foto = true;
        }

        public void setar_parte1(string nome_funcionario,string cpf,string pdc,string n_carteira,string sigla,string telefones,string email,string rg,string endereco,string numero_endereco,string cep,string complemento,string nascimento,string funcao,string setor,string sexo)
        {
            this.nome = nome_funcionario; this.cpf = cpf; this.pcd = pdc; this.carteira_de_trabalho = n_carteira; this.sigla = sigla; this.telefone = telefones; this.email = email; this.rg = rg; this.endereco = endereco; this.numero = numero_endereco; this.cep = cep; this.complemento = complemento; this.nascimento = nascimento; this.funcao = funcao; this.setor = setor; this.sexo = sexo;
        }

        public void setar_parte2(string pis,string agencia,string n_conta,string banco,string salario)
        {
            this.pis = pis; this.agencia = agencia; this.n_conta = n_conta; this.banco = banco; this.salario = salario;
        }

        public void setar_parte3(string login, string senha)
        {
            this.usuario = login; this.senha = senha; 
        }

        
        /// //////////##################  CADASTRO  #########################/////////////////


        private void cadastrar_funcionario_parte1()////#PRIMEIRA PARTE, TABELA funcionario#////
        {
            BlockInput(true);
            

                if (tem_foto == true)
                {
                    Mover_foto(Imagem_Diretorio, this.rg);
                    tem_foto = false;
                }
                string mensagem = "INSERT INTO funcionario (nome_funcionario, cpf, pdc, n_carteira, sigla, telefones, email, rg, endereco, numero_endereco, cep, complemento, nascimento, funcao, setor, sexo, quem_registro, quando_registro) values ( @nome_funcionario, @cpf, @pdc, @n_carteira, @sigla, @telefones, @email, @rg, @endereco, @numero_endereco, @cep, @complemento, @nascimento, @funcao, @setor, @sexo, @quem_registro, @quando_registro)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                try
                {

                    //conectar com o banco
                    conexao.Open();


                    //executar comando
                    //executar 1 por 1 para identificar o erro... proxima vez que for mexer

                    cmd.Parameters.AddWithValue("@nome_funcionario", this.nome);
                    cmd.Parameters.AddWithValue("@cpf", this.cpf);
                    cmd.Parameters.AddWithValue("@pdc", this.pcd);
                    cmd.Parameters.AddWithValue("@n_carteira", this.carteira_de_trabalho);
                    cmd.Parameters.AddWithValue("@sigla", this.sigla);
                    cmd.Parameters.AddWithValue("@telefones", this.telefone);
                    cmd.Parameters.AddWithValue("@email", this.email);                 
                    cmd.Parameters.AddWithValue("@rg", this.rg);
                    cmd.Parameters.AddWithValue("@endereco", this.endereco);
                    cmd.Parameters.AddWithValue("@numero_endereco", this.numero);
                    cmd.Parameters.AddWithValue("@cep", this.cep);
                    cmd.Parameters.AddWithValue("@complemento", this.complemento);
                    cmd.Parameters.AddWithValue("@nascimento", this.nascimento);
                    cmd.Parameters.AddWithValue("@funcao", this.funcao);
                    cmd.Parameters.AddWithValue("@setor", this.setor);
                    cmd.Parameters.AddWithValue("@sexo", this.sexo);
                    cmd.Parameters.AddWithValue("@quem_registro", this.Nome_Pessoa_Logada);
                    cmd.Parameters.AddWithValue("@quando_registro", this.Data_Pessoa_logada);
                    cmd.ExecuteNonQuery();
                    //desconectar
                    conexao.Close();

                    cadastrar_funcionario_parte2();
                    cadastrar_funcionario_parte3();

                    //if (this.contador_ocorrencia > 0)
                    //{
                    //    cadastrar_funcionario_parte4();
                    //}
                    cadastrar_funcionario_parte5();
                    cadastrar_funcionario_parte6();

                    BlockInput(false);
                    System.Windows.Forms.MessageBox.Show("Funcionário cadastrado com sucesso!");

                }
                catch(Exception e)
                {
                    conexao.Close();
                    BlockInput(false);
                    erro(e.ToString(), "parte 1 de cadastro");
                    File.Delete(@"C:\\Foto\\" + nome + ".jpg");
                }
           



        }

        private void cadastrar_funcionario_parte2()////#SEGUNDA PARTE, TABELA funcionario_financa#////
        {
            try
            {
                string mensagem = "INSERT INTO funcionario_financa (pis, agencia, n_conta, banco, salario, funcionario_rg) values(@pis, @agencia, @n_conta, @banco, @salario, @funcionario_rg)";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                conexao.Open();

                cmd.Parameters.AddWithValue("@pis", this.pis);
                //cmd.Parameters.AddWithValue("@caixa_fgts", this.caixa_fgts);
                cmd.Parameters.AddWithValue("@agencia", this.agencia);
                cmd.Parameters.AddWithValue("@n_conta", this.n_conta);
                cmd.Parameters.AddWithValue("@banco", this.banco);
                cmd.Parameters.AddWithValue("@salario", this.salario);
                cmd.Parameters.AddWithValue("@funcionario_rg", this.rg);
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch(Exception e)
            {
                erro(e.ToString(), "parte 2 de cadastro");
            }

        }

        private void cadastrar_funcionario_parte3()////#TERCEIRA PARTE, TABELA info_trab alho#////
        {
            try
            {
               
                    for (int i = 0; i < contador_expediente; i++)
                    {
                        string mensagem = "INSERT INTO info_trabalho (entrada, saida, dia_semana, inicio_intervalo, fim_intervalo, funcionario_rg) values (@entrada, @saida, @dia_semana, @inicio_intervalo, @fim_intervalo, @funcionario_rg)";
                        MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                        try
                        {

                            conexao.Close();
                        }
                        catch { }
                        conexao.Open();


                        cmd.Parameters.AddWithValue("@entrada", this.inicio_expediente[i]);
                        cmd.Parameters.AddWithValue("@saida", this.termino_expediente[i]);
                        cmd.Parameters.AddWithValue("@dia_semana", this.dia_semana[i]);
                        cmd.Parameters.AddWithValue("@inicio_intervalo", this.inicio_intervalo[i]);
                        cmd.Parameters.AddWithValue("@fim_intervalo", this.termino_intervalo[i]);
                        cmd.Parameters.AddWithValue("@funcionario_rg", this.rg);
                        cmd.ExecuteNonQuery();

                        conexao.Close();
                    }
               
            }
            catch (Exception e) { erro(e.ToString(), "parte 3 de cadastro"); }

        }

        private void cadastrar_funcionario_parte4()////#QUARTA PARTE, TABELA ocorrencias_func#////
        {
            try
            {
                for (int i = 0; i < contador_ocorrencia; i++)
                {
            string mensagem = "INSERT INTO ocorrencias_func (motivo, registrado, descricao, funcionario_rg) values (@motivo, @registrado, @descricao, @funcionario_rg)";

            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
           
                conexao.Open();
                
                    cmd.Parameters.AddWithValue("@motivo", this.motivo[i]);
                    cmd.Parameters.AddWithValue("@registrado", this.quem_fez_ocorrencia[i]);
                    cmd.Parameters.AddWithValue("@descricao", this.descricao[i]);
                    cmd.Parameters.AddWithValue("@funcionario_rg", this.rg);
                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
            catch (Exception e) { erro(e.ToString(), "parte 4 de cadastro"); }
        }

        private void cadastrar_funcionario_parte5()////#QUINTA PARTE, TABELA login#////
        {
            string mensagem = "INSERT INTO login (usuario, senha, funcionario_rg) values (@usuario, @senha, @funcionario_rg)";

            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
            try
            {
                try
                {
                    conexao.Close();
                }

                catch { }
                conexao.Open();
                
                    cmd.Parameters.AddWithValue("@usuario", this.usuario);
                    cmd.Parameters.AddWithValue("@senha", this.senha);
                    cmd.Parameters.AddWithValue("@funcionario_rg", this.rg);
                    cmd.ExecuteNonQuery();
                
                conexao.Close();
            }
            catch (Exception e) { erro(e.ToString(), "parte 5 de cadastro"); }
        }

        private void cadastrar_funcionario_parte6() //#SEXTA PARTE, TABELA beneficio#////
        {
            try
            {
                for (int i = 0; i < contador_beneficio; i++)
                {
                    string mensagem = "INSERT INTO beneficios (descricao_benefio, valor, funcionario_rg) values (@descricao_benefio, @valor, @funcionario_rg)";

                    MySqlCommand cmd = new MySqlCommand(mensagem, conexao);

                    try
                    {
                        conexao.Close();
                    }

                    catch { }
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@descricao_benefio", this.beneficio[i]);
                    cmd.Parameters.AddWithValue("@valor", this.valor_beneficio[i]);
                    cmd.Parameters.AddWithValue("@funcionario_rg", this.rg);                    
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }
               
            }
            catch (Exception e) { erro(e.ToString(), "parte 6 de cadastro"); }
        }

        /// //////////##################  ATUALIZAÇÃO  #########################/////////////////

        private void atualizar_funcionario_parte1()////#PRIMEIRA PARTE, TABELA funcionario#////
        {
            if (tem_foto == true)
            {
                Mover_foto(Imagem_Diretorio, this.rg);
                tem_foto = false;
            }
            string mensagem = "UPDATE funcionario SET pdc ='" + this.pcd + "', telefones = '" + this.telefone + "', email = '"+ this.email + "', endereco = '" + this.endereco + "', numero_endereco = '" + this.numero + "', cep = '" + this.cep + "', complemento = '" + this.complemento + "', funcao = '" + this.funcao + "', setor ='" + this.setor + "' , quem_atualizou = '" + this.Nome_Pessoa_Logada + "', quando_atualizou ='" + this.Data_Pessoa_logada + "' WHERE funcionario_rg ='" + this.rg + "' ";

            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
            try
            {
                BlockInput(true);
                //conectar com o banco
                conexao.Open();


                //executar comando                    
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Close();
                atualizar_funcionario_parte2();
                atualizar_funcionario_parte3();

                if (this.contador_ocorrencia > 0)
                {
                    cadastrar_funcionario_parte4();
                }
                atualizar_funcionario_parte4();
                
                BlockInput(false);
                MessageBox.Show("Regiastro atualizado com sucesso!");

            }
            catch (Exception e)
            {
                BlockInput(false);
                erro(e.ToString(), "parte 1 do atualizar");
            }
        
        
        
        
        
        }

        private void atualizar_funcionario_parte2()////#SEGUNDA PARTE, TABELA funcionario_financa#////
        {
            string mensagem = "UPDATE funcionario_financa SET agencia = '" + this.agencia + "', n_conta = '" + this.n_conta + "', banco = '" + this.banco + "', salario ='" + this.salario + "', funcionario_rg ='" + this.rg + "' ";


            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
            try
            {
                BlockInput(true);
                //conectar com o banco
                conexao.Open();


                //executar comando                    
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Close();

                BlockInput(false);
               

            }
            catch (Exception e)
            {
                BlockInput(false);
                erro(e.ToString(), "parte 2 do atualizar");
            }
        }

        private void atualizar_funcionario_parte3()////#TERCEIRA PARTE, TABELA info_trabalho E  beneficios#////
        {
            string mensagem = "DELETE FROM beneficios WHERE funcionario_rg = '" + this.rg + "' ";
            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);

            string mensagem2 = "DELETE FROM info_trabalho WHERE funcionario_rg = '" + this.rg + "' ";
            MySqlCommand cmd2 = new MySqlCommand(mensagem, conexao);
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
                cmd2.ExecuteNonQuery();
                //desconectar
                conexao.Close();
                cadastrar_funcionario_parte3();
                cadastrar_funcionario_parte6();
                BlockInput(false);
                 

            }
            catch (Exception e)
            {
                BlockInput(false);
                System.Windows.Forms.MessageBox.Show("Devido a algum erro não foi possível atualizar o registro!\n " + e);
            }
        }

        private void atualizar_funcionario_parte4()////#TERCEIRA PARTE, TABELA login#////
        {
            string mensagem = "UPDATE login SET usuario = '" + this.usuario + "', senha = '" + this.senha + "' WHERE funcionario_rg = '" + this.rg + "' ";
            MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
            try
            {
                BlockInput(true);
                //conectar com o banco
                conexao.Open();


                //executar comando                    
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Close();

                BlockInput(false);
            

            }
            catch (Exception e)
            {
                BlockInput(false);
                System.Windows.Forms.MessageBox.Show("Devido a algum erro não foi possível atualizar o registro!\n " + e);
            }
        }


        /// //////////##################  DELETAR REGISTRO  #########################/////////////////

        private void apagar_registro(string rg)
        {
            


                string mensagem1 = "DELETE FROM funcionario WHERE rg = '" + this.rg + "' ";
                string mensagem2 = "DELETE FROM funcionario_financa WHERE funcionario_rg = '" + this.rg + "' ";
                string mensagem3 = "DELETE FROM info_trabalho WHERE funcionario_rg = '" + this.rg + "' ";
                string mensagem4 = "DELETE FROM login WHERE funcionario_rg = '" + this.rg + "' ";
                string mensagem5 = "DELETE FROM ocorrencias_func WHERE funcionario_rg = '" + this.rg + "' ";
                string mensagem6 = "DELETE FROM beneficios WHERE funcionario_rg = '" + this.rg + "' ";

                MySqlCommand delete1 = new MySqlCommand(mensagem1, conexao);
                MySqlCommand delete2 = new MySqlCommand(mensagem2, conexao);
                MySqlCommand delete3 = new MySqlCommand(mensagem3, conexao);
                MySqlCommand delete4 = new MySqlCommand(mensagem4, conexao);
                MySqlCommand delete5 = new MySqlCommand(mensagem5, conexao);
                MySqlCommand delete6 = new MySqlCommand(mensagem6, conexao);
                try
                {

                    try
                    {
                        conexao.Close();
                    }
                    catch { }

                    //conectar com o banco
                    conexao.Open();

                    delete6.ExecuteNonQuery();
                    delete5.ExecuteNonQuery();
                    delete4.ExecuteNonQuery();
                    delete3.ExecuteNonQuery();
                    delete2.ExecuteNonQuery();
                    delete1.ExecuteNonQuery();
                    
                   
                    //desconectar
                    conexao.Close();
                    System.Windows.Forms.MessageBox.Show("Registro excluido com sucesso!");
                    
                }
                catch(Exception e)
                {
                    erro(e.ToString(), "parte de apagar registro");
                }
            


        }

        /// //////////##################  BUSCAR INFORMAÇÕES  #########################/////////////////

        private void buscar_informacoes_parte1(string rg)//PARTE 1  ####  tabela funcionario    #########////
        {
            
                string mensagem = "SELECT funcionario.nome_funcionario, funcionario.cpf, funcionario.pdc, funcionario.n_carteira, funcionario.sigla, funcionario.telefones, funcionario.email, funcionario.rg, funcionario.endereco, funcionario.numero_endereco, funcionario.cep, funcionario.complemento, funcionario.nascimento, funcionario.funcao, funcionario.setor, funcionario.sexo FROM funcionario WHERE funcionario.rg = '" + this.rg + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                MySqlDataAdapter adapter;
                try
                {
                    DataTable tabela_retorno = new DataTable();
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    
                    //desconectar
                    conexao.Close();
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabela_retorno);
                    //falta inserir os dados do setar
 ///////////////////////////////////////////////////////## PRECISA FAZER O SETAR#//////////////////
                    setar_parte1(tabela_retorno.Rows[0][0].ToString(), tabela_retorno.Rows[0][1].ToString(), tabela_retorno.Rows[0][2].ToString(), tabela_retorno.Rows[0][3].ToString(), tabela_retorno.Rows[0][4].ToString(), tabela_retorno.Rows[0][5].ToString(), tabela_retorno.Rows[0][6].ToString(), tabela_retorno.Rows[0][7].ToString(), tabela_retorno.Rows[0][8].ToString(), tabela_retorno.Rows[0][9].ToString(), tabela_retorno.Rows[0][10].ToString(), tabela_retorno.Rows[0][11].ToString(), tabela_retorno.Rows[0][12].ToString(), tabela_retorno.Rows[0][13].ToString(), tabela_retorno.Rows[0][14].ToString(), tabela_retorno.Rows[0][15].ToString());
                    buscar_informacoes_parte2(rg);  
                    buscar_informacoes_parte3(rg);
                    buscar_informacoes_parte4(rg);

                }
                catch (Exception e)
                {
                    erro(e.ToString(), "parte 1 de buscar funcionario");
                }
            

            
        }

        private void buscar_informacoes_parte2(string rg)//PARTE 2 ########  tabela login   ################////
        {
            
                //string mensagem = "SELECT  pis, agencia, n_conta, banco, salario FROM funcionario_financa WHERE funcionario_rg = '" + this.rg + "' ";
                //MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                //MySqlDataAdapter adapter;
                string mensagem2 = "SELECT usuario, senha  FROM  login WHERE funcionario_rg = '" + this.rg + "' ";
                MySqlCommand cmd2 = new MySqlCommand(mensagem2, conexao);
                DataTable tabela = new DataTable();
                try
                {
                   // DataTable tabela_retorno = new DataTable();
                    //conectar com o banco
                    try
                    {
                        conexao.Close();
                    }
                    catch { }
                    conexao.Open();
                    //cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    //desconectar
                    conexao.Close();
                    //adapter = new MySqlDataAdapter(cmd);
                   
                    //adapter.Fill(tabela_retorno);

                    adapter = new MySqlDataAdapter(cmd2);
                    adapter.Fill(tabela);
                   // setar_parte2(tabela_retorno.Rows[0][0].ToString(), tabela_retorno.Rows[0][1].ToString(), tabela_retorno.Rows[0][2].ToString(), tabela_retorno.Rows[0][3].ToString(), tabela_retorno.Rows[0][4].ToString());

                  
                    try
                    {
                        setar_parte3(tabela.Rows[0][0].ToString(), tabela.Rows[0][1].ToString());
                    }
                    catch { MessageBox.Show("Login e senha de funcionário não existe."); }
                  

                }
                catch(Exception e)
                {
                    erro(e.ToString(), "parte 2 de buscar funcionario");
                }
            
        }

        private void buscar_informacoes_parte3(string rg)//PARTE 3 ########  tabela info_trabalho e beneficios ################////
        {
            remover_expediente("ss");
            remover_beneficios("ss", "ss");

            

            try
            {

                string mensagem = "select  entrada, saida, dia_semana, inicio_intervalo, fim_intervalo from info_trabalho where funcionario_rg = '" + this.rg + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                MySqlDataAdapter adapter;

                DataTable tabela_retorno = new DataTable();
                //conectar com o banco
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                cmd.ExecuteNonQuery();
            
                //desconectar
                conexao.Close();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabela_retorno);
                //falta inserir os dados do setar
                for (int i = 0; i < tabela_retorno.Rows.Count ; i++)
                {
                    adicionar_expediente(tabela_retorno.Rows[i][2].ToString(), tabela_retorno.Rows[i][0].ToString(), tabela_retorno.Rows[i][3].ToString(), tabela_retorno.Rows[i][4].ToString(), tabela_retorno.Rows[i][1].ToString());
                }
               
                


            }
            catch (Exception e)
            {
                erro(e.ToString(), "parte 3 de buscar funcionario => expediente");
            }

            

            try
            {

                string mensagem = "select  descricao_benefio, valor from beneficios where funcionario_rg = '" + this.rg + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                MySqlDataAdapter adapter;

                DataTable tabela_retorno = new DataTable();
                //conectar com o banco
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                cmd.ExecuteNonQuery();

                //desconectar
                conexao.Close();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabela_retorno);
                //falta inserir os dados do setar
                for (int i = 0; i < tabela_retorno.Rows.Count; i++)
                {
                    adicionar_beneficios(tabela_retorno.Rows[i][0].ToString(), tabela_retorno.Rows[i][1].ToString());
                }

                



            }
            catch (Exception e)
            {
                erro(e.ToString(), "parte 3 de buscar funcionario => benefício");
            }


        }

        private void buscar_informacoes_parte4(string rg)//PARTE 4  ####  tabela funcionario_financa    #########////
        {
            try
            {

                string mensagem = "select  pis, agencia, n_conta, banco, salario from funcionario_financa where funcionario_rg = '" + this.rg + "' ";
                MySqlCommand cmd = new MySqlCommand(mensagem, conexao);
                MySqlDataAdapter adapter;

                DataTable tabela_retorno = new DataTable();
                //conectar com o banco
                try
                {
                    conexao.Close();
                }
                catch { }
                conexao.Open();
                cmd.ExecuteNonQuery();

                //desconectar
                conexao.Close();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabela_retorno);
                //falta inserir os dados do setar
                setar_parte2(tabela_retorno.Rows[0][0].ToString(), tabela_retorno.Rows[0][1].ToString(), tabela_retorno.Rows[0][2].ToString(), tabela_retorno.Rows[0][3].ToString(), tabela_retorno.Rows[0][4].ToString());

                ///////////////////////////////////////////////////////## PRECISA FAZER O SETAR#//////////////////



            }
            catch (Exception e)
            {
                erro(e.ToString(), "parte 4 de buscar funcionario");
            }
        }
        
        
        
        /// //////////##################  FOTO  #########################/////////////////

        


       
        
        /// <param name="diretorio_imagem"></param>


        private void Mover_foto(string diretorio_imagem, string nome)
        {

            try
            {

                if (!Directory.Exists(@"C:\\Foto"))
                {
                    Directory.CreateDirectory(@"C:\\Foto");
                }
                if (File.Exists(@"C:\\Foto\\" + nome+ ".jpg"))
                {
                    File.Delete(@"C:\\Foto\\" + nome + ".jpg");
                }
                File.Move(diretorio_imagem, @"C:\\Foto\\" + nome+ ".jpg");
                //this.Diretorio_salvar = "C:\\Foto\\" + nome + ".jpg";
                
            }

            catch (Exception e)
            {
                File.Delete(@"C:\\Foto\\" + nome + ".jpg");
                this.tem_foto = false;
                erro(e.ToString(), "parte de mover a foto");
            }
        }

        /// //////////##################  OCORRENCIA  #########################/////////////////

        public void adicionar_ocorrencia(string motivo_ocorrencia, string quem_registrou, string descreva_ocorrencia)
        {
            motivo[contador_ocorrencia] = motivo_ocorrencia;
            quem_fez_ocorrencia[contador_ocorrencia] = quem_registrou;
            descricao[contador_ocorrencia] = descreva_ocorrencia;
            contador_ocorrencia += 1;
            nova_ocorrencia = true;
        }

        public void limpar_ocorrencia_nao_salva()
        {
            for (int i = 0; i < 50; i++)
            {
                motivo[i] = null;
                quem_fez_ocorrencia[i] = null;
                descricao[i] = null;
            }
            contador_ocorrencia = 0;
            nova_ocorrencia = false;
        }

        /// //////////##################  BENEFICIOS  #########################/////////////////

        public void adicionar_beneficios(string beneficio_, string valor_)
        {
            beneficio[contador_beneficio] = beneficio_;
            valor_beneficio[contador_beneficio] = valor_;
            contador_beneficio += 1;

        }
        public void remover_beneficios(string beneficio_, string valor_)
        {
            if (beneficio_ == "ss" && valor_ == "ss")
            {
                for (int i = 0; i < 50; i++)
                {
                    beneficio[i] = null;
                    valor_beneficio[i] = null;                    
                }
                contador_beneficio = 0;
            }
            else
            {
                contador_beneficio -= 1;
                beneficio[contador_beneficio] = null;
                valor_beneficio[contador_beneficio] = null;                
            }
        }

        /// //////////##################  EXPEDIENTES  #########################/////////////////

        public void adicionar_expediente(string dia, string inicioE, string comeco_intervalo, string fim_intervalo, string fimE)
        {
            dia_semana[contador_expediente] = dia;
            inicio_expediente[contador_expediente] = inicioE;//aqui é a entrada          
            inicio_intervalo[contador_expediente] = comeco_intervalo;//aqui é o inicio do intervalo 
            termino_intervalo[contador_expediente] = fim_intervalo;//aqui é o fim do intervalo            
            termino_expediente[contador_expediente] = fimE;//aqui é a saida

            contador_expediente += 1;

        }

        public void remover_expediente(string dia)
        {
            if (dia == "ss")
            {
                for (int i = 0; i < 50; i++)
                {
                    dia_semana[i] = null;
                    inicio_expediente[i] = null;                  
                    inicio_intervalo[i] = null;
                    termino_intervalo[i] = null;
                    termino_expediente[i] = null;
                   

                    
                }
                contador_expediente = 0;
            }
            else
            {
                contador_expediente -=1;

                dia_semana[contador_expediente] = null;
                inicio_expediente[contador_expediente] = null;
                inicio_intervalo[contador_expediente] = null;
                termino_intervalo[contador_expediente] = null;
                termino_expediente[contador_expediente] = null;
            }
        }

      
        
        /// <summary>
        /// /////////////////////////######### PEGAR VALOR E RETORNAR #################################
        /// </summary>
        /// #################### PEGAR VALOR DA TABELA FUNCIONARIO ####################################
        public string get_Nome {get{return nome;}}
        public string get_CPF {get{return cpf;}}
        public string get_PCD {get {return pcd;}}
        public string get_n_carteira {get {return carteira_de_trabalho;}}
        public string get_sigla {get {return sigla;}}
        public string get_telefones {get {return telefone;}}
        public string get_email {get {return email;}}
        public string get_rg {get {return rg;}}
        public string get_endereco {get {return endereco;}}
        public string get_numero_endereco {get {return numero;}}
        public string get_cep  {get {return cep;}}
        public string get_complemento {get {return complemento ;}}
        public string get_nascimento {get {return nascimento;}}
        public string get_funcao {get {return funcao;}}
        public string get_setor {get {return setor;}}
        public string get_sexo {get {return sexo;}}
        public string get_quem_registro {get {return quem_registro ;}}
        public string get_quando_registro {get {return quando_registro;}}
        public string get_quem_atualizou { get { return quem_atualizou; } }
        public string get_quando_atualizou {get {return quando_atualizou;}}

        /// #################### PEGAR VALOR DA TABELA FUNCIONARIO_FINANCA ####################################

        public string get_pis { get { return pis; } }
        public string get_agencia { get { return agencia; } }
        public string get_n_conta { get{return n_conta;}}
        public string get_banco {get {return banco;}}
        public string get_salario { get { return salario; } }

        /// #################### PEGAR VALOR DA TABELA LOGIN ####################################
        public string get_login { get { return usuario; } }
        public string get_senha { get { return senha; } }

        /// #################### PEGAR VALOR DA TABELA BENEFICIOS ####################################
        public int get_contador_beneficios { get { return contador_beneficio; } }
        public string get_beneficios_descricao(int indice)
        {
            return beneficio[indice];
        }
        public string get_beneficios_valor(int indice)
        {
            return valor_beneficio[indice];
        }

        /// #################### PEGAR VALOR DA TABELA INFO TRABALHO ####################################
        public int get_contador_expediente { get { return contador_expediente; } }
        public string get_expediente_entrada(int indice)
        {
            return inicio_expediente[indice];
        }
        public string get_expediente_inicio_intervalo(int indice)
        {
            return inicio_intervalo[indice];
        }
        public string get_expediente_termino_intervalo(int indice)
        {
            return termino_intervalo[indice];
        }
        public string get_expediente_termino(int indice)
        {
            return termino_expediente[indice];
        }
        public string get_expediente_dia(int indice)
        {
            return dia_semana[indice];
        }


        /// <summary>
        /// ////////############################ CHECAGEM DE DADOS ################################3
        /// </summary>
        private string checagem;
        private bool Funcionario_cadastrado;
        public void Checagem(string desejado)
        {
            BlockInput(true);
            try
            {
                string verifica = "SELECT rg FROM funcionario WHERE rg = '" + rg + "'";
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
                    checagem = tabela_retorno.Rows[0][0].ToString();
                }
                catch { }
                if (checagem != "" && checagem != null)
                {
                    Funcionario_cadastrado = true;
                }
                else
                {
                    Funcionario_cadastrado = false;
                }
            }
            catch { }

            

            if (desejado == "CADASTRAR")
            {
                if (Funcionario_cadastrado == false)
                {

                    cadastrar_funcionario_parte1();                    

                }
                else { MessageBox.Show("Funcionario já cadastrado"); }
                Funcionario_cadastrado = false;
             
                checagem = null;
                
            }

            else if (desejado == "ATUALIZAR")
            {
                if (Funcionario_cadastrado == true)
                {
                    atualizar_funcionario_parte1();
                }
                else { MessageBox.Show("Funcionario não está cadastrado"); }


            }

            else if (desejado == "DELETAR")
            {
                try
                {
                    string verifica = "SELECT rg,nome FROM aluno WHERE rg = '" + rg + "'";
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
                        this.rg = tabela_retorno.Rows[0][0].ToString();
                       
                        this.nome = tabela_retorno.Rows[0][1].ToString();
                        if (File.Exists(@"C:\\Foto\\" + this.rg + ".jpg"))
                        {
                            File.Delete(@"C:\\Foto\\" + this.rg + ".jpg");
                        }
                    }
                    catch { }
                    apagar_registro(rg);

                }
                catch { MessageBox.Show("Este registro não foi excluído porque ele não existe."); }
            }

            else if (desejado == "BUSCAR")
            {
                buscar_informacoes_parte1(rg);
              
            }
            BlockInput(false);

        }


        ////////################################ ERRO ########################################
        private void erro(string erro, string parte)
        {

            MessageBox.Show("Ocorreu um erro na " + parte + " pelo seguinte motivo: " + erro);
        }
    }
}
