using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Decision.API
{
    public class CadastroController : ApiController
    {
        private readonly string UrlBase = "https://eastus2.api.cognitive.microsoft.com/vision/v2.0/";
        private readonly string Token = "1df9a911fd2844d5a75db1026761bcd2";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async void Post()
        {
            string action = "recognizeText?mode=Printed";
            string urlPost = UrlBase + action;

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Token);

            var values = new Dictionary<string, string>
            {
               { "url", "https://www.senior.com.br/wp-content/uploads/2019/03/190313_Fluxograma-LGPD.png" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}