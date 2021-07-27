using System;
using System.Collections.Generic;
using System.Linq;

using Entities.Common;
using Entities.Contracts;
using Entities.Models;

namespace BusinessLayer
{
    /// <summary>
    /// This class contains the whole business logic
    /// </summary>
    public class SlotMachine : ISlotMachine
    {
        /// <summary>
        /// This method calculates the profit of the current game
        /// </summary>
        /// <param name="bet"></param>
        public void CalculateProfit(ref SlotMachineModel bet)
        {
            double profit = 0;
            foreach (var item in bet.Sources)
            {
                double sum = Math.Round(this.SumCoefficients(item), 2);

                switch (sum)
                {
                    case 0.4:
                    case 0.6:
                    case 0.8:
                    case 2.4:
                        profit += sum * bet.Bet;
                        break;

                    case 1.2:
                        if (new List<double> { item.LeftCoefficent, item.MiddleCoefficent, item.RightCoefficent }
                            .Find(x => x == 0.8) != 0.8) profit += sum * bet.Bet;
                        break;

                    case 1.8:
                        if ((this.AllEqual(item.LeftCoefficent, item.MiddleCoefficent, item.RightCoefficent))) profit += sum * bet.Bet;
                        break;

                    case 1.6:
                        if (new List<double> { item.LeftCoefficent, item.MiddleCoefficent, item.RightCoefficent }
                            .Find(x => x == 0.4) != 0.4) profit += sum * bet.Bet;
                        break;

                    default:
                        break;
                }

            }

            bet.Won = Math.Round(profit, 2);
        }

        /// <summary>
        /// This method returns the betting coefficents
        /// </summary>
        /// <returns></returns>
        public SlotMachineModel GetNewBettingCoefficients()
        {
            var imageSources = new SlotMachineModel();

            for (int i = 0; i < ConstantsClass.rowsNumber; i++)
            {
                var source = GetSource();

                imageSources.Sources[i] = source;
            }

            return imageSources;
        }

        /// <summary>
        /// CalculateBalance method
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bet"></param>
        /// <returns></returns>
        public SlotMachineModel CalculateBalance(SlotMachineModel model, SlotMachineModel bet)
        {
            if (model.Bet != 0)
            {
                bet.Bet = model.Bet;

                this.CalculateProfit(ref bet);

                bet.Balance = ((model.Balance - model.Bet + bet.Won) >= 0) ? Math.Round((model.Balance - model.Bet + bet.Won), 2, MidpointRounding.AwayFromZero) : 0;
                bet.Bet = (bet.Balance != 0) ? model.Bet : 0;
                bet.IsGameRunning = (bet.Balance != 0) ? model.IsGameRunning : false;
                bet.IsGameOver = (bet.Balance == 0) ? true : false;
            }

            return bet;
        }

        /// <summary>
        /// This method checks the coefficents weight
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private bool AllEqual(params double[] values)
        {
            if (values == null || values.Length == 0) return true;

            return values.All(v => v.Equals(values[0]));
        }

        /// <summary>
        /// Returns random number in a specific range 
        /// </summary>
        /// <returns></returns>
        private int GetRandomNumberInRange()
        {
            return new Random().Next(0, ConstantsClass.SymbolWeights.Count);
        }

        /// <summary>
        /// Returns a new image entity
        /// </summary>
        /// <returns></returns>
        private ImageEntity GetSource()
        {
            return new ImageEntity
            {
                LeftSource = ConstantsClass.SymbolImageSources[ConstantsClass.SymbolCoefficients.IndexOf(ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()])],
                LeftCoefficent = ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()],
                MiddleSource = ConstantsClass.SymbolImageSources[ConstantsClass.SymbolCoefficients.IndexOf(ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()])],
                MiddleCoefficent = ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()],
                RightSource = ConstantsClass.SymbolImageSources[ConstantsClass.SymbolCoefficients.IndexOf(ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()])],
                RightCoefficent = ConstantsClass.SymbolWeights[this.GetRandomNumberInRange()]
            };
        }

        /// <summary>
        /// This method sums coefficents
        /// </summary>
        /// <param name="coefficents"></param>
        /// <returns></returns>
        private double SumCoefficients(ImageEntity coefficents)
        {
            return coefficents.LeftCoefficent + coefficents.MiddleCoefficent + coefficents.RightCoefficent;
        }
    }
}
