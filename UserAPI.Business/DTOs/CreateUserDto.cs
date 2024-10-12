using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Business.DTOs
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                                  .NotNull()
                                  .MinimumLength(3);

            RuleFor(x => x.LastName).NotEmpty()
                                .NotNull()
                                .MinimumLength(3);

            RuleFor(x => x.CreatedUserId).NotEmpty()
                                      .NotNull()
                                      .NotEqual(Guid.Empty);
        }
    }

    public class CreateUserDto
    {
        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public Guid CreatedUserId { get; set; }
        public bool IsDeletable { get => true; }
    }
}
