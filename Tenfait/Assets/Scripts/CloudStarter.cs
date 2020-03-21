using System.Collections;
using System.Collections.Generic;
using Coflnet.Client;
using UnityEngine;

public class CloudStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // add the new Commands via the extention
        Coflnet.Core.CoreExtentions.Commands.Add(new TenfaitExtention());

        // "boot it up"
        ClientCore.Init();

        var bytes = MessagePack.MessagePackSerializer.Serialize(new Chunk(){});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
