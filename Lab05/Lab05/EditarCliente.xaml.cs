using System.Data.SqlClient;
using System.Windows;

namespace Lab05
{
    public partial class EditarCliente : Window
    {
        private Cliente cliente;

        public EditarCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;

            // Cargar los datos del cliente en los TextBox
            txtIdCliente.Text = cliente.idCliente;
            txtNombreCompañia.Text = cliente.NombreCompañia;
            txtNombreContacto.Text = cliente.NombreContacto;
            txtCargoContacto.Text = cliente.CargoContacto;
            txtDireccion.Text = cliente.Direccion;
            txtCiudad.Text = cliente.Ciudad;
            txtTelefono.Text = cliente.Telefono;
        }

        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Data Source=LAB1507-19\\SQLEXPRESS03;Initial Catalog=Neptuno;User ID=userCutti;Password=123456789;";

            // Consulta SQL para actualizar el cliente
            string query = "UPDATE clientes SET NombreCompañia=@NombreCompañia, NombreContacto=@NombreContacto, CargoContacto=@CargoContacto, Direccion=@Direccion, Ciudad=@Ciudad, Telefono=@Telefono WHERE idCliente=@idCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                    command.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                    command.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                    command.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente");
                        this.Close(); // Cierra la ventana después de guardar
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al actualizar el cliente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
