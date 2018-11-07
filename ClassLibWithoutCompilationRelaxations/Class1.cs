using System;

namespace ClassLibWithoutCompilationRelaxations
{
    public class Class1
    {
        public void BlowUp()
        {
            throw new Exception("Thrown from class lib _without_ CompilationRelaxationsAttribute");
        }
    }
}
