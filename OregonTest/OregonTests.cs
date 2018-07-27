using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oregon;

namespace OregonTests
{
    [TestClass]
    public class OregonTesting
    {
        [TestClass]
        public class WagonTests
        {
            [TestMethod]
            public void Should_Not_Travel_Without_Oxen()
            {
                var wagon = new Wagon();

                wagon.Start();
                wagon.HasOxen = false;

                wagon.Update();

                Assert.AreEqual(wagon.DistanceTraveled,0);

            }

            [TestMethod]
            public void Should_Travel_With_Oxen()
            {
                var wagon = new Wagon();

                wagon.Start();
                wagon.HasOxen = true;

                wagon.Update();

                Assert.AreEqual(wagon.DistanceTraveled, 1);

            }
        }

    }
}
