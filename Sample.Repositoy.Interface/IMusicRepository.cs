using System;
using System.Collections.Generic;
using Sample.Domain;

namespace Sample.Repositoy.Interface
{
    public interface IMusicRepository
    {
        MusicInfo Find(int id);
        IEnumerable<MusicInfo> List();
    }
}
