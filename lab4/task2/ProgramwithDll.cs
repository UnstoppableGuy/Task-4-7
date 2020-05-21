using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class ProgramwithDll
    {
        [DllImport("E:\\C# tasks\\C#\\Lab4\\ConsoleApp1\\lib.dll", CharSet = CharSet.Ansi)]
        static extern void SyntaxError(string filename);
        static void Main(string[] args)
        {
            SyntaxError("Somefile.txt");
        }
    }
}
