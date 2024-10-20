namespace HospitalIMSWeb.Models
{
    public class Cloudflare
    {
        public string hostname { get; set; }
        public string clientIp { get; set; }
        public string httpProtocol { get; set; }
        public string asn { get; set; }
        public string asOrganization { get; set; }
        public string colo { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

    }
}
