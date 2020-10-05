using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectElementalist.Interfaces
{
    public partial class Match : Form
    {
        string nickname, password, turn, idmatch;

        public Match(string nickname, string password, string turn, string idmatch)
        {
            InitializeComponent();
            this.nickname = nickname;
            this.password = password;
            this.turn = turn;
            this.idmatch = idmatch;
        }

        private void pbWater_Click(object sender, EventArgs e)
        {
            try
            {
                string element = "Water";
                request_web(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbAir_Click(object sender, EventArgs e)
        {
            try
            {
                string element = "Air";
                request_web(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbEarth_Click(object sender, EventArgs e)
        {
            try
            {
                string element = "Earth";
                request_web(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbFire_Click(object sender, EventArgs e)
        {
            try
            {
                string element = "Fire";
                request_web(element);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        public void request_web(string element)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password +
                    "&match=" + idmatch + "&element=" + element;

                //Configuracion de la solicitud
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                //Enviamos los datos
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(postData);
                }

                // Obtenemos la respuesta del servidor de nuestra solicitud.
                string responseFromRemoteServer;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseFromRemoteServer = reader.ReadToEnd();
                        Console.WriteLine(responseFromRemoteServer);
                        string[] responseclears = response_clear(responseFromRemoteServer);
                        /*foreach (string responseclear in responseclears)
                        {
                            Console.WriteLine("WORD: " + responseclear);
                        }*/
                        if (responseclears[0] == '"' + "respuesta" + '"' + ':' + '"' + "true" + '"')
                        {
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
                            Game game = new Game(nickname, password, turn, idmatch);
                            this.Hide();
                            game.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        public string[] response_clear(string texto)
        {
            try
            {
                string nueva = texto.Trim(new Char[] { '{', '}' });
                string[] corte = nueva.Split(',');
                return corte;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
                string[] error = texto.Split('{');
                return error;
            }
        }

        public string message_clear(string texto)
        {
            try
            {
                string[] corte = texto.Split(':');
                string nueva = corte[1].Trim(new Char[] { '"' });
                return nueva;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
                string error = "Error";
                return error;
            }
        }

        private void pbWater_MouseHover(object sender, EventArgs e)
        {
            pbWater.Image = Properties.Resources.pjwaterhover;
        }

        private void pbWater_MouseLeave(object sender, EventArgs e)
        {
            pbWater.Image = Properties.Resources.pjwater;
        }

        private void pbAir_MouseHover(object sender, EventArgs e)
        {
            pbAir.Image = Properties.Resources.pjairhover;
        }

        private void pbAir_MouseLeave(object sender, EventArgs e)
        {
            pbAir.Image = Properties.Resources.pjair;
        }

        private void pbEarth_MouseHover(object sender, EventArgs e)
        {
            pbEarth.Image = Properties.Resources.pjearthhover;
        }

        private void pbEarth_MouseLeave(object sender, EventArgs e)
        {
            pbEarth.Image = Properties.Resources.pjearth;
        }

        private void pbFire_MouseHover(object sender, EventArgs e)
        {
            pbFire.Image = Properties.Resources.pjfirehover;
        }

        private void pbFire_MouseLeave(object sender, EventArgs e)
        {
            pbFire.Image = Properties.Resources.pjfire;
        }

    }
}
