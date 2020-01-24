using Coflnet;

public class MoveCommand : Command
{
    public override string Slug => "mv";

    public override void Execute(MessageData data)
    {
        // TODO move
    }

    protected override CommandSettings GetSettings()
    {
        return new CommandSettings(true,true,true);
    }
}