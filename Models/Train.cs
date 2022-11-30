using System.ComponentModel.DataAnnotations;

namespace StoredProc_Latt.Models
{
    public class Train
    {
        [Key]
        public string Color { get; set; }
        public string Brand { get; set; }

        public string Fuel { get; set; }
        public int Price { get; set; }

    }
}
