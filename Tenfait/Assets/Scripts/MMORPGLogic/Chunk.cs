using Coflnet;
using Coflnet.Core;
using MessagePack;

[MessagePackObject]
public class Chunk : Referenceable
{
    private static CommandController _commands = new CommandController(globalCommands);

    /// <summary>
    /// The position of this chunk relative to the origin (0,0)
    /// </summary>
    public IntVector2 Position;

    /// <summary>
    /// The terrain of this chunk
    /// </summary>
    /// <value></value>
    public HeightMap Terrain {get;set;} 

    /// <summary>
    /// Physical Objects in this chunk altering the terain
    /// </summary>
    public RemoteList<WorldObject> Objects;

    /// <summary>
    /// The entities in this chunk
    /// </summary>
    public RemoteList<EntityPosition> Entities;

    /// <summary>
    /// Chunk Settings
    /// </summary>
    public ChunkSettings Settings;

    /// <summary>
    /// Sibbling chunks hosting the same region
    /// </summary>
    public RemoteList<SourceReference> Sibblings;

    /// <summary>
    /// The 8 Sorounding chunks
    /// </summary>
    public RemoteDictionary<IntVector2,Reference<Chunk>> Neightbours;


    /// <summary>
    /// Determines what you can do in this chunk
    /// </summary>
    public enum ChunkSettings
    {
        /// <summary>
        /// Can you build in this chunk
        /// </summary>
        BUILD = 1,
        /// <summary>
        /// Can this chunk scale up or is there only ever one instance
        /// </summary>
        SCALE = 2,
        /// <summary>
        /// Can you attack other players in this chunk
        /// </summary>
        PVP = 4,
        /// <summary>
        /// Can you even enter the chunk
        /// </summary>
        ENTER = 8
    }


    static Chunk()
    {
        _commands.RegisterCommand<MoveCommand>();
    }

    public override CommandController GetCommandController()
    {
        return _commands;
    }
}
