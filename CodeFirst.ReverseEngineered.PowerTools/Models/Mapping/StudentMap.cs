using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.ReverseEngineered.PowerTools.Models.Mapping
{
    class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.ToTable("Student");
        }
    }
}