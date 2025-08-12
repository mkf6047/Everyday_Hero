using Godot;
using System;

public partial class Save : Button
{
    [Export]
    public string saveFilepath;
    PlayerVariables PlayerInfo;
    public override void _Ready()
    {
        base._Ready();
        this.Pressed += Clicked;
        PlayerInfo = (PlayerVariables)GetNode("/root/PlayerVariables");
    }

    //when clicked, the below activates
    private void Clicked()
    {
        using var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read);
        string content = file.GetAsText();
        PlayerInfo.coin = Int32.Parse(content);
        GetTree().Root.AddChild(PlayerInfo);
        GetTree().ChangeSceneToFile("res://Maps/ExteriorMaps/MainScene.tscn");
    }
}
