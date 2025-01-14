using SnipperSnippetApi.Models;
using System.Collections.Generic;

namespace SnipperSnippetApi.Data
{
    public static class SeedData
    {
        public static List<Snippet> GetSeedSnippets()
        {
            return new List<Snippet>
            {
                new Snippet { Id = 1, Language = "C#", Code = "Console.WriteLine(\"Hello World\");" },
                new Snippet { Id = 2, Language = "Python", Code = "print(\"Hello World\")" },
                new Snippet { Id = 3, Language = "Python", Code = "def add(a, b):\n    return a + b" },
                new Snippet { Id = 4, Language = "JavaScript", Code = "console.log('Hello, World!');" },
                new Snippet { Id = 5, Language = "JavaScript", Code = "function multiply(a, b) {\n    return a * b;\n}" },
                new Snippet { Id = 6, Language = "JavaScript", Code = "const square = num => num * num;" },
                new Snippet { Id = 7, Language = "Java", Code = "public class HelloWorld {\n    public static void main(String[] args) {\n        System.out.println(\"Hello, World!\");\n    }\n}" },
                new Snippet { Id = 8, Language = "Java", Code = "public class Rectangle {\n    private int width;\n    private int height;\n\n    public Rectangle(int width, int height) {\n        this.width = width;\n        this.height = height;\n    }\n\n    public int getArea() {\n        return width * height;\n    }\n}" },
            };
        }
    }
}
