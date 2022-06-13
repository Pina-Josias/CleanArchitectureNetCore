
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infraestructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILoggerFactory loggerFactory)
        {
            if (!context.Streamers!.Any())
            {
                var logger = loggerFactory.CreateLogger<StreamerDbContextSeed>();
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Inserting new Default Streamers {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer
                {
                    CreatedBy= "Josias",
                    Nombre = "HBO Max",
                    Url = "https://www.hbomax.com"
                },
                new Streamer
                {
                    CreatedBy= "Josias",
                    Nombre = "Amazon VIP",
                    Url = "https://www.amazonvip.com"
                }
            };
        }
    }
}
