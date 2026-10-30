/*
PART A: Project & Structure 

1. Project Structure Explanation:
   .csproj: The C# project file (XML format) that defines build configurations target framework dependencies, and project settings
    Program.cs: The main entry point file where application execution begins
    obj/: Temporary build directory storing intermediate compiled object files (.obj) and assets created before final linking
    bin/: Binary output directory where the final compiled executable (.exe) and library dependencies (.dll) are stored

2. File-Scoped Namespace Explanation:
    Using `namespace CSharpBasicsAssignment` applies the namespace to the entire file
    It eliminates the need to wrap the file content inside curly braces { ... }, saving one full level of code indentation

3. Solution Format Comparison (.sln vs .slnx):
    This project uses the classic .sln format
    Advantage of .slnx (newer XML-based format): 
    It is human-readable, lightweight, cleanly structured as standard XML, and significantly reduces merge conflicts when working with Git
*/

internal class Program
{
    static void Main(string[] args)
    {
        Program demo = new Program();

        #region Part B

        RunTypesDemo();
        Console.WriteLine();

        #endregion
        
        #region PART C 
        RunValueVsReferenceDemo();
        Console.WriteLine();
        #endregion
        
        #region PART D1

        Console.WriteLine("=== PART D1: Scope Demonstrations ===");
        demo.ReadFieldFirstTime();
        demo.ReadFieldSecondTime();
        demo.DemonstrateMethodScope();
        DemonstrateBlockScope();
        Console.WriteLine();

        #endregion
        
        #region PART D2
        Console.WriteLine("=== PART D2: Compound Assignment Demonstrations ===");
        DemonstrateCompoundAssignments();
        Console.WriteLine();
        #endregion
        
        #region PART D3 
        RunBitwiseDemo();
        Console.WriteLine();
        #endregion
        
        #region PART F 

        RunPartF();

        #endregion 
        
    }

    #region Part B - Variables, Types & Casting
    public static void RunTypesDemo()
    {
        Console.WriteLine("=== PART B: Variables, Types & Casting ===");

        int myInt = 42;
        long myLong = 10000000000L;
        double myDouble = 3.14159;
        decimal myDecimal = 99.99m;
        bool myBool = true;
        char myChar = 'A';
        string myString = "Hello C#";
        var myInferred = 123.45; 

        Console.WriteLine($"int: {myInt} | Type: {myInt.GetType()}");
        Console.WriteLine($"long: {myLong} | Type: {myLong.GetType()}");
        Console.WriteLine($"double: {myDouble} | Type: {myDouble.GetType()}");
        Console.WriteLine($"decimal: {myDecimal} | Type: {myDecimal.GetType()}");
        Console.WriteLine($"bool: {myBool} | Type: {myBool.GetType()}");
        Console.WriteLine($"char: {myChar} | Type: {myChar.GetType()}");
        Console.WriteLine($"string: {myString} | Type: {myString.GetType()}");
        Console.WriteLine($"var (inferred): {myInferred} | Type: {myInferred.GetType()}");

        long implicitLong = myInt;
        int implicitIntFromChar = myChar;
        Console.WriteLine($"Implicit int -> long: {implicitLong}");
        Console.WriteLine($"Implicit char -> int: {implicitIntFromChar}");

        double valToConvert = 9.87;
        int castedInt = (int)valToConvert;
        int convertedInt = Convert.ToInt32(valToConvert);
        Console.WriteLine($"Explicit (int) cast: {castedInt}"); 
        Console.WriteLine($"Convert.ToInt32: {convertedInt}");  

        int intResult = 5 / 2;
        double doubleResult = 5.0 / 2;
        Console.WriteLine($"5 / 2 (int division): {intResult}");
        Console.WriteLine($"5.0 / 2 (double division): {doubleResult}");

        int num = 100;
        object boxedNum = num; 
        Console.WriteLine($"Boxed object: {boxedNum}");
        int unboxedNum = (int)boxedNum; 
        Console.WriteLine($"Unboxed int: {unboxedNum}");

        int parsedInt = int.Parse("42");
        Console.WriteLine($"Parsed '42': {parsedInt}");

        bool parseSuccess = int.TryParse("abc", out int parseResult);
        Console.WriteLine($"TryParse 'abc' succeeded: {parseSuccess}, Result: {parseResult}");

        float myFloat = 10.5f;
        decimal explicitDecimal = (decimal)myFloat;
        Console.WriteLine($"Explicit float -> decimal: {explicitDecimal}");
    }
    #endregion

    #region Part C - Value vs Reference Types
    public static void RunValueVsReferenceDemo()
    {
        Console.WriteLine("=== PART C: Value vs Reference Types ===");

        Point p1 = new Point { X = 1, Y = 2 };
        Point p2 = p1;
        p2.X = 99;
        Console.WriteLine($"p1.X: {p1.X} | p2.X: {p2.X}");

        Order o1 = new Order
        {
            OrderId = 101,
            CustomerName = "Ali",
            Quantity = 3,
            UnitPrice = 20.0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Cairo",
            Priority = 'H',
            ItemCode = 1234567890L
        };
        o1.CalculateTotal();

        Order o2 = o1;
        o2.IsPaid = true;

        Console.WriteLine($"o1.IsPaid: {o1.IsPaid} | o2.IsPaid: {o2.IsPaid}");

        object boxedOrder = o1; 
        Order o3 = (Order)boxedOrder;
        Console.WriteLine($"ReferenceEquals(o1, o3): {object.ReferenceEquals(o1, o3)}");

        o2.PrintSummary();

        /*
       
         Value types (int, struct) store their actual values on the stack (or inline inside objects) 
          Reference types store the actual object on the heap while the stack holds a reference (pointer) to that heap address
         Value type assignment copies the full data  Reference type assignment copies only the reference pointer
         Storing a reference type inside an object variable does not create a new object or trigger boxing because reference types are already objects residing on the heap
        */
    }
    #endregion

    #region Part D1 & D2 - Scope & Composite Assignment
    private int _appCounter = 42;

    public void ReadFieldFirstTime()
    {
        Console.WriteLine($"[ReadFieldFirstTime] Counter value: {_appCounter}");
    }

    public void ReadFieldSecondTime()
    {
        Console.WriteLine($"[ReadFieldSecondTime] Counter value: {_appCounter}");
    }

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
        // Console.WriteLine(i)
        // CS0103: The name 'i' does not exist in the current context
        // Reason: 'i' was declared in the for-loop header and was destroyed when the loop ended

        // Console.WriteLine(loopBodyVar); 
        // CS0103: The name 'loopBodyVar' does not exist in the current context
        // Reason: 'loopBodyVar' was declared inside the loop's block scope ({}) and went out of scope at the closing brace
    }

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
    #endregion

    #region Part D3 - Bitwise Operators
    public static void RunBitwiseDemo()
    {
        Console.WriteLine("=== PART D3: Bitwise Operators ===");

        int a = 12; 
        int b = 10;

        int andResult = a & b;
        int orResult = a | b; 
        int xorResult = a ^ b;

        Console.WriteLine($"a & b  = {andResult}");
        Console.WriteLine($"a | b  = {orResult}");
        Console.WriteLine($"a ^ b  = {xorResult}");

        /*
        Bitwise calculations:
          a     = 12 -> 1100
          b     = 10 -> 1010
          ------------------
          a & b =  8 -> 1000
          a | b = 14 -> 1110
          a ^ b =  6 -> 0110

        Difference between & (bitwise) and && (logical):
         The logical && operator short-circuits (if the left operand is false the right operand is never evaluated)
         The bitwise & operator evaluates both operands unconditionally regardless of whether the left operand is false
        */
    }
    #endregion

    #region Part F - LeetCode Single Number
    public static int FindSingleNumber(int[] nums)
    {
        int single = 0;
        foreach (int num in nums)
        {
            single ^= num;
        }
        return single;
    }
    

    public static void RunPartF()
    {
        Console.WriteLine("=== PART F: Find Single Number ===");

        int[] test1 = { 4, 1, 2, 1, 2 };
        int[] test2 = { 2, 2, 1 };

        Console.WriteLine($"Input: [4, 1, 2, 1, 2] -> Single Number: {FindSingleNumber(test1)}");
        Console.WriteLine($"Input: [2, 2, 1]       -> Single Number: {FindSingleNumber(test2)}");
    }
    #endregion
    
    
    // class 
    public class Order
    {
        public int OrderId;
        public string CustomerName;
        public int Quantity;
        public decimal UnitPrice;
        public decimal TotalPrice;
        public bool IsPaid;
        public double DiscountPercent;
        public string ShippingCity;
        public char Priority;
        public long ItemCode;

        public void CalculateTotal()
        {
            TotalPrice = (Quantity * UnitPrice) * (decimal)(1 - (DiscountPercent / 100));
        }

        public void PrintSummary()
        {
            Console.WriteLine($"[Summary] Order ID: {OrderId} | Customer: {CustomerName} | Total Price: ${TotalPrice:F2} | Is Paid: {IsPaid}");
        }
    }
    
    // struct 
    public struct Point
    {
        public int X;
        public int Y;
    }

}