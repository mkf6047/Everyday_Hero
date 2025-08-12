using Godot;
using System;

public partial class SaveText : RichTextLabel
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        base._Ready();
        this.Text =
        "Playtime: " + PlayerStats.Instance.Playtime +
        "\nRank: " + PlayerStats.Instance.Rank +
        "\nCoins: " + PlayerStats.Instance.Coins;
    }

    //when clicked, the below activates
    // private void Clicked()
    // {
    //     using var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read);
    //     string content = file.GetAsText();
    //     PlayerInfo.coin = Int32.Parse(content);
    //     GetTree().Root.AddChild(PlayerInfo);
    //     GetTree().ChangeSceneToFile("res://Maps/ExteriorMaps/MainScene.tscn");
    // }
}
