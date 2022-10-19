using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppSorveteria__WPF.Views
{
    /// <summary>
    /// Lógica interna para CadastroAcai.xaml
    /// </summary>
    public partial class CadastroAcai : Window
    {
        public CadastroAcai()
        {
            InitializeComponent();
        }

        private void SalvarAcai_Button(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
