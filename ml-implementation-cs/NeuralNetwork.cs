using System;

public class NeuralNetwork {
	private int[] layerSize;
	private Matrix[] weights;
	private Matrix[] bias;
	private double learningRate;
	private Random rng;

	public NeuralNetwork(int[] layers, double lr = 0.13) {
		this.layerSize = layers;
		this.learningRate = lr;

		weights = new Matrix[layers.Length - 1];
		bias = new Matrix[layers.Length];

		rng = new Random();

		// Initialize random weights and bias
		for(int i = 0; i < layers.Length - 1; i++) {
			weights[i] = new Matrix(layerSize[i], layerSize[i + 1], true);
		}
		for(int i = 0; i < layers.Length; i++) {
			bias[i] = new Matrix(1, layerSize[i], true);
		}
	}

	public Matrix Predict(Matrix data) {
		Matrix output = new Matrix(data.rows, layerSize[layerSize.Length - 1]);
		for(int i = 0; i < data.rows; i++) {
			output[i] = FeedForward(data[i])[weights.Length - 1];
		}

		return output;
	}

	public void Fit(Matrix data, Matrix expected, int epochs, bool verbose = false) {
		for(int e = 0; e < epochs; e++) {
			Console.Write("\nEpoch: " + (e + 1).ToString() + " / " + epochs.ToString());
			for(int i = 0; i < data.rows; i++) {
				if(verbose) {
					Console.WriteLine("\nData point: " + (i + 1).ToString() + " / " + data.rows.ToString());
				}
				
				Matrix[] stepOutput = FeedForward(data[i]);
				Matrix[] error = new Matrix[stepOutput.Length];
				Matrix[] newWeights = new Matrix[weights.Length];
				Matrix tp = expected[i] - stepOutput[stepOutput.Length - 1];
				if(verbose) {
					Console.WriteLine("Variables set");
				}

				error[error.Length - 1] = Matrix.ScalarMultiply(tp, tp) / 2.0;
				if(verbose) {
					Console.WriteLine("Error assigned, proceeding with weight tuning");
				}

				for(int o = stepOutput.Length - 1; o > 0; o--) {
					if(verbose) {
						Console.WriteLine("Tuning Weight: " + (o + 1).ToString() + " / " + weights.Length.ToString() + "\nOld Weight: ");
						weights[o].print();
						Console.WriteLine("Error:");
						error[o].print();
						Console.WriteLine("Layer Input: ");
						stepOutput[o - 1].print();
					}
					newWeights[o] = weights[o] - learningRate * !(!error[o] * ActivationDerivative(stepOutput[o - 1]));
					error[o - 1] = error[o] * !weights[o];
					if(verbose) {
						Console.WriteLine("Error propogated");
					}
				}

				newWeights[0] = weights[0] - learningRate * !(!error[0] * ActivationDerivative(data[i]));

				for(int w = 0; w < weights.Length; w++) {
					weights[w] = newWeights[w];
				}
			}
		}
	}

	public Matrix[] FeedForward(Matrix data, bool verbose = false) {
		Matrix[] layerOutput = new Matrix[weights.Length];

		layerOutput[0] = ActivationFunction((data.copy() + bias[0]) * weights[0]);
		if(verbose) {
			Console.WriteLine("\nInput Layer");
			Console.WriteLine("Layer Output:");
			for(int j = 0; j < layerOutput[0].rows; j++) {
				for(int k = 0; k < layerOutput[0].cols; k++) {
					Console.Write(layerOutput[0][j, k].ToString() + " ");
				}
				Console.Write("\n");
			}
		}

		for(int i = 0; i < weights.Length - 1; i++) {
			layerOutput[i + 1] = layerOutput[i];
			layerOutput[i + 1] = ActivationFunction((layerOutput[i + 1] + bias[i +  1]) * weights[i + 1]);

			if(!verbose) {
				continue;
			}
			Console.WriteLine("\nLayer: " + (i + 1).ToString());
			Console.WriteLine("Layer Input:");
			for(int j = 0; j < layerOutput[i].rows; j++) {
				for(int k = 0; k < layerOutput[i].cols; k++) {
					Console.Write(layerOutput[i][j, k].ToString() + " ");
				}
				Console.Write("\n");
			}
			Console.WriteLine("Layer Output:");
			for(int j = 0; j < layerOutput[i + 1].rows; j++) {
				for(int k = 0; k < layerOutput[i + 1].cols; k++) {
					Console.Write(layerOutput[i + 1][j, k].ToString() + " ");
				}
				Console.Write("\n");
			}
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
	public Matrix ActivationDerivative(Matrix data) {
		Matrix ret = data.copy();
		for(int i = 0; i < data.rows; i++) {
			for(int j = 0; j < data.cols; j++) {
				ret[i, j] = 4 * Math.Exp(-2 * data[i, j]) / Math.Pow(Math.Exp(-2 * data[i, j] + 1), 2);
			}
		}
		return ret;
	}

	public void DebugOutput() {
		Console.WriteLine("Bias:");
		for(int c = 0; c < bias.Length; c++) {
			Console.WriteLine((c + 1).ToString() + ":");
			for(int i = 0; i < bias[c].rows; i++) {
				for(int j = 0; j < bias[c].cols; j++) {
					Console.Write(bias[c][i, j].ToString() + " ");
				}
				Console.Write("\n");
			}
		}

		Console.WriteLine("Weights:");
		for(int c = 0; c < weights.Length; c++) {
			Console.WriteLine((c + 1).ToString() + ":");
			for(int i = 0; i < weights[c].rows; i++) {
				for(int j = 0; j < weights[c].cols; j++) {
					Console.Write(weights[c][i, j].ToString() + " ");
				}
				Console.Write("\n");
			}
		}
	}
}
