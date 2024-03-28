using FluentValidation;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestCommandValidator()
        {
            RuleFor(q => q.Approved)
                .NotNull()
                .WithMessage("Approval Status Can't be null.");
        }
    }
}
