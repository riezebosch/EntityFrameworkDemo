using System.Collections.Generic;

namespace EntityFramework.CodeFirst
{
    internal class Store
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public IList<Supplier> Suppliers { get; set; }
    }
}