namespace codingame.chuck.norris.test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class StringToBinaryConverterTest
    {
        private StringToBinaryConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new StringToBinaryConverter();
        }

        [TestMethod]
        public void WhenCThenRetrun1000011()
        {
            var expected = "1000011";

            Check.That(_converter.Execute("C")).IsEqualTo(expected);
        }

        [TestMethod]
        public void WhenCCThenRetrun10000111000011()
        {
            var expected = "10000111000011";

            Check.That(_converter.Execute("CC")).IsEqualTo(expected);
        }
    }
}
