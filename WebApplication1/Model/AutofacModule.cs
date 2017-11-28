using Autofac;
using Processor.Database;

namespace Host
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseManager>();
            builder.RegisterType<SqlDatabase>().As<IDatabase>();

            // 注册IService、Service层的
            var services = System.Reflection.Assembly.Load("Service");
            var iservices = System.Reflection.Assembly.Load("IService");
            builder.RegisterAssemblyTypes(iservices, services).AsImplementedInterfaces();
        }
    }
}
