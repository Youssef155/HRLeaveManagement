using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ChangeLeaveRequestApprovalCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);

            var email = new EmailMessage
            {
                To = string.Empty,
                Body = "The approval status for your leave request for" +
                    $" {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been updated",
                Subject = "Leave Request Approval status Updated"

            };

            await _emailSender.SendEmail(email);

            return Unit.Value;
        }
    }
}
