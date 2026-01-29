using IkkinchiModul.Dtos;

namespace IkkinchiModul.Services;

public interface IMusicService
{
    public Guid AddMusic(MusicDto musicDto);
    public bool UpdateMusic(MusicDto musicDto);
    public bool DeleteMusic(Guid id);
    public List<MusicDto> GetAllMusicByAuthorName(string name);
    public MusicDto GetMostLikedMusic();
    public MusicDto GetMusicByName (string name);
    public List<MusicDto> GetAllMusicAboveSize(double minSize);
    public List<MusicDto> GetTopMostLikedMusic(int count);
    public List<MusicDto> GetMusicWithLikesInRange(int minLikes,  int maxLikes);
    public double GetTotalMusicSizeByAuthor(string authorName);
    


}