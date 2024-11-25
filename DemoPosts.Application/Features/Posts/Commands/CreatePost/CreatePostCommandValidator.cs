using FluentValidation;

namespace DemoPosts.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(p=>p.Content).NotEmpty().NotNull();
        }
    }
}
