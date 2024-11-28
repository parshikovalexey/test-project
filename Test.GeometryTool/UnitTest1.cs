using GeometryLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Test.GeometryTool {
	public class Tests {
		private IServiceProvider _serviceProvider;

		[SetUp]
		public void Setup() {
			var services = new ServiceCollection();
			services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
			services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger), typeof(Logger<object>)));
			services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
			services.AddGeometryTools();
			_serviceProvider = services.BuildServiceProvider();
		}

		[Test]
		public void GetServiceDoesNotThrow() {
			Assert.DoesNotThrow(() => _serviceProvider.GetService<IGeometryTool>());
		}

		[Test]
		public void GetCircleAreaDoesNotThrow() {
			Assert.DoesNotThrow(() => {
				double cirleArea = _serviceProvider.GetService<IGeometryTool>()!.GetCircleArea(10);
			});
		}

		[Test]
		public void IsCircleAreaCalculatedCorrect() {
			IGeometryTool? tool = _serviceProvider.GetService<IGeometryTool>();
			double r = 10;
			double? result = Math.Round(tool?.GetCircleArea(r) ?? 0, 3);
			double? result2 = Math.Round(tool?.GetFigureArea(r) ?? 0, 3);
			double? correct = Math.Round(Math.PI * Math.Pow(r, 2), 3);

			Assert.That(result, Is.EqualTo(correct), "Dirrect Circle Area is incorrect");
			Assert.That(result2, Is.EqualTo(correct), "Common Circle Area is incorrect");
		}

		[Test]
		public void GetTrianleAreaDoesNotThrow() {
			Assert.DoesNotThrow(() => {
				double cirleArea = _serviceProvider.GetService<IGeometryTool>()!.GetTriangleArea(3, 4, 5);
			});
		}

		[Test]
		public void IsTriangleAreaCalculatedCorrect() {
			IGeometryTool? tool = _serviceProvider.GetService<IGeometryTool>();
			double a = 3, b = 5, c = 4;
			double? result = Math.Round(tool?.GetTriangleArea(a, b, c) ?? 0, 3);
			double? result2 = Math.Round(tool?.GetFigureArea(a, b, c) ?? 0, 3);
			double p = (a + b + c) / 2;
			double? correct = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 3);

			Assert.That(result, Is.EqualTo(correct), "Direct Triangle Area is incorrect");
			Assert.That(result2, Is.EqualTo(correct), "Common Triangle Area is incorrect");
		}

		[Test]
		public void IsSecondTriangleAreaCalculatedCorrect() {
			IGeometryTool? tool = _serviceProvider.GetService<IGeometryTool>();
			double a = 5, b = 5, c = 5;
			double? result = Math.Round(tool?.GetTriangleArea(a, b, c) ?? 0, 3);
			double? result2 = Math.Round(tool?.GetFigureArea(a, b, c) ?? 0, 3);
			double p = (a + b + c) / 2;
			double? correct = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 3);

			Assert.That(result, Is.EqualTo(correct), "Direct Triangle Area is incorrect");
			Assert.That(result2, Is.EqualTo(correct), "Common Triangle Area is incorrect");
		}

		[Test]
		public void IncorrectParamsHandledForCircle() {
			Assert.Throws<ArgumentOutOfRangeException>(() => {
				double cirleArea = _serviceProvider.GetService<IGeometryTool>()!.GetFigureArea(-10);
			});
		}

		[Test]
		public void IncorrectParamsHandledForTriangle() {
			Assert.Throws<ArgumentOutOfRangeException>(() => {
				double cirleArea = _serviceProvider.GetService<IGeometryTool>()!.GetFigureArea(-3, 4, 5);
			});
		}
	}
}