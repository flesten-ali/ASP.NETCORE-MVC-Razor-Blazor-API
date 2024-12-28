using Microsoft.EntityFrameworkCore;

namespace BathenyShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BathenyShopDbContext _context;

        public PieRepository(BathenyShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _context.Pies.Include(e => e.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _context.Pies.Include(e => e.Category).Where(e => e.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int id)
        {
            return _context.Pies.FirstOrDefault(e => e.PieId == id);
        }

        public IEnumerable<Pie> SearhcPies(string searchQuery)
        {
            return _context.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
