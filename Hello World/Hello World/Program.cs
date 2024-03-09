using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Threading;
using System;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

// Naming Conventions
// C# uses different text casing depending on where it's being declared.  Here is a summary of the conventions:

// Object	        Casing
// Classes	        PascalCase
// Public Members	PascalCase
// Private Members	_camelCase
// Methods	        PascalCase
// Variables	    camelCase
// Enums	        PascalCase

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        _dataTypesAndVariables()
        _collections();
    }

    private static void _dataTypesAndVariables()
    {


        // Data types -> Values and References
        // Values
        // Values are vars that take an int, byte, bool or char, por example.
        // References are vars that point to abstract things like strings, arrays and classes


        /* Integers and Floating Points

        An integer is whole number, -2, -1, 0, 1, 2, etc.

        If we want an integer to be negative, it should be declared as a "signed" integer.  Otherwise, it can be "unsigned".  
        Unsigned integers can be larger than signed integers because we're not wasting a "sign" bit.  
        We can allocate different sizes for an integer in multiples of 8 bits:  8, 16, 32 and 64 bits.

        The naming of these types can be a little hard to remember - they are:

        Keyword Size
        sbyte 	Signed 8-bit
        byte 	Unsigned 8-bit
        short 	Signed 16-bit
        ushort 	Unsigned 16-bit
        int 	Signed 32-bit
        uint 	Unsigned 32-bit
        long 	Signed 64-bit
        ulong 	Unsigned 64-bit
        */

        int sInt = -20;
        uint uInt = 20;

        byte uByte = 255;

        Console.WriteLine("signed int: {0}\nunsigned int: {1}\nunsigned byte: {2}", sInt, uInt, uByte);

        /*
        A floating point is a number that can have decimal places, 8.2, 3.14, etc.

        There are three types (all of which are signed):


        Keyword     Size
        float       4 bytes
        double      8 bytes
        decimal     16 bytes


        When declaring a float or double, the letter F or D should be appended to the value.  
        You can declare a value that is more precise than the specified data type, but it will only "use" the range that it is able when carrying out any mathematics, etc.
        */

        float piFloat = 3.14159265359F;
        double piDouble = 3.14159265359F;

        Console.WriteLine("Pi as a float: {0}\nPi as a double: {1}", piFloat, piDouble);

        /*
        A bool is a true or false value.It's a fundamental type as most "decisions" in a program are made based on a boolean expression (something that evaluates to true or false).

        A char is a single letter or number, represented by an integer.  Those "integers" are standardised in the ASCII and Unicode tables.Different languages allow different byte sizes for characters, from 1 to 4 bytes.C# uses 2 bytes, which allows it to use any character in UTF-16.

        A character is defined with single quotes.
        */

        bool myBool = true;
        char myChar = 'A';

        // Arrays and tuples

        // The array and tuple are both types of collections.
        // An array can hold multiple values of a single data type; whereas a tuple can hold multiple values but of various data types.
        // Both types are fast to use at runtime, but they are fixed size.To initialise an array with values, we can do something like:

        int[] intArray = { 1, 2, 3, 4, 5 };

        // You can also create an empty array by declaring the number of elements you want to have.  
        // The values in the array are assigned the default value for the relevant data type.
        // For an integer, that would be 0.

        int[] initIntArray = new int[5];

        // An element in an array can be accessed by its index.  Arrays are "zero-indexed" which means the first element is index 0, the second is index 1 and so on.  The index of an array is accessed using square brackets, e.g. array[0].
        // To print the 3rd element:

        Console.WriteLine("{0}", intArray[2]);

        // A tuple is declared using parenthesise for both the data types and initial values; and instead of accessing a tuple index via square brackets, we use the period, .
        // Each item is given a name like Item1, Item2, etc.

        (string, string, int) tuple = ("Charles", "Dickens", 1812);
        Console.WriteLine("{0} {1} was born in {2}", tuple.Item1, tuple.Item2, tuple.Item3);

        // You may also use a concept called "deconstruction" to assign friendly variable names to your elements.

        (string tFirstName, string tLastName, int tDob) = tuple;
        Console.WriteLine("{0} {1} was born in {2}", tFirstName, tLastName, tDob);

        // Strings
        // C# has made it very easy to work and manage strings.
        // A string can be declared using double quotes.

        string name = "Rasta Mouse";
        Console.WriteLine(name);

        // There are multiple ways to concatenate strings.
        // One way is via interpolation, denoted by a prepended $.

        string firstName = "Rasta";
        string lastName = "Mouse";
        string fullName = $"{firstName} {lastName}";
        Console.WriteLine(fullName);

        // Another is by using the + operator.
        
        string plusFullName = firstName + " " + lastName;
        Console.WriteLine(plusFullName);

        // Or by using the string.Concat() method.
        
        string methodFullName = string.Concat(firstName, " ", lastName);
        Console.WriteLine(methodFullName);

        // In fact, string has lots of really useful methods including Split, Join, Equals, and IsNullOrEmpty/IsNullOrWhiteSpace.

        // Variables
        // They can be declared either explicitly or implicitly

        int int1 = 10; // Exclicit declaration
        var int2 = 10; // Implicit declaration

        // One of the main benefits of using implicit typing is that it can shorten your code and make it more readable.

        (string, string, int) ex1 = ("Charles", "Dickens", 1812); // Explicit
        var im1 = ("Charles", "Dickens", 1812); // Implicit 

        // There are instances where var cannot be used. 
        // One is when declaring a variable without assigning it a value, 
        // and another is when the compiler cannot infer from context what the data type is meant to be.
    
        int novar1; // ok
        var cannotInferType; // not ok

        // Every variable declared in C# is mutable, which means it can be changed.  
        // To make a variable immutable, prepend it with the const keyword.

        var i1 = 10;
        i1 = 20;

        const int i2 = 10;
        i2 = 20; // error

        // Casting -> convert one data type to another
        // Can be explicit or implicit

        // Implicit cast
        var i = 20;
        double d = i;

        // However, the inverse process to cast a double to an integer cannot be done implicitly
        // Must be explicit
        // invalid
        // double d1 = 3.14D;
        // int i1 = d1;

        // Valid (explicit)
        double d2 = 3.14D;
        int i2 = (int)d2; // Data precision is now lost

        // Other data types can be cast to each other when it makes sense.
        // For example, because a char is just a Unicode value, it can be cast to an int
        var c = 'A';
        int i = c;
        Console.WriteLine($"{c} == {i}");

        c = (char)i;
        Console.WriteLine($"{i} == {c}");

        // Don't try to cast nonsensecally, i.e., string to float
    }

    private static void _collections()
    {
        using System.Collections.Generic;

        // Lists, Dictionaries, Hashtables and Queues

        // Lists
        var list1 = new List<int>();
        var list2 = new List<int> { 1, 2, 3, 4, 5 };

        // Append to the list with the Add method, 
        // delete with Remove or RemoveAt
        var integers = new List<int>();

        integers.Add(1);
        integers.Add(2);
        integers.Add(3);
        integers.Add(4);
        integers.Add(5);

        // Remove a known value
        integers.Remove(1);

        // Remove from a given index
        integers.RemoveAt(2);

        Console.WriteLine($"The value at index 2 is {integers[2]}.");

        // Contains returns bool if value is there
        if (integers.Contains(5))
            Console.WriteLine("5 is present");

        // And Find can be used to search for a value,
        // taking in a "predicate" which is a lambda:  
        var item = integers.Find(v => v == 2); 

        Console.WriteLine(item);
        // Note that if the value does not exist, 
        // the method returns the default value for the list's data type, T. 

        // Dictionary
        var dict = new Dictionary<int, string>();

        dict.Add(0, "Charles Dickens");
        dict.Add(1, "George Orwell");
        dict.Add(2, "Carlos Zafon");

        // kvp = key value pair
        foreach(var kvp in dict)
            Console.WriteLine($"Key: {kvp.Key} contains: {kvp.Value}.")
    }
}