using FluentValidation;

using Demo.Model;

namespace Demo.Validation
{
    /// <summary>
    /// This class executes abstract validation against the user
    /// </summary>
    public class UserAgeValidator : AbstractValidator<User>
    {
        public UserAgeValidator()
        {
            RuleFor(x => x.Age)
                .Must(IsOver18)
                .WithMessage("You must be over 18 years old.");
        }

        private bool IsOver18(int age)
        {
            return age > 18;
        }
    }
}
