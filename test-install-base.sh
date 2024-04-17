rm -rf ../dotnet-template-test-output-base
dotnet new install ./templates/opinionated-solution --force
dotnet new karls-solution -o ../dotnet-template-test-output-base -n TestSolution
dotnet new uninstall ./templates/opinionated-solution

cd ../dotnet-template-test-output-base/
git init
git add .
git commit -m "Initial commit"
dotnet build
dotnet test

cd ../dotnet-template/