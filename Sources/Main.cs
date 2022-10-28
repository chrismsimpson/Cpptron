
namespace DeepScroll;

public static partial class Program {

    public static void Main(String[] args) {

        // WriteLine($"args: {args.Length}");

        // for (var i = 0; i < args.Length; i++) {

        //     WriteLine($"  {i}: {args[i]}");
        // }

        // WriteLine($"foo");

        Foo();
    }

    public static void Foo() {

        // jakt file.jakt
        // clang++ -std=c++20 -I. -Iruntime -Wno-user-defined-literals ./build/file.cpp

        var n = "Apps/foo";

        var (stdOutput, stdError, exitSuccess) = Process.Run(
            name: "clang++",
            arguments: $"-std=c++20 -I. -IRuntime -Wno-user-defined-literals ./build/{n}.cpp -o ./build/{n}.out",
            dataReceived: data => {

                WriteLine(data);
            },
            errorReceived: err => {

                var og = Console.ForegroundColor;

                Console.ForegroundColor = 
                    err.Contains("error")
                        ? ConsoleColor.Red
                        : ConsoleColor.Yellow;

                WriteLine(err);

                Console.ForegroundColor = og;
            });

        // WriteLine($"success: {exitSuccess}");
    }
}

public enum BuildMode {

    Clang,
    CMakeLists
}