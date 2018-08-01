using System;
using System.Collections.Generic;

namespace Sample.Repository.EF.Models
{
    public partial class TUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pw { get; set; }
    }
}
