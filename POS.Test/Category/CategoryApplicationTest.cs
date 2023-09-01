using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.Application.Dtos.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingNullOrEmptyValues_ValidationErrors()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope.ServiceProvider.GetService<ICategoryApplication>();

            //arrange
            var name = "";
            var description = "";
            var state =  1;
            var expected = Replymessage.MESSAGE_VALIDATE;
            //act
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;
            
            //assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopeFactory?.CreateScope();
            var context = scope.ServiceProvider.GetService<ICategoryApplication>();

            //arrange
            var name = "Test name";
            var description = "Test desc";
            var state = 1;
            var expected = Replymessage.MESSAGE_SAVE;
            //act
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;

            //assert
            Assert.AreEqual(expected, current);
        }

    }
}
