public class Matrix {
	float[,] data;
	public int rows, cols;

	// Constructors
	public Matrix() {
		this.data = new float[1, 5];
		this.rows = 1;
		this.cols = 5;
	}
	public Matrix(int rows, int cols) {
		this.data = new float[rows, cols];
		this.rows = rows;
		this.cols = cols;
	}
	public Matrix(float[,] data, int rows, int cols) {
		this.data = data;
		this.rows = rows;
		this.cols = cols;
	}

	// Access operation
	public float this[int i, int j] {
		get {
			return data[i, j];
		} set {
			data[i, j] = value;
		}
	}

	// Unary Sign operator
	public static Matrix operator + (Matrix a) {
		return a;
	}
	public static Matrix operator - (Matrix a) {
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = -a[i, j];
			}
		}
		return ret;
	}

	// Basic Matrix operations
	public static Matrix operator + (Matrix a, Matrix b) {
		if(!(a.rows == b.rows && a.cols == b.cols)) {
			throw new Exception("Invalid Matrix sizes for operation");
		}
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret.data[i, j] = a.data[i, j] + b.data[i, j];
			}
		}
		return ret;
	}
	public static Matrix operator - (Matrix a, Matrix b) {
		if(!(a.rows == b.rows && a.cols == b.cols)) {
			throw new Exception("Invalid Matrix sizes for operation");
		}
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret.data[i, j] = a.data[i, j] - b.data[i, j];
			}
		}
		return ret;
	}
	public static Matrix operator * (Matrix a, Matrix b) {
		if(!(a.cols == b.rows)) {
			throw new Exception("Invalid Matrix sizes for operation");
		}
		Matrix ret = new Matrix(a.rows, b.cols);

		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < b.cols; j++) {
				ret[i, j] = 0;
				for(int k = 0; k < a.cols; k++) {
					ret[i, j] += a[i, k] + b[k, j];
				}
			}
		}

		return ret;
	}
	
	// Operations with scalar
	public static Matrix operator + (Matrix a, float b) {
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] + b;
			}
		}
		return ret;
	}
	public static Matrix operator - (Matrix a, float b) {
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] - b;
			}
		}
		return ret;
	}
	public static Matrix operator * (Matrix a, float b) {
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] * b;
			}
		}
		return ret;
	}
	public static Matrix operator / (Matrix a, float b) {
		Matrix ret = new Matrix(a.rows, a.cols);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] / b;
			}
		}
		return ret;
	}

	// Other operations
	public static Matrix scalarMul(Matrix a, Matrix b) {
		if(!(a.rows == b.rows && a.cols == b.cols)) {
			throw new Exception("Invalid Matrix sizes for operation");
		}
		Matrix ret = new Matrix(a.rows, a.cols);

		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] * b[i, j];
			}
		}

		return ret;
	}
	public static Matrix scalarDiv(Matrix a, Matrix b) {
		if(!(a.rows == b.rows && a.cols == b.cols)) {
			throw new Exception("Invalid Matrix sizes for operation");
		}
		Matrix ret = new Matrix(a.rows, a.cols);

		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[i, j] = a[i, j] / b[i, j];
			}
		}

		return ret;
	}
	public Matrix transpose() {
		Matrix ret = new Matrix(cols, rows);

		for(int i = 0; i < rows; i++) {
			for(int j = 0; j < cols; j++) {
				ret[j, i] = data[i, j];
			}
		}

		return ret;
	}

	public void print() {
		string o;
		for(int i = 0; i < rows; i++) {
			o = "";
			for(int j = 0; j < cols; j++) {
				o += data[i, j].ToString();
			}
			Console.WriteLine(o);
		}
	}
	public void debugPrint() {
		Console.WriteLine("Rows: " + rows.ToString());
		Console.WriteLine("Cols: " + cols.ToString());
		Console.WriteLine("Data:");

		string o;
		for(int i = 0; i < rows; i++) {
			o = "";
			for(int j = 0; j < cols; j++) {
				o += data[i, j].ToString();
			}
			Console.WriteLine(o);
		}
	}
}
