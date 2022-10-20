using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSorveteria__WPF;
using AppSorveteria__WPF.Classes;
using AppSorveteria__WPF.Interfaces;
using AppSorveteria__WPF.Repository;
using Moq;

namespace AppSorveteria__WPFTest
{
    [TestClass]
    public class Acai_Teste_Integracao
    {

        private List<Acai> MockAcai()
        {
            List<Acai> output = new List<Acai>()
            {
                new Acai
                {
                    Id = 1,
                    Tamanho = "Grande",
                    Fruta = "Morango",
                    Complemento = "Granola"
                },

                new Acai
                {
                    Id = 2,
                    Tamanho = "Médio",
                    Fruta = "Banana",
                    Complemento = "Sucrilhos"
                }

            };

            return output;
        }

        [TestMethod]
        public void busca_acai_lista()
        {
            Mock<IDatabase> mockedDB = new Mock<IDatabase>();
            mockedDB.Setup(x => x.BuscaAcai()).Returns(MockAcai());

            DataBase conn = new DataBase(mockedDB.Object);

            ObservableCollection<Acai> listaAcai = new ObservableCollection<Acai>(conn.BuscaAcai());

            var expected = MockAcai();
            var actual = listaAcai;

            Assert.IsTrue(actual != null);
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Tamanho, actual[i].Tamanho);
                Assert.AreEqual(expected[i].Fruta, actual[i].Fruta);
                Assert.AreEqual(expected[i].Complemento, actual[i].Complemento);
            }

        }
    }
}