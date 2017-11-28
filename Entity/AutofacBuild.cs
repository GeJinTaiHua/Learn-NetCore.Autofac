using Autofac;

namespace Entity
{
    public class AutofacBuild
    {
        /// <summary>
        /// 全局
        /// </summary>
        private static IContainer ApplicationContainer = null;

        public static void Set(IContainer _IContainer)
        {
            if (ApplicationContainer == null)
            {
                ApplicationContainer = _IContainer;
            }
        }

        public static T Get<T>()
        {
            return ApplicationContainer.Resolve<T>();
        }
    }
}
