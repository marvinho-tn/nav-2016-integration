using System;
using Microsoft.Dynamics.Nav.Client;

namespace Nav.Integration.Sdk
{
    class Program
    {
        static void Main(string[] args)
        {
            string navServerUrl = "http://localhost:7047/DynamicsNAV110/";
            string navUserName = "admin";
            string navPassword = "password";

            NavCredentials credentials = new NavCredentials(navServerUrl, navUserName, navPassword);

            using (NavClient navClient = new NavClient(credentials))
            {
                try
                {
                    navClient.Open();

                    // Exemplo de consulta a uma tabela (substitua "Customer" pelo nome da tabela no seu ambiente)
                    var customers = navClient.Customers;

                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"Customer ID: {customer.No}, Name: {customer.Name}");
                    }
                }
                catch (NavClientException ex)
                {
                    Console.WriteLine($"Erro ao conectar ao Dynamics NAV: {ex.Message}");
                }
                finally
                {
                    navClient.Close();
                }
            }
        }
    }
}