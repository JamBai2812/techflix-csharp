using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechFlixApi.Models.Response;

namespace TechFlixApi.Models.CacheService
{
    public interface ICacheService
    {
        Dictionary<string, ResultList<Film>> CacheDictionary { get; set; }
        ResultList<Film> GetOrCreate(string key, Func<ResultList<Film>> createAction);
    }

    public class CacheService : ICacheService
    {
        public Dictionary<string, ResultList<Film>> CacheDictionary { get; set; }

        public CacheService()
        {
            CacheDictionary = new Dictionary<string, ResultList<Film>>();
        }

        public ResultList<Film> GetOrCreate(string key, Func<ResultList<Film>> createAction)
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