using AutoMapper;
using DemoShopping.ProductAPI.Data.Context;
using DemoShopping.ProductAPI.Entities;
using DemoShopping.ProductAPI.Entities.Value_Objects;
using Microsoft.EntityFrameworkCore;

namespace DemoShopping.ProductAPI.Data.Repository {
    public class ProductRepository : IProductRepository {
        private readonly MyApplicationContext _context;
        private IMapper _mapper;

        public ProductRepository(MyApplicationContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll() {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }
        public async Task<ProductVO> FindById(long id) {
            Product newProduct = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(newProduct);
        }
        public async Task<ProductVO> Create(ProductVO vo) {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);

        }
        public async Task<ProductVO> Update(ProductVO vo) {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<bool> Delete(long id) {
            try {
                Product productToDelete = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productToDelete is null) return false;
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }
    }
}
