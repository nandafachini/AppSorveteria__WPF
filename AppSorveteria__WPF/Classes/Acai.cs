using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSorveteria__WPF.Classes
{
    public class Acai
    {
        private int id;
        private string tamanho;
        private string fruta;
        private string complemento;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        public string Fruta
        {
            get { return fruta; }
            set { fruta = value; }
        }

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public Acai()
        {

        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
