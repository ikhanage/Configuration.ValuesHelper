using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configuration.ValuesHelper;
using System.Configuration;
using System;

namespace Configuration.ValuesHelperTestsProject
{
    [TestClass]
    public class UnitTest1
    {
        const string intKey = "TestInt";
        const string doubleKey = "TestDouble";
        const string stringKey = "TestString";
        const string dmykey = "TestDateStringddmmyyyy";
        const string dmyhmkey = "TestDateStringddmmyyyyhhmm";
        const string noSetting = "NoSettings";

        [TestMethod]
        public void CorrectInt()
        {
            var expectedResult = 1;

            var actualResult = ConfigValue.GetAsInt(intKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException), "The value of TestString was not an int.")]
        public void NotInt()
        {
            var actualResult = ConfigValue.GetAsInt(stringKey);           
        }

        [TestMethod]
        public void CorrectIntNull()
        {
            var expectedResult = 1;

            var actualResult = ConfigValue.GetAsNullableInt(intKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void NotIntNull()
        {
            var actualResult = ConfigValue.GetAsNullableInt(stringKey);

            Assert.AreEqual(null, actualResult);
        }

        [TestMethod]
        public void CorrectDouble()
        {
            var expectedResult = 5.0;

            var actualResult = ConfigValue.GetAsDouble(doubleKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException), "The value of TestString was not a double.")]
        public void IncorrectDouble()
        {
            var actualResult = ConfigValue.GetAsDouble(stringKey);
        }

        [TestMethod]
        public void CorrectDoubleNull()
        {
            var expectedResult = 5.0;

            var actualResult = ConfigValue.GetAsNullableDouble(doubleKey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IncorrectDoubleNull()
        {
            var actualResult = ConfigValue.GetAsNullableDouble(stringKey);

            Assert.AreEqual(null, actualResult);
        }

        [TestMethod]
        public void CorrectDateTime()
        {
            var expectedResult = DateTime.Parse("15/12/1990 00:00:00");

            var actualResult = ConfigValue.GetAsDateTime(dmykey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationException), "The value of TestString was not a double.")]
        public void IncorrectDateTime()
        {
            var actualResult = ConfigValue.GetAsDateTime(stringKey);
        }

        [TestMethod]
        public void CorrectDateTimeNull()
        {
            var expectedResult = DateTime.Parse("15/12/1990 00:00:00");

            var actualResult = ConfigValue.GetAsNullableDateTime(dmykey);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IncorrectDateTimeNull()
        {
            var actualResult = ConfigValue.GetAsNullableDateTime(stringKey);

            Assert.AreEqual(null, actualResult);
        }

        [TestMethod]
        public void ValueExistsCheck()
        {
            var actualResult = ConfigValue.CheckSettingExists(stringKey);

            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        public void ValueNotExistsCheck()
        {
            var actualResult = ConfigValue.CheckSettingExists(noSetting);

            Assert.AreEqual(false, actualResult);
        }
    }
}