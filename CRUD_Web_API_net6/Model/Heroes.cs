using CRUD_Web_API_net6.Service.HeroesServices;

namespace CRUD_Web_API_net6.Model
{
    public class Heroes
    {
        public int id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
    }

    public class Response<T>
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = string.Empty;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
    }

    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = string.Empty;
            this.Succeeded = true;
            this.Errors = string.Empty;
        }
    }

    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 2;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 2 ? 2 : pageSize;
        }
    }
}
