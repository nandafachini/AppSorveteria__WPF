using AppSorveteria__WPF.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSorveteria__WPF.Interfaces
{
    public interface IDatabase
    {
        void AdicionarAcai(Acai acai);
        void ExcluirAcai(Acai acai);
        void AtualizarAcai(Acai acai);
        bool ValidaAcai(Acai acai);
        IEnumerable<Acai> BuscaAcai();
    }
}
