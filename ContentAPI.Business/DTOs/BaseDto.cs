using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.DTOs
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
