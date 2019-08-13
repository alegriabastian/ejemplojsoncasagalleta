using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class Casa
    {    
        [JsonProperty("nombreGato")] 
        public string nombreGato {get;set;}

        [JsonProperty("numGuitarras")] 
        public int numGuitarras {get;set;}
        
        [JsonProperty("galletas")] 
        public List<string> galletas{get;set;}
    }
}