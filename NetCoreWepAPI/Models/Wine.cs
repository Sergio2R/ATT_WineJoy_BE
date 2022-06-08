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
        public float Swetness { get; set; }
        public float Acidity { get; set; }
        public float Alcohol { get; set; }
        public string Notes { get; set; }

    }
}
