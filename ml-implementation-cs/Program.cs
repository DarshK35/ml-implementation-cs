// See https://aka.ms/new-console-template for more information

using System;

Console.WriteLine("\nLinear Regression Test:\n");
double[,] data = {
	{1, 2},
	{1, 3},
	{2, 4},
	{2, 5},
	{0, 1}
};
double[,] output = {
	{1},
	{2},
	{1},
	{4},
	{2}
};
Matrix x = new Matrix(data);
Matrix y = new Matrix(output);

LinearRegression lr = new LinearRegression();
lr.Fit(x, y);

double[,] newData = {{2, 3}};
Matrix testData = new Matrix(newData);
Matrix testOutput = lr.Predict(testData);

Console.WriteLine("Test Data: ");
testData.print();
Console.WriteLine("Test Output: ");
testOutput.print();


Console.WriteLine("\nNeural Network Code testing");
int[] layers = { 4, 4, 5, 1 };
NeuralNetwork test = new NeuralNetwork(layers, 0.07);
Console.WriteLine("Neural Network defined");
test.DebugOutput();

// Generating 4 variable boolean data
Matrix nnInput = new Matrix(16, 4);
Matrix nnOutput = new Matrix(16, 1);
testData = new Matrix(3, 4, true);
Matrix nnPred;

for(int i = 0; i < 16; i++) {
	string bin = Convert.ToString(i, 2).PadLeft(4, '0');
	for(int j = 0; j < 4; j++) {
		nnInput[i, j] = (bin[j] == '0') ? -1 : 1;
	}

	if((nnInput[i, 0] > 0 || nnInput[i, 2] > 0) && nnInput[i, 1] > 0 && nnInput[i, 3] < 0) {
		nnOutput[i, 0] = 1;
	} else {
		nnOutput[i, 0] = -1;
	}
}

Console.WriteLine("\n\nTest Input:");
testData.print();

Console.WriteLine("\n\nTest Output:");
nnPred = test.Predict(testData);
nnPred.print();

Console.WriteLine("Training...");
test.Fit(nnInput, nnOutput, 20);


nnPred = test.Predict(testData);
Console.WriteLine("\n\nTest Output:");
nnPred.print();
test.DebugOutput();
