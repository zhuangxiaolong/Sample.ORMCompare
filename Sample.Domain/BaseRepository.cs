using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain
{
    public abstract class BaseRepository
    {
        private string _connectionstring= "data source=.;initial catalog=MusicStore;user id=sa;password=123;";

        public string ConnectionString
        {
            get {return _connectionstring; }
            set { _connectionstring = value; }
        }
    }
}
