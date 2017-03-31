using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Diccionary
{
    public class Client
    {
        private string m_strName = "";

        public string Name
        {
            get { return m_strName; }
        }

        public Client(string strName)
        {
            m_strName = strName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Client> lstClients = new List<Client>();

            Client client = new Client("Marcelo");
            lstClients.Add(client);

            Client client2 = new Client("Luis");
            lstClients.Add(client2);

            Client client3 = new Client("Juan");
            lstClients.Add(client3);

            Console.WriteLine();
            foreach (Client clientAux in lstClients)
            {
                Console.WriteLine(clientAux.Name);
            }

            Console.ReadKey();
        }
    }
}
