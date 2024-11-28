using Microsoft.Extensions.Logging;

namespace GeometryLibrary.Services {
	public class BaseTool {
		protected readonly ILogger Logger;
		public BaseTool(ILogger logger) {
			Logger = logger;
		}

		public double SafeCalculation(Func<double> calculationFunction, double onFailReturn) {
			try {
				return calculationFunction.Invoke();
			} catch (Exception ex) {
				Logger.LogError(ex, "Exception in calculation");
				return onFailReturn;
			}
		}
	}
}
