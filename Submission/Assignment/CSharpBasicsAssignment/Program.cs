using System;
class Program
{    // Main method to run all demonstrations
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
    }
    

    // D1 — Scope
    
    // Field Scope: Accessible to any non-static method inside this class instance
    private int _appCounter = 42;

    public void ReadFieldFirstTime()
    {
        Console.WriteLine($"[ReadFieldFirstTime] Counter value: {_appCounter}");
    }

    public void ReadFieldSecondTime()
    {
        Console.WriteLine($"[ReadFieldSecondTime] Counter value: {_appCounter}");
    }

    // Method Scope: Local variables exist only within the method lifetime
    public void DemonstrateMethodScope()
    {
        string secretToken = "ABC-123";
        Console.WriteLine($"[Method Scope] Inside method, token is: {secretToken}");
    }

    // Block Scope: Variables declared in loops/blocks exist only within those braces
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

    // ==========================================
    // D2 — Composite (compound assignment) operators
    // ==========================================

    public static void DemonstrateCompoundAssignments()
    {
        int total = 100;
        Console.WriteLine($"Initial total: {total}");

        total += 25; // Compound addition
        // Long form equivalent: total = total + 25;
        Console.WriteLine($"After += 25 : {total}");

        total -= 15; // Compound subtraction
        Console.WriteLine($"After -= 15 : {total}");

        total *= 2;  // Compound multiplication
        Console.WriteLine($"After *= 2  : {total}");

        total /= 4;  // Compound division
        Console.WriteLine($"After /= 4  : {total}");

        total %= 7;  // Compound modulus (remainder)
        Console.WriteLine($"After %= 7  : {total}");
    }
}