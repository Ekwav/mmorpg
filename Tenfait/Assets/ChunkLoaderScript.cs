using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoaderScript : MonoBehaviour
{

    public float junkSize;

    public GameObject chunkPrefab;
    public List<Chunk> chunks = new List<Chunk>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var terrain in GameObject.FindGameObjectsWithTag("Terrain"))
        {
            TerrainData td = terrain.GetComponent<Terrain>().terrainData;
            float[,] heightmapFloat = td.GetHeights(0, 0, td.detailWidth, td.detailHeight);
            byte[,] heightmapByte = new byte[heightmapFloat.GetLength(0) * 4, heightmapFloat.GetLength(1) * 4];
            Buffer.BlockCopy(heightmapFloat, 0, heightmapByte, 0, heightmapByte.Length);

            Coflnet.RemoteList<WorldObject> worldObjects = new Coflnet.RemoteList<WorldObject>();
            foreach (var obj in terrain.GetComponentsInChildren<GameObject>())
            {
                WorldObjectPointer wop = new WorldObjectPointer(){ Direction = Direction3.FRONT, RelativePosition = new IntVector3() { x = (int)obj.transform.position.x, y = (int)obj.transform.position.y, z = (int)obj.transform.position.z },  };
            }

            Chunk c = new Chunk() { Position =  new IntVector2() { x = (int)terrain.transform.position.x, y = (int)terrain.transform.position.z } , Terrain = new HeightMap() { Heights = heightmapByte }, Objects =  };
        }
        
        //float size = junkSize / 4f;
        //Instantiate(chunk);
        //Instantiate(chunk, new Vector3(size, 0f, 0f), Quaternion.identity);
        //Instantiate(chunk, new Vector3(size, 0f, size), Quaternion.identity);
        //Instantiate(chunk, new Vector3(0f, 0f, size), Quaternion.identity);
        var bytes = MessagePack.MessagePackSerializer.Serialize(new Chunk() { Position = null, Terrain = null, Objects = null });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
