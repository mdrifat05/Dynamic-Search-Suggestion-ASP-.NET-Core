using MongoDB.Bson;

namespace Dynamic_Search.Models
{
    public class SearchItem
    {
            public ObjectId Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

    }
}
