using System;

public class Assignment1
{
    public static void Main(string[] args)
    {
        var obj1 = new object();
        var obj2 = new object();
        Console.WriteLine(obj1 == obj2);
        // False - reference equality, checks if they refer to the same object

        var str1 = "hello";
        var str2 = "hello";
        Console.WriteLine(str1.Equals(str2));
        // True - value equality, string overrides Equals to check content

        var obj3 = new object();
        var obj4 = obj1;
        Console.WriteLine(object.ReferenceEquals(obj3, obj4));
        // True - same reference
    }
}
