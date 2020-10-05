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
    public partial class Game : Form
    {
        string nickname, password, turn, idmatch, lastcard, now;
        string elementPlayer, elementEnemy1, elementEnemy2, elementEnemy3;
        string card1, card2, card3, card4, card5, card6, card7, card8, card9, card10;
        string[] hand;
        string validate, validateWin;

        public Game(string nickname, string password, string turn, string idmatch)
        {
            InitializeComponent();
            hideElements();
            this.nickname = nickname;
            this.password = password;
            this.turn = turn;
            this.idmatch = idmatch;
            if(turn != "1")
            {
                pbStart.Hide();
            }
            validate = "No";
            validateWin = "No";
        }

        private void pbStart_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatch;

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
                            pbStart.Hide();
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

        private void timerGame_Tick(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatch;

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
                            lastcard = message_clear(responseclears[2]);
                            now = message_clear(responseclears[3]);
                            string jugador = message_clear(responseclears[4]);
                            string enemigo1 = message_clear(responseclears[5]);
                            string enemigo2 = message_clear(responseclears[6]);
                            string enemigo3 = message_clear(responseclears[7]);
                            string ganador = message_clear(responseclears[8]);
                            hand = hand_clear(responseFromRemoteServer);
                            showInfoGeneral(jugador, enemigo1, enemigo2, enemigo3);
                            showNowGame(now);
                            showLastCard(lastcard);
                            if (validate == "No")
                            {
                                showHandInitial(hand);
                                pbPass.Show();
                                validate = "Si";
                            }
                            else
                            {
                                if(lastcard == "22" || lastcard == "23" || lastcard == "47" || lastcard == "48"
                                    || lastcard == "72" || lastcard == "73" || lastcard == "97" || lastcard == "98")
                                {
                                    hideHand();
                                }                               
                                showHand(hand);
                                if (ganador != "0" && validateWin == "No")
                                {
                                    validateWin = "Si";
                                    if (turn == "1")
                                    {
                                        request_win();
                                    }
                                    MessageBox.Show(ganador, "Mensaje de alerta");
                                    Menu menu = new Menu(nickname, password);
                                    this.Hide();
                                    menu.ShowDialog();
                                    this.Close();
                                }                               
                            }
                        }
                        else
                        {
                            string mensaje = message_clear(responseclears[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbPass_Click(object sender, EventArgs e)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatch;

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

        private void pbCard1_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "1";
                request_web(number, card1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard2_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "2";
                request_web(number, card2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard3_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "3";
                request_web(number, card3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard4_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "4";
                request_web(number, card4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard5_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "5";
                request_web(number, card5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard6_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "6";
                request_web(number, card6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard7_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "7";
                request_web(number, card7);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard8_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "8";
                request_web(number, card8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard9_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "9";
                request_web(number, card9);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        private void pbCard10_Click(object sender, EventArgs e)
        {
            try
            {
                string number = "10";
                request_web(number, card10);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        public void request_win()
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatch;

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

        public void request_web(string number, string card)
        {
            try
            {
                string code = "";
                // Definimos la solicitud que se enviará a la API del servidor.
                string requestUrl = "";
                HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);

                // Seteamos los datos a enviar por la solicitud POST.
                string postData = "code=" + code + "&nickname=" + nickname + "&password=" + password + "&match=" + idmatch
                    + "&card=" + card;

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
                            if(number == "1")
                            {
                                card1 = null;
                                pbCard1.Image = null;
                            }
                            else if(number == "2")
                            {
                                card2 = null;
                                pbCard2.Image = null;
                            }
                            else if (number == "3")
                            {
                                card3 = null;
                                pbCard3.Image = null;
                            }
                            else if (number == "4")
                            {
                                card4 = null;
                                pbCard4.Image = null;
                            }
                            else if (number == "5")
                            {
                                card5 = null;
                                pbCard5.Image = null;
                            }
                            else if (number == "6")
                            {
                                card6 = null;
                                pbCard6.Image = null;
                            }
                            else if (number == "7")
                            {
                                card7 = null;
                                pbCard7.Image = null;
                            }
                            else if (number == "8")
                            {
                                card8 = null;
                                pbCard8.Image = null;
                            }
                            else if (number == "9")
                            {
                                card9 = null;
                                pbCard9.Image = null;
                            }
                            else if (number == "10")
                            {
                                card10 = null;
                                pbCard10.Image = null;
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

        public void showNowGame(string now)
        {
            try
            {
                lbNow.Show();
                lbNow.Text = "Turno jugando: " + now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
            }
        }

        public void showInfoGeneral(string jugador, string enemigo1, string enemigo2, string enemigo3)
        {
            string[] player = jugador.Split('-');
            string[] enemy1 = enemigo1.Split('-');
            string[] enemy2 = enemigo2.Split('-');
            string[] enemy3 = enemigo3.Split('-');
            if (validate == "No")
            {
                // Informacion del player
                lbNickname.Show();
                lbNickname.Text = player[0];
                elementPlayer = player[1];
                if (player[1] == "Water")
                {
                    pbPlayer.Image = Properties.Resources.pjwater;
                    pbPlayer.Show();
                }
                else if (player[1] == "Air")
                {
                    pbPlayer.Image = Properties.Resources.pjair;
                    pbPlayer.Show();
                }
                else if (player[1] == "Fire")
                {
                    pbPlayer.Image = Properties.Resources.pjfire;
                    pbPlayer.Show();
                }
                else if (player[1] == "Earth")
                {
                    pbPlayer.Image = Properties.Resources.pjearth;
                    pbPlayer.Show();
                }
                lbTurn.Show();
                lbTurn.Text = "Tu turno: " + player[3];
                // Informacion del enemigo1
                lbNickEnemy1.Show();
                lbNickEnemy1.Text = enemy1[0];
                elementEnemy1 = enemy1[1];
                if (enemy1[1] == "Water")
                {
                    pbEnemy1.Image = Properties.Resources.pjwater;
                    pbEnemy1.Show();
                }
                else if (enemy1[1] == "Air")
                {
                    pbEnemy1.Image = Properties.Resources.pjair;
                    pbEnemy1.Show();
                }
                else if (enemy1[1] == "Fire")
                {
                    pbEnemy1.Image = Properties.Resources.pjfire;
                    pbEnemy1.Show();
                }
                else if (enemy1[1] == "Earth")
                {
                    pbEnemy1.Image = Properties.Resources.pjearth;
                    pbEnemy1.Show();
                }
                lbTurnEnemy1.Show();
                lbTurnEnemy1.Text = "Turno: " + enemy1[3];
                // Informacion del enemigo2
                lbNickEnemy2.Show();
                lbNickEnemy2.Text = enemy2[0];
                elementEnemy2 = enemy2[1];
                if (enemy2[1] == "Water")
                {
                    pbEnemy2.Image = Properties.Resources.pjwater;
                    pbEnemy2.Show();
                }
                else if (enemy2[1] == "Air")
                {
                    pbEnemy2.Image = Properties.Resources.pjair;
                    pbEnemy2.Show();
                }
                else if (enemy2[1] == "Fire")
                {
                    pbEnemy2.Image = Properties.Resources.pjfire;
                    pbEnemy2.Show();
                }
                else if (enemy2[1] == "Earth")
                {
                    pbEnemy2.Image = Properties.Resources.pjearth;
                    pbEnemy2.Show();
                }
                lbTurnEnemy2.Show();
                lbTurnEnemy2.Text = "Turno: " + enemy2[3];
                // Informacion del enemigo3
                lbNickEnemy3.Show();
                lbNickEnemy3.Text = enemy3[0];
                elementEnemy3 = enemy3[1];
                if (enemy3[1] == "Water")
                {
                    pbEnemy3.Image = Properties.Resources.pjwater;
                    pbEnemy3.Show();
                }
                else if (enemy3[1] == "Air")
                {
                    pbEnemy3.Image = Properties.Resources.pjair;
                    pbEnemy3.Show();
                }
                else if (enemy3[1] == "Fire")
                {
                    pbEnemy3.Image = Properties.Resources.pjfire;
                    pbEnemy3.Show();
                }
                else if (enemy3[1] == "Earth")
                {
                    pbEnemy3.Image = Properties.Resources.pjearth;
                    pbEnemy3.Show();
                }
                lbTurnEnemy3.Show();
                lbTurnEnemy3.Text = "Turno: " + enemy3[3];
            }
            else
            {
                lbPoints.Show();
                lbPoints.Text = "Tus puntos: " + player[2];
                lbPointsEnemy1.Show();
                lbPointsEnemy1.Text = "Puntos: " + enemy1[2];
                lbCardsEnemy1.Show();
                lbCardsEnemy1.Text = "Cartas: " + enemy1[4];
                lbPointsEnemy2.Show();
                lbPointsEnemy2.Text = "Puntos: " + enemy2[2];
                lbCardsEnemy2.Show();
                lbCardsEnemy2.Text = "Cartas: " + enemy2[4];
                lbPointsEnemy3.Show();
                lbPointsEnemy3.Text = "Puntos: " + enemy3[2];
                lbCardsEnemy3.Show();
                lbCardsEnemy3.Text = "Cartas: " + enemy3[4];
            }
        }

        public void hideElements()
        {
            try
            {
                pbPlayer.Hide();
                pbEnemy1.Hide();
                pbEnemy2.Hide();
                pbEnemy3.Hide();
                lbNickname.Hide();
                lbNickEnemy1.Hide();
                lbNickEnemy2.Hide();
                lbNickEnemy3.Hide();
                lbCardsEnemy1.Hide();
                lbCardsEnemy2.Hide();
                lbCardsEnemy3.Hide();
                lbPoints.Hide();
                lbPointsEnemy1.Hide();
                lbPointsEnemy2.Hide();
                lbPointsEnemy3.Hide();
                lbTurn.Hide();
                lbTurnEnemy1.Hide();
                lbTurnEnemy2.Hide();
                lbTurnEnemy3.Hide();                                                            
                pbMaze.Hide();
                pbGame.Hide();
                lbNow.Hide();
                pbPass.Hide();
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

        public string[] hand_clear(string texto)
        {
            try
            {
                string[] corte = texto.Split(':');
                string nueva1 = corte[corte.Length-1].Trim(new Char[] { '[', ']', '}' });
                //string nueva1 = nueva.Trim(new Char[] { ']', '}' });
                string nueva2 = nueva1.Replace(Char.ToString('"'), "");
                // Otra forma de poner espacios en blanco
                //string result = string.Concat(nueva2.Where(c => !char.IsWhiteSpace(c)));
                string[] corte1 = nueva2.Split(',');
                return corte1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex, "Mensaje de alerta");
                string[] error = texto.Split('{');
                return error;
            }
        }

        public void hideHand()
        {
            pbCard1.Image = null;
            pbCard2.Image = null;
            pbCard3.Image = null;
            pbCard4.Image = null;
            pbCard5.Image = null;
            pbCard6.Image = null;
            pbCard7.Image = null;
            pbCard8.Image = null;
            pbCard9.Image = null;
            pbCard10.Image = null;
            card1 = null;
            card2 = null;
            card3 = null;
            card4 = null;
            card5 = null;
            card6 = null;
            card7 = null;
            card8 = null;
            card9 = null;
            card10 = null;
        }

        public void showHandInitial(string[] hand)
        {
            int maxHand = hand.Length;
            for (int i = 0; i < maxHand; i++)
            {
                if (i == 0)
                {
                    showImageHand(hand[i], pbCard1);
                    card1 = hand[i];
                }
                else if (i == 1)
                {
                    showImageHand(hand[i], pbCard2);
                    card2 = hand[i];
                }
                else if (i == 2)
                {
                    showImageHand(hand[i], pbCard3);
                    card3 = hand[i];
                }
                else if (i == 3)
                {
                    showImageHand(hand[i], pbCard4);
                    card4 = hand[i];
                }
                else if (i == 4)
                {
                    showImageHand(hand[i], pbCard5);
                    card5 = hand[i];
                }
                else
                {
                    showImageHand(hand[i], pbCard6);
                    card6 = hand[i];
                }
            }
        }

        public void showHand(string[] hand)
        {
            int maxHand = hand.Length;
            for (int i = 0; i < maxHand; i++)
            {
                if(hand[i] != card1 && hand[i] != card2 && hand[i] != card3 && hand[i] != card4 && hand[i] != card5
                    && hand[i] != card6 && hand[i] != card7 && hand[i] != card8 && hand[i] != card9 &&
                    hand[i] != card10)
                {
                    if(pbCard1.Image == null)
                    {
                        showImageHand(hand[i], pbCard1);
                        card1 = hand[i];
                    }
                    else if(pbCard2.Image == null)
                    {
                        showImageHand(hand[i], pbCard2);
                        card2 = hand[i];
                    }
                    else if (pbCard3.Image == null)
                    {
                        showImageHand(hand[i], pbCard3);
                        card3 = hand[i];
                    }
                    else if (pbCard4.Image == null)
                    {
                        showImageHand(hand[i], pbCard4);
                        card4 = hand[i];
                    }
                    else if (pbCard5.Image == null)
                    {
                        showImageHand(hand[i], pbCard5);
                        card5 = hand[i];
                    }
                    else if (pbCard6.Image == null)
                    {
                        showImageHand(hand[i], pbCard6);
                        card6 = hand[i];
                    }
                    else if (pbCard7.Image == null)
                    {
                        showImageHand(hand[i], pbCard7);
                        card7 = hand[i];
                    }
                    else if (pbCard8.Image == null)
                    {
                        showImageHand(hand[i], pbCard8);
                        card8 = hand[i];
                    }
                    else if (pbCard9.Image == null)
                    {
                        showImageHand(hand[i], pbCard9);
                        card9 = hand[i];
                    }
                    else if (pbCard10.Image == null)
                    {
                        showImageHand(hand[i], pbCard10);
                        card10 = hand[i];
                    }
                }
            }
        }

        public void showImageHand(string image, PictureBox pb)
        {
            if (image == "1")
            {
                pb.Image = Properties.Resources.miniwater0;
            }
            else if (image == "2")
            {
                pb.Image = Properties.Resources.miniwater1;
            }
            else if (image == "3")
            {
                pb.Image = Properties.Resources.miniwater1;
            }
            else if (image == "4")
            {
                pb.Image = Properties.Resources.miniwater2;
            }
            else if (image == "5")
            {
                pb.Image = Properties.Resources.miniwater2;
            }
            else if (image == "6")
            {
                pb.Image = Properties.Resources.miniwater3;
            }
            else if (image == "7")
            {
                pb.Image = Properties.Resources.miniwater3;
            }
            else if (image == "8")
            {
                pb.Image = Properties.Resources.miniwater4;
            }
            else if (image == "9")
            {
                pb.Image = Properties.Resources.miniwater4;
            }
            else if (image == "10")
            {
                pb.Image = Properties.Resources.miniwater5;
            }
            else if (image == "11")
            {
                pb.Image = Properties.Resources.miniwater5;
            }
            else if (image == "12")
            {
                pb.Image = Properties.Resources.miniwater6;
            }
            else if (image == "13")
            {
                pb.Image = Properties.Resources.miniwater6;
            }
            else if (image == "14")
            {
                pb.Image = Properties.Resources.miniwater7;
            }
            else if (image == "15")
            {
                pb.Image = Properties.Resources.miniwater7;
            }
            else if (image == "16")
            {
                pb.Image = Properties.Resources.miniwater8;
            }
            else if (image == "17")
            {
                pb.Image = Properties.Resources.miniwater8;
            }
            else if (image == "18")
            {
                pb.Image = Properties.Resources.miniwater9;
            }
            else if (image == "19")
            {
                pb.Image = Properties.Resources.miniwater9;
            }
            else if (image == "20")
            {
                pb.Image = Properties.Resources.miniwaterturn;
            }
            else if (image == "21")
            {
                pb.Image = Properties.Resources.miniwaterturn;
            }
            else if (image == "22")
            {
                pb.Image = Properties.Resources.miniwaterinvert;
            }
            else if (image == "23")
            {
                pb.Image = Properties.Resources.miniwaterinvert;
            }
            else if (image == "24")
            {
                pb.Image = Properties.Resources.miniwatermore2;
            }
            else if (image == "25")
            {
                pb.Image = Properties.Resources.miniwatermore2;
            }
            else if (image == "26")
            {
                pb.Image = Properties.Resources.miniearth0;
            }
            else if (image == "27")
            {
                pb.Image = Properties.Resources.miniearth1;
            }
            else if (image == "28")
            {
                pb.Image = Properties.Resources.miniearth1;
            }
            else if (image == "29")
            {
                pb.Image = Properties.Resources.miniearth2;
            }
            else if (image == "30")
            {
                pb.Image = Properties.Resources.miniearth2;
            }
            else if (image == "31")
            {
                pb.Image = Properties.Resources.miniearth3;
            }
            else if (image == "32")
            {
                pb.Image = Properties.Resources.miniearth3;
            }
            else if (image == "33")
            {
                pb.Image = Properties.Resources.miniearth4;
            }
            else if (image == "34")
            {
                pb.Image = Properties.Resources.miniearth4;
            }
            else if (image == "35")
            {
                pb.Image = Properties.Resources.miniearth5;
            }
            else if (image == "36")
            {
                pb.Image = Properties.Resources.miniearth5;
            }
            else if (image == "37")
            {
                pb.Image = Properties.Resources.miniearth6;
            }
            else if (image == "38")
            {
                pb.Image = Properties.Resources.miniearth6;
            }
            else if (image == "39")
            {
                pb.Image = Properties.Resources.miniearth7;
            }
            else if (image == "40")
            {
                pb.Image = Properties.Resources.miniearth7;
            }
            else if (image == "41")
            {
                pb.Image = Properties.Resources.miniearth8;
            }
            else if (image == "42")
            {
                pb.Image = Properties.Resources.miniearth8;
            }
            else if (image == "43")
            {
                pb.Image = Properties.Resources.miniearth9;
            }
            else if (image == "44")
            {
                pb.Image = Properties.Resources.miniearth9;
            }
            else if (image == "45")
            {
                pb.Image = Properties.Resources.miniearthturn;
            }
            else if (image == "46")
            {
                pb.Image = Properties.Resources.miniearthturn;
            }
            else if (image == "47")
            {
                pb.Image = Properties.Resources.miniearthinvert;
            }
            else if (image == "48")
            {
                pb.Image = Properties.Resources.miniearthinvert;
            }
            else if (image == "49")
            {
                pb.Image = Properties.Resources.miniearthmore2;
            }
            else if (image == "50")
            {
                pb.Image = Properties.Resources.miniearthmore2;
            }
            else if (image == "51")
            {
                pb.Image = Properties.Resources.minifire0;
            }
            else if (image == "52")
            {
                pb.Image = Properties.Resources.minifire1;
            }
            else if (image == "53")
            {
                pb.Image = Properties.Resources.minifire1;
            }
            else if (image == "54")
            {
                pb.Image = Properties.Resources.minifire2;
            }
            else if (image == "55")
            {
                pb.Image = Properties.Resources.minifire2;
            }
            else if (image == "56")
            {
                pb.Image = Properties.Resources.minifire3;
            }
            else if (image == "57")
            {
                pb.Image = Properties.Resources.minifire3;
            }
            else if (image == "58")
            {
                pb.Image = Properties.Resources.minifire4;
            }
            else if (image == "59")
            {
                pb.Image = Properties.Resources.minifire4;
            }
            else if (image == "60")
            {
                pb.Image = Properties.Resources.minifire5;
            }
            else if (image == "61")
            {
                pb.Image = Properties.Resources.minifire5;
            }
            else if (image == "62")
            {
                pb.Image = Properties.Resources.minifire6;
            }
            else if (image == "63")
            {
                pb.Image = Properties.Resources.minifire6;
            }
            else if (image == "64")
            {
                pb.Image = Properties.Resources.minifire7;
            }
            else if (image == "65")
            {
                pb.Image = Properties.Resources.minifire7;
            }
            else if (image == "66")
            {
                pb.Image = Properties.Resources.minifire8;
            }
            else if (image == "67")
            {
                pb.Image = Properties.Resources.minifire8;
            }
            else if (image == "68")
            {
                pb.Image = Properties.Resources.minifire9;
            }
            else if (image == "69")
            {
                pb.Image = Properties.Resources.minifire9;
            }
            else if (image == "70")
            {
                pb.Image = Properties.Resources.minifireturn;
            }
            else if (image == "71")
            {
                pb.Image = Properties.Resources.minifireturn;
            }
            else if (image == "72")
            {
                pb.Image = Properties.Resources.minifireinvert;
            }
            else if (image == "73")
            {
                pb.Image = Properties.Resources.minifireinvert;
            }
            else if (image == "74")
            {
                pb.Image = Properties.Resources.minifiremore2;
            }
            else if (image == "75")
            {
                pb.Image = Properties.Resources.minifiremore2;
            }
            else if (image == "76")
            {
                pb.Image = Properties.Resources.miniair0;
            }
            else if (image == "77")
            {
                pb.Image = Properties.Resources.miniair1;
            }
            else if (image == "78")
            {
                pb.Image = Properties.Resources.miniair1;
            }
            else if (image == "79")
            {
                pb.Image = Properties.Resources.miniair2;
            }
            else if (image == "80")
            {
                pb.Image = Properties.Resources.miniair2;
            }
            else if (image == "81")
            {
                pb.Image = Properties.Resources.miniair3;
            }
            else if (image == "82")
            {
                pb.Image = Properties.Resources.miniair3;
            }
            else if (image == "83")
            {
                pb.Image = Properties.Resources.miniair4;
            }
            else if (image == "84")
            {
                pb.Image = Properties.Resources.miniair4;
            }
            else if (image == "85")
            {
                pb.Image = Properties.Resources.miniair5;
            }
            else if (image == "86")
            {
                pb.Image = Properties.Resources.miniair5;
            }
            else if (image == "87")
            {
                pb.Image = Properties.Resources.miniair6;
            }
            else if (image == "88")
            {
                pb.Image = Properties.Resources.miniair6;
            }
            else if (image == "89")
            {
                pb.Image = Properties.Resources.miniair7;
            }
            else if (image == "90")
            {
                pb.Image = Properties.Resources.miniair7;
            }
            else if (image == "91")
            {
                pb.Image = Properties.Resources.miniair8;
            }
            else if (image == "92")
            {
                pb.Image = Properties.Resources.miniair8;
            }
            else if (image == "93")
            {
                pb.Image = Properties.Resources.miniair9;
            }
            else if (image == "94")
            {
                pb.Image = Properties.Resources.miniair9;
            }
            else if (image == "95")
            {
                pb.Image = Properties.Resources.miniairturn;
            }
            else if (image == "96")
            {
                pb.Image = Properties.Resources.miniairturn;
            }
            else if (image == "97")
            {
                pb.Image = Properties.Resources.miniairinvert;
            }
            else if (image == "98")
            {
                pb.Image = Properties.Resources.miniairinvert;
            }
            else if (image == "99")
            {
                pb.Image = Properties.Resources.miniairmore2;
            }
            else if (image == "100")
            {
                pb.Image = Properties.Resources.miniairmore2;
            }
            else if (image == "101")
            {
                pb.Image = Properties.Resources.minimore4;
            }
            else if (image == "102")
            {
                pb.Image = Properties.Resources.minimore4;
            }
            else if (image == "103")
            {
                pb.Image = Properties.Resources.minimore4;
            }
            else if (image == "104")
            {
                pb.Image = Properties.Resources.minimore4;
            }
            else if (image == "105")
            {
                pb.Image = Properties.Resources.minielement;
            }
            else if (image == "106")
            {
                pb.Image = Properties.Resources.minielement;
            }
            else if (image == "107")
            {
                pb.Image = Properties.Resources.minielement;
            }
            else if (image == "108")
            {
                pb.Image = Properties.Resources.minielement;
            }
        }

        public void showLastCard(string image)
        {
            pbMaze.Show();
            pbGame.Show();
            if (image == "1")
            {
                pbGame.Image = Properties.Resources.cardwater0;
            }
            else if (image == "2" || image == "3")
            {
                pbGame.Image = Properties.Resources.cardwater1;
            }
            else if (image == "4" || image == "5")
            {
                pbGame.Image = Properties.Resources.cardwater2;
            }
            else if (image == "6" || image == "7")
            {
                pbGame.Image = Properties.Resources.cardwater3;
            }
            else if (image == "8" || image == "9")
            {
                pbGame.Image = Properties.Resources.cardwater4;
            }
            else if (image == "10" || image == "11")
            {
                pbGame.Image = Properties.Resources.cardwater5;
            }
            else if (image == "12" || image == "13")
            {
                pbGame.Image = Properties.Resources.cardwater6;
            }
            else if (image == "14" || image == "15")
            {
                pbGame.Image = Properties.Resources.cardwater7;
            }
            else if (image == "16" || image == "17")
            {
                pbGame.Image = Properties.Resources.cardwater8;
            }
            else if (image == "18" || image == "19")
            {
                pbGame.Image = Properties.Resources.cardwater9;
            }
            else if (image == "20" || image == "21")
            {
                pbGame.Image = Properties.Resources.cardwaterturn;
            }
            else if (image == "22" || image == "23")
            {
                pbGame.Image = Properties.Resources.cardwaterinvert;
            }
            else if (image == "24" || image == "25")
            {
                pbGame.Image = Properties.Resources.cardwatermore2;
            }
            else if (image == "26")
            {
                pbGame.Image = Properties.Resources.cardearth0;
            }
            else if (image == "27" || image == "28")
            {
                pbGame.Image = Properties.Resources.cardearth1;
            }
            else if (image == "29" || image == "30")
            {
                pbGame.Image = Properties.Resources.cardearth2;
            }
            else if (image == "31" || image == "32")
            {
                pbGame.Image = Properties.Resources.cardearth3;
            }
            else if (image == "33" || image == "34")
            {
                pbGame.Image = Properties.Resources.cardearth4;
            }
            else if (image == "35" || image == "36")
            {
                pbGame.Image = Properties.Resources.cardearth5;
            }
            else if (image == "37" || image == "38")
            {
                pbGame.Image = Properties.Resources.cardearth6;
            }
            else if (image == "39" || image == "40")
            {
                pbGame.Image = Properties.Resources.cardearth7;
            }
            else if (image == "41" || image == "42")
            {
                pbGame.Image = Properties.Resources.cardearth8;
            }
            else if (image == "43" || image == "44")
            {
                pbGame.Image = Properties.Resources.cardearth9;
            }
            else if (image == "45" || image == "46")
            {
                pbGame.Image = Properties.Resources.cardearthturn;
            }
            else if (image == "47" || image == "48")
            {
                pbGame.Image = Properties.Resources.cardearthinvert;
            }
            else if (image == "49" || image == "50")
            {
                pbGame.Image = Properties.Resources.cardearthmore2;
            }
            else if (image == "51")
            {
                pbGame.Image = Properties.Resources.cardfire0;
            }
            else if (image == "52" || image == "53")
            {
                pbGame.Image = Properties.Resources.cardfire1;
            }
            else if (image == "54" || image == "55")
            {
                pbGame.Image = Properties.Resources.cardfire2;
            }
            else if (image == "56" || image == "57")
            {
                pbGame.Image = Properties.Resources.cardfire3;
            }
            else if (image == "58" || image == "59")
            {
                pbGame.Image = Properties.Resources.cardfire4;
            }
            else if (image == "60" || image == "61")
            {
                pbGame.Image = Properties.Resources.cardfire5;
            }
            else if (image == "62" || image == "63")
            {
                pbGame.Image = Properties.Resources.cardfire6;
            }
            else if (image == "64" || image == "65")
            {
                pbGame.Image = Properties.Resources.cardfire7;
            }
            else if (image == "66" || image == "67")
            {
                pbGame.Image = Properties.Resources.cardfire8;
            }
            else if (image == "68" || image == "69")
            {
                pbGame.Image = Properties.Resources.cardfire9;
            }
            else if (image == "70" || image == "71")
            {
                pbGame.Image = Properties.Resources.cardfireturn;
            }
            else if (image == "72" || image == "73")
            {
                pbGame.Image = Properties.Resources.cardfireinvert;
            }
            else if (image == "74" || image == "75")
            {
                pbGame.Image = Properties.Resources.cardfiremore2;
            }
            else if (image == "76")
            {
                pbGame.Image = Properties.Resources.cardair0;
            }
            else if (image == "77" || image == "78")
            {
                pbGame.Image = Properties.Resources.cardair1;
            }
            else if (image == "79" || image == "80")
            {
                pbGame.Image = Properties.Resources.cardair2;
            }
            else if (image == "81" || image == "82")
            {
                pbGame.Image = Properties.Resources.cardair3;
            }
            else if (image == "83" || image == "84")
            {
                pbGame.Image = Properties.Resources.cardair4;
            }
            else if (image == "85" || image == "86")
            {
                pbGame.Image = Properties.Resources.cardair5;
            }
            else if (image == "87" || image == "88")
            {
                pbGame.Image = Properties.Resources.cardair6;
            }
            else if (image == "89" || image == "90")
            {
                pbGame.Image = Properties.Resources.cardair7;
            }
            else if (image == "91" || image == "92")
            {
                pbGame.Image = Properties.Resources.cardair8;
            }
            else if (image == "93" || image == "94")
            {
                pbGame.Image = Properties.Resources.cardair9;
            }
            else if (image == "95" || image == "96")
            {
                pbGame.Image = Properties.Resources.cardairturn;
            }
            else if (image == "97" || image == "98")
            {
                pbGame.Image = Properties.Resources.cardairinvert;
            }
            else if (image == "99" || image == "100")
            {
                pbGame.Image = Properties.Resources.cardairmore2;
            }
            else if (image == "101" || image == "102" || image == "103" || image == "104")
            {
                pbGame.Image = Properties.Resources.cardmore4;
            }
            else if (image == "105" || image == "106" || image == "107" || image == "108")
            {
                pbGame.Image = Properties.Resources.cardelement;
            }
            else if (image == "109")
            {
                pbGame.Image = Properties.Resources.cardcomodin;
            }
        }

        private void pbPass_MouseHover(object sender, EventArgs e)
        {
            pbPass.Image = Properties.Resources.buttonPasshover;

        }

        private void pbPass_MouseLeave(object sender, EventArgs e)
        {
            pbPass.Image = Properties.Resources.buttonPass;
        }

        private void pbStart_MouseHover(object sender, EventArgs e)
        {
            pbStart.Image = Properties.Resources.buttonStarthover;
        }

        private void pbStart_MouseLeave(object sender, EventArgs e)
        {
            pbStart.Image = Properties.Resources.buttonStart;
        }

        private void pbPlayer_MouseHover(object sender, EventArgs e)
        {
            if(elementPlayer == "Water")
            {
                pbPlayer.Image = Properties.Resources.pjwaterhover2;
            }
            else if(elementPlayer == "Air")
            {
                pbPlayer.Image = Properties.Resources.pjairhover2;
            }
            else if (elementPlayer == "Fire")
            {
                pbPlayer.Image = Properties.Resources.pjfirehover2;
            }
            else if (elementPlayer == "Earth")
            {
                pbPlayer.Image = Properties.Resources.pjearthhover2;
            }
        }

        private void pbPlayer_MouseLeave(object sender, EventArgs e)
        {
            if (elementPlayer == "Water")
            {
                pbPlayer.Image = Properties.Resources.pjwater;
            }
            else if (elementPlayer == "Air")
            {
                pbPlayer.Image = Properties.Resources.pjair;
            }
            else if (elementPlayer == "Fire")
            {
                pbPlayer.Image = Properties.Resources.pjfire;
            }
            else if (elementPlayer == "Earth")
            {
                pbPlayer.Image = Properties.Resources.pjearth;
            }
        }

        private void pbEnemy1_MouseHover(object sender, EventArgs e)
        {
            if (elementEnemy1 == "Water")
            {
                pbEnemy1.Image = Properties.Resources.pjwaterhover2;
            }
            else if (elementEnemy1 == "Air")
            {
                pbEnemy1.Image = Properties.Resources.pjairhover2;
            }
            else if (elementEnemy1 == "Fire")
            {
                pbEnemy1.Image = Properties.Resources.pjfirehover2;
            }
            else if (elementEnemy1 == "Earth")
            {
                pbEnemy1.Image = Properties.Resources.pjearthhover2;
            }
        }

        private void pbEnemy1_MouseLeave(object sender, EventArgs e)
        {
            if (elementEnemy1 == "Water")
            {
                pbEnemy1.Image = Properties.Resources.pjwater;
            }
            else if (elementEnemy1 == "Air")
            {
                pbEnemy1.Image = Properties.Resources.pjair;
            }
            else if (elementEnemy1 == "Fire")
            {
                pbEnemy1.Image = Properties.Resources.pjfire;
            }
            else if (elementEnemy1 == "Earth")
            {
                pbEnemy1.Image = Properties.Resources.pjearth;
            }
        }

        private void pbEnemy2_MouseHover(object sender, EventArgs e)
        {
            if (elementEnemy2 == "Water")
            {
                pbEnemy2.Image = Properties.Resources.pjwaterhover2;
            }
            else if (elementEnemy2 == "Air")
            {
                pbEnemy2.Image = Properties.Resources.pjairhover2;
            }
            else if (elementEnemy2 == "Fire")
            {
                pbEnemy2.Image = Properties.Resources.pjfirehover2;
            }
            else if (elementEnemy2 == "Earth")
            {
                pbEnemy2.Image = Properties.Resources.pjearthhover2;
            }
        }

        private void pbEnemy2_MouseLeave(object sender, EventArgs e)
        {
            if (elementEnemy2 == "Water")
            {
                pbEnemy2.Image = Properties.Resources.pjwater;
            }
            else if (elementEnemy2 == "Air")
            {
                pbEnemy2.Image = Properties.Resources.pjair;
            }
            else if (elementEnemy2 == "Fire")
            {
                pbEnemy2.Image = Properties.Resources.pjfire;
            }
            else if (elementEnemy2 == "Earth")
            {
                pbEnemy2.Image = Properties.Resources.pjearth;
            }
        }

        private void pbEnemy3_MouseHover(object sender, EventArgs e)
        {
            if (elementEnemy3 == "Water")
            {
                pbEnemy3.Image = Properties.Resources.pjwaterhover2;
            }
            else if (elementEnemy3 == "Air")
            {
                pbEnemy3.Image = Properties.Resources.pjairhover2;
            }
            else if (elementEnemy3 == "Fire")
            {
                pbEnemy3.Image = Properties.Resources.pjfirehover2;
            }
            else if (elementEnemy3 == "Earth")
            {
                pbEnemy3.Image = Properties.Resources.pjearthhover2;
            }
        }

        private void pbEnemy3_MouseLeave(object sender, EventArgs e)
        {
            if (elementEnemy3 == "Water")
            {
                pbEnemy3.Image = Properties.Resources.pjwater;
            }
            else if (elementEnemy3 == "Air")
            {
                pbEnemy3.Image = Properties.Resources.pjair;
            }
            else if (elementEnemy3 == "Fire")
            {
                pbEnemy3.Image = Properties.Resources.pjfire;
            }
            else if (elementEnemy3 == "Earth")
            {
                pbEnemy3.Image = Properties.Resources.pjearth;
            }
        }

        private void pbCard1_MouseHover(object sender, EventArgs e)
        {
            if(card1 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard1.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard1.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard1.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard1.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard1_MouseLeave(object sender, EventArgs e)
        {
            pbCard1.BackgroundImage = null;
        }

        private void pbCard2_MouseHover(object sender, EventArgs e)
        {
            if(card2 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard2.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard2.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard2.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard2.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard2_MouseLeave(object sender, EventArgs e)
        {
            pbCard2.BackgroundImage = null;
        }

        private void pbCard3_MouseHover(object sender, EventArgs e)
        {
            if(card3 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard3.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard3.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard3.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard3.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard3_MouseLeave(object sender, EventArgs e)
        {
            pbCard3.BackgroundImage = null;
        }

        private void pbCard4_MouseHover(object sender, EventArgs e)
        {
            if(card4 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard4.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard4.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard4.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard4.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard4_MouseLeave(object sender, EventArgs e)
        {
            pbCard4.BackgroundImage = null;
        }

        private void pbCard5_MouseHover(object sender, EventArgs e)
        {
            if(card5 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard5.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard5.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard5.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard5.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }            
        }

        private void pbCard5_MouseLeave(object sender, EventArgs e)
        {
            pbCard5.BackgroundImage = null;
        }

        private void pbCard6_MouseHover(object sender, EventArgs e)
        {
            if(card6 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard6.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard6.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard6.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard6.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }            
        }

        private void pbCard6_MouseLeave(object sender, EventArgs e)
        {
            pbCard6.BackgroundImage = null;
        }

        private void pbCard7_MouseHover(object sender, EventArgs e)
        {
            if(card7 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard7.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard7.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard7.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard7.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }
        }

        private void pbCard7_MouseLeave(object sender, EventArgs e)
        {
            pbCard7.BackgroundImage = null;
        }

        private void pbCard8_MouseHover(object sender, EventArgs e)
        {
            if(card8 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard8.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard8.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard8.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard8.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard8_MouseLeave(object sender, EventArgs e)
        {
            pbCard8.BackgroundImage = null;
        }

        private void pbCard9_MouseHover(object sender, EventArgs e)
        {
            if(card9 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard9.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard9.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard9.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard9.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }            
        }

        private void pbCard9_MouseLeave(object sender, EventArgs e)
        {
            pbCard9.BackgroundImage = null;
        }

        private void pbCard10_MouseHover(object sender, EventArgs e)
        {
            if(card10 != null)
            {
                if (elementPlayer == "Water")
                {
                    pbCard10.BackgroundImage = Properties.Resources.effectcardwater;
                }
                else if (elementPlayer == "Air")
                {
                    pbCard10.BackgroundImage = Properties.Resources.effectcardair;
                }
                else if (elementPlayer == "Fire")
                {
                    pbCard10.BackgroundImage = Properties.Resources.effectcardfire;
                }
                else if (elementPlayer == "Earth")
                {
                    pbCard10.BackgroundImage = Properties.Resources.effectcardearth;
                }
            }           
        }

        private void pbCard10_MouseLeave(object sender, EventArgs e)
        {
            pbCard10.BackgroundImage = null;
        }

    }
}
