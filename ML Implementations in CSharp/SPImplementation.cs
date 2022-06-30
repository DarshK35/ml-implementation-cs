/*
	Single Perceptron Implementation 
	
	Function: Y = (X1 && X2) || (X3 && X4) && !(X1 || X3)
*/

public class SPImplementation {
	void initTable(out Matrix[] left, out Matrix[] right) {
		left = new Matrix[16];
		right = new Matrix[16];
		for(int i = 0; i < left.Length; i++) {
			left[i] = new Matrix(1, 4);
			right[i] = new Matrix(1, 1);
		}

		string bin;
		bool a, b, c, d, res;
		for(int i = 0; i < left.Length; i++) {
			bin = Convert.ToString(i, 2).PadLeft(4, '0');

			for(int j = 0; j < 4; j++) {
				switch(bin[j]) {
					case '0':
						left[i][0, j] = 0;
						break;

					case '1':
						left[i][0, j] = 1;
						break;
				}
			}

			if(left[i][0, 0] == 1) {
				a = true;
			} else {
				a = false;
			}
			if(left[i][0, 1] == 1) {
				b = true;
			} else {
				b = false;
			}
			if(left[i][0, 2] == 1) {
				c = true;
			} else {
				c = false;
			}
			if(left[i][0, 3] == 1) {
				d = true;
			} else {
				d = false;
			}

			res = (a && b) || (c && d) && !(a || c);

			if(res) {
				right[i][0, 0] = 1;
			} else {
				right[i][0, 0] = 0;
			}
		}
	}

	public static void Main(String[] args) {
		SinglePerceptron sp = new SinglePerceptron(4, 0.1f);
		Matrix[] spIn = new Matrix[16];
		Matrix[] spOut = new Matrix[16];
		SPImplementation handler = new SPImplementation();

		handler.initTable(out spIn, out spOut);
		Matrix[] prediction = sp.predict(spIn);
		for(int i = 0; i < spIn.Length; i++) {
			Console.Write("\nInput: ");
			spIn[i].print();
			Console.Write("Output: ");
			prediction[i].print();
		}

		Console.WriteLine("");
		sp.train(spIn, spOut, 40);

		handler.initTable(out spIn, out spOut);
		prediction = sp.predict(spIn);
		for(int i = 0; i < spIn.Length; i++) {
			Console.Write("\nInput: ");
			spIn[i].print();
			Console.Write("Output: ");
			prediction[i].print();
		}
	}
}