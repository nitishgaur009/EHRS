namespace EHRS.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(nameof(UserLogin))]
    public partial class UserLogin
    {
        public UserLogin()
        {
            UserRole = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
