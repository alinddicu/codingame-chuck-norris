namespace codingame.chuck.norris.test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class SerieTest
    {
        [TestMethod]
        public void When1ZeroThen00Space0()
        {
            var serie = new Serie("0");
            serie.Increment();

            Check.That(serie.ToString()).IsEqualTo("00 0");
        }

        [TestMethod]
        public void When1OneThen0Space0()
        {
            var serie = new Serie("1");
            serie.Increment();

            Check.That(serie.ToString()).IsEqualTo("0 0");
        }
    }
}
