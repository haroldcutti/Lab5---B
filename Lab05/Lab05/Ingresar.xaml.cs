using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Lab05
{
    public partial class Ingresar : Window
    {
        public Ingresar()
        {
            InitializeComponent();
        }

        private void GuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            string idCliente = txtIdCliente.Text;
            string nombreCompania = txtNombreCompañia.Text;
            string nombreContacto = txtNombreContacto.Text;
            string cargoContacto = txtCargoContacto.Text;
            string direccion = txtDireccion.Text;
            string ciudad = txtCiudad.Text;
            string telefono = txtTelefono.Text;

            string connectionString = "Data Source=LAB1507-19\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=userCutti;Password=123456789;";

            string query = "INSERT INTO clientes (idCliente, NombreCompañia, NombreContacto, CargoContacto, Direccion, Ciudad, Telefono) " +
                           "VALUES (@idCliente, @NombreCompañia, @NombreContacto, @CargoContacto, @Direccion, @Ciudad, @Telefono)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@NombreCompañia", nombreCompania);
                    command.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                    command.Parameters.AddWithValue("@CargoContacto", cargoContacto);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Ciudad", ciudad);
                    command.Parameters.AddWithValue("@Telefono", telefono);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente guardado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar el cliente");
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error de SQL: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}