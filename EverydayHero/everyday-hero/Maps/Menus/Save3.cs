using Godot;
using System;

public partial class Save3 : Button
{
    //save file 3
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
        using var file = FileAccess.Open("user://save_game_3.dat", FileAccess.ModeFlags.Read);
        string content = file.GetAsText();
        PlayerInfo.coin = Int32.Parse(content);
        GetTree().Root.AddChild(PlayerInfo);
        GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
    }
}
