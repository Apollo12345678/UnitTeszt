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
        public void UjJarat()
        {
            b.UjJarat("1234", "Budapest", "Madrid", new DateTime(2019, 3,1,10,45,0));
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
    }
}
