# Karls Opinionated Templates [![NuGet version (Karls.Templates)](https://img.shields.io/nuget/v/Karls.Templates.svg?style=flat-square)](https://www.nuget.org/packages/Karls.Templates/)

This repository contains a collection of templates for the
[dotnet new](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new)
command based on my own preferences.

This might not be overly useful for you, but it was a fun experiment and this
repo at lest shows of some of the features available when creating your own
templates.

## Installing

Just run the following command to install the templates.

```bash
dotnet new install Karls.Templates
```

If you have them installed and need to update them you can run the above
command again.

Or simply this to update all template packages (which is often a good idea).

```bash
dotnet new update
```

## Templates

### Opinionated Solution

This template creates a solution with a single Core project (+tests) and
some default settings based on my own preferences.

```bash
dotnet new karls-solution -n Company.CoolProject
```

Since version 1.4.0 a flag can be passed to also generate a frontend
project based on Vite and other tools. To have this just pass
`--addFrontendProject` when creating the project.

```bash
dotnet new karls-solution -n CoolProject --addFrontendProject
```

The project per default includes a set of Github Actions workflows.
If another CI tool is to be used these can be skipped by setting
`includeGithubActions` to `false`. This will still add a depenadbot
configuration though since I host all my projects on Github.

```bash
dotnet new karls-solution -n CoolProject --includeGithubActions=false
```

To see available options, run this.

```bash
dotnet new karls-solution --help
```

## References

Includes an adapted version of <https://github.com/hrvey/combine-prs-workflow/>
