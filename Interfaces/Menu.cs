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
    public partial class Menu : Form
    {
        string nickname, password, turn;
        string match1, match2, match3, match4, match5;
        string idmatch, idmatch1, idmatch2, idmatch3, idmatch4, idmatch5;

        public Menu(string nickname, string password)
        {
            InitializeComponent();
            this.nickname = nickname;
            this.password = password;
            btMatch1.Hide();
            btMatch2.Hide();
            btMatch3.Hide();
            btMatch4.Hide();
            btMatch5.Hide();
            if (this.nickname != "Ratatui")
            {
                pbReload.Hide();
            }
        }

        private void pbCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
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
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
                            turn = message_clear(responseclears[2]);
                            idmatch = message_clear(responseclears[3]);
                            Match match = new Match(nickname, password, turn, idmatch);
                            this.Hide();
                            match.ShowDialog();
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

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
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
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
                            match1 = message_clear(responseclears[2]);
                            match2 = message_clear(responseclears[3]);
                            match3 = message_clear(responseclears[4]);
                            match4 = message_clear(responseclears[5]);
                            match5 = message_clear(responseclears[6]);
                            if (match1 != "0")
                            {
                                btMatch1.Text = match1;
                                btMatch1.Show();
                                idmatch1 = message_clear(responseclears[7]);
                            }
                            if (match2 != "0")
                            {
                                btMatch2.Text = match2;
                                btMatch2.Show();
                                idmatch2 = message_clear(responseclears[8]);
                            }
                            if (match3 != "0")
                            {
                                btMatch3.Text = match3;
                                btMatch3.Show();
                                idmatch3 = message_clear(responseclears[9]);
                            }
                            if (match4 != "0")
                            {
                                btMatch4.Text = match4;
                                btMatch4.Show();
                                idmatch4 = message_clear(responseclears[10]);
                            }
                            if (match5 != "0")
                            {
                                btMatch5.Text = match5;
                                btMatch5.Show();
                                idmatch5 = message_clear(responseclears[11]);
                            }
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

        private void pbReload_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
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
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
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

        private void pbMymatch_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
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
                            string mensaje = message_clear(responseclears[1]);
                            MessageBox.Show(mensaje, "Mensaje de alerta");
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

        private void btMatch1_Click(object sender, EventArgs e)
        {
            try
            {
                request_web(idmatch1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void btMatch2_Click(object sender, EventArgs e)
        {
            try
            {
                request_web(idmatch2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void btMatch3_Click(object sender, EventArgs e)
        {
            try
            {
                request_web(idmatch3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void btMatch4_Click(object sender, EventArgs e)
        {
            try
            {
                request_web(idmatch4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void btMatch5_Click(object sender, EventArgs e)
        {
            try
            {
                request_web(idmatch5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        public void request_web(string idmatchRequest)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatchRequest;

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
                            turn = message_clear(responseclears[2]);
                            Match match = new Match(nickname, password, turn, idmatchRequest);
                            this.Hide();
                            match.ShowDialog();
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

        private void pbRefresh_MouseHover(object sender, EventArgs e)
        {
            pbRefresh.Image = Properties.Resources.buttonRefreshhover;
        }

        private void pbRefresh_MouseLeave(object sender, EventArgs e)
        {
            pbRefresh.Image = Properties.Resources.buttonRefresh;
        }

        private void pbCreate_MouseHover(object sender, EventArgs e)
        {
            pbCreate.Image = Properties.Resources.buttonCreatehover;
        }

        private void pbCreate_MouseLeave(object sender, EventArgs e)
        {
            pbCreate.Image = Properties.Resources.buttonCreate;
        }

        private void pbReload_MouseHover(object sender, EventArgs e)
        {
            pbReload.Image = Properties.Resources.buttonReloadhover;
        }

        private void pbReload_MouseLeave(object sender, EventArgs e)
        {
            pbReload.Image = Properties.Resources.buttonReload;
        }

        private void pbMymatch_MouseHover(object sender, EventArgs e)
        {
            pbMymatch.Image = Properties.Resources.buttonReloadhover;
        }

        private void pbMymatch_MouseLeave(object sender, EventArgs e)
        {
            pbMymatch.Image = Properties.Resources.buttonReload;
        }

    }
}
