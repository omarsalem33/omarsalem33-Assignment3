
/*
 * 1- csproj => this is a project configuration blueprint | build setting and project reference
 *
 * 2- program.cs => Source code
 *  contain main app logic and top-level statements
 * serves as the primary entry point where program execution begins when running the compiled executable
 * 
 * 3- obj => Temp build directory
 * holds temp files generated during the compilation process
 *
 * 4- bin => out directory
 * holds the final compiled out of your project => .ex
 * 
 */
namespace CSharpBasicsAssignment;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
 