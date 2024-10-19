using Newtonsoft.Json;

// Use this for the HomeController that shows pictures of a cat/cats.
// Made in case JavaScript API would not be considered allowed in this activity.

namespace HospitalIMSWeb.Models
{
    public class Cat
    {
        [JsonProperty("object")]
        public Tag tags { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string mimetype { get; set; }
        public string size { get; set; }
        public string _id { get; set; }
    }
    public class Tag
    {
        public string[] elements {  get; set; }
    }
}
