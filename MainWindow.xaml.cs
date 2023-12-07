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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Http;
using Newtonsoft.Json;

namespace WPFpruebaTecnicaGET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient _client;

        public MainWindow()
        {
            _client = new HttpClient();
            InitializeComponent();
        }

        private async Task Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var NombrePersona = txtNombre.Text;
            var APaterno = txtAPaterno.Text;
            var AMaterno = txtAMaterno.Text;
            var IdentificacionPersona = txtIdentificacion.Text;

            var data = new StringContent(JsonConvert.SerializeObject(new { 
                Nombre = NombrePersona,
                ApellidoPaterno = APaterno,
                ApellidoMaterno = AMaterno,
                Identificacion = IdentificacionPersona
            }));

            var response = await _client.PostAsync("https://localhost:7059/api/Directorio/personas", data);
        }
    }
}
