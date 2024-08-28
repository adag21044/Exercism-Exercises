/*Introduction
Arrays
In C#, data structures that can hold zero or more elements are known as collections. An array is a collection that has a fixed size/length and whose elements must all be of the same type. Elements can be assigned to an array or retrieved from it using an index. C# arrays are zero-based, meaning that the first element's index is always zero:

// Declare array with explicit size (size is 2)
int[] twoInts = new int[2];

// Assign second element by index
twoInts[1] = 8;

// Retrieve the second element by index
twoInts[1] == 8; // => true
Arrays can also be defined using a shortcut notation that allows you to both create the array and set its value. As the compiler can now tell how many elements the array will have, the length can be omitted:

// Three equivalent ways to declare and initialize an array (size is 3)
int[] threeIntsV1 = new int[] { 4, 9, 7 };
int[] threeIntsV2 = new[] { 4, 9, 7 };
int[] threeIntsV3 = { 4, 9, 7 };
Arrays can be manipulated by either calling an array instance's methods or properties, or by using the static methods defined in the Array class.

For Loops
A for loop allows one to repeatedly execute code in a loop until a condition is met.

for (int i = 0; i < 5; i++)
{
    System.Console.Write(i);
}

// => 01234
A for loop consists of four parts:

The initializer: executed once before entering the loop. Usually used to define variables used within the loop.
The condition: executed before each loop iteration. The loop continues to execute while this evaluates to true.
The iterator: execute after each loop iteration. Usually used to modify (often: increment/decrement) the loop variable(s).
The body: the code that gets executed each loop iteration.
Foreach Loops
The fact that an array is also a collection means that, besides accessing values by index, you can iterate over all its values using a foreach loop:

char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

foreach (char vowel in vowels)
{
    // Output the vowel
    System.Console.Write(vowel);
}

// => aeiou
Instructions
You're an avid bird watcher that keeps track of how many birds have visited your garden in the last seven days.

You have six tasks, all dealing with the numbers of birds that visited your garden.

For comparison purposes, you always keep a copy of last week's counts nearby, which were: 0, 2, 5, 3, 7, 8 and 4. Implement the (static) BirdCount.LastWeek() method that returns last week's counts:

BirdCount.LastWeek();
// => [0, 2, 5, 3, 7, 8, 4]

Stuck? Reveal Hints
Opens in a modal
Implement the BirdCount.Today() method to return how many birds visited your garden today. The bird counts are ordered by day, with the first element being the count of the oldest day, and the last element being today's count.

int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.Today();
// => 1

Stuck? Reveal Hints
Opens in a modal
Implement the BirdCount.IncrementTodaysCount() method to increment today's count:

int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.IncrementTodaysCount();
birdCount.Today();
// => 2

Stuck? Reveal Hints
Opens in a modal
Implement the BirdCount.HasDayWithoutBirds() method that returns true if there was a day at which zero birds visited the garden; otherwise, return false:

int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.HasDayWithoutBirds();
// => true

Stuck? Reveal Hints
Opens in a modal
Implement the BirdCount.CountForFirstDays() method that returns the number of birds that have visited your garden from the start of the week, but limit the count to the specified number of days from the start of the week.

int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.CountForFirstDays(4);
// => 14

Stuck? Reveal Hints
Opens in a modal
Some days are busier that others. A busy day is one where five or more birds have visited your garden. Implement the BirdCount.BusyDays() method to return the number of busy days:

int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.BusyDays();
// => 2*/


using System;

class BirdCount
{
    private int[] birdsPerDay;

    // Static method to return last week's bird counts
    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };
    

    // Constructor to initialize the instance variable
    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    // Returns the number of birds counted today
    public int Today() => birdsPerDay[birdsPerDay.Length - 1];
    

    // Increments the bird count for today by 1
    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    // Checks if any day had zero birds
    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0) return true;
        }
        return false;
    }

    // Returns the total number of birds counted in the first `numberOfDays` days
    public int CountForFirstDays(int numberOfDays)
    {
        int birdCount = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            birdCount += birdsPerDay[i];
        }
        return birdCount;
    }

    // Returns the number of busy days (more than 4 birds)
    public int BusyDays()
    {
        int busyDays = 0;

        for (int i = 0; i < birdsPerDay.Length; i++)
        {
            if (birdsPerDay[i] > 4)
            {
                busyDays++;
            }
        }

        return busyDays;
    }
}

