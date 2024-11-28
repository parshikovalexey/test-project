using GeometryLibrary.Interfaces;

namespace GeometryLibrary.Services {
	public class TriangleTool : ITriangleTool {
		public double GetTriangleArea(double a, double b, double c) {
			if (a <= 0 || b <= 0 || c <= 0) {
				throw new ArgumentOutOfRangeException("Invalid sides lengths");
			}
			double g = Math.Max(a, Math.Max(b, c));
			double k1 = Math.Min(a, Math.Min(b, c));
			double p = a + b + c;
			double k2 = p - g - k1;
			if (Math.Pow(g, 2) == Math.Pow(k1, 2) + Math.Pow(k2, 2)) {
				return k1 * k2 / 2;
			}
			p = p / 2;
			return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}
	}
}
