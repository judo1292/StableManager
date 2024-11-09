
using Newtonsoft.Json;

namespace StableManager.Model
{
    class PromptToJson
    {
        public string PromptMaker()
        {
            Beans.Payload payload = new Beans.Payload();
            var payloadJson = JsonConvert.SerializeObject(payload);
            return payloadJson;
        }
    }
}
