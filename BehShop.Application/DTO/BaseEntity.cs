namespace BehShop.Application.DTO
{
    public class BaseEntity<T>
    {

        public BaseEntity(T data, IList<string> message, bool isSuccess)
        {
            this.Data = data;
            this.Message = message;
            this.IsSuccess = isSuccess;
        }

        private T Data { get;  set; }
        private IList<string> Message { get;  set; }
        private bool IsSuccess { get;  set; }
    }

    public class BaseEntity
    {
        public BaseEntity(IList<string> message, bool isSuccess)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
        }
        private IList<string> Message { get;  set; }
        private bool IsSuccess { get;  set; }
    }
}
