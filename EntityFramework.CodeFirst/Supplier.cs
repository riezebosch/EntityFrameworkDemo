using System.Collections.Generic;

namespace EntityFramework.CodeFirst
{
    internal class Supplier
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public IList<Store> Stores { get; set; }
    }
}