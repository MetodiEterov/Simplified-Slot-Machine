using Entities.Common;

namespace Entities.Models
{
    /// <summary>
    /// SlotMachineModel class
    /// </summary>
    public class SlotMachineModel
    {
        public SlotMachineModel()
        {
            Sources = new ImageEntity[ConstantsClass.rowsNumber];
        }

        public bool IsGameRunning { get; set; } = false;

        public bool IsGameOver { get; set; } = false;

        public double Balance { get; set; } = 0.0;

        public double Bet { get; set; } = 0.0;

        public double Won { get; set; } = 0.0;

        public ImageEntity[] Sources { get; set; }
    }
}
