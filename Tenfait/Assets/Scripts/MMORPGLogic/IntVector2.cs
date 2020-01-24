using MessagePack;

/// <summary>
/// Two dimentional Int vector 
/// </summary>
[MessagePackObject]
public struct IntVector2
{
    [Key(0)]
    public int x;
    
    [Key(1)]
    public int y;
}