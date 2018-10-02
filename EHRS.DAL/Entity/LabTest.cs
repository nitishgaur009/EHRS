
namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(LabTest))]
    public partial class LabTest
    {   
        public int Id { get; set; }
        public string TestName { get; set; }
    }
}
