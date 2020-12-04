using AgendaLive.Api.Models;
using System.Collections.Generic;

namespace AgendaLive.Api.Repository.Interfaces
{
    public interface IRepository<T>
    {
        List<LiveDocument> GetAll();
        LiveDocument GetById(string id);
        void Create(T item);
        void Update(string id, T item);
        void Remove(string id);
    }
}
