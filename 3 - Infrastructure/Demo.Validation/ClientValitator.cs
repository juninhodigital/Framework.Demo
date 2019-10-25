using FluentValidation;

using Demo.BES;

namespace Demo.Validation
{
    /// <summary>
    /// This class executes abstract validation against the client
    /// </summary>
    public class ClientValidator : AbstractValidator<ClientBES>
    {
        public ClientValidator(bool IsUpdate = false)
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("The label cannot be null or empty");
            RuleFor(o => o.Nickname).NotEmpty().WithMessage("The nickname cannot be null or empty");

            if (IsUpdate)
            {
                RuleFor(o => o.ID).GreaterThan(0).WithMessage("The ID cannot be null or empty, and must be greater than zero");
            }
        }
    }
}
