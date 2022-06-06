using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;

namespace CleanArchitecture.Application.UnitTest.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRespository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamers = fixture.CreateMany<Streamer>().ToList();
            streamers.Add(fixture.Build<Streamer>()
                .With(tr => tr.Id, 8001)
                .Without(x => x.Videos)
                .Create()
            );

            //var options = new DbContextOptionsBuilder<StreamerDbContext>()
            //    .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
            //    .Options;

            //var streamerDbContextFake = new StreamerDbContext(options);

            streamerDbContextFake.Streamers!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();

            //var mockRepository = new Mock<VideoRepository>(streamerDbContextFake);

            //mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(videos);

            //return mockRepository;
        }
    }
}
