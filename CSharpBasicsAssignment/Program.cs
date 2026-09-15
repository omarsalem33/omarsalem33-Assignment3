using System;
class Program
{
    // D1 — Scope
    private int _appCounter = 42;
    public void ReadFieldFirstTime() => Console.WriteLine($"[ReadFieldFirstTime] Counter value: {_appCounter}");
    

    public void ReadFieldSecondTime()
        => Console.WriteLine($"[ReadFieldSecondTime] Counter value: {_appCounter}");
   

    public void DemonstrateMethodScope()
    {
        string secretToken = "ABC-123";
        Console.WriteLine($"[Method Scope] Inside method, token is: {secretToken}");
    }

    public static void DemonstrateBlockScope()
    {
        for (int i = 0; i < 3; i++)
        {
            int loopBodyVar = i * 10;
            Console.WriteLine($"[Block Scope] Iteration {i}: loopBodyVar = {loopBodyVar}");
        }

        // UNCOMMENTING EITHER LINE BELOW CAUSES A COMPILE ERROR:
        // Console.WriteLine(i); 
        // CS0103: The name 'i' does not exist in the current context.
        // Reason: 'i' was declared in the for-loop header and was destroyed when the loop ended.

        // Console.WriteLine(loopBodyVar); 
        // CS0103: The name 'loopBodyVar' does not exist in the current context.
        // Reason: 'loopBodyVar' was declared inside the loop's block scope ({}) and went out of scope at the closing brace.
    }

    // D2 — Composite (compound assignment) operators
    public static void DemonstrateCompoundAssignments()
    {
        int total = 100;
        Console.WriteLine($"Initial total: {total}");

        total += 25; 
        Console.WriteLine($"After += 25 : {total}");

        total -= 15; 
        Console.WriteLine($"After -= 15 : {total}");

        total *= 2;  
        Console.WriteLine($"After *= 2  : {total}");

        total /= 4; 
        Console.WriteLine($"After /= 4  : {total}");

        total %= 7;  
        Console.WriteLine($"After %= 7  : {total}");
    }

    // D3 — Single-character bitwise operators
    public static void DemonstrateBitwiseOperators()
    {
        int a = 12; // Binary: 1100
        int b = 10; // Binary: 1010

        // Bitwise AND (&): 1 where both bits are 1
        //   1100 (12)
        // & 1010 (10)
        // ------
        //   1000 (8)
        Console.WriteLine($"a & b = {a & b}");

        // Bitwise OR (|): 1 where at least one bit is 1
        //   1100 (12)
        // | 1010 (10)
        // ------
        //   1110 (14)
        Console.WriteLine($"a | b = {a | b}");

        // Bitwise XOR (^): 1 where bits are different
        //   1100 (12)
        // ^ 1010 (10)
        // ------
        //   0110 (6)
        Console.WriteLine($"a ^ b = {a ^ b}");
    }

    // Main entry point
    static void Main(string[] args)
    {
        Program demo = new Program();

        Console.WriteLine("--- D1: Scope Demonstrations ---");
        demo.ReadFieldFirstTime();
        demo.ReadFieldSecondTime();
        demo.DemonstrateMethodScope();
        DemonstrateBlockScope();

        Console.WriteLine("\n--- D2: Compound Assignment Demonstrations ---");
        DemonstrateCompoundAssignments();

        Console.WriteLine("\n--- D3: Bitwise Operators Demonstrations ---");
        DemonstrateBitwiseOperators();
    }
}