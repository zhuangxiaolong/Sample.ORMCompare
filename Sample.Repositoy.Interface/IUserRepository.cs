using System;
using System.Collections.Generic;
using Sample.Domain;

namespace Sample.Repositoy.Interface
{
    public interface IUserRepository
    {
        UserInfo Find(int id);
        IEnumerable<UserInfo> List();
    }
}
