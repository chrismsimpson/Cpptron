
namespace DeepScroll;

public static partial class Program {

    public static int Main(String[] args) {

        // WriteLine($"args: {args.Length}");

        // for (var i = 0; i < args.Length; i++) {

        //     WriteLine($"  {i}: {args[i]}");
        // }

        // WriteLine($"foo");

        // Foo();

        

        switch (true) {

            case var _ when 
                args.Length >= 2
                && args[0] == "build"
                && File.Exists(args[1]): {

                Build(
                    path: args[1], 
                    verbose: !args.Contains("--silent"));

                return 0;
            }

            case var _ when 
                args.Length == 1 
                && File.Exists(args[0]): {

                throw new Exception();
            }

            default: {

                Error.WriteLine($"usage foo");

                return 1;
            }
        }
    }

    public static void Build(
        String path,
        bool verbose) {

        var ext = System.IO.Path.GetExtension(path);

        var pathWithoutExt = path.Substring(0, path.Length - ext.Length);

        var o = (String data) => {

            WriteLine(data);
        };

        var e = (String err) => {
            
            var og = Console.ForegroundColor;

            Console.ForegroundColor = 
                err.Contains("error")
                    ? ConsoleColor.Red
                    : ConsoleColor.Yellow;

            WriteLine(err);

            Console.ForegroundColor = og;
        };

        var (stdOutput, stdError, exitSuccess) = Process.Run(
            name: "clang++",
            arguments: $"-std=c++20 -I. -IRuntime -Wno-user-defined-literals {path} -o {pathWithoutExt}.out",
            dataReceived: verbose ? o : null,
            errorReceived: verbose ? e : null);
    }

    // public static void Foo() {

    //     // jakt file.jakt
    //     // clang++ -std=c++20 -I. -Iruntime -Wno-user-defined-literals ./build/file.cpp

    //     var n = "Apps/foo";

    //     var (stdOutput, stdError, exitSuccess) = Process.Run(
    //         name: "clang++",
    //         arguments: $"-std=c++20 -I. -IRuntime -Wno-user-defined-literals ./build/{n}.cpp -o ./build/{n}.out",
    //         dataReceived: data => {

    //             WriteLine(data);
    //         },
    //         errorReceived: err => {

    //             var og = Console.ForegroundColor;

    //             Console.ForegroundColor = 
    //                 err.Contains("error")
    //                     ? ConsoleColor.Red
    //                     : ConsoleColor.Yellow;

    //             WriteLine(err);

    //             Console.ForegroundColor = og;
    //         });

    //     // WriteLine($"success: {exitSuccess}");
    // }
}

public enum BuildMode {

    Clang,
    CMakeLists
}