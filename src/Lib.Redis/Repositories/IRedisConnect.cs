using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Redis.Repositories
{
    public interface IRedisConnect
    {
        void Set(object value);
    }
}
