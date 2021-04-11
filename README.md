# Member Path Utility

路径式对象成员访问工具，支持读写操作。

Path-based object member access tool, supporting read and write operations.

# API

## Path Extensions

### Get value

* PathGet<TItem, TValue>

* PathGet<object, TValue>

* PathGet<object, object>

### Get nullable value

* PathGetOrDefault<TItem, TValue?>

* PathGetOrDefault<object, TValue?>

* PathGetOrDefault<object, object?>

### Set value

* PathSet<TItem, TValue>

* PathSet<object, TValue>

* PathSet<object, object>

## Path Helper

### Get value

* GetDelegate

* GetDelegate<TItem, TValue>

* GetDelegate<object, TValue>

* GetDelegate<object, object>

* GetLambda

* GetLambda<TItem, TValue>

* GetLambda<object, TValue>

* GetLambda<object, object>

* GetExpression

### Get value or default

* GetDelegateDefault<TItem, TValue?>

* GetDelegateDefault<object, TValue?>

* GetDelegateDefault<object, object?>

* GetLambdaDefault<TItem, TValue?>

* GetLambdaDefault<object, TValue?>

* GetLambdaDefault<object, object?>

### Set value

* SetDelegate

* SetDelegate<TItem, TValue>

* SetDelegate<object, TValue>

* SetDelegate<object, object>

* SetLambda

* SetLambda<TItem, TValue>

* SetLambda<object, TValue>

* SetLambda<object, object>

* SetExpression

# Performance

## Get value

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
| Method          | N        |     Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
| --------------- | -------- | -------: | -------: | -------: | ----: | ------: | ----: | ----: | ----: | --------: |
| Normal          | 10000000 | 120.0 ms |  0.94 ms |  0.83 ms |  1.00 |    0.00 |     - |     - |     - |     267 B |
| PathGetTV       | 10000000 | 745.9 ms | 14.02 ms | 19.19 ms |  6.28 |    0.19 |     - |     - |     - |         - |
| PathGetOV       | 10000000 | 758.6 ms | 14.84 ms | 14.58 ms |  6.34 |    0.11 |     - |     - |     - |    1344 B |
| PathGetOO       | 10000000 | 722.1 ms |  6.45 ms |  6.03 ms |  6.02 |    0.05 |     - |     - |     - |    1344 B |
| PathGetTVCached | 10000000 | 128.1 ms |  1.59 ms |  1.48 ms |  1.07 |    0.01 |     - |     - |     - |         - |
| PathGetOVCached | 10000000 | 131.3 ms |  1.85 ms |  1.73 ms |  1.10 |    0.01 |     - |     - |     - |     260 B |
| PathGetOOCached | 10000000 | 132.2 ms |  0.90 ms |  0.80 ms |  1.10 |    0.01 |     - |     - |     - |         - |

## Get value or default

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
| Method                   | N        |      Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
| ------------------------ | -------- | --------: | -------: | -------: | ----: | ------: | ----: | ----: | ----: | --------: |
| Normal                   | 10000000 |  38.67 ms | 0.731 ms | 1.116 ms |  1.00 |    0.00 |     - |     - |     - |         - |
| PathGetOrDefaultTV       | 10000000 | 610.19 ms | 3.800 ms | 3.369 ms | 15.67 |    0.42 |     - |     - |     - |         - |
| PathGetOrDefaultOV       | 10000000 | 647.96 ms | 7.410 ms | 6.568 ms | 16.65 |    0.53 |     - |     - |     - |         - |
| PathGetOrDefaultOO       | 10000000 | 634.03 ms | 8.877 ms | 8.303 ms | 16.25 |    0.46 |     - |     - |     - |         - |
| PathGetOrDefaultTVCached | 10000000 |  45.71 ms | 0.395 ms | 0.370 ms |  1.17 |    0.03 |     - |     - |     - |     822 B |
| PathGetOrDefaultOVCached | 10000000 |  65.84 ms | 0.517 ms | 0.432 ms |  1.70 |    0.04 |     - |     - |     - |      78 B |
| PathGetOrDefaultOOCached | 10000000 |  67.15 ms | 1.318 ms | 1.760 ms |  1.73 |    0.06 |     - |     - |     - |         - |

## Set value

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1440 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```
| Method          | N        |      Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
| --------------- | -------- | --------: | --------: | --------: | ----: | ------: | ----: | ----: | ----: | --------: |
| Normal          | 10000000 |  15.18 ms |  0.051 ms |  0.045 ms |  1.00 |    0.00 |     - |     - |     - |      96 B |
| PathSetTV       | 10000000 | 512.88 ms | 10.139 ms | 13.879 ms | 33.97 |    1.04 |     - |     - |     - |      96 B |
| PathSetOV       | 10000000 | 499.74 ms |  4.543 ms |  4.249 ms | 32.91 |    0.27 |     - |     - |     - |      96 B |
| PathSetOO       | 10000000 | 479.01 ms |  3.574 ms |  3.344 ms | 31.58 |    0.23 |     - |     - |     - |      96 B |
| PathSetTVCached | 10000000 |  27.69 ms |  0.096 ms |  0.085 ms |  1.82 |    0.01 |     - |     - |     - |      96 B |
| PathSetOVCached | 10000000 |  27.99 ms |  0.287 ms |  0.268 ms |  1.84 |    0.02 |     - |     - |     - |      96 B |
| PathSetOOCached | 10000000 |  32.96 ms |  0.267 ms |  0.223 ms |  2.17 |    0.02 |     - |     - |     - |      96 B |
