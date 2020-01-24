using MessagePack;

[MessagePackObject]
public struct IntVector3 
{

    [Key(0)]
    public int x;
        //
    // Summary:
    //     Y component of the vector.
    [Key(1)]
    public int y;
    //
    // Summary:
    //     Z component of the vector.
    [Key(2)]
    public int z;

}
