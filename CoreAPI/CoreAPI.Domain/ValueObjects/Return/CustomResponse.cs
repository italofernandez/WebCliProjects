using System.Collections.Generic;

namespace CoreAPI.Domain.ValueObjects.Return
{
    public class CustomResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public List<CustomNotificationResponse> Notifications { get; set; }
    }
}