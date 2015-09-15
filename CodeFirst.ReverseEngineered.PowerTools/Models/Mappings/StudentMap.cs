using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.ReverseEngineered.PowerTools.Models.Mappings
{
    class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.Map(m => m.Requires(p => p.EnrollmentDate).HasValue());
        }
    }
}