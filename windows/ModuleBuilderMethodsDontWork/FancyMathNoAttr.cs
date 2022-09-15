using System;
using Microsoft.ReactNative.Managed;

namespace NativeModuleSample
{
  class FancyMathNoAttr
  {
    public double E = Math.E;

    public double PI = Math.PI;

    public double Add(double a, double b)
    {
        return a + b;
    }
  }
}