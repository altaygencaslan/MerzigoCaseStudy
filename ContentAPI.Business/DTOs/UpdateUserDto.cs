using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.DTOs
{
    public class UpdateUserDto
    {
        public UpdateUserDto(Guid id, int incrementTotalContent)
        {
            Id = id;
            IncrementTotalContent = incrementTotalContent;
        }

        public Guid Id { get; set; }
        public int IncrementTotalContent { get; set; }
    }
}
