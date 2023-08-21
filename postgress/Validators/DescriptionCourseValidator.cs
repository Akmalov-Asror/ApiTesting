using FluentValidation;
using postgress.Entities;

namespace postgress.Validators;

public class DescriptionCourseValidator : AbstractValidator<DescriptionCourse>
{
    public DescriptionCourseValidator()
    {
        RuleFor(description => description.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(description => description.Review).NotEmpty().WithMessage("Review is required.");
        RuleFor(descriptionCourse => descriptionCourse.CourseId).NotEmpty().WithMessage("CourseId is required.")
            .Must(BeAGuid).WithMessage("CourseId must be a valid Guid.");
        
    }

    private bool BeAGuid(Guid? guid) => guid != null && guid != Guid.Empty;
}