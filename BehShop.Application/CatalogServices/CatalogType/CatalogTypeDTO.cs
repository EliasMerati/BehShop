namespace BehShop.Application.CatalogServices.CatalogType
{

    public class CatalogTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
