using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnergyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyLib.Tests {
    [TestClass()]
    public class EnergyConverterTests {
        [TestMethod()]
        public void ToJouleTest(){
            EnergyData energy = new EnergyData();
            energy.EnergyValue = EnergyConverter.ToCalorie(534);
            Assert.AreEqual(Math.Round(534/4.2, 2), energy.EnergyValue);

        }

        [TestMethod()]
        public void ToCalorieTest() {
            Assert.Fail();
        }
    }
}