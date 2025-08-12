using Godot;
using System;

public partial class Save : Button
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        base._Ready();
        this.Pressed += Clicked;
    }

    //when clicked, the below activates
    private void Clicked()
    {
        using var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read);
        string content = file.GetLine();
        PlayerStats.Instance.Coins = Int32.Parse(content);
        content = file.GetLine();
        PlayerStats.Instance.Playtime = float.Parse(content);
        content = file.GetLine();
        PlayerStats.Instance.Rank = content[0];
        while (!file.EofReached())
        {
            content = file.GetLine();
            PlayerStats.Instance.inventory.Add(content);
        }
        GetTree().ChangeSceneToFile("res://Maps/ExteriorMaps/MainScene.tscn");
    }
}
