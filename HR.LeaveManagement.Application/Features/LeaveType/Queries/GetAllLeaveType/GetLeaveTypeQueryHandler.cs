using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        async Task<List<LeaveTypeDto>> IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>.Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync();
            var data = _mapper.Map<List<LeaveTypeDto>> (leaveType);

            return data;
        }
    }
}
