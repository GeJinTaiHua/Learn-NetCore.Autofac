using Entity;
using System.Linq;

namespace Processor.MovieLister
{
    /// <summary>
    /// 筛选MPG类型的电影
    /// </summary>
    public class MPGMovieLister
    {
        private readonly IMovieFinder _movieFinder;

        public MPGMovieLister(IMovieFinder movieFinder)
        {
            _movieFinder = movieFinder;
        }

        public Movie[] GetMPG()
        {
            var allMovies = _movieFinder.FindAll();
            return allMovies.Where(m => m.Name.EndsWith(".MPG")).ToArray();
        }
    }
}
