using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGF.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategory { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
