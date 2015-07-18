using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hell1024.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Hell1024.model.Tests
{
    [TestClass()]
    public class MovementTests
    {
        [TestMethod()]
        public void RunTest()
        {

        }

        [TestMethod()]
        public void ToStringTest()
        {
            var m = new Movement();
            m.Appear(0, 0, 2, 0);
            m.Appear(0, 0, 4, 1);
            m.Appear(0, 0, 8, 2);
            m.Disappear(3, 5, 0);
            m.Move(4, 2, 4, 5, 1);
            Console.WriteLine(m.ToString());
        }
    }
}
