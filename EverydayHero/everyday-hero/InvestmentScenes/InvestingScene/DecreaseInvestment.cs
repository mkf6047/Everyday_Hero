using Godot;
using System;

public partial class DecreaseInvestment : Button
{
    BuildingIdentity identity;
    RichTextLabel levelDisplay, priceDisplay;
    int price;

    public override void _Ready()
    {
        identity = (BuildingIdentity)GetNode("../");
        levelDisplay = (RichTextLabel)GetNode("../InvestmentLevel");
        priceDisplay = (RichTextLabel)GetNode("../PriceDisplay");
        price = 50 * InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        InvestmentBenefits.Instance.buildingLevels[identity.buildingName]--;
        PlayerStats.Instance.Coins += 50 * InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        price = 50 * InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        levelDisplay.Text = "[center]" + InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        priceDisplay.Text = "[center]" + price;
    }
}
