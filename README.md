# Karls Opinionated Templates

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
some default settings based on my own preferences. It can also include some
Github Actions/Dependabot specific stuff if passed the `--includeGithubActions`
flag.

```bash
dotnet new karls-solution -n Company.CoolProject
```

To see available options, run this.

```bash
dotnet new karls-solution --help
```
