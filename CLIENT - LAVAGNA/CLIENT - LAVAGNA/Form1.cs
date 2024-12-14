    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace CLIENT___LAVAGNA
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                NascondiMenu();
                tela.BackColor = Color.White; // Imposta il colore di sfondo della tela
            }

            public void MostraMenu()
            {
                button_colore.Visible = true;
                button_gomma.Visible = true;
                button_pulisci.Visible = true;
                textBox_chat.Visible = true;
                listBox_chat.Visible = true;
                spessorePennello.Visible = true;
            }

            public void NascondiMenu()
            {
                button_colore.Visible = false;
                button_gomma.Visible = false;
                button_pulisci.Visible = false;
                textBox_chat.Visible = false;
                listBox_chat.Visible = false;
                spessorePennello.Visible = false;
            }

            // Quando premo il tasto 'm' mostro/nascondo il menu
            public bool stato_menu = false;
            private void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 'm')
                {
                    if (!stato_menu)
                    {
                        MostraMenu();
                        stato_menu = true;
                    }
                    else
                    {
                        NascondiMenu();
                        stato_menu = false;
                    }
                }
            }

            public Point? PuntoPrecedente = null;
            public Color ColoreCorrente = Color.Black;
            public int SpessoreCorrente = 2;
            public bool GommaAttiva = false;
            public Client client;
            public string nome;

            public Form1(string nome, Client client)
            {
                InitializeComponent();
                this.nome = nome;
                this.client = client;

                // Avvia un thread per ricevere messaggi dal server
                Thread ricezioneThread = new Thread(RiceviMessaggi)
                {
                    IsBackground = true
                };
                ricezioneThread.Start();
            }

            private void RiceviMessaggi()
            {
                try
                {
                    while (true)
                    {
                        string messaggio = client.RiceviMessaggio();
                        if (!string.IsNullOrEmpty(messaggio) && messaggio.StartsWith("disegna"))
                        {
                            string[] dati = messaggio.Split(';');
                            string[] punti = dati[1].Split(',');
                            Point puntoInizio = new Point(int.Parse(punti[0]), int.Parse(punti[1]));
                            Point puntoFine = new Point(int.Parse(punti[2]), int.Parse(punti[3]));
                            Color colore = Color.FromArgb(int.Parse(dati[2]));
                            bool gomma = bool.Parse(dati[3]);

                            tela.Invoke((MethodInvoker)(() =>
                            {
                                using (Graphics g = tela.CreateGraphics())
                                {
                                    using (Pen penna = new Pen(gomma ? Color.White : colore, SpessoreCorrente))
                                    {
                                        g.DrawLine(penna, puntoInizio, puntoFine);
                                    }
                                }
                            }));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Connessione chiusa.");
                }
            }


            private void tela_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PuntoPrecedente = e.Location;
                }
            }

            private void tela_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left && PuntoPrecedente.HasValue)
                {
                    Point puntoCorrente = e.Location;

                    using (Graphics g = tela.CreateGraphics())
                    {
                        using (Pen penna = new Pen(GommaAttiva ? Color.White : ColoreCorrente, SpessoreCorrente))
                        {
                            g.DrawLine(penna, PuntoPrecedente.Value, puntoCorrente);
                        }
                    }

                    string messaggio = $"disegna;{PuntoPrecedente.Value.X},{PuntoPrecedente.Value.Y},{puntoCorrente.X},{puntoCorrente.Y};{ColoreCorrente.ToArgb()};{GommaAttiva}";
                    client.InviaMessaggio(messaggio);

                    PuntoPrecedente = puntoCorrente;
                }
            }

            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {

                client.Disconnetti();
            }

            private void button_gomma_Click(object sender, EventArgs e)
            {

                GommaAttiva = !GommaAttiva;
            }

            private void spessorePennello_Scroll(object sender, EventArgs e)
            {

                SpessoreCorrente = spessorePennello.Value;
            }

            private void button_colore_Click(object sender, EventArgs e)
            {
                using (ColorDialog dialogoColore = new ColorDialog())
                {
                    if (dialogoColore.ShowDialog() == DialogResult.OK)
                    {
                        ColoreCorrente = dialogoColore.Color;
                    }
                }
            }

            private void button_pulisci_Click(object sender, EventArgs e)
            {

                tela.Invalidate();
            }

            private void tela_MouseUp(object sender, MouseEventArgs e)
            {

                PuntoPrecedente = null;
            }
        }

        public class Client
        {
            private Socket socketCliente;

            public Client(string ip, int porta)
            {
                socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketCliente.Connect(ip, porta);
            }

            public string RiceviMessaggio()
            {
                byte[] buffer = new byte[1024];
                int bytesRicevuti = socketCliente.Receive(buffer);
                return Encoding.ASCII.GetString(buffer, 0, bytesRicevuti).TrimEnd('$');
            }

            public void InviaMessaggio(string messaggio)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messaggio + "$");
                socketCliente.Send(buffer);
            }

            public void Disconnetti()
            {
                try
                {
                    socketCliente.Shutdown(SocketShutdown.Both);
                    socketCliente.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore durante la disconnessione: {ex.Message}");
                }
            }
        }
    }
