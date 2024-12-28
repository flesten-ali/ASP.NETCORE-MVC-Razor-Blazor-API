using BathenyShop.Controllers;
using BathenyShop.ViewModels;
using BathenyShopTest.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BathenyShopTest.ControllersTests;

public class PieControllerTests
{
    [Fact]
    public void List_WithEmptyCategory_ShouldReturnAllPies()
    {
        // arrange
        var pieRepository = RepositoryMocks.GetPieRepository();
        var categoryRepository = RepositoryMocks.GetCategoryRepository();
        var pieController = new PieController(categoryRepository.Object, pieRepository.Object);

        //act
        var ViewResult = pieController.List("");

        // assert
        //ViewResult.Should().BeOfType<ViewResult>();
        //var pieListModel = Assert.IsAssignableFrom<PieListViewModel>(ViewResult.ViewData.Model);
        //pieListModel.Pies.Should().HaveCount(10);
    } 
}
