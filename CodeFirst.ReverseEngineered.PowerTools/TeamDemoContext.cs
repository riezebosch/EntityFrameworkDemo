using System;
using System.Data.Entity;

namespace CodeFirst.ReverseEngineered.PowerTools
{
    public class TeamDemoContext : DbContext
    {
        public TeamDemoContext()
            : base("TeamDemo")
        {
        }
        public DbSet<DemoData> DemoData { get; set; }
    }
}