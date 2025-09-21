using Godot;
using System;

public partial class InvestmentBenefits : Node
{
    public static InvestmentBenefits Instance;
    private string loadFile = "";
    Godot.Collections.Dictionary<string, int> buildingLevels;

    public string LoadFile
    {
        get { return loadFile; }
        set { loadFile = value; }
    }

    public override void _Ready()
    {
        buildingLevels = new Godot.Collections.Dictionary<string, int>();
        Instance = this;
    }

}
