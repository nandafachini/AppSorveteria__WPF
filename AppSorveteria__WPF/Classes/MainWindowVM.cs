using AppSorveteria__WPF.Repository;
using AppSorveteria__WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppSorveteria__WPF.Classes
{
    public class MainWindowVM : INotifyPropertyChanged
    {

        public ObservableCollection<Acai> listaAcais { get; set; }
        public ICommand AddAcai { get; set; }
        public ICommand RemoveAcai { get; set; }
        public ICommand UpdateAcai { get; set; }

        private Acai _acaiSelecionado;

        private readonly PGsqlDb _conn;

        public MainWindowVM()
        {
            _conn = new PGsqlDb();
            try
            {
                listaAcais = new ObservableCollection<Acai>(_conn.BuscaAcai());
                Notifica();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                Application.Current.Shutdown();

            }


            IniciaComandos();
        }

        public Acai AcaiSelecionado
        {
            get { return _acaiSelecionado; }
            set { _acaiSelecionado = value; }

        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void Notifica(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void IniciaComandos()
        {
            AddAcai = new RelayCommand((object _) =>
            {
                Acai novoAcai = new Acai();
                CadastroAcai telaCadastroAcai = new CadastroAcai();
                telaCadastroAcai.DataContext = novoAcai;
                telaCadastroAcai.ShowDialog();

                try
                {
                    _conn.AdicionarAcai(novoAcai);
                    listaAcais = new ObservableCollection<Acai>(_conn.BuscaAcai());
                    Notifica();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            });


            RemoveAcai = new RelayCommand((object _) =>
            {
                try
                {
                    _conn.ExcluirAcai(AcaiSelecionado);
                    listaAcais = new ObservableCollection<Acai>(_conn.BuscaAcai());
                    Notifica();
                    /*listaAcais.Clear();*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }, (object _) => this.AcaiSelecionado != null);


            UpdateAcai = new RelayCommand((object _) =>
            {
                Acai acaiClonado = (Acai)AcaiSelecionado.Clone();
                CadastroAcai telaCadastroAcai = new CadastroAcai();
                telaCadastroAcai.DataContext = acaiClonado;
                bool? verificaBotao = telaCadastroAcai.ShowDialog();

                if (verificaBotao.HasValue && verificaBotao.Value)
                {
                    try
                    {
                        _conn.AtualizarAcai(acaiClonado);
                        listaAcais = new ObservableCollection<Acai>(_conn.BuscaAcai());
                        Notifica();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message);
                    }
                }

            }, (object _) => this.AcaiSelecionado != null);

        }
    }
}
