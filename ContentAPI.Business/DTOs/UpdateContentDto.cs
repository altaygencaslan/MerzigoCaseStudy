using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.DTOs
{
    public class UpdateContentDto
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid UpdateUserId { get; set; }
    }
}
