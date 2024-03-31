using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveType.Queries
{
    public class GetLeaveTypeListQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypeQueryHandler>> _mockAppLogger;

        public GetLeaveTypeListQueryHandlerTest()
        {
            _leaveTypeRepositoryMock = MocLeaveTypeRepository.GetLeaveType();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypeQueryHandler>>();
        }

        [Fact]
        public async Task GetLeavetypeListTest()
        {
            var handler = new GetLeaveTypeQueryHandler(_mapper,
                _leaveTypeRepositoryMock.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetLeaveTypeQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
