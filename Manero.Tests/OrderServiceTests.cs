using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq.Expressions;

namespace Manero.Tests;

public class OrderServiceTests
{

	[Fact]
	public async Task GetOrderIfExistAsync_ShouldReturnOrder_WhenOrderExists()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockOrderRepository = new Mock<IOrderRepository>();
		var mockOrderRowRepository = new Mock<IOrderRowRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		var mockRequestCookieCollection = new Mock<IRequestCookieCollection>();

		var order = new OrderEntity
		{
			Id = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"),
			UserId = "testUserId",
			Created = DateTime.Now,
			PromocodeId = null,
			SubtotalPrice = 0,
			DeliveryPrice = 0,
			TotalPrice = 0,
			TotalQuantity = 0,
			OrderRows = new[]
			{
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("d7b106ff-c03b-482b-a76a-83a9f06ed154"), ProductArticleNumber = "TestProductOne", ProductPrice = (decimal)19.99, Discount = (decimal)15.99, Quantity = 2 },
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("81d5d32f-fef7-45c5-96c3-f3a8c12c0f60"), ProductArticleNumber = "TestProductTwo", ProductPrice = (decimal)5.99, Quantity = 1 },
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("e7644c67-3c69-478d-8117-7a5a5f39e0e1"), ProductArticleNumber = "TestProductThree", ProductPrice = (decimal)25.99, Discount = 20, Quantity = 4 }
			}
		};


		mockRequestCookieCollection.Setup(x => x["OrderID"]).Returns(order.Id.ToString());

		var defaultHttpContext = new DefaultHttpContext { RequestServices = new ServiceCollection().BuildServiceProvider() };
		defaultHttpContext.Request.Headers["Host"] = "localhost";
		defaultHttpContext.Request.Scheme = "http";
		defaultHttpContext.Request.Cookies = mockRequestCookieCollection.Object;

		mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(defaultHttpContext);

		mockOrderRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<OrderEntity, bool>>>()))
						  .ReturnsAsync(order);

		var orderService = new OrderService(mockOrderRepository.Object, mockOrderRowRepository.Object, mockHttpContextAccessor.Object);

		// Act
		//------------------------------------------------------------------
		var result = await orderService.GetOrderIfExistAsync();

		// Assert
		//------------------------------------------------------------------
		Assert.NotNull(result);
		Assert.Equal(order.Id, result.Id);

		mockOrderRepository.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<OrderEntity, bool>>>()), Times.Once);
	}

	[Fact]
	public async Task GetOrderIfExistAsync_ShouldReturnNull_WhenOrderDoesNotExist()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockOrderRepository = new Mock<IOrderRepository>();
		var mockOrderRowRepository = new Mock<IOrderRowRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

		mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());

		// Mock OrderRepository returning null (order does not exist)
		var orderRepositoryMock = new Mock<IOrderRepository>();
		orderRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<OrderEntity, bool>>>()))
						  .ReturnsAsync((OrderEntity)null!);

		var orderService = new OrderService(mockOrderRepository.Object, mockOrderRowRepository.Object, mockHttpContextAccessor.Object);

		// Act
		//------------------------------------------------------------------
		var result = await orderService.GetOrderIfExistAsync();

		// Assert
		//------------------------------------------------------------------
		Assert.Null(result);
		mockOrderRepository.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<OrderEntity, bool>>>()), Times.Once);
	}


	[Fact]
	public async Task UpdateOrderWithRowsAsync_ShouldCalculateAndUpdateOrderCorrectly()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockOrderRepository = new Mock<IOrderRepository>();
		var mockOrderRowRepository = new Mock<IOrderRowRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

		var orderService = new OrderService(mockOrderRepository.Object, mockOrderRowRepository.Object, mockHttpContextAccessor.Object);

		// Mock data for the test
		var order = new OrderEntity
		{
			Id = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"),
			UserId = "testUserId",
			Created = DateTime.Now,
			PromocodeId = null,
			SubtotalPrice = 0,
			DeliveryPrice = 0,
			TotalPrice = 0,
			TotalQuantity = 0,
		};

		var orderRows = new List<OrderRowEntity>
		{
			new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("d7b106ff-c03b-482b-a76a-83a9f06ed154"), ProductArticleNumber = "TestProductOne", ProductPrice = (decimal)19.99, Discount = (decimal)15.99, Quantity = 2 },
			new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("81d5d32f-fef7-45c5-96c3-f3a8c12c0f60"), ProductArticleNumber = "TestProductTwo", ProductPrice = (decimal)5.99, Quantity = 1 },
			new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("e7644c67-3c69-478d-8117-7a5a5f39e0e1"), ProductArticleNumber = "TestProductThree", ProductPrice = (decimal)25.99, Discount = 20, Quantity = 4 },

		};

		var expectedTotalPrice = (decimal) 117.97;
		var expectedTotalQuantity = 7;
		var expectedDeliveryPrice = (decimal) 0;
		var expectedSubtotalPrice = (decimal) 149.93;

		mockOrderRowRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<OrderRowEntity, bool>>>()))
			.ReturnsAsync(orderRows); // Mock the GetAllAsync method to return order rows

		mockOrderRepository.Setup(x => x.UpdateAsync(It.IsAny<OrderEntity>()))
			.ReturnsAsync(order); // Mock the UpdateAsync method to return the order

		// Act
		//------------------------------------------------------------------
		var result = await orderService.UpdateOrderWithRowsAsync(order);

		// Assert
		//------------------------------------------------------------------
		Assert.NotNull(result);
		Assert.Equal(expectedSubtotalPrice, result.SubtotalPrice);
		Assert.Equal(expectedTotalPrice, result.TotalPrice);
		Assert.Equal(expectedTotalQuantity, result.TotalQuantity);
		Assert.Equal(expectedDeliveryPrice, result.DeliveryPrice);

		mockOrderRowRepository.Verify(repo => repo.GetAllAsync(It.IsAny<Expression<Func<OrderRowEntity, bool>>>()), Times.Once);
		mockOrderRepository.Verify(repo => repo.UpdateAsync(It.IsAny<OrderEntity>()), Times.Once);

	}


	[Fact]
	public void ImplicitConversion_ShouldConvertsToOrder_WithValidEntity()
	{
		// Arrange
		//------------------------------------------------------------------
		var entity = new OrderEntity
		{
			Id = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"),
			UserId = "testUserId",
			Created = DateTime.Now,
			PromocodeId = null,
			SubtotalPrice = 0,
			DeliveryPrice = 0,
			TotalPrice = 0,
			TotalQuantity = 0,
			OrderRows = new[] 
			{
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("d7b106ff-c03b-482b-a76a-83a9f06ed154"), ProductArticleNumber = "TestProductOne", ProductPrice = (decimal)19.99, Discount = (decimal)15.99, Quantity = 2 },
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("81d5d32f-fef7-45c5-96c3-f3a8c12c0f60"), ProductArticleNumber = "TestProductTwo", ProductPrice = (decimal)5.99, Quantity = 1 },
				new OrderRowEntity() { OrderId = new Guid("b54f44c7-8236-4a25-a482-bf2148f8f5ff"), ProductVariantId = new Guid("e7644c67-3c69-478d-8117-7a5a5f39e0e1"), ProductArticleNumber = "TestProductThree", ProductPrice = (decimal)25.99, Discount = 20, Quantity = 4 }
			}
		};

		// Act
		//------------------------------------------------------------------
		Order order = entity; // Implicit conversion

		// Assert
		//------------------------------------------------------------------
		Assert.NotNull(order);
		Assert.Equal(entity.Id, order.Id);
		Assert.Equal(entity.Created, order.Created);
		Assert.Equal(entity.UserId, order.UserId);
		Assert.Equal(entity.TotalQuantity, order.TotalQuantity);
		Assert.Equal(entity.PromocodeId, order.PromocodeId);
		Assert.Equal(entity.SubtotalPrice, order.SubtotalPrice);
		Assert.Equal(entity.DeliveryPrice, order.DeliveryPrice);
		Assert.Equal(entity.TotalPrice, order.TotalPrice);
		Assert.Equal(entity.OrderRows.Count, order.OrderRows.Count);
	}

	[Fact]
	public void ImplicitConversion_ShouldReturnNullOrder_WithNullEntity()
	{
		// Arrange
		//------------------------------------------------------------------
		OrderEntity entity = null!; // Simulate null entity

		// Act
		//------------------------------------------------------------------
		Order order = entity; // Implicit conversion

		// Assert
		//------------------------------------------------------------------
		Assert.Null(order);
	}
}
