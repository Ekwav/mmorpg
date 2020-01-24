using System.Collections.Generic;
using Coflnet;

public abstract class WorldObject : Referenceable
{
    public string TexturePath;

    /// <summary>
    /// The total outer bounds of the object and all its childs
    /// </summary>
    public IntVector3 Size;

    /// <summary>
    /// Additional objects that are part of this one
    /// </summary>
    public List<WorldObject> Childs;


    /// <summary>
    /// Relative Position to the root position (0,0)
    /// </summary>
    public IntVector3 FillsTo;

    public ObjectModifiers Fodiefiers;

    public enum ObjectModifiers
    {
        /// <summary>
        /// Entities can move through this object
        /// </summary>
        AIR = 1,
        /// <summary>
        /// Determines when to swim
        /// </summary>
        WATER = 2,
        /// <summary>
        /// Doors are open if they are also air, closed otherwise
        /// </summary>
        DOOR = 4
    }
}

/// <summary>
/// Used in place of the actual WorldObject to allow reuse
/// </summary>
public class WorldObjectPointer 
{
    /// <summary>
    /// The Object actually on this position
    /// </summary>
    public Reference<WorldObject> WorldObject;

    /// <summary>
    /// Relative Position to the parent object/ or the world
    /// </summary>
    public IntVector3 RelativePosition;

    /// <summary>
    /// Direction facing in
    /// </summary>
    public Direction3 Direction;
}
