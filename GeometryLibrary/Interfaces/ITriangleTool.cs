namespace GeometryLibrary.Interfaces {
	public interface ITriangleTool {
		/// <summary>
		/// Calculates the Triangle area by 3 sides
		/// </summary>
		/// <param name="a">The side a length</param>
		/// <param name="b">The side a length</param>
		/// <param name="c">The side a length</param>
		/// <returns>The Triangle area</returns>
		double GetTriangleArea(double a, double b, double c);
	}
}
