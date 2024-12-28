using BathenyShop.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;

namespace BathenyShopTest.TagHelpersTests;

public class EmailTagHelperTests
{

    [Fact]
    public void Should_Generate_Email_Link()
    {
        //arrange
        var emailTagHelper = new EmailTagHelper()
        {
            Address = "flesten.a@gmail.com",
            Content = "Email"
        };

        var content = new Mock<TagHelperContent>();

        var context =
            new TagHelperContext(
               new TagHelperAttributeList(),
               new Dictionary<object, object>(),
               string.Empty
            );

        var output = new TagHelperOutput(
            "a",
            new TagHelperAttributeList(),
            (cache, encoder) => Task.FromResult(content.Object)
        );

        // act
        emailTagHelper.Process(context, output);

        //assert
        Assert.Equal("Email", output.Content.GetContent());
        Assert.Equal("a", output.TagName);
        Assert.Equal("mailto:flesten.a@gmail.com", output.Attributes[0].Value);
    }
}
