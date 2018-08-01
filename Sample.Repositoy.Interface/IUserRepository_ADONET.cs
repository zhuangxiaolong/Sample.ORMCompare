using System;
using System.Collections.Generic;
using Sample.Domain;

namespace Sample.Repositoy.Interface
{
    public interface IUserRepository_ADONET
    {
        UserInfo Find(int id);
        IEnumerable<UserInfo> List();
    }
}
