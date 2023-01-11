using ApiGF.Model;
using System.ComponentModel.DataAnnotations;

namespace ApiGF.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int? IdCategory { get; set; }
        public Category Categories { get; set; }
    }
}
