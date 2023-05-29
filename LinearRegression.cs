public class LinearRegression {
	private Matrix coeffs;

	public LinearRegression() {
		coeffs = new Matrix();
	}

	public void Fit(Matrix x, Matrix y) {
		x = AddBias(x);

		// Coeffs calculation
		Matrix xTransX = !x * x;
		Matrix xTransY = !x * y;

		coeffs = xTransX.inverse() * xTransY;
	}

	public Matrix Predict(Matrix x) {
		x = AddBias(x);

		return x * coeffs;
	}

	private Matrix AddBias(Matrix x) {
		Matrix ret = new Matrix(x.rows, x.cols + 1);
		for(int i = 0; i < ret.rows; i++) {
			ret[i, 0] = 1;
			for(int j = 1; j < ret.cols; j++) {
				ret[i, j] = x[i, j - 1];
			}
		}
		return ret;
	}
}