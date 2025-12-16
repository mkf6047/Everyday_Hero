using Godot;
using System;

public partial class ChangeColorCollide : Area2D
{
    //LeaderSprite parent;
    ClassInformationV2 classInfo;
    public override void _Ready()
    {
        //parent = (LeaderSprite)GetParent();
        classInfo = (ClassInformationV2)GetNode("ClassInformation2");
    }

    public void UpdateClassInfo(string questerClass)
    {
        classInfo.UpdateCharInfo(questerClass);
    }

	public void MouseEnter()
	{
        if (TutorialInfo.Instance.tutorialComplete[3])
        {
			classInfo.Show();
        }
	}
	public void MouseExit()
	{
		classInfo.Hide();
	}
}
