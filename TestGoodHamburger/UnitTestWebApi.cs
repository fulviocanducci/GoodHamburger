using Application.DTOs;
using Application.DTOs.Category;
using Application.DTOs.Menu;
using Application.DTOs.Order;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace TestGoodHamburger
{
    public class UnitTestWebApi
    {
        #region TestCategoryController
        [Fact]
        public async Task GetAll_ReturnsOkWithCategories()
        {
            var mock = new Mock<ICategoryService>();
            var list = new List<CategoryView>
            {
                new CategoryView { Id = 1, Name = "Category1" },
                new CategoryView { Id = 2, Name = "Category2" }
            };
            mock.Setup(s => s.GetAsync()).ReturnsAsync(list.AsEnumerable());

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsAssignableFrom<IEnumerable<CategoryView>>(okResult.Value);
            Assert.Equal(2, data.Count());
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenFound()
        {
            var mock = new Mock<ICategoryService>();
            mock.Setup(s => s.GetAsync(1)).ReturnsAsync(new CategoryView { Id = 1, Name = "Category1" });

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Get(1);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsType<CategoryView>(okResult.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<ICategoryService>();
            mock.Setup(s => s.GetAsync(99)).ReturnsAsync((CategoryView?)null);

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Get(99);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Create_ReturnsCreated_WhenValid()
        {
            var mock = new Mock<ICategoryService>();
            var created = new CategoryView { Id = 3, Name = "NewCategory" };
            mock.Setup(s => s.CreateAsync(It.IsAny<CategoryCreate>())).ReturnsAsync(created);

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Create(new CategoryCreate { Name = "NewCategory" });
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var data = Assert.IsType<CategoryView>(createdResult.Value);
            Assert.Equal(3, data.Id);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelNull()
        {
            var mock = new Mock<ICategoryService>();
            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Create(null!);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenValid()
        {
            var mock = new Mock<ICategoryService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<CategoryUpdate>())).ReturnsAsync(Result.Success());

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Update(1, new CategoryUpdate { Id = 1, Name = "Updated" });
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var res = Assert.IsType<Result>(okResult.Value);
            Assert.True(res.Status);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenIdMismatch()
        {
            var mock = new Mock<ICategoryService>();
            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Update(1, new CategoryUpdate { Id = 2, Name = "Updated" });
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenIdZero()
        {
            var mock = new Mock<ICategoryService>();
            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Delete(0);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<ICategoryService>();
            mock.Setup(s => s.IsIdExist(5)).Returns(false);

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Delete(5);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenDeleted()
        {
            var mock = new Mock<ICategoryService>();
            mock.Setup(s => s.IsIdExist(2)).Returns(true);
            mock.Setup(s => s.DeleteAsync(2)).ReturnsAsync(Result.Success());

            var controller = new CategoryController(mock.Object);
            var actionResult = await controller.Delete(2);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var res = Assert.IsType<Result>(okResult.Value);
            Assert.True(res.Status);
        }
        #endregion TestCategoryController

        #region TestMenuController

        [Fact]
        public async Task Menu_GetAll_ReturnsOkWithMenus()
        {
            var mock = new Mock<IMenuService>();
            var list = new List<MenuView>
            {
                new MenuView { Id = 1, Name = "Menu1", Value = 10 },
                new MenuView { Id = 2, Name = "Menu2", Value = 20 }
            };
            mock.Setup(s => s.GetAsync()).ReturnsAsync(list.AsEnumerable());

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsAssignableFrom<IEnumerable<MenuView>>(okResult.Value);
            Assert.Equal(2, data.Count());
        }

        [Fact]
        public async Task Menu_GetById_ReturnsOk_WhenFound()
        {
            var mock = new Mock<IMenuService>();
            mock.Setup(s => s.GetAsync(1)).ReturnsAsync(new MenuView { Id = 1, Name = "Menu1" });

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Get(1);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsType<MenuView>(okResult.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task Menu_GetById_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<IMenuService>();
            mock.Setup(s => s.GetAsync(99)).ReturnsAsync((MenuView?)null);

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Get(99);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Menu_GetByNameFilter_ReturnsOk()
        {
            var mock = new Mock<IMenuService>();
            var list = new List<MenuView> { new MenuView { Id = 1, Name = "Special" } };
            mock.Setup(s => s.GetAsync("Special")).ReturnsAsync(list.AsEnumerable());

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Get("Special");
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsAssignableFrom<IEnumerable<MenuView>>(okResult.Value);
            Assert.Single(data);
        }

        [Fact]
        public async Task Menu_Create_ReturnsCreated_WhenValid()
        {
            var mock = new Mock<IMenuService>();
            var created = new MenuView { Id = 5, Name = "NewMenu", Value = 30 };
            mock.Setup(s => s.CreateAsync(It.IsAny<MenuCreate>())).ReturnsAsync(created);

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Create(new MenuCreate { CategoryId = 1, Name = "NewMenu", Value = 30 });
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var data = Assert.IsType<MenuView>(createdResult.Value);
            Assert.Equal(5, data.Id);
        }

        [Fact]
        public async Task Menu_Create_ReturnsBadRequest_WhenModelNull()
        {
            var mock = new Mock<IMenuService>();
            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Create(null!);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Menu_Update_ReturnsOk_WhenValid()
        {
            var mock = new Mock<IMenuService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<MenuUpdate>())).ReturnsAsync(Result.Success());

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Update(1, new MenuUpdate { Id = 1, CategoryId = 1, Name = "Upd", Value = 15 });
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var res = Assert.IsType<Result>(okResult.Value);
            Assert.True(res.Status);
        }

        [Fact]
        public async Task Menu_Update_ReturnsBadRequest_WhenIdMismatch()
        {
            var mock = new Mock<IMenuService>();
            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Update(1, new MenuUpdate { Id = 2, CategoryId = 1, Name = "Upd", Value = 15 });
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Menu_Delete_ReturnsBadRequest_WhenIdZero()
        {
            var mock = new Mock<IMenuService>();
            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Delete(0);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Menu_Delete_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<IMenuService>();
            mock.Setup(s => s.IsIdExist(7)).Returns(false);

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Delete(7);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Menu_Delete_ReturnsOk_WhenDeleted()
        {
            var mock = new Mock<IMenuService>();
            mock.Setup(s => s.IsIdExist(2)).Returns(true);
            mock.Setup(s => s.DeleteAsync(2)).ReturnsAsync(Result.Success());

            var controller = new MenuController(mock.Object);
            var actionResult = await controller.Delete(2);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var res = Assert.IsType<Result>(okResult.Value);
            Assert.True(res.Status);
        }

        #endregion TestMenuController

        #region TestOrderController

        [Fact]
        public async Task Order_GetAll_ReturnsOkWithOrders()
        {
            var mock = new Mock<IOrderService>();
            var list = new List<OrderView>
            {
                new OrderView { Id = 1, Name = "O1", Total = 10 },
                new OrderView { Id = 2, Name = "O2", Total = 20 }
            };
            mock.Setup(s => s.GetAsync()).ReturnsAsync(list.AsEnumerable());

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsAssignableFrom<IEnumerable<OrderView>>(okResult.Value);
            Assert.Equal(2, data.Count());
        }

        [Fact]
        public async Task Order_GetById_ReturnsOk_WhenFound()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(s => s.GetAsync(1)).ReturnsAsync(new OrderView { Id = 1, Name = "O1" });

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Get(1);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var data = Assert.IsType<OrderView>(okResult.Value);
            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task Order_GetById_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(s => s.GetAsync(99)).ReturnsAsync((OrderView?)null);

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Get(99);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Order_Create_ReturnsCreated_WhenValid()
        {
            var mock = new Mock<IOrderService>();
            var created = new OrderView { Id = 10, Name = "NewOrder", Total = 50 };
            mock.Setup(s => s.CreateAsync(It.IsAny<OrderCreate>())).ReturnsAsync(created);

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Create(new OrderCreate { Name = "NewOrder" });
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            var data = Assert.IsType<OrderView>(createdResult.Value);
            Assert.Equal(10, data.Id);
        }

        [Fact]
        public async Task Order_Create_ReturnsBadRequest_WhenModelNull()
        {
            var mock = new Mock<IOrderService>();
            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Create(null!);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Order_Delete_ReturnsBadRequest_WhenIdZero()
        {
            var mock = new Mock<IOrderService>();
            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Delete(0);
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task Order_Delete_ReturnsNotFound_WhenMissing()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(s => s.IsIdExist(7)).Returns(false);

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Delete(7);
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Order_Delete_ReturnsOk_WhenDeleted()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(s => s.IsIdExist(2)).Returns(true);
            mock.Setup(s => s.DeleteAsync(2)).ReturnsAsync(Result.Success());

            var controller = new OrderController(mock.Object);
            var actionResult = await controller.Delete(2);
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var res = Assert.IsType<Result>(okResult.Value);
            Assert.True(res.Status);
        }

        #endregion TestOrderController

    }
}
