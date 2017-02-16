using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerScorer.Repository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> FindById(string id);
        Task Insert(string id, T item);
        Task Remove(string id);
    }

    public class InMemoryRepo<T> : IBaseRepository<T>
    {
        private class Item<T>
        {
            public string Id { get; set; }
            public T Value { get; set; }
        }
        private readonly List<Item<T>> items = new List<Item<T>>();

        Task<List<T>> IBaseRepository<T>.GetAll()
        {
            return Task.Run(() => items.Select(x => x.Value).ToList());
        }

        Task<T> IBaseRepository<T>.FindById(string id)
        {
            return Task.Run(() => items
                    .Where(x => x.Id == id)
                    .Select(x => x.Value)
                    .FirstOrDefault()
                );
        }

        Task IBaseRepository<T>.Insert(string id, T item)
        {
            return Task.Run(
                () => items.Add(new Item<T>
                {
                    Id = id,
                    Value = item
                })
            );
        }

        Task IBaseRepository<T>.Remove(string id)
        {
            return Task.Run(
                () =>
                {
                    var item = items.Where(x => x.Id == id).FirstOrDefault();
                    items.Remove(item);
                }
            );
        }
    }

    public class InMemoryBaseRepository<T> : IBaseRepository<T>
    {
        private readonly Dictionary<string, T> dictionary;

        protected Dictionary<string, T> Dictionary => dictionary;

        public InMemoryBaseRepository()
        {
            dictionary = new Dictionary<string, T>();
        }

        Task<T> IBaseRepository<T>.FindById(string id)
        {
            return Task.Run(() => Dictionary[id]);
        }

        Task<List<T>> IBaseRepository<T>.GetAll()
        {
            return Task.Run(() => Dictionary.Values.ToList());
        }

        Task IBaseRepository<T>.Insert(string id, T item)
        {
            return Task.Run(() => Dictionary[id] = item);
        }

        Task IBaseRepository<T>.Remove(string id)
        {
            return Task.Run(() => Dictionary.Remove(id));
        }
    }
}