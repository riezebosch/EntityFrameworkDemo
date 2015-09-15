using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.CodeFirst
{
    [Table("Speelgoed")]
    internal class Toy
    {
        public int Id { get; set; }

        [MaxLength(128)]
        [ConcurrencyCheck]
        public string Name { get; set; }
        [ConcurrencyCheck]
        public decimal? Price { get; set; }
        public byte[] Timestamp { get; internal set; }
    }
}