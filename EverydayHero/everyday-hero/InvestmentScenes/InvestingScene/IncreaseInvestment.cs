using Godot;
using System;

public partial class IncreaseInvestment : Button
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
        levelDisplay.Text = "[center]" + InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        priceDisplay.Text = "[center]Price: " + price;
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        if (PlayerStats.Instance.Coins < price) { return; }
        PlayerStats.Instance.Coins -= price;
        InvestmentBenefits.Instance.buildingLevels[identity.buildingName]++;
        price = 50 * InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        levelDisplay.Text = "[center]" + InvestmentBenefits.Instance.buildingLevels[identity.buildingName];
        priceDisplay.Text = "[center]" + price;
    }
}
