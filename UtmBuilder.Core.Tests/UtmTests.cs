using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    private const string Result = "https://google.com/" +
                                  "?utm_source=src" +
                                  "&utm_medium=med" +
                                  "&utm_campaign=nme" +
                                  "&utm_id=id" +
                                  "&utm_term=ter" +
                                  "&utm_content=ctn";

    private readonly Url _url = new("https://google.com/");

    private readonly Campaign _campaign = new(
        "src",
        "med",
        "nme",
        "id",
        "ter",
        "ctn");

    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_url, _campaign);
        
        Assert.AreEqual(Result, utm.ToString());
        Assert.AreEqual(Result, (string)utm);
    }
    
    [TestMethod]
    public void ShouldReturnUtmFromUrl()
    {
        Utm utm = Result;
        Assert.AreEqual("https://google.com/", utm.Url.Address);
        Assert.AreEqual("src", utm.Campaign.Source);
        Assert.AreEqual("med", utm.Campaign.Medium);
        Assert.AreEqual("nme", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("ter", utm.Campaign.Term);
        Assert.AreEqual("ctn", utm.Campaign.Content);
    }
}