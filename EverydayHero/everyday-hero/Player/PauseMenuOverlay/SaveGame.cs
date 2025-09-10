using Godot;
using System;
using System.Net;

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
            file.StoreLine("" + PlayerStats.Instance.QuestsSorted);
            file.StoreLine("" + PlayerStats.Instance.CurrentScene);
            foreach (string a in PlayerStats.Instance.inventory)
            {
                file.StoreLine(a);
            }
            file.StoreLine(":");
            foreach (bool a in TutorialInfo.Instance.tutorialComplete)
            {
                file.StoreLine(a.ToString());
            }
            saveCompleteLabel.Saved();
            parent.Hide();
            child.ResetText();
        }
    }
}
