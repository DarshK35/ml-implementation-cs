# ML Implementations in CSharp

Continuation of my ML Implementations in C++ repository, switched over to C# due to poor memory management in C++ when dealing with double pointers.

## [Old Repository](https://github.com/DarshK35/ML-Implementations-C-)

## Requirements
* Microsoft .NET SDK 7.0
* Microsoft Visual Studio 2022

## Running the code
### From Source Code
#### Clone this Repository

```sh
git clone https://github.com/DarshK35/ml-implementation-cs
```

#### Open Project in Visual Studio
Select `File > Open > Project/Solution` in VS menu, then navigate to `ml-implementation-cs.sln` file cloned with the repo.

#### Run Code in Visual Studio
The code can be run using either of the following methods:

- `Debug > Start without Debugging` in VS Menu
- `Ctrl + F5` shortcut key

Debugging can be left disabled for running this project, unless contributing to the code.


### Release Version
#### Coming soon

## Development Checklist

- [x] Matrix Class
	- [x] Overloaded arithmetic functions
	- [x] Array-like indexing
- [x] Linear Regression Class
	- [x] Statistics-based Fitting function
	- [x] Support for multiple independent variables
- [x] Neural Network Class
	- [x] Prediction Function
	- [x] Actually Working Backpropogation Algorithm
	- [x] Training algorithm
	- [ ] Multiple Loss function support (optional)
	- [ ] Multiple Activation Function support for Neural Network (optional)
- [x] Linear SVM Classifier Class
	- [ ] Multiple kernel function support
- [x] Add functions for Model parameter reviewing
- [ ] Menu-based Driver Code
- [ ] GPU Support (Maybe)

## Notes
* Matrix class currently supports only matrix multiplication, Dot product is not supported yet
* Neural Network class is only useful for classification tasks, Regression tasks will be handled by separate activation function
* SVC class expects single output variable
* Kernel functions yet to be implemented