using System;
using Microsoft.ReactNative;
using Microsoft.ReactNative.Managed;

namespace NativeModuleSample
{
  public sealed class FancyMathNoAttrPackageProvider : IReactPackageProvider
  {
    public void CreatePackage(IReactPackageBuilder packageBuilder)
    {
      packageBuilder.AddModule("FancyMathNoAttr", (IReactModuleBuilder moduleBuilder) => {
        var module = new FancyMathNoAttr();
        //moduleBuilder.SetName("FancyMathNoAttr"); This does not compile
        moduleBuilder.AddConstantProvider((IJSValueWriter writer) => {
          writer.WritePropertyName("E");
          writer.WriteDouble(module.E);
          writer.WritePropertyName("Pi");
          writer.WriteDouble(module.PI);
        });
        moduleBuilder.AddMethod("add", MethodReturnType.Callback,
          (IJSValueReader inputReader,
          IJSValueWriter outputWriter,
          MethodResultCallback resolve,
          MethodResultCallback reject) => {
            double a = inputReader.GetNextArrayItem() ? inputReader.GetDouble() : throw new Exception();
            double b = inputReader.GetNextArrayItem() ? inputReader.GetDouble() : throw new Exception();
            double result = module.Add(a, b);
            outputWriter.WriteDouble(result);
          resolve(outputWriter);
          });
        return module;
      });
    }
  }
}