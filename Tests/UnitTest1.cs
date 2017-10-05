using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrekNextGeneration;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        Shield shield;

        [TestInitialize]
        public void MakeNewShield()
        {
            shield = new Shield();
        }

        [TestMethod]
        public void ShieldsDownByDefault()
        {
            Assert.IsFalse(shield.IsUp);
        }

        [TestMethod]
        public void ShieldsAreUpAfterWeRaiseThem()
        {
            shield.Raise();
            Assert.IsTrue(shield.IsUp);
        }

        [TestMethod]
        public void ShieldChargedByDefault()
        {
            Assert.AreEqual(Shield.StartingEnergy, shield.Energy);
        }

        [TestMethod]
        public void ShieldStartingEnergyIsTenThousand()
        {
            Assert.AreEqual(10000, Shield.StartingEnergy);
        }

        [TestMethod]
        public void ShieldIsAtMinimum()
        {
            //Given
            shield.Energy = 0;
            //When
            shield.TakeHit(10);
            //Then
            Assert.AreEqual(0, shield.Energy);
        }

        [TestMethod]
        public void ReducesToMinimum()
        {
            //Given
            shield.Energy = 9;
            //When
            shield.TakeHit(10);
            //Then
            Assert.AreEqual(0, shield.Energy);
        }

        [TestMethod]
        public void ShieldReductionIsCorrect()
        {
            //Given
            shield.Energy = 21;
            //When
            shield.TakeHit(10);
            //Then
            Assert.AreEqual(11, shield.Energy);
        }

        [TestMethod]
        public void ShieldIsDown()
        {
            Assert.IsFalse(shield.IsUp);
        }

        [TestMethod]
        public void TransferEnergyFromShipToShield()
        {
            Ship ship = new Ship();
            //Given
            shield.Energy = 10;
            //When
            shield.TransferEnergy(shield.ShieldEnergyCost);
            //Then
            Assert.AreEqual(0, shield.Energy);
        }
    }
}
