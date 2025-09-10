using Godot;
using System;

public partial class Load : Button
{
    [Export]
    public string saveFilepath;
    public override void _Ready()
    {
        this.Pressed += Clicked;
        base._Ready();
    }

    //when clicked, the below activates
    private void Clicked()
    {
        using (var file = FileAccess.Open(saveFilepath, FileAccess.ModeFlags.Read))
        {
            string content = file.GetLine();
            PlayerStats.Instance.Coins = int.Parse(content);
            content = file.GetLine();
            PlayerStats.Instance.Playtime = float.Parse(content);
            content = file.GetLine();
            PlayerStats.Instance.Rank = content;
            content = file.GetLine();
            PlayerStats.Instance.CurrentScene = content;
            while ((content = file.GetLine()) != ":")
            {
                PlayerStats.Instance.inventory.Add(content);
            }
            int count = 0;
            while (file.EofReached())
            {
                content = file.GetLine();
                TutorialInfo.Instance.tutorialComplete[count] = bool.Parse(content);
                count++;
            }
            GetTree().ChangeSceneToFile(PlayerStats.Instance.CurrentScene);
        }
    }
}
