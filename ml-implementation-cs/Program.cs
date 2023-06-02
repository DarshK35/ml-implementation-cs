// See https://aka.ms/new-console-template for more information

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
NeuralNetwork test = new NeuralNetwork(layers);
Console.WriteLine("Neural Network defined");
test.DebugOutput();
Matrix input = new Matrix(1, 2, true);
Matrix noutput = test.FeedForward(input);

Console.WriteLine("\n\nTest Output:");
for(int i = 0; i < noutput.rows; i++) {
	for(int j = 0; j < noutput.cols; j++) {
		Console.Write(noutput[i, j].ToString() + " ");
	}
	Console.Write("\n");
}