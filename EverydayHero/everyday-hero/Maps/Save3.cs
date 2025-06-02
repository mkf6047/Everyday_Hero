using Godot;
using System;

public partial class Save3 : Button
{
    PlayerVariables PlayerInfo;
    public override void _Ready()
    {
        base._Ready();
        this.Pressed += Clicked;
        PlayerInfo = GD.Load<PackedScene>("res://PlayerInformation/PlayerVariables.tscn").Instantiate<PlayerVariables>();
        using var file = FileAccess.Open("user://save_game_3.dat", FileAccess.ModeFlags.Read);
        string content = file.GetAsText();
        PlayerInfo.coin = Int32.Parse(content);
    }

    private void Clicked()
    {
        GetTree().Root.AddChild(PlayerInfo);
        GetTree().ChangeSceneToFile("res://Maps/MainScene.tscn");
    }

}
