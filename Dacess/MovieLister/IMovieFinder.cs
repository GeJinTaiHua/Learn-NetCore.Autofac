using Entity;
using System.Collections.Generic;

namespace Processor.MovieLister
{
    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }
}
