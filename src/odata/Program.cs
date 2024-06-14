using Microsoft.OData.Client;

namespace NavIntegration
{
    class NavContext : DataServiceContext
    {
        public NavContext(Uri serviceRoot) : base(serviceRoot) { }

        public DataServiceQuery<Entity> YourEntities
        {
            get { return base.CreateQuery<Entity>("Entities"); }
        }
    }

    [Key("ID")]
    class Entity
    {
        public int ID { get; set; }
        public string FieldName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //example: http://your-server:7048/DynamicsNAV/OData/Company('YourCompany')
            var serverUri = Environment.GetEnvironmentVariable("NAV_SERVER_URI");

            if(serverUri is null)
                return;

            var serviceRoot = new Uri(serverUri);
            var context = new NavContext(serviceRoot);
            var query = context.YourEntities.Where(e => e.ID == 1);

            foreach (var entity in query)
            {
                Console.WriteLine(entity.FieldName);
            }
        }
    }
}
