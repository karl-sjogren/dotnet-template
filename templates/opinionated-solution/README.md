# Karls Opinionated Solution Template

This project was scaffolded using Karls Opinionated Solution Template.

It has been created with the following features:

* Source code goes in the `src` folder.
* Tests go in the `tests` folder.
* An editor config file is added with Karls preferred settings.
* A gitignore file is added with the default .NET gitignore settings.
* A NuGet config file is added with the default NuGet feed settings.
* Several Directory.Build.props files are added.
  * One in the root folder which references analyzers and some global settings.
  * One in the `src` folder which sets `InternalsVisibleTo` to test projects ands
    adds the `BannedApiAnalyzers` package.
  * One in the `tests` folder which sets up some default settings for test assemblies,
    adds implicit usings for Moq, Xunit and Shouldly. It also adds code coverage and
    test result output for release builds.
<!--#if (includeGithubActions)-->
* Several GitHub Actions workflows are added.
  * One that runs tests and builds the project on every push except from Dependabot.
  * One that runs tests and builds the project on every pull request from Dependabot.
  * One that can be used to combine several Dependabot updates into one single pull request.
<!--#endif-->
<!--#if (addFrontendProject)-->
* A frontend project is added with the following features:
  * Yarn 4 with zero installs.
  * Vite (<https://vitejs.dev/>) for building and Vitest (<https://vitest.dev/>) for testing.
  * Sass for styling via postcss. Setup with cssnano and autoprefixer.
  * Linting using ESLint and Stylelint with a bunch of plugins.
<!--#endif-->
