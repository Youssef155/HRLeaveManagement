using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
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
        private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

        public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<GetLeaveTypeQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }

        async Task<List<LeaveTypeDto>> IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>.Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync();
            var data = _mapper.Map<List<LeaveTypeDto>> (leaveType);

            _logger.LogInformation("Leave types were retrived succcessfully");

            return data;
        }
    }
}
