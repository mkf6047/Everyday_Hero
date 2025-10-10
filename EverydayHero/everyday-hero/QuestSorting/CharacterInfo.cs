using Godot;
using System;

public partial class CharacterInfo : Area2D
{
    [Export]
    int charOrder = 0;
    public int partySize = 0;
    ClassInformation classInfo;
    public override void _Ready()
    {
        classInfo = (ClassInformation)GetNode("ClassInformation");
    }


    public void updateInfo(string questerClass)
    {
        
    }
    public void MouseEnter()
    {
        if (charOrder < partySize)
        {
            classInfo.Show();
        }
    }
    public void MouseExit()
    {
        classInfo.Hide();
    }
}
