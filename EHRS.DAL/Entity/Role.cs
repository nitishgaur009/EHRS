namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(Role))]
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
