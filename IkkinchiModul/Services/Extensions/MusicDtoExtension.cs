using IkkinchiModul.Dtos;

namespace IkkinchiModul.Services.Extensions;

public static  class MusicDtoExtension
{
    public static double GetMusicKB(this MusicDto music)
    {
        return music.MB * 1024;
    }

}
