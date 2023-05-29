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

	private void FeedForward(Matrix data) {
		
	}
}