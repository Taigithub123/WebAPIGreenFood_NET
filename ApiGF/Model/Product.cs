using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGF.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int? IdCategory { get; set; }
        public Category? Categories { get; set; }

    }
}
