public class SVC {
	public Matrix weights;
	public double bias;
	public double lambda;
	public double learningRate;

	public SVC(int features, double lr, double lamb) {
		learningRate = lr;
		lambda = lamb;
		weights = new Matrix(features, 1, true);
		bias = new Matrix(1, 1, true)[0, 0];
	}

	public void Fit(Matrix x, Matrix y, int epochs = 400) {
		weights = new Matrix(x.cols, 1, true);
		bias = new Matrix(1, 1, true)[0, 0];

		for(int e = 0; e < epochs; e++) {
			Matrix decision = x * weights + bias;
			Matrix hinge = 1 - Matrix.ScalarMultiply(y, decision);
			Matrix deltaW = new Matrix(weights.rows, weights.cols);
			double deltaB = 0;

			for(int i = 0; i < decision.rows; i++) {
				if(hinge[i, 0] < 0) {
					deltaW += weights;
				} else {
					deltaW += weights - lambda * y[i, 0] * !x[i];
					deltaB -= lambda * y[i, 0];
				}
			}
			deltaW /= (double)x.rows;
			deltaB /= (double)x.rows;

			weights -= learningRate * deltaW;
			bias -= learningRate * deltaB;
		}
	}

	public Matrix Predict(Matrix x) {
		Matrix pred = x * weights + bias;
		for(int i = 0; i < pred.rows; i++) {
			if(pred[i, 0] > 0) {
				pred[i, 0] = 1;
			} else if(pred[i, 0] == 0) {
				pred[i, 0] = 0;
			} else {
				pred[i, 0] = -1;
			}
		}
		return pred;
	}

	public void DebugOutput() {
		Console.WriteLine("Bias: " + bias.ToString() + "\n");
		Console.WriteLine("weights:");
		weights.print();
	}
}
