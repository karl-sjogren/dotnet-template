rm -rf ../dotnet-template-test-output-github
dotnet new install ./templates/opinionated-solution --force
dotnet new karls-solution -o ../dotnet-template-test-output-github -n TestSolution --includeGithubActions
dotnet new uninstall ./templates/opinionated-solution

cd ../dotnet-template-test-output-github/
dotnet build
dotnet test

cd ../dotnet-template/