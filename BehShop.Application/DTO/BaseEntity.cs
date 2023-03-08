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

        public T Data { get; private set; }
        public IList<string> Message { get; private set; }
        public bool IsSuccess { get; private set; }
    }

    public class BaseEntity
    {
        public BaseEntity(IList<string> message, bool isSuccess)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
        }
        public IList<string> Message { get; private set; }
        public bool IsSuccess { get; private set; }
    }
}
