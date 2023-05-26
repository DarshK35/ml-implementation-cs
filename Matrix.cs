using System;

public class Matrix {
	// Data variables
	public float[,] data;
	public int rows, cols;
	private Random rng;

	// Constructors
	public Matrix(bool fillRand = false) {
		rows = 5;
		cols = 5;
		
		data = new float[rows, cols];
		if(fillRand) {
			rng = new Random();
			for(int i = 0; i < rows; i++) {
				for(int j = 0; j < rows; j++) {
					data[i, j] = (float)rng.NextDouble();
				}
			}
		}
	}
	public Matrix(int r, int c, bool fillRand = false) {
		rows = r;
		cols = c;

		data = new float[rows, cols];
		if(fillRand) {
			rng = new Random();
			for(int i = 0; i < rows; i++) {
				for(int j = 0; j < rows; j++) {
					data[i, j] = (float)rng.NextDouble();
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
	}


	// Indexing
	public float this[int r, int c] {
		get {
			return data[rows, cols];
		} set {
			data[rows, cols] = value;
		}
	}


	// Unary negation overload
	public static Matrix operator- (Matrix a) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] = -ret[i, j];
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
	public static Matrix operator+ (Matrix a, float b) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] += b;
			}
		}
		return ret;
	}
	public static Matrix operator+ (float a, Matrix b) {
		return b + a;
	}

	// Subtraction operation overloads
	public static Matrix operator- (Matrix a, Matrix b) {
		return a + (-b);
	}
	public static Matrix operator- (Matrix a, float b) {
		return a + (-b);
	}
	public static Matrix operator- (float a, Matrix b) {
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
	public static Matrix operator* (Matrix a, float b) {
		Matrix ret = a.copy();
		for(int i = 0; i < ret.rows; i++) {
			for(int j = 0; j < ret.cols; j++) {
				ret[i, j] *= b;
			}
		}
		return ret;
	}
	public static Matrix operator* (float a, Matrix b) {
		return b * a;
	}

}