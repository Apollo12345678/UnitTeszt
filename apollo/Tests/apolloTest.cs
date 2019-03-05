using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace apollo.Tests
{
    [TestFixture]
    class apolloTest
    {
        JaratKezelo b;

        [SetUp]
        public void SetUp()
        {
            b = new JaratKezelo();
        }

        [Test]
        public void UjJarat1()
        {
            Assert.AreEqual(0, b.getListDarab());
        }

        [Test]
        public void UjJarat2()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("1234", "Paris", "New York", new DateTime(2020, 5, 4, 10, 45, 0));
            b.UjJarat("1234", "Stockholm", "Bukarest", new DateTime(2022, 6, 3, 9, 35, 0));
            Assert.AreEqual(1, b.getListDarab());
        }

        [Test]
        public void UjJarat3()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("1234", "Paris", "New York", new DateTime(2020, 5, 4, 10, 45, 0));
            b.UjJarat("9876", "Paris", "New York", new DateTime(2020, 5, 4, 10, 45, 0));
            Assert.AreEqual(2, b.getListDarab());
        }

        [Test]
        public void Keses1()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            b.Keses("1234", 10);
            Assert.AreEqual(new DateTime(2019, 3, 1, 10, 55, 0), b.MikorIndul("1234"));
        }

        [Test]
        public void Keses2()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            b.Keses("1234", 30);
            b.Keses("1234", -10);
            Assert.AreEqual(new DateTime(2019, 3, 1, 11, 05, 0), b.MikorIndul("1234"));
        }

        [Test]
        public void Keses3Kiveteldob()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));          
            Assert.Throws<JaratKezelo.NegativKesesException>(
                () =>
                {
                    b.Keses("1234", -30);
                }
            );
        }

        [Test]
        public void MikorIndul1()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            Assert.AreEqual(new DateTime(2019, 3, 1, 10, 45, 0), b.MikorIndul("1234"));
        }

        [Test]

        public void MikorIndul2()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            Assert.AreNotEqual(b.MikorIndul("1234"), b.MikorIndul("2456"));
        }

        [Test]
        public void JaratokRepuloterrol1()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("2345", "Budapest", "Milano", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("3456", "Paris", "Budapest", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("4567", "Barcelona", "Berlin", new DateTime(2019, 3, 1, 10, 45, 0));
            List<string> list = new List<string>();
            list.Add("1234");
            list.Add("2345");
            Assert.AreEqual(list, b.JaratokRepuloterrol("Budapest"));
        }

        [Test]
        public void JaratokRepuloterrol2()
        {
            List<string> list = new List<string>();
            Assert.AreEqual(list, b.JaratokRepuloterrol("Budapest"));
        }

        [Test]
        public void JaratokRepuloterrol3()
        {          
            b.UjJarat("3456", "Paris", "Budapest", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("4567", "Barcelona", "Berlin", new DateTime(2019, 3, 1, 10, 45, 0));
            b.UjJarat("2345", "Budapest", "Milano", new DateTime(2019, 3, 1, 10, 45, 0));
            List<string> list = new List<string>();
            list.Add("1234");
            list.Add("2345");
            Assert.AreNotEqual(list, b.JaratokRepuloterrol("Budapest"));
        }
    }
}
