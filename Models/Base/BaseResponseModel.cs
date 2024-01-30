using Newtonsoft.Json;

namespace EtiqaCDN.Models.Base
{
    public class BaseResponseModel<T>
    {
        /// <summary>
        /// Message text
        /// </summary>
        public string Message { get; set; } = default!;

        /// <summary>
        /// Data to return
        /// </summary>
        public T Data { get; set; } = default!;

        /// <summary>
        /// List of errors
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<BaseErrorResponse> Errors { get; set; } = default!;
    }
}
