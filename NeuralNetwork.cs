using System;

public class NeuralNetwork {
	private int[] layerSize;
	private Matrix[] weights;
	private Matrix[] bias;
	private Random rng;

	public NeuralNetwork(int[] layers) {
		this.layerSize = layers;

		weights = new Matrix[layers.Length - 1];
		bias = new Matrix[layers.Length];

		rng = new Random();

		// Initialize random weights and bias
		for(int i = 0; i < layers.Length - 2; i++) {
			weights[i] = new Matrix(layerSize[i + 1], layerSize[i], true);
		}
		for(int i = 0; i < layers.Length; i++) {
			weights[i] = new Matrix(1, layerSize[i], true);
		}
	}

	public Matrix Predict(Matrix data) {
		Matrix output = new Matrix(data.rows, layerSize[layerSize.Length - 1]);
		for(int i = 0; i < data.rows; i++) {
			output[i] = FeedForward(data[i]);
		}

		return output;
	}

	public void Fit(Matrix data, Matrix expected, int epochs) {
		for(int i = 0; i < data.rows; i++) {
			Matrix actual = FeedForward(data[i]);
			Matrix error = expected - actual;
		}
	}

	private Matrix FeedForward(Matrix data) {
		Matrix layerOutput = ActivationFunction(data.copy() + bias[0]);

		for(int i = 1; i < layerSize.Length; i++) {
			layerOutput = layerOutput * weights[i - 1];
			layerOutput = ActivationFunction(layerOutput * bias[i]);
		}
		return layerOutput;
	}

	// Tanh function is used as activation function for now, more will be added
	private Matrix ActivationFunction(Matrix data) {
		Matrix ret = data.copy();
		for(int i = 0; i < data.rows; i++) {
			for(int j = 0; j < data.cols; j++) {
				ret[i, j] = Math.Tanh(data[i, j]);
			}
		}
		return ret;
	}
	private Matrix ActivationDerivative(Matrix data) {
		Matrix ret = data.copy();
		for(int i = 0; i < data.rows; i++) {
			for(int j = 0; j < data.cols; j++) {
				ret[i, j] = 4 * Math.Exp(-2 * data[i, j]) / Math.Pow(Math.Exp(-2 * data[i, j] + 1, 2);
			}
		}
		return ret;
	}
}