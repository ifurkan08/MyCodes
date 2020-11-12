using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CalculateCompiler
    {
        public double CalculatedExecuteCode(string operation)
        {
            MethodInfo function = CreateFunction(operation);
            object result = function.Invoke(null, new object[] { 2, 3 });
            return (double) result;
        }
        public static MethodInfo CreateFunction(string function)
        {
            string code = @"
                using System;
            
                    namespace CamBalkonSiparis.Editors
                    {                
                            public class BinaryFunction
                            {                
                                public static double Function(double x, double y)
                                {
                                    return func_xy;
                                }
                            }
                    }
                            ";

            string finalCode = code.Replace("func_xy", function);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), finalCode);

            Type binaryFunction = results.CompiledAssembly.GetType("CamBalkonSiparis.Editors.BinaryFunction");
            return binaryFunction.GetMethod("Function");
        }

    }
}
