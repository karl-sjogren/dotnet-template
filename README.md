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

If you have them installed and need to update them you can run the following.

```bash
dotnet new update
```

## Templates

### Opinionated Solution

This template creates a solution with a few projects and some default settings
based on my own preferences.

```bash
dotnet new karls-solution -n Company.CoolProject
```
