using Autofac;
using Processor.MovieLister;
using System;

namespace Service
{
    public class MovieListerService
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            //注册ListMovieFinder类型，这里的AsImplementedInterfaces表示以接口的形式注册
            builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces();
            //注册MPGMovieLister类型
            builder.RegisterType<MPGMovieLister>();

            var _container = builder.Build();
            var lister = _container.Resolve<MPGMovieLister>();
            foreach (var movie in lister.GetMPG())
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
