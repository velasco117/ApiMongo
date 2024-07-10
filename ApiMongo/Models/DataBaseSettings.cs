namespace ApiMongo.Models
{
    public class DataBaseSettings
    {
        public String ConnectionString { get; set; } = null!;
        public String DatabaseName { get; set; } = null!;
        public String CollectionName { get; set; } = null!;
        public String LoginCollection { get; set; } = null!;

    }
}
