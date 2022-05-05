using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace CidadeMySql
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader rConsulta;
        string strConexao = "server=br536.hostgator.com.br;uid=dsetec86_aula;pwd=etecjau;database=dsetec86_bd_xamarin";

        public async void Incluir()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("insert into cidades (nome, uf) " +
                                                       "values (@nome, @uf)", conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@uf", uf);
                comando.ExecuteNonQuery();
                conexao.Close();
                await App.Current.MainPage.DisplayAlert("Inclusão", "Cidade incluida com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void Consultar()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("select * from cidades where id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                rConsulta = comando.ExecuteReader();
                if (rConsulta.Read())
                {
                    nome = rConsulta["NOME"].ToString();
                    uf = rConsulta["UF"].ToString();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Consulta", "Cidade não encontrada!", "OK");
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void Atualizar()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("update cidades set nome = @nome, @uf = uf " +
                    "where id = @id", conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@uf", uf);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                conexao.Close();
                await App.Current.MainPage.DisplayAlert("Alteração", "Cidade atualizada com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void Excluir()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("delete from cidades where id = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                conexao.Close();
                await App.Current.MainPage.DisplayAlert("Exclusão", "Cidade excluida com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
