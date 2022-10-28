
namespace Neu;

public partial class Compiler {

    public const Int32 UnknownTypeId    = 0;
    public const Int32 VoidTypeId       = 1;
    public const Int32 BoolTypeId       = 2;

    public const Int32 Int8TypeId       = 3;
    public const Int32 Int16TypeId      = 4;
    public const Int32 Int32TypeId      = 5;
    public const Int32 Int64TypeId      = 6;

    public const Int32 UInt8TypeId      = 7;
    public const Int32 UInt16TypeId     = 8;
    public const Int32 UInt32TypeId     = 9;
    public const Int32 UInt64TypeId     = 10;

    public const Int32 FloatTypeId      = 11;
    public const Int32 DoubleTypeId     = 12;

    public const Int32 CCharTypeId      = 13;
    public const Int32 CIntTypeId       = 14;

    public const Int32 UIntTypeId       = 15;
    public const Int32 IntTypeId        = 16;

    // Note: keep StringTypeId last as it is how we know how many slots to pre-fill

    public const Int32 StringTypeId     = 17;

    public List<(String, byte[])> RawFiles { get; init; }

    ///

    public Compiler() {

        this.RawFiles = new List<(String, byte[])>();
    }

    public void IncludePrelude(
        Project project) {

        // First, let's make types for all the builtin types
        // This order *must* match the order of the constants the typechecker expects

        for (var i = 0; i < (Compiler.StringTypeId + 1); i++) {

            project.Types.Add(new Builtin());
        }


        
        

    }

}