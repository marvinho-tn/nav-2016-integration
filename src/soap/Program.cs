using System;
using System.Net;

namespace Nav.Integration.Soap
{
    class Program
    {
        static void Main(string[] args)
        {
            // Substitua por suas credenciais
            string serviceUrl = "http://localhost:7047/DynamicsNAV/WS/YourCompany/Page/Customer";
            string username = "yourusername";
            string password = "yourpassword";

            // Configurar a autenticação
            NetworkCredential credentials = new NetworkCredential(username, password);
            Customer_Service service = new Customer_Service();
            service.Url = serviceUrl;
            service.Credentials = credentials;

            try
            {
                // Obter a lista de clientes
                Customer[] customers = service.ReadMultiple(null, null, 0);

                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.No}, Name: {customer.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao Dynamics NAV: {ex.Message}");
            }
        }
    }
}