using Newtonsoft.Json;

namespace EtiqaCDN.Models.Base
{
    public class BaseErrorResponse
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Field which has the error
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; } = default!;

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; } = default!; 

        /// <summary>
        /// Stack trace details for error
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; } = default!;

        /// <summary>
        /// Title used on Kill Switch exception handler
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; } = default!;

        /// <summary>
        /// Provide structured data about the error
        /// </summary>
        public object Data { get; set; } = default!;
    }
}
