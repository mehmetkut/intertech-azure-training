> project.json adında dosya oluşturun içeriği aşağıdaki gibi olacak.

```json
{
    "frameworks": {
        "net46": {
            "dependencies": {
                "StackExchange.Redis":"1.1.603",
                "Newtonsoft.Json": "9.0.1"
            }
        }
    }
}
```

> Queue tipinde bir azure functions içeriği aşağıdaki gibi olacak 

```C#
using System;
using System.Net;
using Newtonsoft.Json;
using StackExchange.Redis;


public static void Run(string myQueueItem, TraceWriter log)
{
     log.Info("Started");

 // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = Connection.GetDatabase();

            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache
            cache.StringSet("af1", "Intertech");
            cache.StringSet("af2", 25);

            // Simple get of data types from the cache
            string key1 = cache.StringGet("af1");
            int key2 = (int)cache.StringGet("af2");

    log.Info("Cached");
}


private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("hol11.redis.cache.windows.net:6380,password=QVPwKmy5/U2/y8LEToibR33p5ccQjhV1f46clX3OdZE=,ssl=True,abortConnect=False");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
```