namespace AgendaLive.Api.Models
{
    public interface IAgendaLiveDatabaseSettings
    {
        public string LivesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
