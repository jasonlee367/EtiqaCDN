using Newtonsoft.Json;
using EtiqaCDN.Models.Base;

namespace Herbalife.Server.Models.Base
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// Message text
        /// </summary>
        public string Message { get; set; } = default!;

        /// <summary>
        /// Data to return
        /// </summary>
        public object Data { get; set; } = default!;

        /// <summary>
        /// List of errors
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<BaseErrorResponse> Errors { get; set; } = default!;
    }



}