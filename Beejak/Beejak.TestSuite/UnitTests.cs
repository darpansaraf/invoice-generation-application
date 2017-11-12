using System;
using System.Collections.Generic;
using Beejak.DataLayer.Interfaces;
using Beejak.DI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beejak.TestSuite
{
    [TestClass]
    public class UnitTests
    {
        IProductProvider productsProvider = null;

        [TestInitialize]
        public void Initialize()
        {
            productsProvider = DependancyManager.Resolve<IProductProvider>();
        }


        [TestMethod]
        public void TestToGetCategoryAndProductsMappingFromMockProvider()
        {
            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();

            Assert.IsNotNull(categoryToProductsMapping);
        }

        [TestMethod]
        public void TestToGetCategoryAndTaxMappingFromConfigFile()
        {

            var taxProvider = DependancyManager.Resolve<ITaxProvider>();

            var categoryToTaxMapping = taxProvider.GetCategoryAndTaxMapping();

            Assert.IsNotNull(categoryToTaxMapping);

        }

        [TestMethod]
        public void TestToGetCategoryAndRateMappingFromConfigFile()
        {
            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();

            Assert.IsNotNull(categoryToProductsMapping);
        }

        [TestMethod]
        public void TestToCheckWhetherApplicationProvidesValidOutputForAGivenValidInput()
        {
            var inputProducts = new List<string>() { "1", "4", "7" };

            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();

            var grandTotal = BillCalculator.CalculateBill(inputProducts, categoryToProductsMapping);

            Assert.AreEqual(grandTotal, 116.7);
        }

        [TestMethod]
        public void TestToReturnACollaboratedListAllProductsOfAllCategoies()
        {
            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();

            var productsOfAllCategories = Helper.GetProductsOfAllCategories(categoryToProductsMapping);

            Assert.IsNotNull(productsOfAllCategories);

            Assert.AreEqual(productsOfAllCategories.Count, 9);

        }

        [TestMethod]
        public void TestToCheckWhetherInvalidProductsArePresentInCart()
        {
            var productsInCart = new List<string>(){ "1", "2", "3", "4", "5", "55" };
            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();
            var availableProducts = Helper.GetProductsOfAllCategories(categoryToProductsMapping);
            var invalidProducts = Helper.GetInvalidProductsIfPresent(productsInCart, availableProducts);

            Assert.IsNotNull(invalidProducts);

        }
    }
}
