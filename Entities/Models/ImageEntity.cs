namespace Entities.Models
{
    /// <summary>
    /// ImageEntity class
    /// </summary>
    public class ImageEntity
    {
        public string LeftSource { get; set; }

        public double LeftCoefficent { get; set; } = 0.0;

        public string MiddleSource { get; set; }

        public double MiddleCoefficent { get; set; } = 0.0;

        public string RightSource { get; set; }

        public double RightCoefficent { get; set; } = 0.0;
    }
}
