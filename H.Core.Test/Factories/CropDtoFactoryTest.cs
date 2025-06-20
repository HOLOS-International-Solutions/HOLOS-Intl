using H.Avalonia.ViewModels.ComponentViews.LandManagement.Field;
using H.Core.Enumerations;
using H.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H.Core.Test.Factories;

[TestClass]
public class CropDtoFactoryTest
{
    #region Fields

    private ICropFactory _factory;

    #endregion

    #region Initialization

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
    }

    [TestInitialize]
    public void TestInitialize()
    {
        _factory = new CropFactory();
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    #endregion

    [TestMethod]
    public void CreateReturnsNonNull()
    {
        var result = _factory.CreateCropDto();

        Assert.IsNotNull(result);
    }
}
