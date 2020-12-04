using AgendaLive.Api.Models;
using AgendaLive.Api.Repository.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AgendaLive.Api.Repository
{
    public class LiveRepository : ILiveRepository
    {
        private readonly IMongoCollection<LiveDocument> _lives;

        public LiveRepository(IMongoCollection<LiveDocument> lives)
        {
            _lives = lives;
        }

        public void Create(LiveDocument liveDocument)
        {
            _lives.InsertOne(liveDocument);
        }

        public List<LiveDocument> GetAll()
        {
            return _lives.Find(_ => true).ToList();
        }

        public LiveDocument GetById(string id)
        {
            return _lives.Find(live => live.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _lives.DeleteOne(live => live.Id == id);
        }

        public void Update(string id, LiveDocument liveDocument)
        {
            _lives.ReplaceOne(live => live.Id == id, liveDocument);
        }
    }
}
