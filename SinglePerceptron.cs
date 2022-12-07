public class SinglePerceptron {
	Matrix input, weight, output;
	int inputSize;
	float bias;
	float error, learningRate;

	public SinglePerceptron() {
		this.inputSize = 4;
		this.learningRate = 0.1f;
		this.input = new Matrix(1, 4);
		this.weight = new Matrix(4, 1);
		this.output = new Matrix(1, 1);

		Random rng = new Random();
		this.bias = (float)rng.NextDouble();
		for(int i = 0; i < inputSize; i++) {
			this.weight[i, 0] = (float)rng.NextDouble();
		}
	}
	public SinglePerceptron(int inputSize) {
		this.inputSize = inputSize;
		this.learningRate = 0.1f;
		this.input = new Matrix(1, inputSize);
		this.weight = new Matrix(inputSize, 1);
		this.output = new Matrix(1, 1);

		Random rng = new Random();
		this.bias = (float)rng.NextDouble();
		for(int i = 0; i < inputSize; i++) {
			this.weight[i, 0] = (float)rng.NextDouble();
		}
	}
	public SinglePerceptron(int inputSize, float learningRate) {
		this.inputSize = inputSize;
		this.learningRate = learningRate;
		this.input = new Matrix(1, inputSize);
		this.weight = new Matrix(inputSize, 1);
		this.output = new Matrix(1, 1);

		Random rng = new Random();
		this.bias = (float)rng.NextDouble();
		for(int i = 0; i < inputSize; i++) {
			this.weight[i, 0] = (float)rng.NextDouble();
		}
	}

	// ML Essential Functions
	void predictSingle(Matrix input) {
		this.input = input;
		output = bulkSigmoidActivation(input * weight + bias);
	}
	void trainSingle(Matrix input, Matrix output) {
		this.input = input;
		this.output = bulkSigmoidActivation(this.input * weight + bias);

		error = (this.output - output)[0,0];
		Matrix delta = Matrix.scalarMul(this.input.transpose(), weight) * (error * learningRate);
		weight = weight - delta;
		bias = bias - error * learningRate;
	}
	public Matrix[] predict(Matrix[] input) {
		Matrix[] ret = new Matrix[input.Length];
		for(int i = 0; i < input.Length; i++) {
			ret[i] = new Matrix(1, 1);
			predictSingle(input[i]);
			ret[i] = this.output;
		}
		return ret;
	}
	public void train(Matrix[] input, Matrix[] output, int epochs) {
		float avgError;
		Console.WriteLine("Starting training: " + input.Length + " over " + epochs + " epochs");

		for(int i = 1; i <= epochs; i++) {
			Console.Write("Epoch: " + i + "/" + epochs);
			avgError = 0;
			for(int j = 0; j < input.Length; j++) {
				trainSingle(input[j], output[j]);
				avgError += MathF.Abs(error) / (float)input.Length;
			}
			Console.WriteLine(": Complete");
			Console.WriteLine("Error: " + avgError);
		}
	}

	// Helper Functions
	float sigmoidActivation(float x) {
		return 1.0f / (1.0f + MathF.Exp(-x));
	}
	Matrix bulkSigmoidActivation(Matrix x) {
		Matrix ret = new Matrix(x.rows, x.cols);
		for(int i = 0; i < x.rows; i++) {
			for(int j = 0; j < x.cols; j++) {
				ret[i, j] = sigmoidActivation(x[i, j]);
			}
		}
		return ret;
	}
}