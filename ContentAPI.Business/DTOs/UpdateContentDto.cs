using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.DTOs
{

    public class UpdateContentDtoValidator : AbstractValidator<UpdateContentDto>
    {
        public UpdateContentDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                                  .NotNull()
                                  .NotEqual(Guid.Empty);

            RuleFor(x => x.UpdatedUserId).NotEmpty()
                                  .NotNull()
                                  .NotEqual(Guid.Empty);
        }
    }

    public class UpdateContentDto
    {
        [Required(ErrorMessage = "*")]
        public Guid Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public string Tags { get; set; }

        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "*")]
        public Guid UpdatedUserId { get; set; }
    }
}
