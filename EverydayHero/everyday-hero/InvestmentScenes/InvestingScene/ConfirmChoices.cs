using Godot;
using System;

public partial class ConfirmChoices : Button
{
    public override void _Ready()
    {
        this.Pressed += Clicked;
    }

    public void Clicked()
    {
        GetTree().ChangeSceneToFile("res://Maps/BuildingInteriors/BuildingInterior.tscn");
        if(InvestmentBenefits.Instance.firstInvest){ InvestmentBenefits.Instance.firstInvest = false; }
    }
}
