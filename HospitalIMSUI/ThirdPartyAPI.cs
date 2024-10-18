using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace HospitalIMSServices
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cache
    {
        public string lastUpdated { get; set; }
        public string expires { get; set; }
        public long lastUpdatedTimestamp { get; set; }
        public long expiresTimestamp { get; set; }
    }

    public class China
    {
        public int confirmed { get; set; }
        public int recovered { get; set; }
        public int deaths { get; set; }
    }

    public class DataSource
    {
        public string url { get; set; }
        public DateTime lastGithubCommit { get; set; }
        public string publishedBy { get; set; }
        public string @ref { get; set; }
    }

    public class Global
    {
        public int confirmed { get; set; }
        public object recovered { get; set; }
        public int deaths { get; set; }
    }

    public class NonChina
    {
        public int confirmed { get; set; }
        public object recovered { get; set; }
        public int deaths { get; set; }
    }

    public class RawDatum
    {
        public string FIPS { get; set; }
        public string Admin2 { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public string Last_Update { get; set; }
        public string Lat { get; set; }
        public string Long_ { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
        public string Active { get; set; }
        public string Combined_Key { get; set; }
        public string Incident_Rate { get; set; }
        public string Case_Fatality_Ratio { get; set; }
    }

    public class Root
    {
        public SummaryStats summaryStats { get; set; }
        public Cache cache { get; set; }
        public DataSource dataSource { get; set; }
        public string apiSourceCode { get; set; }
        public List<RawDatum> rawData { get; set; }
    }

    public class SummaryStats
    {
        public Global global { get; set; }
        public China china { get; set; }
        public NonChina nonChina { get; set; }
    }


    internal class ThirdPartyAPI
    {
        // Init. API URLs
        
        public string Covid19PHAPIURL = "";
        public string InfermedicaAPIURL = "";

        public ThirdPartyAPI() { 

        
        }

        public async void ShowCovid19Tracker()
        {
            // visit https://json2csharp.com/
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await ProcessRepositoriesAsync(client);

            static async Task ProcessRepositoriesAsync(HttpClient client)
            {
                string Covid19APIURL = "https://coronavirus.m.pipedream.net/";
                await using Stream stream = await client.GetStreamAsync(Covid19APIURL);
                var repositories = await JsonSerializer.DeserializeAsync<Root>(stream);
                Console.Write(repositories.summaryStats.global.confirmed);
            }
        }
    }
}
