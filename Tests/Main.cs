
namespace DeepScroll;

public static partial class Program {

    public static ErrorOrVoid TestSamples(
        String path) {

        if (!Directory.Exists(path)) {

            return new ErrorOrVoid();
        }

        var files = Directory.GetFiles(path);

        if (!files.Any()) {

            return new ErrorOrVoid();
        }

        foreach (var sample in files.OrderBy(x => x)) {

            var ext = Path.GetExtension(sample);

            if (ext == ".neu") {

                // Great, we found test file

                // var 

            }
        }

        return new ErrorOrVoid();
    }

    public static void Main(String[] args) {

        Console.Clear();

        Compiler.Clean();
    }

    public static ErrorOrVoid TestScratchpad() {

        return TestSamples("./Samples/Scratchpad");
    }

    public static ErrorOrVoid TestApps() {

        return TestSamples("./Samples/Apps");
    }

    public static ErrorOrVoid TestBasics() {

        return TestSamples("./Samples/Basics");
    }

    public static ErrorOrVoid TestControlFlow() {

        return TestSamples("./Samples/ControlFlow");
    }

    public static ErrorOrVoid TestFunctions() {

        return TestSamples("./Samples/Functions");
    }

    public static ErrorOrVoid TestMath() {

        return TestSamples("./Samples/Math");
    }

    public static ErrorOrVoid TestVariables() {

        return TestSamples("./Samples/Variables");
    }

    public static ErrorOrVoid TestStrings() {

        return TestSamples("./Samples/Strings");
    }

    public static ErrorOrVoid TestArrays() {

        return TestSamples("./Samples/Arrays");
    }

    public static ErrorOrVoid TestOptional() {

        return TestSamples("./Samples/Optional");
    }

    public static ErrorOrVoid TestTuples() {

        return TestSamples("./Samples/Tuples");
    }

    public static ErrorOrVoid TestStructs() {

        return TestSamples("./Samples/Structs");
    }

    public static ErrorOrVoid TestPointers() {

        return TestSamples("./Samples/Pointers");
    }

    public static ErrorOrVoid TestClasses() {

        return TestSamples("./Samples/Classes");
    }

    public static ErrorOrVoid TestBoolean() {

        return TestSamples("./Samples/Boolean");
    }

    public static ErrorOrVoid TestRanges() {

        return TestSamples("./Samples/Ranges");
    }

    public static ErrorOrVoid TestDictionaries() {

        return TestSamples("./Samples/Dictionaries");
    }

    public static ErrorOrVoid TestGenerics() {

        return TestSamples("./Samples/Generics");
    }

    public static ErrorOrVoid TestEnums() {

        return TestSamples("./Samples/Enums");
    }

    public static ErrorOrVoid TestInlineCPP() {

        return TestSamples("./Samples/InlineCPP");
    }

    public static ErrorOrVoid TestParser() {

        return TestSamples("./Tests/Parser");
    }

    public static ErrorOrVoid TestTypeChecker() {

        return TestSamples("./Tests/TypeChecker");
    }

    public static ErrorOrVoid TestSets() {

        return TestSamples("./Samples/Sets");
    }

    public static ErrorOrVoid TestNamespaces() {

        return TestSamples("./Samples/Namespaces");
    }

    public static ErrorOrVoid TestWeak() {

        return TestSamples("./Samples/Weak");
    }

    public static ErrorOrVoid TestCodeGen() {

        return TestSamples("./Tests/CodeGen");
    }
}