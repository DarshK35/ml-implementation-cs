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
`File > Open > Project/Solution` in VS menu

#### Run Code in Visual Studio

### Release Version
#### Coming soon

## Development Checklist

- [x] Matrix Class
- [x] Linear Regression Class
- [ ] Neural Network Class
- [x] SVM Class
- [ ] Extend SVM to SV Regressor and SV Classifier
- [ ] Add functions for Model parameter reviewing
- [ ] Menu-based Driver Code
- [ ] GPU Support (Maybe)

## Notes
* Matrix class currently supports only matrix multiplication, Dot product is not supported yet
* Neural Network class is still missing backpropogation function for tuning weights
* SVM class expects single output variable