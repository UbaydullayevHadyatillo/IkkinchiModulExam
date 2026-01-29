using IkkinchiModul.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkkinchiModul.Services.Extensions;

public static class MusicDtoListExtension
{
    public static int GetTotalLikes(this List<MusicDto> musics)
    {
        int total = 0;
        foreach (var music in musics)
        {
            total += music.QuentityLikes;
        }
        return total;
    }
}
