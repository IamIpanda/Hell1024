using System.Collections.Generic;

namespace Hell1024.model.Tests
{
    public static class CoreGenerator
    {
        static  public Core generateCore()
        {
            var c = new Core(5)
            {
                [0] = new List<long>() {0, 2, 2, 0, 2},
                [1] = new List<long>() {4, 2, 0, 2, 2},
                [2] = new List<long>() {-4, 0, 2, 0, 2},
                [3] = new List<long>() {4, 0, 0, 2, 2},
                [4] = new List<long>() {0, 0, 2, 4, 2},
            };
            return c;
        }
         
    }
}