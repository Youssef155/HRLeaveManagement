﻿using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocation
{
    public class LeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOdDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period {  get; set; }
    }
}
