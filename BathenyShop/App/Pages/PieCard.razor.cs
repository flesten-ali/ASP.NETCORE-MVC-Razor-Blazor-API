using BathenyShop.Models;
using Microsoft.AspNetCore.Components;
namespace BathenyShop.App.Pages;

public partial class PieCard
{
    [Parameter]
    public Pie? Pie { get; set; }
}
