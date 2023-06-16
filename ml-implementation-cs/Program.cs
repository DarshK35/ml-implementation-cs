// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
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

Console.WriteLine("Test Data: " + testData[0, 0].ToString() + ", " + testData[0, 1].ToString());
Console.WriteLine("Test Output: " + testOutput[0, 0].ToString());


Console.WriteLine("\nNeural Network Code testing");
int[] layers = { 2, 4, 5, 1 };
NeuralNetwork test = new NeuralNetwork(layers, 0.01);
Console.WriteLine("Neural Network defined");
test.DebugOutput();

// Generating Random data
Matrix nnInput = (new Matrix(10, 2, true)) * 20 - 10;
Matrix nnOutput = new Matrix(10, 1, true);
for(int i = 0; i < nnOutput.rows; i++) {
	nnOutput[i, 0] = (nnOutput[i, 0] >= 0) ? 1 : -1;
}
testData = new Matrix(1, 2, true) * 20 - 10;
Matrix nnPred;

Console.WriteLine("\n\nTest Output:");
nnPred = test.Predict(testData);
nnPred.print();

Console.WriteLine("Training...");
test.Fit(nnInput, nnOutput, 5);


nnPred = test.Predict(testData);
Console.WriteLine("\n\nTest Output:");
nnPred.print();
//test.DebugOutput();
