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

	private Matrix FeedForward(Matrix data) {
		Matrix layerOutput = ActivationFunction(data.copy() + bias[0]);

		for(int i = 1; i < layerSize.Length; i++) {
			layerOutput = layerOutput * weights[i - 1];
			layerOutput = ActivationFunction(layerOutput * bias[i]);
		}
		return layherOutput;
	}

	private Matrix ActivationFunction(Matrix data) {
		Matrix ret = data.copy();
		for(int i = 0; i < data.rows; i++) {
			for(int j = 0; j < data.cols; j++) {
				ret[i, j] = Math.Tanh(data[i, j]);
			}
		}
		return ret;
	}
}