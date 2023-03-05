using BehShop.Application.DTO;

namespace BehShop.Application.CatalogServices.CatalogType
{
    public interface ICatalogTypeService
    {
        BaseEntity<CatalogTypeDTO> Add(CatalogTypeDTO catalogType);
        BaseEntity Remove(int Id);
        BaseEntity<CatalogTypeDTO> Edit(CatalogTypeDTO catalogType);
        BaseEntity<CatalogTypeDTO> FindById(int id);
        PaginatedItemDTO<CatalogTypeDTO> GetAll(int? parentId, int pageSize, int page);
    }
}
