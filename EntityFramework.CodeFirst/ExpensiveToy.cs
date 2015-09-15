using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.CodeFirst
{
    [Table("Expensive")]
    internal class ExpensiveToy : Toy
    {
        public int Commission { get; set; }
        public Supplier Supplier { get; internal set; }
    }
}