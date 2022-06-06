
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video?> GetVideoByName(string name)
        {
            return await _context.Videos!.FirstOrDefaultAsync(x => x.Nombre == name);
        }

        public async Task<IEnumerable<Video>> GetVideoByUserName(string userName)
        {
            return await _context.Videos!.Where(x => x.CreatedBy == userName).ToListAsync();
        }
    }
}
