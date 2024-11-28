namespace GeometryLibrary.Interfaces {
	public interface IGeometryTool: ICircleTool, ITriangleTool {			
		/// <summary>
		/// Calculates the Geomtry figure area by figure parameters: sides length (besides circle, where radius is used). The type of figure is defined by the number of parameters: Single - Circle, 2 sides - Rectangle, 3 sides - Triangle, etc
		/// </summary>
		/// <param name="parameters">Parameter's length</param>
		/// <returns>The figure area</returns>
		double GetFigureArea(params double[] parameters);
	}
}
