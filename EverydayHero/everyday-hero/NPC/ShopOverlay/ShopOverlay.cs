using Godot;
using System;

public partial class ShopOverlay : Control
{
    bool isOpen = false;
    bool isAvailable = false;
    bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }
    BuyItems buyOverlay;
    SellItems sellOverlay;
    public override void _Ready()
    {
        this.Hide();
        buyOverlay = (BuyItems)GetNode("./Buy");
        sellOverlay = (SellItems)GetNode("./Sell");
    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel") && isOpen)
        {
            CloseShop();
        }
    }
    public virtual void OpenShop()
    {
        if (isAvailable == false) { return; }
        GetTree().Paused = true;
        this.Show();
        isOpen = true;
    }
    public virtual void CloseShop()
    {
        GetTree().Paused = false;
        this.Hide();
        isOpen = false;
    }
    public void SetBuyInventory()
    {
        
    }
    public void SetSellInventory()
    {
        
    }
}
