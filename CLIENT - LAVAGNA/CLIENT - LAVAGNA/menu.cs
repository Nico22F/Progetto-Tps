using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server_Lavagna
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(5000);
            server.Avvia();
        }
    }

    public class Server
    {
        private Socket socketServer;
        private List<ClientInfo> clientConnessi = new List<ClientInfo>();
        private int portaServer;

        public Server(int porta)
        {
            portaServer = porta;
        }

        public void Avvia()
        {
            try
            {
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Bind(new IPEndPoint(IPAddress.Any, portaServer));
                socketServer.Listen(10);

                Console.WriteLine($"Server avviato sulla porta {portaServer}. In attesa di connessioni...");

                while (true)
                {
                    Socket clientSocket = socketServer.Accept();
                    Console.WriteLine($"Nuovo client connesso: {clientSocket.RemoteEndPoint}");

                    Thread clientThread = new Thread(() => GestisciClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }

        private void GestisciClient(Socket clientSocket)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRicevuti = clientSocket.Receive(buffer);

                    if (bytesRicevuti == 0)
                    {
                        Console.WriteLine("Connessione terminata dal client.");
                        break;
                    }

                    string messaggio = Encoding.ASCII.GetString(buffer, 0, bytesRicevuti).Trim();
                    Console.WriteLine($"Messaggio ricevuto: {messaggio}");

                    string[] dati = messaggio.Split(';');
                    if (dati.Length == 0) continue;

                    string comando = dati[0];

                    switch (comando)
                    {
                        case "accedi":
                            GestisciAccesso(clientSocket, dati);
                            break;

                        case "disegna":
                            GestisciDisegno(clientSocket, dati);
                            break;

                        default:
                            Console.WriteLine($"Comando non riconosciuto: {messaggio}");
                            break;
                    }
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("Connessione interrotta dal client.");
            }
            finally
            {
                RimuoviClient(clientSocket);
            }
        }

        private void GestisciAccesso(Socket clientSocket, string[] dati)
        {
            if (dati.Length < 2)
            {
                Console.WriteLine("Messaggio di accesso incompleto.");
                return;
            }

            string nomeUtente = dati[1];
            if (clientConnessi.Exists(c => c.Nome == nomeUtente))
            {
                InviaMessaggio(clientSocket, "nome_duplicato");
                clientSocket.Close();
                Console.WriteLine($"Tentativo di accesso con nome duplicato: {nomeUtente}");
            }
            else
            {
                clientConnessi.Add(new ClientInfo { Nome = nomeUtente, Socket = clientSocket });
                InviaMessaggio(clientSocket, "accesso_riuscito");
                Console.WriteLine($"Utente {nomeUtente} connesso.");
            }
        }

        private void GestisciDisegno(Socket clientSocket, string[] dati)
        {
            if (dati.Length < 4)
            {
                Console.WriteLine("Messaggio di disegno incompleto.");
                return;
            }

            string coordinate = dati[1];
            string colore = dati[2];
            string gomma = dati[3].ToLower();

            Console.WriteLine($"Disegno ricevuto: {coordinate}, Colore: {colore}, Gomma: {gomma}");

            InoltraATutti($"disegna;{coordinate};{colore};{gomma}", clientSocket);
        }

        private void InviaMessaggio(Socket clientSocket, string messaggio)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messaggio + "$");
                clientSocket.Send(buffer);
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Errore durante l'invio del messaggio: {ex.Message}");
            }
        }

        private void InoltraATutti(string messaggio, Socket mittente)
        {
            foreach (var client in clientConnessi)
            {
                try
                {
                    if (client.Socket != mittente)
                    {
                        InviaMessaggio(client.Socket, messaggio);
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Errore durante l'invio al client {client.Nome}: {ex.Message}");
                }
            }
        }

        private void RimuoviClient(Socket clientSocket)
        {
            var client = clientConnessi.Find(c => c.Socket == clientSocket);
            if (client != null)
            {
                clientConnessi.Remove(client);
                Console.WriteLine($"Client {client.Nome} disconnesso.");
            }

            try
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Errore durante la chiusura del socket: {ex.Message}");
            }
        }
    }

    public class ClientInfo
    {
        public string Nome { get; set; }
        public Socket Socket { get; set; }
    }
}
