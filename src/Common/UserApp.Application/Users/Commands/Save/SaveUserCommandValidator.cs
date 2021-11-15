using FluentValidation;
using UserApp.Application.Common.Interfaces;

namespace UserApp.Application.Users.Commands.Save
{
    public class SaveUserCommandValidator : AbstractValidator<SaveUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public SaveUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(v => v.LastName)
                //.MustAsync(BeUniqueName).WithMessage("The specified city already exists.")
                .NotEmpty().WithMessage("Last Name is required.");
        }

        //private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        //{
        //    return await _context.Cities.AllAsync(x => x.Name != name, cancellationToken);
        //}
    }
}
