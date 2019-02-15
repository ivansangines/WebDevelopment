﻿using Couchbase;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Cache
{
    public class MemCachedAdapter : IWebCache
    {
        static ClientConfiguration config = null;
        private readonly Cluster cluster = null;

        public MemCachedAdapter()
        {
            config = new ClientConfiguration
            {
                Servers = new List<Uri>
                {
                    //new Uri("http://127.0.0.1:8091/pools"),
                    new Uri("http://localhost:8091")

                }
            };
            cluster = new Cluster(config);
            cluster.Authenticate("sangines", "Iv55875587");
        }
        // for Memcached product #region IWebCache Members

        public void Remove(string key)
        {
            try
            {
                //using (var cluster = new Cluster(config))   
                var cluster = new Cluster(config);

                //using (var bucket = cluster.OpenBucket())
                var bucket = cluster.OpenBucket("default");
                {
                    var upsert = bucket.Remove(key);
                    
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Store(string key, object obj)
        {
            try
            {
                //using (var cluster = new Cluster(config))
                var cluster = new Cluster(config);

                //using (var bucket = cluster.OpenBucket())
                var bucket = cluster.OpenBucket("default");
                {
                    var upsert = bucket.Upsert(key, obj);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public T Retrieve<T>(string key)
        {
            T cachedData = default(T);
            //using (var cluster = new Cluster(config))
            var cluster = new Cluster(config);

            //using (var bucket = cluster.OpenBucket())
            var bucket = cluster.OpenBucket("default");
                {
                    var data = bucket.GetDocument<T>(key);
                    cachedData = data.Document.Content;
                }
            
            return cachedData;
            //return default(T);
            //throw new NotImplementedException();
        }
        
    }
}