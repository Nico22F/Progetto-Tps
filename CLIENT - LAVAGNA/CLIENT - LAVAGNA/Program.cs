using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT___LAVAGNA
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostra il form menu
            menu menuForm = new menu();
            menuForm.ShowDialog();

            // Se l'utente ha scelto di avviare la lavagna, apri Form1
            if (menuForm.AvviaLavagna)
            {
                Client client = new Client("127.0.0.1", 5000); // Configura il client
                Application.Run(new Form1(menuForm.NomeUtente, client));
            }
        }
    }
}
