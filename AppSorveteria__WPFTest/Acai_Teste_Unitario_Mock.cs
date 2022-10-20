using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSorveteria__WPF.Classes;
using AppSorveteria__WPF.Interfaces;
using AppSorveteria__WPF.Repository;
using Autofac.Extras.Moq;
using Moq;


namespace AppSorveteria__WPFTest
{
    [TestClass]
    public class Acai_Teste_Unitario_Mock
    {
        private List<Acai> MockAcai()
        {
            List<Acai> output = new List<Acai>
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
        public void Busca_acai_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDatabase>()
                    .Setup(x => x.BuscaAcai())
                    .Returns(MockAcai());

                var cls = mock.Create<DataBase>();
                var expected = MockAcai().ToList();
                var actual = cls.BuscaAcai().ToList();

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

        [TestMethod]
        public void Adiciona_acai_com_dados_corretos_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = MockAcai()[0];
                mock.Mock<IDatabase>()
                    .Setup(x => x.AdicionarAcai(acai));

                var cls = mock.Create<DataBase>();

                cls.AdicionarAcai(acai);

                mock.Mock<IDatabase>()
                    .Verify(x => x.AdicionarAcai(acai), Times.Exactly(1));

            }
        }

        [TestMethod]
        public void Adiciona_acai_sem_dados_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Tamanho = "",
                    Fruta = "",
                    Complemento = "",
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AdicionarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Adiciona_acai_sem_tamanho_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 4,
                    Tamanho = "",
                    Fruta = "Banana",
                    Complemento = "Granola"
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AdicionarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Adiciona_acai_sem_fruta_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 5,
                    Tamanho = "Médio",
                    Fruta = "",
                    Complemento = "Sucrilhos"
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AdicionarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Adiciona_acai_sem_complemento_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 6,
                    Tamanho = "Melão",
                    Fruta = "Banana",
                    Complemento = ""
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AdicionarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Exclui_acai_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = MockAcai()[0];
                mock.Mock<IDatabase>()
                    .Setup(x => x.ExcluirAcai(acai));

                var cls = mock.Create<DataBase>();

                cls.ExcluirAcai(acai);

                mock.Mock<IDatabase>()
                    .Verify(x => x.ExcluirAcai(acai), Times.Exactly(1));

            }
        }

        [TestMethod]
        public void Atualiza_acai_test()
        {
            using (var mock = AutoMock.GetLoose())
            {

                var acai = MockAcai()[0];
                mock.Mock<IDatabase>()
                    .Setup(x => x.AtualizarAcai(acai));

                var cls = mock.Create<DataBase>();

                cls.AtualizarAcai(acai);

                mock.Mock<IDatabase>()
                    .Verify(x => x.AtualizarAcai(acai), Times.Exactly(1));

            }
        }

        [TestMethod]
        public void Atualiza_acai_para_sem_tamanho_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 7,
                    Tamanho = "",
                    Fruta = "Banana",
                    Complemento = "Granola"
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AtualizarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Atualiza_acai_para_sem_fruta_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 8,
                    Tamanho = "Grande",
                    Fruta = "",
                    Complemento = "Granola"
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AtualizarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public void Atualiza_acai_para_sem_complemento_test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var acai = new Acai()
                {
                    Id = 9,
                    Tamanho = "Grande",
                    Fruta = "Manga",
                    Complemento = ""
                };

                mock.Mock<IDatabase>()
                    .Setup(x => x.AtualizarAcai(acai));

                var cls = mock.Create<DataBase>();

                var exc = Assert.ThrowsException<ArgumentException>(() => cls.AdicionarAcai(acai));
                Assert.AreEqual("Os parâmetros Tamanho, Fruta e Complemento são obrigatórios.", exc.Message);

            }
        }

        [TestMethod]
        public bool Valida_acai_test()
        {
            using (var mock = AutoMock.GetLoose())
            {

                var acai = MockAcai()[0];
                mock.Mock<IDatabase>()
                    .Setup(x => x.ValidaAcai(acai));

                var cls = mock.Create<DataBase>();

                cls.ValidaAcai(acai);

                mock.Mock<IDatabase>()
                    .Verify(x => x.ValidaAcai(acai), Times.Exactly(1));
            }

            return true;
        }

    }
}
    
