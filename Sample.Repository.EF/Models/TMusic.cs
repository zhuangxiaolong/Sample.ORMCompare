using System;
using System.Collections.Generic;

namespace Sample.Repository.EF.Models
{
    public partial class TMusic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
