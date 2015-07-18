using System.Collections.Generic;

namespace Hell1024.model.Tests
{
    public static class CoreGenerator
    {
        static  public Core generateCore()
        {
            var c = new Core(5);
            c[0] = new List<long>() { 2, 2, 2, 0, 2 };
            c[1] = new List<long>() { 2, 2, 0, 2, 2 };
            c[2] = new List<long>() { 2, 0, 2, 0, 2 };
            c[3] = new List<long>() { 0, 0, 0, 2, 2 };
            c[4] = new List<long>() { 0, 0, 2, 4, 2 };
            c[5] = new List<long>() { 0, -1, 0, -1, -1 };
            c[6] = new List<long>() { -2, -2, -2, -2, -2 };
            c[7] = new List<long>() { -2, -2, -2, -2, -2 };
            c[8] = new List<long>() { -2, -2, -2, -2, -2 };
            c[9] = new List<long>() { -2, -2, -2, -2, -2 };
            c[10] = new List<long>() { -2, -2, -2, -2, -2 };
            return c;
        }
         
    }
}