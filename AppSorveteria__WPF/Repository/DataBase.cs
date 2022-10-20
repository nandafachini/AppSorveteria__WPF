using AppSorveteria__WPF.Classes;
using AppSorveteria__WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSorveteria__WPF.Repository
{
    public class DataBase
    {
        private IDatabase database;

        public DataBase(IDatabase novoDataBase)
        {
            database = novoDataBase;
        }

        public IEnumerable<Acai> BuscaAcai()
        {
            return database.BuscaAcai();
        }



        public void AdicionarAcai(Acai acai)
        {
            if (ValidaAcai(acai) == false)
            {
                throw new ArgumentException("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.");
            }
            else
            {
                database.AdicionarAcai(acai);
            }
        }



        public void ExcluirAcai(Acai acai)
        {
            if (acai != null)
            {
                database.ExcluirAcai(acai);
            }
            else
            {
                throw new ArgumentException("Nenhum acai selecionado!");
            }

        }



        public void AtualizarAcai(Acai acai)
        {
            if (acai != null)
            {
                if (ValidaAcai(acai) == false)
                {
                    throw new ArgumentException("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.");
                }
                else
                {
                    database.AtualizarAcai(acai);
                }
            }
            else
            {
                throw new ArgumentException("Nenhum acai selecionado!");
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