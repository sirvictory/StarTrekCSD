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
		public void ReduceShieldEnergyToMinimum()
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
        public void EnsureShipHasSufficientEnergyForShield()
        {
            Ship ship = new Ship();

            //When
            bool sufficientEnergy = ship.SufficientEnergyToTransferToShield(1000);
            //Then
            Assert.IsTrue(sufficientEnergy);
        }

        [TestMethod]
        public void EnergyRequestExceedsShipEnergyReserve()
        {
            Ship ship = new Ship();

            //When
            bool insufficientEnergy = ship.SufficientEnergyToTransferToShield(100000);
            //Then
            Assert.IsFalse(insufficientEnergy);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void VerifyEnergyTransferCannotBeNegative()
        {
            Ship ship = new Ship();

            //Given
            ship.shield.Energy = 9000;
            //When
            ship.TransferEnergyToShield(-500);
            //Then
            Assert.AreEqual(9000, ship.shield.Energy);
        }

		[TestMethod]
		public void TransferEnergyFromShipToShield()
		{
			Ship ship = new Ship();

			//Given
			ship.shield.Energy = 9000;
			//When
            ship.TransferEnergyToShield(500);
			//Then
			Assert.AreEqual(9500, ship.shield.Energy);
        }


    }
}
