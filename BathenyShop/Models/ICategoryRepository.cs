namespace BathenyShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories {  get; }
    }
}
