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
    public class ChuckNorrisBinaryConverterTest
    {
        private ChuckNorrisBinaryConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new ChuckNorrisBinaryConverter();
        }

        [TestMethod]
        public void GivenCThenReturn0Space0Space00Space0000Space0Space00()
        {
            Check.That(_converter.Execute("C")).IsEqualTo("0 0 00 0000 0 00");
        }

        [TestMethod]
        public void GivenPercentThenReturnSomething()
        {
            // 100101
            //                                             0 0 00 00 0 0 00 0 0 0
            Check.That(_converter.Execute("%")).IsEqualTo("0 0 00 00 0 0 00 0 0 0");
        }

        [TestMethod]
        public void GivenChucksMessageThenReturnSomething()
        {
            var message = "Chuck Norris' keyboard has 2 keys: 0 and white space.";

            var result = _converter.Execute(message);

            Check.That(result)
                .IsEqualTo("0 0 00 0000 0 0000 00 0 0 0 00 000 0 000 00 0 0 0 00 0 0 000 00 000 0 0000 00 0 0 0 00 0 0 00");
        }
    }
}
