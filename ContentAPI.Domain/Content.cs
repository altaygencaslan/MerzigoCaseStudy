using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Domain
{
    public class Content
    {
        [Key]
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
