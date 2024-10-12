using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Business.DTOs
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                                  .NotNull()
                                  .NotEqual(Guid.Empty);

            RuleFor(x => x.UpdatedUserId).NotEmpty()
                                  .NotNull()
                                  .NotEqual(Guid.Empty);
        }
    }

    public class UpdateUserDto
    {
        [Required(ErrorMessage = "*")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? IncrementTotalContent { get; set; }

        [Required(ErrorMessage = "*")]
        public Guid UpdatedUserId { get; set; }
    }
}
