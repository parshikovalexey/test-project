using GeometryLibrary.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeometryLibrary.Services {
	public class GeometryTool : BaseTool, IGeometryTool {
		protected readonly ICircleTool CircleTool;
		protected readonly ITriangleTool TriangleTool;

		public GeometryTool(ILogger<GeometryTool> logger, ICircleTool circleTool, ITriangleTool triangleTool): base(logger) {
			CircleTool = circleTool;
			TriangleTool = triangleTool;
		}

		public double GetCircleArea(double r) {
			return CircleTool.GetCircleArea(r);
		}

		public double GetFigureArea(params double[] parameters) {
			switch (parameters.Length) {
				case 0: throw new ArgumentException("Not enough parameters to calculate figure area"); break;
				case 1: return GetCircleArea(parameters[0]);
				case 3: return GetTriangleArea(parameters[0], parameters[1], parameters[2]);
				default: throw new NotImplementedException();
			}
		}

		public double GetTriangleArea(double a, double b, double c) {
			return TriangleTool.GetTriangleArea(a, b, c);
		}
	}
}
