using Entities.Models;
using Entities.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace SlotMachineLayer.Controllers
{
    /// <summary>
    /// HomeController class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ISlotMachine _slotmachine;

        public HomeController(ISlotMachine slotmachine)
        {
            _slotmachine = slotmachine;
        }

        /// <summary>
        /// Index method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Index(SlotMachineModel model = null)
        {
            var bet = _slotmachine.GetNewBettingCoefficients();
            return View(_slotmachine.CalculateBalance(model, bet));
        }
    }
}
