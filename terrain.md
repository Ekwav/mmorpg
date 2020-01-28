The terrain is devided up into cubes of length `0.25` that can be modified in any way but have to connect to the rest of the world.
They have to be connected in order for the collision system to work more effectively as it only tests in a Ring.


## Chunks
To handle the terrain effectively it is deviced into chungs of length 64x64. 
A chunk has the following attributes:
```
{
  "terrain":[[5,4,3,3,..]..],
  "objects":[{"position":[x,y,z],"typeId":[1,39729387],"orientation":1}],
  "Entities":[{"position":[x,y,z],"typeId":[1,39729387],"orientation":{"body":345.323,"head":[36.478,4.4512,0]}]
}
```
* `terrain` A two dimentional array of the terrain where each position tells you the height-difference to the point, relative to itself that is closer to (0,0) on the map.
* `objects` Additional objects placed in the terrain.
* `Entities` Entities in this chung, with their head and body orientation

Objects have the following:
```
{
  "id":[1,3479],
  "texturePath":"realtivePath/to/Texture",
  "maxSize":[x,y,z],
  "childs":[{"id":[1,340987],"realtivePosition":[x,y,z],"direction":1}]
  "fillsFrom":[x,y,z],
  "fillsTo":[x,y,z],
  "modifiers":0
}
```
* `fillsFrom` and `fillsTo` The two points that are filled by the object.
* `childs` Additional objects making up this one.
* `maxSize` The total size of all size (cube) here for performance reasons.
* `texturePath` The path to the texture for this object loaded from the resource pack.
* `modifiers` enum additional modifers 
    * `1` solid or not solid, 0 is passable

## Processing of the terrain:

* The terrain can be flattet by using a shovel. 
* With the shovel you activate a possibility to see the vertexpoints in a close range.
* Changing the terrain by grabbing one vertexpoint and move it up or down.
* The vertexpoint is moved in block steps.
* Vertexpoints around the selectet one move with every 2 block difference.
