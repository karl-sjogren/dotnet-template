rm -rf ../dotnet-template-test-output-no-benchmarks
dotnet new install ./templates/opinionated-solution --force
dotnet new karls-solution -o ../dotnet-template-test-output-no-benchmarks -n TestSolution --includeBenchmarkProject=false
dotnet new uninstall ./templates/opinionated-solution

cd ../dotnet-template-test-output-no-benchmarks/
dotnet build
dotnet test

cd ../dotnet-template/