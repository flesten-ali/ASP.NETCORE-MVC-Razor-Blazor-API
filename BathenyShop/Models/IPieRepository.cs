namespace BathenyShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies {  get; }  
        IEnumerable<Pie> PiesOfTheWeek {  get; }  
        Pie? GetPieById(int id);
        IEnumerable<Pie> SearhcPies(string searchQuery);
    }
}
