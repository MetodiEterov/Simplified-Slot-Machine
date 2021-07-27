using System.Collections.Generic;

namespace Entities.Common
{
    /// <summary>
    /// This class contains different constants 
    /// </summary>
    public static class ConstantsClass
    {
        public static int rowsNumber = 4;

        public static List<string> SymbolImageSources { get; } = new List<string>()
        {
        "/images/apple.png", "/images/banana.png", "/images/wildcard.png", "/images/pineapple.png"
        };

        public static List<double> SymbolWeights { get; } = new List<double>()
        {
          0, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.8, 0.8, 0.8
        };

        public static List<double> SymbolCoefficients { get; } = new List<double>()
        {
          0.4, 0.6, 0, 0.8
        };
    }
}
