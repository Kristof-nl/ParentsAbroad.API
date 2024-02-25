using Newtonsoft.Json;

namespace ParentsAbroad.Shared.Dto
{
    public class ResponseResult<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MessageServerity { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T ResponseObject { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object ResponseObject2 { get; set; }

        public static ResponseResult<T> Create(T responseObject)
        {
            return new ResponseResult<T>
            {
                ResponseObject = responseObject
            };
        }

    }
}
