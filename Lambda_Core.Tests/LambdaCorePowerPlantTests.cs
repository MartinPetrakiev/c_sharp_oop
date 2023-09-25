using Lambda_Core.Enumerators;
using Lambda_Core.Interfaces;
using Lambda_Core.Services;

namespace Lambda_Core.Tests
{
    [TestFixture]
    public class LambdaCorePowerPlantTests
    {
        [Test]
        public void CreateCore_ValidInput_ReturnsTrueAndAddsCore()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            ICoreService coreService = new CoreService();
            Core currentCore;

            // Act
            bool result = powerPlant.CreateCore("System", 100, coreService, out currentCore);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(currentCore);
            Assert.AreEqual(1, powerPlant.Cores.Count);
        }

        [Test]
        public void RemoveCore_ExistingCore_RemovesCore()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            ICoreService coreService = new CoreService();
            Core currentCore;
            powerPlant.CreateCore("System", 100, coreService, out currentCore);

            // Act
            bool result = powerPlant.RemoveCore(currentCore.Name.ToString());

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, powerPlant.Cores.Count);
        }

        [Test]
        public void SelectCore_ExistingCore_ReturnsTrueAndSetsCurrentCore()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            ICoreService coreService = new CoreService();
            Core currentCore;
            powerPlant.CreateCore("System", 100, coreService, out currentCore);

            // Act
            bool result = powerPlant.SelectCore(currentCore.Name.ToString(), out Core selectedCore);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(selectedCore);
            Assert.AreEqual(currentCore, selectedCore);
        }

        [Test]
        public void SelectCore_NonExistingCore_ReturnsFalseAndSetsCurrentCoreToNull()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            bool result = powerPlant.SelectCore("Non Existent Core", out Core selectedCore);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(selectedCore);
        }

        [Test]
        public void CreateFragment_NuclearFragment_ReturnsFragmentOfTypeNuclearAndChecksPropertie()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            Fragment newNuclearFragment = powerPlant.CreateFragment("Nuclear", "B12", 200);

            // Assert
            Assert.IsNotNull(newNuclearFragment);
            Assert.AreEqual(FragmentType.Nuclear, newNuclearFragment.FragmentType);
            Assert.AreEqual(400, newNuclearFragment.PressureAffection);
        }

        [Test]
        public void CreateFragment_CoolingFragment_ReturnsFragmentOfTypeCoolingAndChecksProperties()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            Fragment newColingFragment = powerPlant.CreateFragment("Cooling", "C12", 200);

            // Assert
            Assert.IsNotNull(newColingFragment);
            Assert.AreEqual(FragmentType.Cooling, newColingFragment.FragmentType);
            Assert.AreEqual(600, newColingFragment.PressureAffection);
        }

        [Test]
        public void CreateFragment_NullFragment_ReturnsNull()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            Fragment nullFragment1 = powerPlant.CreateFragment("a", "B12", -400);
            Fragment nullFragment2 = powerPlant.CreateFragment("Cooling", "B12", -1100);
            Fragment nullFragment3 = powerPlant.CreateFragment("Cooling", "B12", -1100);

            // Assert
            Assert.AreEqual(null, nullFragment1);
            Assert.AreEqual(null, nullFragment2);
            Assert.AreEqual(null, nullFragment3);
        }
    }
}