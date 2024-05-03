using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Threading;
using System;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Security.Cryptography;

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

        _dataTypesAndVariables();
        _collections();
        _operators();
        _controlFlow(args);
        _classes();
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

        if (dict.ContainsKey(2))
        {
            dict[2] = "J.R.R Tolkien";
        }

        // Hashtable
        // The Hashtable is like a stripped-down dictionary 
        // that is designed for pure performance.  
        // It does not maintain any order in the collection and 
        // allows values to be looked up very quickly.  
        // It's a good candidate when computing against large 
        // data sets but for general use, the dictionary is 
        // friendlier.
        var table = new Hashtable
        {
            { 0, "Charles Dickens" },
            { 1, "George Orwell" },
            { 2, "Thomas Mann" },
            { 3, "J.R.R. Tolkien" }
        };

        foreach(DictionaryEntry entry in table)
        {
            Console.WriteLine($"{entry.Key} : {entry.Value}");
        }

        // Queues and Stacks
        // There are two main types of queue: the Queue and the Stack.  
        // The queue is a first-in-first-out (FIFO) collection and 
        // the stack is last-in-first-out (LIFO).  
        // These are useful when the order of data is of the strictest 
        // importance and can be used in places such as message queues.

        // To push an object into a queue, use the Enqueue method.  
        // To remove and return the next object, use Dequeue.

        var queue = new Queue<int>();

        // add items to the queue (enqueue)
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // dequeue items from the queue
        while (queue.TryDequeue(out var value))
            Console.WriteLine(value); // will print 1, 2, 3

        // Stack
        // They work the same way using the push and pop methods

        var stack = new Stack<int>();

        // Add items to the stack (push)
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        // Pop all the items from the stack
        while (stack.TryPop(out var value))
            Console.WriteLine(value); // Will print 3, 2, 1
    }

    private static void _operators()
    {
        // Mathematical Operators
        // Logical Operators
        // Bitwise Operators

        // Mathematical Operators
        Console.WriteLine(23 + 53); // Add
        Console.WriteLine(64 - 13); // Subtract
        Console.WriteLine(23 * 90); // Multiply
        Console.WriteLine(20 / 10); // Divide
        Console.WriteLine(74 % 21); // Modulus

        // Logical Operators
        var rand = new Random(); // Generate some random numbers
        var i1 = rand.Next(0, 100);
        var i2 = rand.Next(0, 100);

        if (i1 == i2) Console.WriteLine("Values are equal");
        if (i1 != i2) Console.WriteLine("Values are not equal");
        if (i1 > i2) Console.WriteLine("i1 is greater than i2");
        if (i1 < i2) Console.WriteLine("i1 is less than i2");
        if (i1 >= i2) Console.WriteLine("i1 is grater than or equal to i2");
        if (i1 <= i2) Console.WriteLine("i1 is less than or equal to i2");

        // Bitwise Operators
        Console.WriteLine(i1 & i2);  // AND
        Console.WriteLine(i1 | i2);  // OR
        Console.WriteLine(i1 ^ i2);  // XOR
        Console.WriteLine(i1 << i2); // Left Shift
        Console.WriteLine(i1 >> i2); // Right Shift
    }

    

    private static void controlFlow(string[] args) 
    {
        _ifelse();
        _switch();
        _enums();
        _loops();
        _args(args);
        _input();

        static void _ifelse()
        {
            // if (condition)
            // {
            //     do something
            // }
            // else if (condition two)
            // {
            //     do something else
            //     If first one is true, the flow will break out and this will not be evaluated
            // }
            // else
            // {
            //     catch everything else
            // } 
            

            var condition1 = true;
            var condition2 = false;
            var condition3 = false;
            
            // Conditions are read AND first, so parenthesis are needed
            if (condition1 || condition2 && condition3)
                Console.WriteLine("This is true because it does && first");
            
            if ((condition1 || condition2) && condition3)
                Console.WriteLine("This is false");
        }

        static void _switch()
        {
            var animal = "Dog";

            // if (animal == "Dog")
            // {
            //     Console.WriteLine("Woof");
            // }
            // else if (animal == "Cat")
            // {
            //     Console.WriteLine("Meow");
            // }
            // else
            // {
            //     Console.WriteLine("Unknown");
            // }  All this can be condensed down to:

            var sound = animal switch
            {
                "Dog" => "Woof",
                "Cat" => "Meow",
                _ => "Unknown" // catch-all
            };

            Console.WriteLine(sound);
        }

        internal enum Status
        {
            Dead,
            Alive
        }

        static void _enums()
        {
            // An enum (or enumeration) is a set of pre-defined constants.  
            // For example, we could have a "status" enum to indicate 
            // whether a person is dead or alive.

            var (firstName, lastName, status) = ("Carlos", "Zafon", Status.Dead);

            switch (status)
            {
                case Status.Dead:
                    Console.WriteLine($"{firstName} {lastName} is dead.");
                    break;
                case Status.Alive:
                    Console.WriteLine($"{firstName} {lastName} is alive.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }   
        }

        static void _loops()
        {
            // For loops and while loops are the main loops in C#
            for (var i3 = 0; i3 < 10; i3++)
                Console.WriteLine($"i is {i3}");

            var i4 = 0;
            while (true)
            {
                i4++;

                if (i4 == 5)
                    continue;

                if (i4 > 10)
                    break;

                Console.WriteLine(i4);
            }

            // ForEach loop also exist, providing an easier way
            // to loop over a collection without having to have a counter
            var list = new List<int> { 1, 2, 3, 4, 5 };
            foreach(var i5 in list)
            {
                Console.WriteLine(i5);
            }
        }

        static void _args(string[] args)
        {
            // It's normal to include a length check
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments");
                ShowUsage();
                return;
            }
            // args variable exists and can be used as normal
            for (var i = 0; i < args.Length; i++)
                Console.WriteLine($"Argument {i} is {args[i]}");

            void ShowUsage()
            {
                Console.WriteLine("Usage: app.exe <arg1> <arg2>");
            }
        }

        static void _input()
        {
            while (true)
            {
                // Print a pseudo prompt
                Console.Write("> ");

                // Read from stdin
                var input = Console.ReadLine();

                // Loop again if the string was empty
                if (string.IsNullOrWhiteSpace(input))
                    continue;

                // Break if "exit". Use StringComparison enum to make case-insensitive
                if (input.Equals("exit".Trim(), StringComparison.OrdinalIgnoreCase))
                    break;

                // Print to stdout
                Console.WriteLine($"You said: {input}");
            }
        }
}

// Specifics about classes:
internal class Person
{
    // Constructor
    public Person(string firstName, string lastName, DateOnly dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }
    // Each of these class variables will be "Properties" of the class
    public string FirstName { get; set; }

    public string LastName { get; set; }

    // Init is used below instead of set to make it a const var
    // Then it can be changed to private set to make it private, to ensure the data can
    // only be set from inside the class
    public DateOnly DateOfBirth { get; private set; } 

    public bool SetDateOfBirth(DateOnly dob)
    {
        if (dob > DateOnly.FromDateTime(DateTime.UtcNow))
            return false;

        DateOfBirth = dob;
        return true;
    }

    // We can also define "computed" properties that can be made up of 
    // data from existing properties.  For example, we have FirstName 
    // and LastName, but what if we wanted a FullName as well?  No problem.
    public string FullName => $"{FirstName} {LastName}";
    // The lamba acts as a shorthand for:
    // public string FullName 
    // {
    //     get
    //     {
    //         return $"{FirstName} {LastName}";
    //     }
    // }

    // An Age property is another good candidate for a computed property, 
    // as it could be calculated from the current date and the date of birth.
    public int Age => DateTime.Today.Year - DateOfBirth.Year;
    private static void Main(string[] args)
    {
        var person = new Person("Carlos", "Zafon", new DateOnly(1964, 09, 25));

        var success = Person.SetDateOfBirth(new DateOnly(1812, 2, 7));

        // Ternary conditional expression:
        Console.WriteLine(success ? "Successfully set DOB" : "Setting DOB failed");
        Console.WriteLine(person.DateOfBirth);

        // LINQ: query inside the C# program:
        var people = new List<Person>
        {
        new("Jose", "Gomez", new DateOnly(1957, 2, 3)),
        new("Caroline", "Farias", new DateOnly(19872, 11, 22)),
        new("Rosemarie", "Pickens", new DateOnly(1993, 5, 17)),
        new("Hester", "Funk", new DateOnly(1986, 11, 1)),
        new("Dianne", "Soria", new DateOnly(1979, 7, 26))
        };

        // LINQ: find everyone who was born after 1975
        var after1975 = people.Where(p => p.DateOfBirth.Year > 1975).ToArray();
        Console.WriteLine($"Found {after1975.Length} people. They are: ");

        // Print them
        foreach(var personAfter1975 in after1975)
            Console.WriteLine($"{personAfter1975.FullName}, born on {personAfter1975.DateOfBirth}, age {personAfter1975.Age}.");
        
        // Where filters the collection based on the provided predicate and returns an IEnumerable<T>. 
        // LINQ: find everyone 50 or younger, born on a Monday
        var peopleUnder50 = people.Where(p => p.DateOfBirth.DayOfWeek == DayOfWeek.Monday && p.Age <= 50).ToArray();

        // Predicates that have multiple conditions can look a bit unwieldly when written in this way.  
        // You may also extract the code in to a separate method, which is also useful if you need to use it multiple times.
        var peopleUnder50Method = people.Where(FiftyOrYoungerBornOnMonday).ToArray();

        bool FiftyOrYoungerBornOnMonday(Person person)
        {
            return person.Age <= 50 &&
                   person.DateOfBirth.DayOfWeek == DayOfWeek.Monday;
        }

        // LINQ: Any 
        // Any returns a bool, indicating whether a collection has any elements matching the predicate.  
        // If no predicate is provided, it indicates whether or not the collection is empty.
        if (people.Any())
            Console.WriteLine("People has elements");

        if (!people.Any(p => p.Age < 20))
            Console.WriteLine("Nobody is under the age of 20");

        // LINQ: First (or default)
        // First returns the first element of a collection that matches the predicate.  
        // If no predicate is provided, it will just return the first element of the collection.
        var firstPersonWithF = people.First(p => p.LastName.StartsWith("F"));
        Console.WriteLine(firstPersonWithF is null ? "No matching person found" : firstPersonWithF.FullName);
        
        // LINQ: OrderBy and OrderByDescending
        // OrderBy and OrderByDescending allow you to order a collection based on a key.  
        // It uses the equality comparer for the specific data type.

        // Youngest to oldest
        var ascending = people.OrderBy(p => p.Age);

        // Oldest to youngest
        var descending = people.OrderByDescending(p => p.Age);
}       

// Class Polyphormism (inheritance)
// Add abstract keyword so that it can't be instantiated on its own
internal abstract class Animal
{
    public required string Name { get; set; }

    public void SayYourName()
    {
        Console.WriteLine($"My name is {Name}");
    }

    // Overrides
    // We can also declare abstract methods on a class, which will force those
    // inheriting it to provide their own implementation
    // Linters will tell us if inheriting classess are not using this mandatory method:
    // 'Dog' does not implement inherited abstract member 'Animal.MakeNoise()'CS0534
    public abstract void MakeNoise();   
}

internal class Dog : Animal 
{
    public override void MakeNoise()
    {
        Console.WriteLine("Woof");
    }
}

internal class Cat : Animal
{
    public override void MakeNoise()
    {
        Console.WriteLine("Meow");
    }
}   

// var dog = new Dog { Name = "Lassie" };
// dog.SayYourName();
// var dog = new Cat { Name = "Salem" };
// cat.SayYourName();

// Interfaces
// Another form of abstraction - like an abstract class, but can only contain methods and properties.
// You cannot define methods that also have implementations
// Naming convention for an interface is to have it begin with an "I"
internal interface IAnimal
{
    string Name { get; }
    void MakeNoise();
}

// A class inherits from an interface in the same way as an abstract class
public class Dog2(string name) : IAnimal
{
    public string Name { get; } = name;

    public void MakeNoise()
    {
        Console.WriteLine($"Woof, my name is {Name}");
    }
}

public class Serialization()
{
    // We've seen instances where letters such as T are used to represent a data type, such as List<T>.  This allows you to create a list containing any data type, even custom classes that you create.  For example, we could have a List<Person>.
    public static void main()
    {
        var people = new List<SerializablePerson>();

        // This is far more flexible than having specific concrete implementations only for C#'s default data types.  You can also leverage generics in your own classes and methods.  Let's use (de)serialization as a working example.
        // Now imagine that we have multiple classes that we want to serialize and deserialize - having separate methods for every class is clearly not very efficient and would be a maintenance nightmare.  What we can do instead is refactor these methods to accept generics.  
        // We can do this by replacing the concrete type of Person, with T.
        // byte[] SerializePerson(SerializablePerson person)
        // Also implementing constraint where T : class, which means T must be a reference type //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
        byte[] SerializePerson<T>(T obj) where T : class
        {
            using var ms = new MemoryStream();
            JsonSerializer.Serialize(ms, obj);

            return ms.ToArray();
        }

        // SerializablePerson DeserializePerson(byte[] json)
        T DeserializePerson<T>(byte[] json)
        {
            using var ms = new MemoryStream(json);
            // return JsonSerializer.Deserialize<SerializablePerson>(ms);
            return JsonSerializer.Deserialize<T>(ms);
        }

        var person = new SerializablePerson
        {
            FirstName = "Subtle",
            LastName = "Labs"
        };

        var json = SerializePerson(person);
        Console.WriteLine(Encoding.Default.GetString(json));
    } 
}

[Serializable]
internal class SerializablePerson
{
    [JsonPropertyName("first_name")] public string FirstName { get; set; }
    [JsonPropertyName("last_name")] public string LastName { get; set; }
}