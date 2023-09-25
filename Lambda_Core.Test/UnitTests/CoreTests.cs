using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lambda_Core;

namespace Lambda_Core.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void AddFragment_CoolingFragment_ReducesPressure()
        {
            // Arrange
            Core core = new SystemCore('A', 100);
            Fragment coolingFragment = new CoolingFragment("CoolingFrag", 10);

            // Act
            bool success = core.AddFragment(coolingFragment);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(-10, core.Pressure);
        }

        [TestMethod]
        public void AddFragment_NuclearFragment_IncreasesPressureAndReducesDurability()
        {
            // Arrange
            Core core = new SystemCore('A', 100);
            Fragment nuclearFragment = new NuclearFragment("NuclearFrag", 20);

            // Act
            bool success = core.AddFragment(nuclearFragment);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(20, core.Pressure);
            Assert.AreEqual(80, (int)core.Durability);
        }

        [TestMethod]
        public void AddFragment_NuclearFragment_DurabilityExceedsMaxValue()
        {
            // Arrange
            Core core = new SystemCore('A', uint.MaxValue);
            Fragment nuclearFragment = new NuclearFragment("NuclearFrag", 10);

            // Act
            bool success = core.AddFragment(nuclearFragment);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(10, core.Pressure);
            Assert.AreEqual(4294967285, core.Durability);
        }

        [TestMethod]
        public void IsCritical_DurabilityAboveZero_ReturnsNormal()
        {
            // Arrange
            Core core = new SystemCore('A', 100);

            // Act
            string status = core.IsCritical();

            // Assert
            Assert.AreEqual("NORMAL", status);
        }

        [TestMethod]
        public void IsCritical_DurabilityZero_ReturnsCritical()
        {
            // Arrange
            Core core = new SystemCore('A', 0);

            // Act
            string status = core.IsCritical();

            // Assert
            Assert.AreEqual("CRITICAL", status);
        }
    }
}

