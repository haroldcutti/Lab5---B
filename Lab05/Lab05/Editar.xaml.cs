using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab05
{
    public partial class Editar : Window
    {
        public Editar()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string connectionString = "Data Source=LAB1507-19\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=userCutti;Password=123456789;";
            string query = "SELECT idCliente, NombreCompañia, NombreContacto, CargoContacto, Direccion, Ciudad, Telefono FROM clientes";

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

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            Cliente clienteSeleccionado = dataGridClientes.SelectedItem as Cliente;

            if (clienteSeleccionado != null)
            {
                EditarCliente ventanaEditar = new EditarCliente(clienteSeleccionado);
                ventanaEditar.ShowDialog();

                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }

    public class Cliente
    {
        public string idCliente { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
    }
}