namespace EHRS.DAL.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Role")]
    public partial class Role
    {
        [Key]    
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
