using Godot;
using System;

public partial class BuildingIdentity : Node2D
{
    [Export]
    public string buildingName;
    public override void _Ready()
    {
        if (InvestmentBenefits.Instance.firstInvest)
        {
            InvestmentBenefits.Instance.buildingLevels[buildingName] = 1;
        }
    }

}
