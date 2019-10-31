using FluentValidation;

using Demo.Model;

namespace Demo.Validation
{
    /// <summary>
    /// This class executes abstract validation against the user
    /// </summary>
    public class UserFullValidator : AbstractValidator<User>
    {
        public UserFullValidator(bool IsUpdate = false)
        {
            Include(new UserValidator(true));
            Include(new UserAgeValidator());
        }
    }
}
