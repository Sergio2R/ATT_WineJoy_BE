using System;

namespace NetCoreWepAPI.Models
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Clasification { get; set; }
        public int Year { get; set; }
        public string Aroma { get; set; }
        public int Swetness { get; set; }
        public int Acidity { get; set; }
        public int Alcohol { get; set; }
        public string Notes { get; set; }

    }
}
