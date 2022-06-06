using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTest.Mocks;
using CleanArchitecture.Infraestructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(x =>
                x.AddProfile<MappingProfile>()
            );

            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();

            MockStreamerRepository.
                AddDataStreamerRespository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task DeleteStreamerCommand_InputStreamerById_ReturnsUnit()
        {
            var streamerInput = new DeleteStreamerCommand
            {
                Id = 8001
            };

            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var response = await handler.Handle(streamerInput, CancellationToken.None);

            response.ShouldBeOfType<Unit>();

        }
    }
}
