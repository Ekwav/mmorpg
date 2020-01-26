using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoaderScript : MonoBehaviour
{
    [SerializeField]
    private GameObject chunk;

    public float junkSize;

    // Start is called before the first frame update
    void Start()
    {
        float size = junkSize / 4f;
        Instantiate(chunk);
        Instantiate(chunk, new Vector3(size, 0f, 0f), Quaternion.identity);
        Instantiate(chunk, new Vector3(size, 0f, size), Quaternion.identity);
        Instantiate(chunk, new Vector3(0f, 0f, size), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
