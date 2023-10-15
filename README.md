# ProfessionalArguments
A static class in C# to call your application with arguments like a pro

## Description
Professional arguments is a library that helps you to call your application with arguments like a pro. It is very easy to use and it is very useful for console applications.

You want to call your application like this? Here an example:

```bash
MyDownloader -ssl -url https://www.google.com -output C:\Users\MyUser\Downloads
```

This library helps you to do that. You can define your own options, build them and use them in the exact way as shown above.

## Usage
```csharp
using ProfessionalArguments;
static void Main(string[] args)
{
    Option a = new Option
    {
        Name = "a",
        HasValue = false,
    };
    Option b = new Option
    {
        Name = "b",
        HasValue = true
    };
    Option c = new Option
    {
        Name = "c",
        HasValue = true
    }; 

    List<Option> options = new List<Option>()
    {
        a, b, c
    };

    try
    {
        Arguments.Build(options);
        Console.WriteLine(b.GetValue<string>());
        Console.WriteLine(c.GetValue<string>());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

## Detail
Option contains some Properties:
```
Name : string = The name of the option in the arguments. Has to be set by the developer.
HasValue : bool = If this is true, the Builder-Method expect a value for this option in the arguments. Has to be set by the developer.
Exists : bool = Useful, if you have to check, if an option was set. Even more useful, when it has no value in the arguments. Will be set by the Builder-Method.
```

Method:
```
Arguments.Build(option) = This builder reads the arguments and parses them into your options. There is no return value. It's all magic ;)
GetType<type>() = Returns the value from the option. By setting the type, it will automatically convert the value to the matching type.
```
