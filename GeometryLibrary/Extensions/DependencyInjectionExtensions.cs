using GeometryLibrary.Interfaces;
using GeometryLibrary.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection {
	public static class DependencyInjectionExtensions {
		public static IServiceCollection AddGeometryTools(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) {
			services.AddService<ICircleTool, CircleTool>(lifetime);
			services.AddService<ITriangleTool, TriangleTool>(lifetime);
			services.AddService<IGeometryTool, GeometryTool>(lifetime);
			return services;
		}

		public static IServiceCollection AddService<TInterface, TImplement>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) {
			services.RemoveAll(typeof(TInterface));
			services.TryAdd(new ServiceDescriptor(typeof(TInterface), typeof(TImplement), lifetime));
			return services;
		}
	}
}
