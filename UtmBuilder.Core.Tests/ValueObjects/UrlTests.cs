using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    
    private const string InvalidUrl = "google";
    private const string ValidUrl = "https://www.google.com";
    
    [TestMethod("Should_Return_Exception_When_Url_Is_Invalid")]
    [ExpectedException(typeof(InvalidUrlException))]
    [TestCategory("Url Tests")]
    public void Should_Return_Exception_When_Url_Is_Invalid()
    {
        var url = new Url(InvalidUrl);
    }
    
    [TestMethod("Should_Not_Return_Exception_When_Url_Is_Invalid")]
    [TestCategory("Url Tests")]
    public void Should_Not_Return_Exception_When_Url_Is_Invalid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }
    
    [TestMethod("Test_Learn_DataRow")]
    [DataRow("  ", true)]
    [DataRow("https://www.google.com", false)]
    [DataRow("Laranja", true)]
    [TestCategory("Url Tests")]
    public void Test_Learn_DataRow(string link, bool expectedException)
    {
        if (expectedException)
        {
            try
            {
                new Url(link);
                Assert.Fail(); 
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }
}