using BenchmarkDotNet.Attributes;
using System;

public class StringInterpolation
{
    private int x;
    private int y;

    public StringInterpolation()
    {
        var random = new Random();
        x = random.Next(100);
        y = random.Next(100);
    }

    [Benchmark]
    public string StringConcatenation()
    {
        // Actually should execute the same as StringConcatenationV2
        var str = "My house has " + x + " floors. Also it has " + y + " doors.";
        return str;
    }

    [Benchmark]
    public string StringConcatenationV2()
    {
        var str = string.Concat("My house has ", x, " floors. Also it has ", y, " doors.");
        return str;
    }

    [Benchmark]
    public string NaiveInterpolation()
    {
        // Actually should execute the same as NaiveInterpolationV2
        var str = $"My house has {x} floors. "
                + $"Also it has {y} doors.";
        return str;
    }

    [Benchmark]
    public string NaiveInterpolationV2()
    {
        var str = string.Concat(
            string.Format("My house has {0} floors. ", x),
            string.Format("Also it has {0} doors.", y)
        );
        return str;
    }

    [Benchmark]
    public string UsualInterpolation()
    {
        // Actually should execute the same as UsualInterpolationV2
        var str = $"My house has {x} floors. Also it has {y} doors.";
        return str;
    }

    [Benchmark]
    public string UsualInterpolationV2()
    {
        var str = string.Format("My house has {0} floors. Also it has {1} doors.", x, y);
        return str;
    }
}