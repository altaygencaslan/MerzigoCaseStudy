using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Business.DTOs
{

    public class CreateContentDtoValidator : AbstractValidator<CreateContentDto>
    {
        public CreateContentDtoValidator()
        {
            RuleFor(x => x.Header).NotEmpty()
                                  .NotNull()
                                  .MinimumLength(1);

            RuleFor(x => x.Body).NotEmpty()
                                .NotNull()
                                .MinimumLength(5);

            RuleFor(x => x.CreatedUserId).NotEmpty()
                                  .NotNull()
                                  .NotEqual(Guid.Empty);
        }
    }


    public class CreateContentDto
    {
        [Required(ErrorMessage = "*")]
        public string Header { get; set; }

        [Required(ErrorMessage = "*")]
        public string Body { get; set; }

        [Required(ErrorMessage = "*")]
        public string Tags { get; set; }
        public DateTime? PublishDate { get; set; }

        [Required(ErrorMessage = "*")]
        public Guid CreatedUserId { get; set; }
    }
}
