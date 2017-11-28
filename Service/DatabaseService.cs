using Autofac;
using IService;
using Processor.Database;

namespace Service
{
    public class DatabaseService : IDatabaseService
    {
        public string Run()
        {
            // 原始
            IDatabase sqlDatabase = new SqlDatabase();
            DatabaseManager databaseManager = new DatabaseManager(sqlDatabase);
            string resultOriginal = databaseManager.Search("SELECT * FORM USER");

            // Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();//代替：builder.Register(c => new DatabaseManager(c.Resolve<IDatabase>()));
            builder.RegisterType<SqlDatabase>().As<IDatabase>();//代替：builder.RegisterModule(new ConfigurationSettingsReader("autofac")); 
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                string resultAutofac = manager.Search("SELECT * FORM USER");
                return resultAutofac;
            }
        }
    }
}
