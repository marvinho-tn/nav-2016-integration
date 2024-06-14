using System;
using Microsoft.OData.Client;
using System.Linq;

namespace NavIntegrationExample
{
    public class NavContext : DataServiceContext
    {
        public NavContext(Uri serviceRoot) : base(serviceRoot) { }

        public DataServiceQuery<YourEntity> YourEntities
        {
            get { return base.CreateQuery<YourEntity>("YourEntities"); }
        }
    }

    [Key("ID")]
    public class YourEntity
    {
        public int ID { get; set; }
        public string FieldName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serviceRoot = new Uri("http://your-server:7048/DynamicsNAV/OData/Company('YourCompany')");
            var context = new NavContext(serviceRoot);

            var query = context.YourEntities.Where(e => e.ID == 1);
            foreach (var entity in query)
            {
                Console.WriteLine(entity.FieldName);
            }
        }
    }
}
