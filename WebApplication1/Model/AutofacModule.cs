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

            // 注册Service层的所有名称以Service结束类
            var services = System.Reflection.Assembly.Load("Service");
            builder.RegisterAssemblyTypes(services);
        }
    }
}
