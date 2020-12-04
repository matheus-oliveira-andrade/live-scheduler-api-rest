using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AgendaLive.Api.Models
{
    public class LiveDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("liveName")]
        public string LiveName { get; set; }

        [BsonElement("channelName")]
        public string ChannelName { get; set; }

        [BsonElement("liveDate")]
        public DateTime? LiveDate { get; set; }

        [BsonElement("liveLink")]
        public string LiveLink { get; set; }

        [BsonElement("registrationName")]
        public string RegistrationName { get; set; }
    }
}
