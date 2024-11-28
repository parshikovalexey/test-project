using GeometryLibrary.Interfaces;

namespace GeometryLibrary.Services {
	public class CircleTool : ICircleTool {
		public double GetCircleArea(double r) {
			if (r <= 0) {
				throw new ArgumentOutOfRangeException("Invalid sides lengths");
			}
			return Math.PI * Math.Pow(r, 2);
		}
	}
}
