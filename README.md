### Example of the Builder Design Pattern

This example of the functional builder design pattern was develop using C#.

Using a builder, we can create and API that assumes the responsibility for appending these strings, elements or whatever, and when assembling the elements we don't have to think about it anymore. Its really a build once and use forever approach.

On the method Create(), we’ll return the first interface (on which all the other depends on). This forces the program into calling the next logical method, which will return an implementation of the next interface and so on, eventually coming to the method Build(), returning the main object.

If you're interested in the udemy course by [Dmitri Nesteruk](https://www.udemy.com/user/dmitrinesteruk/) [link](https://www.udemy.com/course/design-patterns-csharp-dotnet).
