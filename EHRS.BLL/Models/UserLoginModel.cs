
using System;
using System.Collections.Generic;

namespace EHRS.BLL.Models
{
    public class UserLoginModel
    {
        public UserLoginModel()
        {
            UserRole = new List<UserRoleModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal MobileNumber { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public bool? Active { get; set; }
        public IEnumerable<UserRoleModel> UserRole { get; set; }
    }
}
