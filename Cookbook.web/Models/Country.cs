using System.ComponentModel.DataAnnotations;

namespace Cookbook.web.Models
{
    public class Country
    {
        public Country()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
