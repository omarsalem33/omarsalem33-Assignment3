
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
        RunTypesDemo();
    }

    public static void RunTypesDemo()
    {
        int x = 26;
        long y = 1234567890123L;
        double z = 9.8843;
        bool isBool = true;
        char c = 'a';
        string s = "Hello World!";
        var v = "Inferred String";

        Console.WriteLine("----- 1- variable Declarations &  Runtime type ------" );
        Console.WriteLine($"int {x} | type : {x.GetType()}");
        Console.WriteLine($"long {y} | type : {y.GetType()}");
        Console.WriteLine($"double {z} | type : {z.GetType()}");
        Console.WriteLine($"char {isBool} | type : {isBool.GetType()}");
        Console.WriteLine($"char {c} | type : {c.GetType()}");
        Console.WriteLine($"string {s} | type : {s.GetType()}");
        Console.WriteLine($"var {v} | type : {v.GetType()}");
        
        // --------------------------------------------------------------
        
        long implicitLong = x;  // int (32-bit) -> long (64-bit)
        int implicitCharInt = c; // char (16-bit UTF-16 code point) -> int (32-bit)

        Console.WriteLine("--- 2. Implicit Conversions ---");
        Console.WriteLine($"int into long: {implicitLong}");
        Console.WriteLine($"char ('A') into int (ASCII/UTF-16 code): {implicitCharInt}");
        Console.WriteLine();
        
        // --------------------------------------------------------------
        double sampleDouble = 9.12345;
        int castResult = (int) sampleDouble;
        int convertResult = Convert.ToInt32(sampleDouble);

        Console.WriteLine("3- Explicit conversions ---");
        Console.WriteLine($"original double : {sampleDouble}");
        Console.WriteLine($"Explicit cast (int) : {castResult} ");
        Console.WriteLine($"convert.ToInt32: {convertResult}");
        Console.WriteLine();
        
        // ---------------------------Integer Division-----------------------------------

        int integerDivision = 5 / 2; // dorp fractional part 
        Console.WriteLine($"integerDivision: {integerDivision}");   
        double doubleDivision = 5.0 / 2;
        Console.WriteLine($"doubleDivision: {doubleDivision}");
        Console.WriteLine();
        
        // ----------------------------Boxing and Unboxing ----------------------------------

        int val = 100;
        object boxVal = val;
        int UnboxVal = (int) boxVal;

        Console.WriteLine("5. Boxing & UnBoxing");
        Console.WriteLine($"Boxed Object value: {boxVal}");
        Console.WriteLine($"Uboed int value: {UnboxVal}");
        Console.WriteLine();
        
        // ----------------------------Parsing (int.Parse & int.TryParse)----------------------------
        string validString = "42";
        string inValidString = "abc";
        
        int parseRes = int.Parse(validString);
        bool isSuccess = int.TryParse(inValidString, out int  tryParseRes);
       
        Console.WriteLine("--- 6. Parsing ---");
        Console.WriteLine($"int.Parse(\"42\") {parseRes}" );
        Console.WriteLine($"int.TryParse(\"abc\") Succeeded {isSuccess} | result: {tryParseRes}");
        Console.WriteLine();
        
        
        // ----------------------------float -> decimal Conversion----------------------------

        float myFloat = 12.34f;
        decimal exolicitDecimal= (decimal)myFloat;
        Console.WriteLine("--- 7. float -> decimal Explicit Cast ---");
        Console.WriteLine($"Explicit (decimal)cast from float: {exolicitDecimal}");
        
    }
}
 