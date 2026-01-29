using IkkinchiModul.Dtos;
using IkkinchiModul.Entities;

namespace IkkinchiModul.Services;

public class MusicService : IMusicService
{
    private List<Music> musics = new List<Music>();
    public Guid AddMusic(MusicDto musicDto)
    {
        Music music = new Music()
        {
            Id = Guid.NewGuid(),
            Name = musicDto.Name,
            MB = musicDto.MB,
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            QuentityLikes = musicDto.QuentityLikes
        };

        musics.Add(music);
        return music.Id;
    }

    public bool DeleteMusic(Guid id)

    {
        for (int i = 0; i < musics.Count; i++)
        {
            if (musics[i].Id == id)
            {
                musics.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public MusicDto ToDto(Music music)
    {
        return new MusicDto()
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes
        };
    }

    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        List<MusicDto> result = new List<MusicDto>();
        foreach (var music in musics)
        {
            if (music.MB >= minSize)
                result.Add(ToDto(music));
        }
        return result;
    }

    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        List<MusicDto> result = new List<MusicDto>();
        foreach (var music in musics)
        {
            if (music.AuthorName == name)
                result.Add(ToDto(music));
        }
        return result;
    }

    public MusicDto GetMostLikedMusic()
    {
        if (musics.Count == 0)
        {
            return null;
        }

        Music mostLiked = musics[0];
        foreach (var music in musics)
        {
            if (music.QuentityLikes > mostLiked.QuentityLikes)
                mostLiked = music;
        }

        return ToDto(mostLiked);
    }

    public MusicDto GetMusicByName(string name)
    {
        foreach (var music in musics)
        {
            if (music.Name == name)
                return ToDto(music);
        }
        return null;
    }

    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        List<MusicDto> result = new List<MusicDto>();
        foreach (var music in musics)
        {
            if (music.QuentityLikes >= minLikes && music.QuentityLikes <= maxLikes)
            {
                result.Add(ToDto(music));
            }
        }
        return result;
    }

    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        List<Music> temp = new List<Music>(musics);
        List<MusicDto> result = new List<MusicDto>();

        for (int i = 0; i < temp.Count - 1; i++)
        {
            for (int j = 0; j < temp.Count - i - 1; j++)
            {
                if (temp[j].QuentityLikes < temp[j + 1].QuentityLikes)
                {
                    var t = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = t;
                }
            }
        }

        for (int i = 0; i < temp.Count && i < count; i++)
        {
            result.Add(ToDto(temp[i]));
        }

        return result;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        double total = 0;
        foreach (var music in musics)
        {
            if (music.AuthorName == authorName)
                total += music.MB;
        }
        return total;
    }

    public bool UpdateMusic(MusicDto musicDto)
    {
        for (int i = 0; i < musics.Count; i++)
        {
            if (musics[i].Id == musicDto.Id)
            {
                musics[i].Name = musicDto.Name;
                musics[i].MB = musicDto.MB;
                musics[i].AuthorName = musicDto.AuthorName;
                musics[i].Description = musicDto.Description;
                musics[i].QuentityLikes = musicDto.QuentityLikes;
                return true;
            }
        }
        return false;
    }
}

