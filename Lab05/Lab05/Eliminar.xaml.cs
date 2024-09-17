using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab05
{
    public partial class Eliminar : Window
    {
        public Eliminar()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string connectionString = "Data Source=LAB1507-19\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=userCutti;Password=123456789;";
            string query = "SELECT idCliente, NombreCompañia, NombreContacto, CargoContacto, Direccion, Ciudad, Telefono FROM clientes WHERE Activo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        idCliente = reader["idCliente"].ToString(),
                        NombreCompañia = reader["NombreCompañia"].ToString(),
                        NombreContacto = reader["NombreContacto"].ToString(),
                        CargoContacto = reader["CargoContacto"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Ciudad = reader["Ciudad"].ToString(),
                        Telefono = reader["Telefono"].ToString()
                    });
                }
            }

            dataGridClientes.ItemsSource = clientes;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = dataGridClientes.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                // Cambiar el estado del cliente a inactivo
                string connectionString = "Data Source=LAB1507-19\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=userCutti;Password=123456789;";
                string query = "UPDATE clientes SET Activo = 0 WHERE idCliente = @idCliente";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idCliente", clienteSeleccionado.idCliente);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente eliminado (marcado como inactivo) exitosamente.");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Aquí puedes manejar la selección si es necesario
        }
    }
}
