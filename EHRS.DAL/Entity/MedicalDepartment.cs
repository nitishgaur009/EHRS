
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(MedicalDepartment))]
    public partial class MedicalDepartment
    {   
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
