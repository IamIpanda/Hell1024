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
    public class BehaveTests
    {
        [TestMethod()]
        public void MoveLeftTest()
        {
            var c = CoreGenerator.generateCore();
            var m = new Movement();
            var b = new Behave(m, c);
            Console.WriteLine(@"From: ");
            Console.WriteLine(c.ToString());
            Console.WriteLine(@"To: ");
            Console.Write(b.MoveLeft().ToString());
            Console.WriteLine(@"Moves: ");
            Console.Write(m.ToString());
        }

        [TestMethod()]
        public void MoveRightTest()
        {
            var c = CoreGenerator.generateCore();
            var m = new Movement();
            var b = new Behave(m, c);
            Console.WriteLine(@"From: ");
            Console.WriteLine(c.ToString());
            Console.WriteLine(@"To: ");
            Console.Write(b.MoveRight().ToString());
            Console.WriteLine(@"Moves: ");
            Console.Write(m.ToString());

        }

        [TestMethod()]
        public void MoveUpTest()
        {
            var c = CoreGenerator.generateCore();
            var m = new Movement();
            var b = new Behave(m, c);
            Console.WriteLine(@"From: ");
            Console.WriteLine(c.ToString());
            Console.WriteLine(@"To: ");
            Console.Write(b.MoveUp().ToString());
            Console.WriteLine(@"Moves: ");
            Console.Write(m.ToString());

        }

        [TestMethod()]
        public void MoveDownTest()
        {
            var c = CoreGenerator.generateCore();
            var m = new Movement();
            var b = new Behave(m, c);
            Console.WriteLine(@"From: ");
            Console.WriteLine(c.ToString());
            Console.WriteLine(@"To: ");
            Console.Write(b.MoveDown().ToString());
            Console.WriteLine(@"Moves: ");
            Console.Write(m.ToString());
        }
    }
}
