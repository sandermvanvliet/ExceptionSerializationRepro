using System;
using System.Runtime.CompilerServices;

[assembly:CompilationRelaxations(8)]

namespace ClassLibWithCompilationRelaxations
{
    public class Class1
    {
        public void BlowUp()
        {
            throw new Exception("Thrown from class lib with CompilationRelaxationsAttribute");
        }
    }
}
