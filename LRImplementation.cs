/*
	Linear Regression Implementation

	Finction: y = 0.4 * x + 2.4
*/
public class LRImplementation {
	void initTable(out Matrix left, out Matrix right) {
		left = new Matrix(32, 1);
		right = new Matrix(32, 1);

		float low = -1f, high = 1f;
		float delta = (high - low) / 31f;
		for(int i = 0; i < 32; i++) {
			left[i, 0] = low + delta * i;
			right[i, 0] = 0.4f * left[i, 0] + 2.4f;
		}
	}

	public static void Main(string[] args) {
		LinearRegression lr = new LinearRegression();
		Matrix lrIn, lrOut;
		LRImplementation handler = new LRImplementation();
		handler.initTable(out lrIn, out lrOut);

		Matrix prediction = lr.predict(lrIn);
		Console.WriteLine("Before fitting:");
		Console.WriteLine("Function: y = " + lr.showSlope() + " * x + " + lr.showBias());
		Console.WriteLine("Input\t\tExpected\tPrediction");
		for(int i = 0; i < 32; i++) {
			Console.WriteLine(lrIn[i, 0] + "\t\t" + lrOut[i, 0] + "\t\t" + prediction[i, 0]);
		}

		lr.fit(lrIn, lrOut, 0);
		Console.WriteLine("After fitting:");
		Console.WriteLine("Function: y = " + lr.showSlope() + " * x + " + lr.showBias());
		Console.WriteLine("Input\t\tExpected\tPrediction");
		for(int i = 0; i < 32; i++) {
			Console.WriteLine(lrIn[i, 0] + "\t\t" + lrOut[i, 0] + "\t\t" + prediction[i, 0]);
		}
	}	
}
