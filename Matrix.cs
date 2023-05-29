using System;

public class Matrix {
	// Data variables
	public double[,] data;
	public int rows, cols;
	private Random rng;

	// Constructors
	public Matrix(bool fillRand = false) {
		rows = 5;
		cols = 5;
		rng = new Random();
		
		data = new double[rows, cols];
		if(fillRand) {
			for(int i = 0; i < rows; i++) {
				for(int j = 0; j < rows; j++) {
					data[i, j] = rng.NextDouble() * 2 - 1;
				}
			}
		}
	}
	public Matrix(double[,] data) {
		rows = data.GetLength(0);
		cols = data.GetLength(1);
		rng = new Random();

		this.data = new double[rows, cols];
		for(int i = 0; i < rows; i++) {
			for(int j = 0; j < cols; j++) {
				this.data[i, j] = data[i, j];
			}
		}
	}
	public Matrix(int r, int c, bool fillRand = false) {
		rows = r;
		cols = c;
		rng = new Random();

		data = new double[rows, cols];
		if(fillRand) {
			for(int i = 0; i < rows; i++) {
				for(int j = 0; j < rows; j++) {
					data[i, j] = rng.NextDouble() * 2 - 1;
				}
			}
		}
	}


	// Copying
	public Matrix copy() {
		Matrix ret = new Matrix(rows, cols);
		for(int i = 0; i < rows; i++) {
			for(int j = 0; j < cols; j++) {
				ret[i, j] = data[i, j];
			}
		}
		return ret;
	}

	// Inverse
	public Matrix inverse() {
		// Initialize augmented matrix
		Matrix augment = new Matrix(rows, cols * 2);
		for(int i = 0; i < rows; i++) {
			for(int j = 0; j < cols; j++) {
				augment[i, j] = data[i, j];
			}
			augment[i, i + rows] = 1;
		}

		// Perform Gaussian elimination
		for(int i = 0; i < rows; i++) {
			double pivot = augment[i, i];

			for(int j = 0; j < cols * 2; j++) {
				augment[i, j] /= pivot;
			}
			for(int k = 0; k < rows; k++) {
				if(i != k) {
					double factor = augment[k, i];
					for(int l = 0; l < cols * 2; l++) {
						augment[k, l] -= factor * augment[i, l];
					}
				}
			}
		}

		Matrix ret = this.copy();
		for(int i = 0; i < rows; i++) {
			for(int j = 0; j < cols; j++) {
				ret[i, j] = augment[i, j + cols];
			}
		}
		return ret;
	}

	// Indexing
	public double this[int r, int c] {
		get {
			return data[r, c];
		} set {
			data[r, c] = value;
		}
	}

	// Unary negation overload
	public static Matrix operator- (Matrix a) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] = -a[i, j];
			}
		}
		return ret;
	}

	// Transpose operation
	public static Matrix operator! (Matrix a) {
		Matrix ret = new Matrix(a.cols, a.rows);
		for(int i = 0; i < a.rows; i++) {
			for(int j = 0; j < a.cols; j++) {
				ret[j, i] = a[i, j];
			}
		}
		return ret;
	}

	// Addition operation overloads
	public static Matrix operator+ (Matrix a, Matrix b) {
		if(!(a.rows == b.rows && a.cols == b.cols)) {
			throw new ArithmeticException("Cannot add unequal size matrices");
		}

		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] += b[i, j];
			}
		}
		return ret;
	}
	public static Matrix operator+ (Matrix a, double b) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] += b;
			}
		}
		return ret;
	}
	public static Matrix operator+ (double a, Matrix b) {
		return b + a;
	}

	// Subtraction operation overloads
	public static Matrix operator- (Matrix a, Matrix b) {
		return a + (-b);
	}
	public static Matrix operator- (Matrix a, double b) {
		return a + (-b);
	}
	public static Matrix operator- (double a, Matrix b) {
		return a + (-b);
	}

	// Multiplication operation overloads
	public static Matrix operator* (Matrix a, Matrix b) {
		if(a.cols != b.rows) {
			throw new ArithmeticException("Matrix A columns should be same length as Matrix B rows");
		}

		Matrix ret = new Matrix(a.rows, b.cols);
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] = 0;
				for(int k = 0; k < a.cols; k++) {
					ret[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return ret;
	}
	public static Matrix operator* (Matrix a, double b) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] *= b;
			}
		}
		return ret;
	}
	public static Matrix operator* (double a, Matrix b) {
		return b * a;
	}

}