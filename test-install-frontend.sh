rm -rf ../dotnet-template-test-output-frontend
dotnet new install ./templates/opinionated-solution --force
dotnet new karls-solution -o ../dotnet-template-test-output-frontend -n TestSolution --addFrontendProject
dotnet new uninstall ./templates/opinionated-solution

cd ../dotnet-template-test-output-frontend/
dotnet build
dotnet test

cd src/TestSolution.Frontend/
rm -rf ./node_modules
yarn
yarn lint:css
yarn lint:js
yarn test
yarn build

cd ../../../dotnet-template/