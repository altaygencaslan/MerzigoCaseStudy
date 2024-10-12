using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Business.DTOs
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CreatedUserId { get; set; }
        public bool IsDeletable { get => true; }
    }
}
