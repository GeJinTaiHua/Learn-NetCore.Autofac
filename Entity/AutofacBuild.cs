using Autofac;

namespace Entity
{
    public class AutofacBuild
    {
        /// <summary>
        /// 全局
        /// </summary>
        public static IContainer ApplicationContainer { get; set; }

        public static T Get<T>()
        {
            return ApplicationContainer.Resolve<T>();
        }
    }
}
