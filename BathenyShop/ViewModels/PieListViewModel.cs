using BathenyShop.Models;

namespace BathenyShop.ViewModels
{
    public class PieListViewModel
    {
        public PieListViewModel(string? currentCategory, IEnumerable<Pie> pies)
        {
            CurrentCategory = currentCategory;
            Pies = pies;
        }

        public string? CurrentCategory { get; set; }
        public IEnumerable<Pie> Pies { get; set; }
    }
}
