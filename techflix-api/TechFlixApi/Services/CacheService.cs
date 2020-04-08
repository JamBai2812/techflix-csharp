using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TechFlixApi.Models.CacheService
{
    public interface ICacheService
    {
        ActionResult GetOrCreate(string key, Func<ActionResult> createAction);
    }

    public class CacheService : ICacheService
    {
        public Dictionary<string, ActionResult> CacheDictionary { get; set; }

        public CacheService()
        {
            CacheDictionary = new Dictionary<string, ActionResult>();
        }

        public ActionResult GetOrCreate(string key, Func<ActionResult> createAction)
        {
            if (!CacheDictionary.ContainsKey(key))
            {
                CacheDictionary[key] = createAction();
            }

            return CacheDictionary[key];
        }

        public void DeleteFromCache(string key)
        {
            CacheDictionary.Remove(key);
        }
    }
}