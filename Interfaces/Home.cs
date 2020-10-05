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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox que contienen los datos de la ventana.
                string nickname = tbLoginNickname.Text;
                string password = tbLoginPassword.Text;
                string code = "";
                string url = "loginelementalist";
                request_web(nickname, password, code, url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox que contienen los datos de la ventana.
                string nickname = tbRegisterNickname.Text;
                string password = tbRegisterPassword.Text;
                string code = "";
                string url = "registerelementalist";
                request_web(nickname, password, code, url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }           
        }

        public void request_web(string nickname, string password, string code, string url)
        {
            try
            {
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "" + url;
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password;

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
                            Menu menu = new Menu(nickname, password);
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
                            this.Hide();
                            menu.ShowDialog();
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

        private void pbLogin_MouseHover(object sender, EventArgs e)
        {
            pbLogin.Image = Properties.Resources.buttonEnterhover;
        }

        private void pbLogin_MouseLeave(object sender, EventArgs e)
        {
            pbLogin.Image = Properties.Resources.buttonEnter;
        }

        private void pbRegister_MouseHover(object sender, EventArgs e)
        {
            pbRegister.Image = Properties.Resources.buttonRegisterhover;
        }

        private void pbRegister_MouseLeave(object sender, EventArgs e)
        {
            pbRegister.Image = Properties.Resources.buttonRegister;
        }
    }
}
