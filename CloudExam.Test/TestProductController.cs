using AutoMapper;
using CloudExam.Controllers;
using CloudExam.Models;
using CloudExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace CloudExam.Test
{
    [TestClass]
    public class TestProductController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public TestProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
        
            var controller = new ProductController(_productService,_mapper);

            var result = controller.GetAsync(1).Result;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(testProducts[3].Name, result.Value.Name);
        }

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
            testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
            testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
           
            return testProducts;
        }
    }
}
