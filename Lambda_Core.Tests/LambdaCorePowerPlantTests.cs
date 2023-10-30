using Lambda_Core.Enumerators;
using Moq;
using System.Reflection;

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

            // Act
            bool result = powerPlant.CreateCore("System", 100);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(powerPlant.CurrentSelectedCore);
            Assert.AreEqual(1, powerPlant.Cores.Count);
        }

        [Test]
        public void RemoveCore_ExistingCore_RemovesCore()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            powerPlant.CreateCore("System", 100);

            // Act
            bool result = powerPlant.RemoveCore("A");

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, powerPlant.Cores.Count);
        }

        [Test]
        public void SelectCore_ExistingCore_ReturnsTrueAndSetsCurrentCore()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            powerPlant.CreateCore("System", 100);

            // Act
            bool result = powerPlant.SelectCore("A");

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(powerPlant.CurrentSelectedCore);
        }

        [Test]
        public void SelectCore_NonExistingCore_ReturnsFalseAndSetsCurrentCoreToNull()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            bool result = powerPlant.SelectCore("Non Existent Core");

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(powerPlant.CurrentSelectedCore);
        }

        [Test]
        public void CreateFragment_NuclearFragment_ReturnsFragmentOfTypeNuclearAndChecksPropertie()
        {
            // Arrange
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            var dynamicCreateFragment = powerPlant.GetType().GetMethod("CreateFragment", BindingFlags.NonPublic | BindingFlags.Instance);

            Fragment newNuclearFragment = dynamicCreateFragment.Invoke(powerPlant, new object[] { "Nuclear", "B12", 200 }) as Fragment;

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
            var dynamicCreateFragment = powerPlant.GetType().GetMethod("CreateFragment", BindingFlags.NonPublic | BindingFlags.Instance);
           
            Fragment newColingFragment = dynamicCreateFragment.Invoke(powerPlant, new object[] { "Cooling", "C12", 200 }) as Fragment;

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
            var dynamicCreateFragment = powerPlant.GetType().GetMethod("CreateFragment", BindingFlags.NonPublic | BindingFlags.Instance);

            Fragment nullFragment1 = dynamicCreateFragment.Invoke(powerPlant, new object[] { "a", "B12", -400 }) as Fragment;
            Fragment nullFragment2 = dynamicCreateFragment.Invoke(powerPlant, new object[] { "Cooling", "B12", -1100 }) as Fragment;
            Fragment nullFragment3 = dynamicCreateFragment.Invoke(powerPlant, new object[] { "Cooling", "B12", -1100 }) as Fragment;

            // Assert
            Assert.AreEqual(null, nullFragment1);
            Assert.AreEqual(null, nullFragment2);
            Assert.AreEqual(null, nullFragment3);
        }

        [Test]
        public void AttachFragment_ValidInput_ReturnsTrueAndAttachesFragment()
        {
            // Arrange
            SystemCore core = new SystemCore('A',(uint)2000);
            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();
            powerPlant.CurrentSelectedCore = core;

            // Act
            bool success = powerPlant.AttachFragment("Cooling", "C12", 200);

            // Assert
            Assert.IsTrue(success);
            Assert.AreEqual(1, core.Fragments.Count);
        }

        [Test]
        public void AttachFragment_InvalidPressureAffection_ReturnsFalseAndDoesNotAttachFragment()
        {
            // Arrange
            SystemCore core = new SystemCore('A', (uint)2000);
            var powerPlant = new LambdaCorePowerPlant();
            powerPlant.CurrentSelectedCore = core;

            // Act
            bool success = powerPlant.AttachFragment("Cooling", "C12", -200);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(0, core.Fragments.Count);
        }

        [Test]
        public void AttachFragment_FragmentCreationFails_ReturnsFalseAndDoesNotAttachFragment()
        {
            // Arrange
            SystemCore core = new SystemCore('A', (uint)2000);
            var powerPlant = new LambdaCorePowerPlant();
            powerPlant.CurrentSelectedCore = core;

            MethodInfo createFragmentMethod = typeof(LambdaCorePowerPlant).GetMethod("CreateFragment", BindingFlags.NonPublic | BindingFlags.Instance);
            createFragmentMethod.Invoke(powerPlant, new object[] { "Cooling", "C12", -200 });

            // Act
            bool success = powerPlant.AttachFragment("Cooling", "C12", -200);

            // Assert
            Assert.IsFalse(success);
            Assert.AreEqual(0, core.Fragments.Count);
        }

        [Test]
        public void DetachFragment_WithFragments_ReturnsTrueAndRemovesFragment()
        {
            // Arrange
            SystemCore systemCore = new SystemCore('A', (uint)2000);
            NuclearFragment fragment = new NuclearFragment("N1", FragmentType.Nuclear, 100);
            systemCore.AddFragment(fragment);

            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            bool success = powerPlant.DetachFragment(systemCore);

            // Assert
            Assert.IsTrue(success);
            Assert.IsEmpty(systemCore.Fragments);
        }

        [Test]
        public void DetachFragment_WithoutFragments_ReturnsFalse()
        {
            // Arrange
            var coreMock = new Mock<SystemCore>('A', (uint)2000);

            LambdaCorePowerPlant powerPlant = new LambdaCorePowerPlant();

            // Act
            bool result = powerPlant.DetachFragment(coreMock.Object);

            // Assert
            Assert.IsFalse(result);
            Assert.IsEmpty(coreMock.Object.Fragments);
        }
    }
}