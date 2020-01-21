The terain is devided up into cubes of length `0.25` that can be modified in any way but have to connect to the rest of the world.
They have to be connected in order for the collision system to work more effectively as it only tests in a Ring.

### Example 
A door might look something like this:
```
XXXXXX
XooooX
Xo  oX
Xo  oX
Xo  oX
Xo  oX
Xo  oX
XooooX
XXXXXX
```
* `o` Player
* `X` Wall
* ` ` (empty) is skipped

Only the fields with `o` are tested. 


## Chunks
To handle the terain effectively it is deviced into chungs of length 64x64. 
A chunk has the following attributes:
```
{
  "terain":[[5,4,3,3,..]..],
  "objects":[{"position":[x,y,z],"typeId":[1,39729387],"orientation":1}]
}
```
* `terain` A two dimentional array of the teran where each position tells you the height of the terain at that point.
* `objects` Additional objects placed in the terain.

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
