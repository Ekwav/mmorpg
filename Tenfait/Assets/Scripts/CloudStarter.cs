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

<<<<<<< HEAD
        var bytes = MessagePack.MessagePackSerializer.Serialize(new Chunk(){});
=======
        
>>>>>>> 528c3c479dad802ad066388975454640fc00bbc9
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Direction3 dir)
    {
        ClientCore.Instance.SendCommand<MoveCommand, Direction3>(new Coflnet.SourceReference(), dir);
    }
}
