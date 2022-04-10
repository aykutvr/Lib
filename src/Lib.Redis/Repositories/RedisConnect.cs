using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Redis.Repositories
{
    public class RedisConnect : IRedisConnect
    {

        public void Set<T>(string key, T value)
        {
            StackExchange.Redis.IConnectionMultiplexer _rdis = null;
            var db = _rdis.GetDatabase();
            db.StringSet(new StackExchange.Redis.RedisKey(""),new StackExchange.Redis.RedisValue())
            using (IRedisClient client = new RedisClient())
            {
                client
                IRedisTypedClient<T> typedClient = client.As<T>();
                typedClient.Store()
            }
        }
        public string Set(byte[] value)
        {
            string key = Guid.NewGuid().ToString();
            Set(key, value);
            return key;
        }    

        public void Set(string key, byte[] value)
        {
            using (IRedisNativeClient client = new RedisClient())
                client.Set(key, value);
        }

    }
}
