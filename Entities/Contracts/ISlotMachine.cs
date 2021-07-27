using Entities.Models;

namespace Entities.Contracts
{
    /// <summary>
    /// ISlotMachine interface
    /// </summary>
    public interface ISlotMachine
    {
        /// <summary>
        /// GetNewBettingCoefficients method contract
        /// </summary>
        /// <returns></returns>
        SlotMachineModel GetNewBettingCoefficients();

        /// <summary>
        /// CalculateBalance method contract
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bet"></param>
        /// <returns></returns>
        SlotMachineModel CalculateBalance(SlotMachineModel model, SlotMachineModel bet);

        /// <summary>
        /// CalculateProfit method contract
        /// </summary>
        /// <param name="bet"></param>
        void CalculateProfit(ref SlotMachineModel bet);
    }
}
