using AutoMapper;
using BehShop.Application.DTO;
using BehShop.Application.Interfaces.Context;


namespace BehShop.Application.CatalogServices.CatalogType
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDatabaseContext _db;
        private readonly IMapper _mapper;
        public CatalogTypeService(IDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public BaseEntity<CatalogTypeDTO> Add(CatalogTypeDTO catalogType)
        {
            var model = _mapper.Map<CatalogType>(catalogType);
            _db.catalogTypes.Add(model);
            _db.SaveChanges();
            return new BaseEntity<CatalogTypeDTO>() { true,
                new IList<string> { $"تایپ {model.Type} با موفقیت در سیستم ثبت شد" },
                _mapper.Map<CatalogTypeDTO>(model)
            };

                

        }

        public BaseEntity<CatalogTypeDTO> Edit(CatalogTypeDTO catalogType)
        {
            var model = _db.catalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
            _mapper.Map(catalogType, model);
            _db.SaveChanges();
            return new BaseEntity<CatalogTypeDTO>(){
                true,
                new IList<string> { $"تایپ {model.Type} با موفقیت ویرایش شد"},
                _mapper.Map<CatalogTypeDTO>(model)
            };
        }

        public BaseEntity<CatalogTypeDTO> FindById(int id)
        {
            var data = _db.catalogTypes.Find(id);
            var result = _mapper.Map<CatalogTypeDTO>(data);
            return new BaseEntity<CatalogTypeDTO>() {

                true,
                 null,
                 result
            };

                 
            
        }

        public PaginatedItemDTO<CatalogTypeDTO> GetAll(int? parentId, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public BaseEntity Remove(int Id)
        {
            var catalogtype = _db.catalogTypes.Find(Id);
            _db.catalogTypes.Remove(catalogtype);
            _db.SaveChanges();
            return new BaseEntity()
            {
                true,
                new List<string> { $"آیتم با موفقیت حذف شد" }
            };


        }
    }
}
