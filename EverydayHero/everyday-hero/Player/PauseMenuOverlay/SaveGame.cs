using Godot;
using System;

public partial class SaveGame : Button
{
    [Export]
    public string filepath, childname;
    SaveComplete saveCompleteLabel;
    SaveSlots parent;
    SaveText child;

    public override void _Ready()
    {
        this.Pressed += Clicked;
        saveCompleteLabel = (SaveComplete)GetNode("../../SaveComplete");
        parent = (SaveSlots)GetParent();
        child = (SaveText)GetNode(childname);
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
            parent.Hide();
            child.ResetText();
        }
    }
}
