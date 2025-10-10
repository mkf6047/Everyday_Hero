using Godot;
using System;

public partial class InvestmentBenefits : Node
{
    public static InvestmentBenefits Instance;
    private string loadFile = "";
    public Godot.Collections.Dictionary<string, int> buildingLevels;
    public bool firstInvest = true;

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

    public void UpdateLevel(string building, int modify)
    {
        buildingLevels[building] += modify;
    }

    public void LoadLevels()
    {
        
    }
}
