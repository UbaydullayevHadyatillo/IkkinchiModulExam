using IkkinchiModul.Dtos;
using IkkinchiModul.Services;
using IkkinchiModul.Services.Extensions;

namespace IkkinchiModul;

internal class Program
{
    static void Main(string[] args)
    {
        IMusicService musicService = new MusicService();
        MusicDto song1 = new MusicDto
        {
            Name = "Song A",
            MB = 5.2,
            AuthorName = "Author1",
            Description = "Description A",
            QuentityLikes = 120
        };
        MusicDto song2 = new MusicDto
        {
            Name = "Song B",
            MB = 3.5,
            AuthorName = "Author2",
            Description = "Description B",
            QuentityLikes = 80
        };

        MusicDto song3 = new MusicDto
        {
            Name = "Song C",
            MB = 7.0,
            AuthorName = "Author1",
            Description = "Description C",
            QuentityLikes = 200
        };

        musicService.AddMusic(song1);
        musicService.AddMusic(song2);
        musicService.AddMusic(song3);

       
        Console.WriteLine($" {song1.Name} hajmi KB: {song1.GetMusicKB()}");

        
        var mostLiked = musicService.GetMostLikedMusic();
        Console.WriteLine($" Eng ko'p like: {mostLiked.Name} ({mostLiked.QuentityLikes})");

        var author1Songs = musicService.GetAllMusicByAuthorName("Author1");
        Console.WriteLine(" Author1 qo'shiqlari:");
        foreach (var song in author1Songs)
        {
            Console.WriteLine($"{song.Name} - {song.MB} MB");
        }

        Console.ReadLine();

    }
}
