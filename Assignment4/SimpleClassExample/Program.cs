// See https://aka.ms/new-console-template for more information

using System;
using System.Reflection;

public class SimpleClass { };
public class SimpleClassExample
{
    public static void Main()
    {
        Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
        Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

        Console.WriteLine("\n----------------------- SIMPLE CLASS EXAMPLE ------------------------\n");

        Type t = typeof(SimpleClass);
        BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                             BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
        MemberInfo[] members = t.GetMembers(flags);
        Console.WriteLine($"\nType {t.Name} has {members.Length} members: ");
        foreach (var member in members)
        {
            string access = "";
            string stat = "";
            var method = member as MethodBase;
            if (method != null)
            {
                if (method.IsPublic)
                    access = " Public";
                else if (method.IsPrivate)
                    access = " Private";
                else if (method.IsFamily)
                    access = " Protected";
                else if (method.IsAssembly)
                    access = " Internal";
                else if (method.IsFamilyOrAssembly)
                    access = " Protected Internal ";
                if (method.IsStatic)
                    stat = " Static";
            }
            var output = $"{member.Name} ({member.MemberType}): {access}{stat}, Declared by {member.DeclaringType}";
            Console.WriteLine(output);
        }
        Console.WriteLine("\n");
    }
}
