using Godot;
using System;

public partial class SaveGame : Button
{
    [Export]
    public string filepath;
    SaveComplete saveCompleteLabel;

    public override void _Ready()
    {
        this.Pressed += Clicked;
        saveCompleteLabel = (SaveComplete)GetNode("../../SaveComplete");
        base._Ready();
    }


    private void Clicked()
    {
        using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Write))
        {
            file.StoreLine("" + PlayerStats.Instance.Coins);
            file.StoreLine("" + PlayerStats.Instance.Playtime);
            file.StoreLine("" + PlayerStats.Instance.Rank);
            foreach (string a in PlayerStats.Instance.inventory)
            {
                file.StoreLine(a);
            }
            saveCompleteLabel.Saved();
        }
    }
}
