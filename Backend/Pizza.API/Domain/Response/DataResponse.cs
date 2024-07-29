using Microsoft.AspNetCore.Mvc;

namespace Pizza.API.Domain.Response
{
    public class DataResponse<T> : Response
    {
        T Data { get; set; }
    }
}
