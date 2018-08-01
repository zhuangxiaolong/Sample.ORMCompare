using System;
using System.Collections.Generic;

namespace Sample.Repository.EF.Models
{
    public partial class TUserMusic
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? MusicId { get; set; }
    }
}
