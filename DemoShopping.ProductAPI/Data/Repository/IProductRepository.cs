using DemoShopping.ProductAPI.Entities.Value_Objects;

namespace DemoShopping.ProductAPI.Data.Repository {
    public interface IProductRepository {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);
    }
}
