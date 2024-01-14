rm -rf ../dotnet-template-test-output
dotnet new install ./templates/opinionated-solution --force
dotnet new karls-solution -o ../dotnet-template-test-output -n TestSolution --addFrontendProject
dotnet new uninstall ./templates/opinionated-solution

cd ../dotnet-template-test-output/
dotnet build
dotnet test

cd src/TestSolution.Frontend/
yarn
yarn lint:css
yarn lint:js
yarn test
yarn build

cd ../../../dotnet-template/