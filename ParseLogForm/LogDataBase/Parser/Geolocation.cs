using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace EntityLogDataBase.Parser
{    
    //http://ip-api.com/docs/api:json  - api инструкция
    class Geolocation
    {
        /// <summary>
        /// инстализирует новый объект класса для геолокации
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public string GetLocation(string host)
        {
            try
            {
                WebRequest request = WebRequest.Create(@"http://ip-api.com/json/" + host);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                RootObject json = (RootObject)new DataContractJsonSerializer(typeof(RootObject)).ReadObject(stream);

                string location = "";
                location += "City: " + json.city  + " \n";
                location += "Country: " + json.country + " \n";
                location += "Contry code: " + json.countryCode + " \n";
                location += "Region: " + json.regionName + " \n";
                location += "Region code: " + json.region + " \n";

                return location;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Объектная модель данных геолокации
        /// </summary>
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public string city { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public string countryCode { get; set; }
            [DataMember]
            public string region { get; set; }
            [DataMember]
            public string regionName { get; set; }
        }
    }
}

