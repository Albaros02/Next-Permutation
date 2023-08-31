# Next-Permutation

#### First, let's explain the problem we have been asked to solve.

>The problem consists of finding the next lexicographically greater permutation of a given arbitrary string. Let's call the given string s, and we need to find another string, let's call it s', that is lexicographically greater than s and there is no other string lexicographically greater than s but smaller than s'.
>
>For example, {1,2,3} implies that s' = {1,3,2}.

#### Now that we understand the problem, let's analyze the solution we will give.

A naive solution would be to iterate through all possible permutations of the symbols in our string and find s' by updating a variable that stores the minimum lexicographically greater string than the given string. However, this solution is slow because iterating through all permutations and performing verifications implies that the time complexity grows **factorially**.

The problem imposes the constraint that there will be at most 100 distinct symbols and 100 of them in our string. This means that our program may potentially have to perform 100! operations, which would take **thousands of years to complete** (I'm not kidding).

#### Let's think of a less complex but equally effective solution.

Notice that when comparing two strings, what determines which is greater is the symbol that follows the common prefix of both strings.

Following this idea, if we find two candidates for the desired string, let's call them s1 and s2, the one with the largest common prefix with the original string will be smaller than the other, and this can be easily proven.

Therefore, we can take advantage of this fact and search for the string with the largest common prefix that is greater than the given string and also lexicographically minimal.

*Now, How do we do this?*

This is where it gets a bit more difficult to see what's going on, but we can achieve this by following a few steps.

> First, we iterate from right to left and ask each element: Is there any symbol to your right that is greater than you? If so, can you give me the smallest one?

The following code answers the aforementioned questions.

```c#
    short minGreater = short.MaxValue;
    int index = -1;
    for (int j = i; j < array.Length; j++)
    {
        if (array[j]> array[i] && array[j]< minGreater)
        {
            index = j;
            minGreater = array[j];
        }    
    }
    // From App/PermutationSolution.cs line 19
```
> Secondly, we swap the element that satisfies step 1 with the minimum found.

> Finally, we lexicographically sort what remains to the right of the position where we found the element in step 1. This ensures that the constructed string is the minimal one.

With this algorithm, we have solved the problem, but unlike the first solution, this one has a different complexity, **quadratic** actually. This means that the maximum number of operations our program will perform is around 100*100, which takes **less than 1 second** on any current computer.

*Therefore, we have improved the performance of our program, going from an algorithm that potentially takes years to finish to one that takes no more than a second.*

>This solution was developed after creating a tester that verified its correctness, at least for small cases, by comparing the outputs with the first solution.

>As we finished the solution for our program, we moved from the console implementation to an API that provides the service of executing the program.

>To use the api properly you should provide a string of numbers separated by comas or whitespace, the validator is gonna accept any input with comas and withspace even if it does not have the correct order, for example : 1 ,2 3 4 ,5,7. 

To deploy Swagger and see the endpoints and other details, navigate to the project path and run the following command:
```
    dotnet watch
```

Regarding input validation, we did not use the Fluent package for validation or patterns like Mediator due to the limited operations our API performs.

DependencyInjection was used to pass our solution implementation to the controller and decouple the implementations as much as possible.