using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Channels;

// Concurrency can be achieved by many ways:
// - Threading
// - Tasks
// - Parallels
// - etc.

// Threads

// A thread is run in the foreground by default, but 
// it can be made to run in the background by setting 
// the IsBackground property to true.
var thread1 = new Thread(RunLoop){
    IsBackground = true
};
var thread2 = new Thread(RunLoop);

thread1.Start(5);
thread2.Start(10);

// The only difference being that a program will not 
// automatically close if there are any foreground threads 
// running.  Backgrounds threads will not keep the program 
// alive if all foregrounds threads finish.
void RunLoop(object obj)
{
    // A single parameter can be passed to a thread via it's Start method.  
    // The parameter on the method must be declared as an object, which means 
    // a type check should be performed on it before use.
    if (obj is not int counter)
        return;

    for (var i = 1; i <= counter; i++)
        Console.WriteLine(i);
}

// Tasks

// The Task.Run method looks the same as when dealing with the thread, but returns 
// a Task<TResult>. These tasks must be awaitedsomewhere to prevent the program 
// from closing before they're finished. A task can be waited on with the 
// await keyword and execution flow will be blocked until the task is complete

var task1 = Task.Run(PrintLoop);
var task2 = Task.Run(PrintLoop);

await Task.WhenAll(task1, task2);


void PrintLoop()
{
    for (var i = 0; i <= 10; i++)
        Console.WriteLine(i);
}

// The return value of a Task can be accessed upon completion.
var task3Result = await Task.Run(SimpleLoop);
Console.WriteLine(task3Result);


int SimpleLoop()
{
    var total = 0;

    for (var i = 1; i <= 10; i++)
        total += 1;

    return total;
}

// Parallel

// The Parallel class has a few interesting methods that are designed to run concurrently
// over a range or collection - like the for and foreach loops. Parallel.For takes a 
// starting and ending integer, and a method to execute. The method accepts int as parameter

Parallel.For(1, 10, Print);

void Print(int i)
{
    Console.WriteLine($"This is loop #{i}");
}

// Parallel.ForEach takes a collection and a method - the method accepts 
// the datatype, T, of the collection.

var people = new List<Person>
{
    new("Stephen", "King", new DateOnly(2020, 01, 01)),
    new("George", "Orwell", new DateOnly(2020, 01, 01)),
    new("Charles", "Dickens", new DateOnly(2020, 01, 01)),
    new("Thomas", "Mann", new DateOnly(2020, 01, 01))
};

Parallel.ForEach(people, PrintPeople);

void PrintPeople(Person person)
{
    Console.WriteLine(person.FirstName);
}

// Channels

// Channels can be used as a means of communicating directly between threads and tasks.  
// They are effectively a thread-safe queue that allows a "producer" to write message 
// into and a "consumer" to read messages from.  There are two main types of 
// channel - unbounded and bounded.  An unbound channel allows for infinite message 
// capacity, whilst a bounded channel explicitly sets a maximum message capacity.

// When creating a channel, you must provide a data type, T depending on what you want the channel to handle.
var channel = Channel.CreateUnbounded<string>();

var task = Task.Run(async () =>
{
    for (var i = 0; i < 10; i++)
        await channel.Writer.WriteAsync($"This is loop {i}");

    channel.Writer.Complete();
});

// Here, we're creating a new unbounded channel of type string, then dropping 
// into a Task.Run.  Within that task, we're calling WriteAsync on the channel's 
// Writer with a message.  Once we've finished writing we call Complete() on the writer, 
// after which, no more messages can be sent.
while (!task.IsCompleted)
{
    try
    {
        var message = await channel.Reader.ReadAsync();
        Console.WriteLine(message);
    }
    catch (ChannelClosedException)
    {
        Console.WriteLine("Channel has been closed");
        break;
    }
}