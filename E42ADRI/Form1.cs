
using Newtonsoft.Json;

namespace E42ADRI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await ObtenerDatos();
        }

        private async Task ObtenerDatos()
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync("http://localhost/examenA/Ejercicio4/index.php");

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        var datos = JsonConvert.DeserializeObject<dynamic[]>(contenido);

                        foreach (var dato in datos)
                        {
                            dataGridView1.Rows.Add(
                                dato.id.ToString(),
                                dato.nombre.ToString(),
                                dato.apellido.ToString(),
                                dato.ci.ToString(),
                                dato.correo.ToString(),
                                dato.contrasenia.ToString(),
                                dato.departamento.ToString()
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener los datos: " + respuesta.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
