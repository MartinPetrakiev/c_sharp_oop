using NUnit.Framework;
using Lambda_Core.Services;
using Lambda_Core.Interfaces;

namespace Lambda_Core.Test
{
    [TestFixture]
    public class LambdaCoreTests
    {
        [Test]
        public void CreateCore_ValidInput_ReturnsTrueAndAddsCore()
        {
            // Arrange
            var powerPlant = new LambdaCorePowerPlant();
            ICoreService coreService = new CoreService();
            Core currentCore;

            // Act
            bool result = powerPlant.CreateCore("System", 100, coreService, out currentCore);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(currentCore);
            Assert.AreEqual(1, powerPlant.Cores.Count);
        }
    }

}
