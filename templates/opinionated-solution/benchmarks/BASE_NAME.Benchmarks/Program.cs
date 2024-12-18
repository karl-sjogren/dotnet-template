using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BenchmarkDotNet.Running;

[assembly: ExcludeFromCodeCoverage]

var switcher = new BenchmarkSwitcher(Assembly.GetExecutingAssembly());
switcher.Run(args);
