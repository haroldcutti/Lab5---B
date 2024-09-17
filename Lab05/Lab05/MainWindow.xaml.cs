using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ingresar_Click(object sender, RoutedEventArgs e)
        {
            Ingresar insertarWindow = new Ingresar();
            insertarWindow.Show();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Editar editarWindow = new Editar();
            editarWindow.Show();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar eliminarWindow = new Eliminar();
            eliminarWindow.Show();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            Listar listarWindow = new Listar();
            listarWindow.Show();
        }
    }
}