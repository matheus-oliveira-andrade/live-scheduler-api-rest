using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaLive.Api.Models
{
    public class AgendaLiveDatabaseSettings : IAgendaLiveDatabaseSettings
    {
        public string LivesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
