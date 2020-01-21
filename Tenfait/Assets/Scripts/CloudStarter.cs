using System.Collections;
using System.Collections.Generic;
using Coflnet;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TenfaitExtention : Coflnet.IRegisterCommands
{
    public void RegisterCommands(CommandController controller)
    {
        // new Commands for the cloud

    }
}

public class Chunk : Referenceable
{
    private static CommandController _commands = new CommandController(globalCommands);

    public HeightMap Terrain {get;set;} 

    public RemoteList<WorldObject> Objects;

    public RemoteList<EntityPosition> Entities;


    static Chunk()
    {
        _commands.RegisterCommand<MoveCommand>();
    }

    public override CommandController GetCommandController()
    {
        return _commands;
    }
}
