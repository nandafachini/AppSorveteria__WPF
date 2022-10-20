using AppSorveteria__WPF.Classes;
using AppSorveteria__WPF.Interfaces;
/*using MySql.Data.MySqlClient;*/
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppSorveteria__WPF.Repository
{
    internal class PGsqlDb : IDatabase
    {
        private static string _host;

        private static string _port;

        private static string _user;

        private static string _password;

        private static string _dbname;

        private string _query;

        public PGsqlDb() { }

        private string _strConnect()
        {
            _host = "localhost";

            _port = "5432";

            _user = "postgres";

            _password = "mysecretpassword";

            _dbname = "postgres";

            return $"Server={_host};Username={_user};Database={_dbname};Port={_port};Password={_password};";
        }



        /* Busco o açaí e seus dados no banco */
        public IEnumerable<Acai> BuscaAcai()
        {
            _query = @"SELECT * FROM acai;";

            using (NpgsqlConnection con = new NpgsqlConnection(_strConnect()))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(_query, con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Acai()
                            {
                                Id = reader.GetInt32(0),
                                Tamanho = reader.GetString(1),
                                Fruta = reader.GetString(2),
                                Complemento = reader.GetString(3),
                            };

                        }
                    }
                }
            }
        }


        /* Adiciono um novo açaí no banco */
        public void AdicionarAcai(Acai acai)
        {
            if (ValidaAcai(acai) == false)
            {
                MessageBox.Show("Os parâmetros do objeto açaí não podem ser nulos");

            } else { 

                _query = $@"INSERT INTO acai(tamanho, fruta, complemento)
                    VALUES
                    ('{acai.Tamanho}', '{acai.Fruta}', '{acai.Complemento}')";

                _ExecuteQuery(_query);

            }

        }


        /* Excluo meu açaí no banco */
        public void ExcluirAcai(Acai acai)
        {
            _query = $@"DELETE
                FROM acai
                WHERE id = '{acai.Id}'";

            _ExecuteQuery(_query);
        }


        /* Atualizo os dados do meu açaí no banco */
        public void AtualizarAcai(Acai acai)
        {
            _query = $@"UPDATE
                acai
                SET tamanho = '{acai.Tamanho}', fruta = '{acai.Fruta}', complemento = '{acai.Complemento}'
                WHERE id = '{acai.Id}'";

            _ExecuteQuery(_query);
        }

        private void _ExecuteQuery(string query)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(_strConnect()))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ValidaAcai(Acai acai)
        {
            if (acai == null || acai.Tamanho.Length == 0 || acai.Fruta.Length == 0 || acai.Complemento.Length == 0)
            {
                return false;
            }
            else 
            { 
            return true;
            }
        }
    }
}
