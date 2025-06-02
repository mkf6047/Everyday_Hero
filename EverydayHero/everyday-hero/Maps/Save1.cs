using Godot;
using System;

public partial class Save1 : Button
{
    //save file 1
    PlayerVariables PlayerInfo;
    public override void _Ready()
    {
        base._Ready();
        this.Pressed += Clicked;
    }

    //when clicked, the below activates
    private void Clicked()
    {
        PlayerInfo = GD.Load<PackedScene>("res://PlayerInformation/PlayerVariables.tscn").Instantiate<PlayerVariables>();
        using var file = FileAccess.Open("user://save_game_1.dat", FileAccess.ModeFlags.Read);
        string content = file.GetAsText();
        PlayerInfo.coin = Int32.Parse(content);
        GetTree().Root.AddChild(PlayerInfo);
        GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
    }

}
