using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string _UserName { get; set; } = String.Empty;

        public GetVideosListQuery(string? userName)
        {
            _UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
