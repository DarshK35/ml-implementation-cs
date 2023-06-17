public class SVC {
	public Matrix W;
	public double b;
	public double learningRate;

	public void Fit(Matrix x, Matrix y, int epochs = 400) {
		W = new Matrix(x.cols, 1);

		for(int e = 0; e < epochs; e++) {
			for(int i = 0; i < x.rows; i++) {
				W += learningRate * (y[i, 0] * !x[i] - 2 * (1 / x.rows) * W);
				b += learningRate * y[i, 0];
			}
		}
	}

	public Matrix Predict(Matrix x) {
		return x * W + b;
	}
}
