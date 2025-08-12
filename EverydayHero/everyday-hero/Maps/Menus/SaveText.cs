using Godot;
using System;

public partial class SaveText : RichTextLabel
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        base._Ready();
        string coins = "Error";
        string playtime = "Error";
        string rank = "Error";
        using (var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read))
        {
            if (file.IsOpen())
            {
                coins = file.GetLine();
                playtime = file.GetLine();
                rank = file.GetLine();
            }
            file.Close();
        }
        this.Text =
        "Playtime: " + playtime +
        "\nRank: " + rank +
        "\nCoins: " + coins;
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
