using System;

using Entities.Common;
using Entities.Contracts;
using Entities.Models;

using Microsoft.AspNetCore.Mvc;

using SlotMachineLayer.Controllers;

using Xunit;

namespace SlotMachineUnitTests
{
    /// <summary>
    /// SlotMachineUnitTests test class
    /// </summary>
    public class SlotMachineUnitTests
    {
        private readonly HomeController _homecontroller;
        private readonly ISlotMachine _slotmachine;

        public SlotMachineUnitTests()
        {
            _slotmachine = new BusinessLayer.SlotMachine();
            _homecontroller = new HomeController(_slotmachine);
        }

        [Fact]
        public void GetRoundNumber_InRange()
        {
            int test = new Random().Next(0, ConstantsClass.SymbolWeights.Count);
            Assert.InRange<int>(test, 0, ConstantsClass.SymbolWeights.Count);
        }

        [Fact]
        public void IndexAction_ReturnsIndexView()
        {
            SlotMachineModel model = new SlotMachineModel();

            var result = _homecontroller.Index(model) as ViewResult;

            // Check for the type of IActionResult that is normally
            // returned from ASP.NET Core MVC Controller classes.
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public void TestCalculateProfit_Example()
        {
            SlotMachineModel testSlotMachine = new SlotMachineModel();
            ImageEntity row1 = new ImageEntity
            {
                LeftSource = ConstantsClass.SymbolImageSources[1],
                LeftCoefficent = ConstantsClass.SymbolCoefficients[1],
                MiddleSource = ConstantsClass.SymbolImageSources[0],
                MiddleCoefficent = ConstantsClass.SymbolCoefficients[0],
                RightSource = ConstantsClass.SymbolImageSources[0],
                RightCoefficent = ConstantsClass.SymbolCoefficients[0]
            };
            testSlotMachine.Sources[0] = row1;

            ImageEntity row2 = new ImageEntity
            {
                LeftSource = ConstantsClass.SymbolImageSources[0],
                LeftCoefficent = ConstantsClass.SymbolCoefficients[0],
                MiddleSource = ConstantsClass.SymbolImageSources[0],
                MiddleCoefficent = ConstantsClass.SymbolCoefficients[0],
                RightSource = ConstantsClass.SymbolImageSources[0],
                RightCoefficent = ConstantsClass.SymbolCoefficients[0]
            };
            testSlotMachine.Sources[1] = row2;

            ImageEntity row3 = new ImageEntity
            {
                LeftSource = ConstantsClass.SymbolImageSources[0],
                LeftCoefficent = ConstantsClass.SymbolCoefficients[0],
                MiddleSource = ConstantsClass.SymbolImageSources[2],
                MiddleCoefficent = ConstantsClass.SymbolCoefficients[2],
                RightSource = ConstantsClass.SymbolImageSources[1],
                RightCoefficent = ConstantsClass.SymbolCoefficients[1]
            };
            testSlotMachine.Sources[2] = row3;

            ImageEntity row4 = new ImageEntity
            {
                LeftSource = ConstantsClass.SymbolImageSources[2],
                LeftCoefficent = ConstantsClass.SymbolCoefficients[2],
                MiddleSource = ConstantsClass.SymbolImageSources[0],
                MiddleCoefficent = ConstantsClass.SymbolCoefficients[0],
                RightSource = ConstantsClass.SymbolImageSources[0],
                RightCoefficent = ConstantsClass.SymbolCoefficients[0]
            };
            testSlotMachine.Sources[3] = row4;

            testSlotMachine.Bet = 10;
            testSlotMachine.Balance = 200;

            _slotmachine.CalculateProfit(ref testSlotMachine);

            Assert.Equal(20, testSlotMachine.Won);
        }
    }
}
