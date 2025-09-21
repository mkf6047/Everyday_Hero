using Godot;
using System;

public partial class IncreaseInvestment : Button
{
    BuildingIdentity identity;
    RichTextLabel levelDisplay;
    public override void _Ready()
    {
        identity = (BuildingIdentity)GetNode("../");
        levelDisplay = (RichTextLabel)GetNode("../InvestmentLevel");
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        InvestmentBenefits.Instance.buildingLevels[identity.buildingName]++;
        levelDisplay.Text = "[center]" + InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
    }
}
