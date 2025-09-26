using Godot;
using System;

public partial class CurrentFunds : RichTextLabel
{
    int previousCoinage;
    public override void _Ready()
    {
        previousCoinage = PlayerStats.Instance.Coins;
        this.Text = "[center]Current Funds: " + PlayerStats.Instance.Coins;
    }

    public override void _Process(double delta)
    {
        if (previousCoinage != PlayerStats.Instance.Coins)
        {
            this.Text = "[center]Current Funds: " + PlayerStats.Instance.Coins;
            previousCoinage = PlayerStats.Instance.Coins;
        }
    }

}
