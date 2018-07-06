using System.ComponentModel.DataAnnotations;

namespace aspnetcoreapp.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Color { get; set; }
    }
}