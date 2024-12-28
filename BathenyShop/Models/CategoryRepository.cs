namespace BathenyShop.Models;
public class CategoryRepository : ICategoryRepository
{
    private readonly BathenyShopDbContext _context;

    public CategoryRepository(BathenyShopDbContext bethanysPieShopDbContext)
    {
        _context = bethanysPieShopDbContext;
    }

    public IEnumerable<Category> AllCategories => _context.Categories.OrderBy(p => p.CategoryName);
}
