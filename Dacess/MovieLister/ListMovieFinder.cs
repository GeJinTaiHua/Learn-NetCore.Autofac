using Entity;
using System.Collections.Generic;

namespace Processor.MovieLister
{
    public class ListMovieFinder : IMovieFinder
    {
        /// <summary>
        /// 查询所有电影类型
        /// </summary>
        public List<Movie> FindAll()
        {
            return new List<Movie>
                      {
                          new Movie
                              {
                                  Name = "Die Hard.wmv"
                              },
                          new Movie
                              {
                                  Name = "My Name is John.MPG"
                              }
                      };
        }
    }
}
