namespace BehShop.Application.DTO
{
    public class PaginatedItemDTO<TEntity> where TEntity : class
    {
        public PaginatedItemDTO(int pageIndex, int pageSize, long pageCount, IEnumerable<TEntity> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.PageCount = pageCount;
            this.Data = data;
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public long PageCount { get; private set; }
        public IEnumerable<TEntity> Data { get; private set; }
    }
}
