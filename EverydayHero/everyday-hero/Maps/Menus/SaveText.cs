using Godot;
using System;

public partial class SaveText : RichTextLabel
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        base._Ready();
        ResetText();
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
    public void ResetText()
    {
        string name = "-";
        string coins = "0";
        string playtime = "0";
        string rank = "Unemployed";
        using (var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read))
        {
            if (file.IsOpen())
            {
                name = file.GetLine();
                coins = file.GetLine();
                playtime = file.GetLine();
                rank = file.GetLine();
            }
            file.Close();
        }
        if (name == "-")
        {
            this.Text = "no data to load!";
            return;
        }
        this.Text =
        "Name: " + name +
        "\nDays Passed: " + playtime +
        "\nRank: " + rank +
        "\nCoins: " + coins;
    }
}
