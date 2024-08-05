using Microsoft.AspNetCore.Mvc;

namespace Pizza.API.Domain.Response
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
