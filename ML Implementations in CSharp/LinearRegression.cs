class LinearRegression {
	float slope, bias;
	Matrix input, output;
	float learningRate;

	public LinearRegression() {
		Random rng = new Random();
		slope = (float)rng.NextDouble();
		bias = (float)rng.NextDouble();
		learningRate = 0.1f;
	}
	public LinearRegression(float learningRate) {
		Random rng = new Random();
		slope = (float)rng.NextDouble();
		bias = (float)rng.NextDouble();
		this.learningRate = learningRate;
	}

	public void fit(Matrix input, Matrix output, int current, int epochs = 100) {
		if(current >= epochs) {
			return;
		}
		Matrix pred = predict(input);

		float slopeDelta = 0;
		float biasDelta = 0;
		for(int i = 0; i < input.rows; i++) {
			slopeDelta += (pred[i, 0] - output[i, 0]) * input[i, 0] / (float)input.rows;
			biasDelta += (pred[i, 0] - output[i, 0]) / (float)input.rows;
		}

		slope -= slopeDelta * learningRate;
		bias -= biasDelta * learningRate;

		fit(input, output, current + 1, epochs);
	}
	public float preddictSingle(float input) {
		return (input * slope) + bias;
	}
	public Matrix predict(Matrix input) {
		return (input * slope) + bias;
	}
	public Matrix line(float low, float high) {
		Matrix range = new Matrix(100, 1);
		float delta = high - low / 99;

		for(int i = 0; i < 100; i++) {
			range[i, 0] = low * i * delta;
		}
		return predict(range);
	}

	public float showSlope() {
		return this.slope;
	}
	public float showBias() {
		return this.bias;
	}
}
