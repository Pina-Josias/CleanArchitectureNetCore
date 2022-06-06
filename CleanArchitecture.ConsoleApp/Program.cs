
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();


await MultipleEntitiesQuery();

//await AddNewDirectorWithVideo();

//await AddNewActorWithVideo();

//await AddNewStreamerWithVideoId();

//await AddNewStreamerWithVideo();


//await QueryFilter();


async Task MultipleEntitiesQuery()
{
    //var videoWithActores =
    //    await dbContext!.Videos!.
    //    Include(q => q.Actores).FirstAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();


    var videoWithDirector = await dbContext!.Videos!
                .Where(x => x.Director != null)
                .Include(x => x.Director)
                .Select(q =>
                    new
                    {
                        Director_N = $"{q.Director.Nombre} {q.Director.Apellido}",
                        Movie_N = q.Nombre
                    }
                )
                .ToListAsync();

    foreach (var item in videoWithDirector)
    {
        Console.WriteLine($"{item.Movie_N} - {item.Director_N}");
    }

}

async Task AddNewDirectorWithVideo()
{

    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{

    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1,
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{

    var batmanForever = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 3,
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer
    {
        Nombre = "Pantaya",
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantalla,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}



//async Task QueryFilter()
//{
//    var streamers = await dbContext!.Streamers!.Where(x => x.Id == 2).ToListAsync();

//    foreach (var item in streamers)
//    {
//        Console.WriteLine($"{item.Id} - {item.Nombre}");
//    }
//}



//Streamer streamer = new()
//{
//    Nombre = "Amazon Prime",
//    Url = "https://www.amazonprime.com"
//};

//dbContext!.Streamers!.Add(streamer);

//await dbContext.SaveChangesAsync();

//var movies = new List<Video>
//{
//    new Video
//    {
//        Nombre = "Mad Max",
//        StreamerId = streamer.Id
//    },
//    new Video
//    {
//        Nombre = "La Mascara",
//        StreamerId = streamer.Id
//    },
//    new Video
//    {
//        Nombre = "Batman",
//        StreamerId = streamer.Id
//    }
//};

//await dbContext!.Videos!.AddRangeAsync(movies);

//await dbContext.SaveChangesAsync();