using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalContents { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsDeleted { get; set; }
    }
}
