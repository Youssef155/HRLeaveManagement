using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class LeaveRequestDto
    {
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDto leaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
