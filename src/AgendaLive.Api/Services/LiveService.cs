using AgendaLive.Api.Models;
using AgendaLive.Api.Repository;
using AgendaLive.Api.Repository.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AgendaLive.Api.Service
{
    public class LiveService
    {
        private readonly ILiveRepository _liveRepository;

        public LiveService(IAgendaLiveDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            IMongoCollection<LiveDocument> lives = database.GetCollection<LiveDocument>(settings.LivesCollectionName);

            _liveRepository = new LiveRepository(lives);
        }

        public List<LiveDocument> FindAll()
        {
            return _liveRepository.GetAll();
        }

        public Optional<LiveDocument> FindById(string id)
        {
            return _liveRepository.GetById(id);
        }

        public void Save(LiveDocument liveDocument)
        {
            _liveRepository.Create(liveDocument);
        }

        public void Delete(string id)
        {
            _liveRepository.Remove(id);
        }

        public void Update(string id, LiveDocument liveDocument)
        {
            liveDocument.Id = id;

            _liveRepository.Update(id, liveDocument);
        }
    }
}
