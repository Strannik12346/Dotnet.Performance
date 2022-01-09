using BenchmarkDotNet.Running;
using System.Reflection;

namespace Dotnet.Performance.StringBuilder
{
    public static class Program 
    {
        public static void Main()
        {
            // Results for .NET 3.1 LTS - look how similar they are!
            // |         Method         |    Mean    |   Error   |   StdDev  |
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | StringConcatenation    | 71.23 ns   | 0.348 ns  | 0.325 ns  |
            // | StringConcatenationV2  | 92.42 ns   | 0.312 ns  | 0.291 ns  |
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | NaiveInterpolation     | 234.77 ns  | 2.426 ns  | 2.269 ns  | 
            // | NaiveInterpolationV2   | 236.62 ns  | 0.670 ns  | 0.523 ns  | 
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | UsualInterpolation     | 192.45 ns  | 0.854 ns  | 0.799 ns  |
            // | UsualInterpolationV2   | 182.91 ns  | 1.057 ns  | 0.825 ns  |

            // Results for .NET 6.0 LTS - something was optimized in all cases
            // |         Method         |    Mean    |   Error   |   StdDev  |
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | StringConcatenation    | 43.91 ns   | 0.453 ns  | 0.402 ns  |
            // | StringConcatenationV2  | 66.54 ns   | 0.239 ns  | 0.212 ns  |
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | NaiveInterpolation     | 52.22 ns   | 0.150 ns  | 0.126 ns  |
            // | NaiveInterpolationV2   | 112.69 ns  | 0.646 ns  | 0.604 ns  |
            // | ---------------------- | ----------:| ---------:| ---------:|
            // | UsualInterpolation     | 52.17 ns   | 0.210 ns  | 0.186 ns  |
            // | UsualInterpolationV2   | 79.67 ns   | 0.452 ns  | 0.423 ns  |

            BenchmarkRunner.Run(Assembly.GetExecutingAssembly());
        }
    }
}
