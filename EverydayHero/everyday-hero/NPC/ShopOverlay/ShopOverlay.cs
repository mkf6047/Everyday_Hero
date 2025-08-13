using Godot;
using System;

public partial class ShopOverlay : Control
{
    bool isOpen = false;
    TransactionSelect selectTransaction;
    BuyItems buyOverlay;
    SellItems sellOverlay;
    public override void _Ready()
    {
        this.Hide();
        buyOverlay = (BuyItems)GetNode("./Buy");
        sellOverlay = (SellItems)GetNode("./Sell");
        selectTransaction = (TransactionSelect)GetNode("./TransactionSelect");
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
        GetTree().Paused = true;
        this.Show();
        isOpen = true;
        selectTransaction.IsActive = true;
    }
    public virtual void CloseShop()
    {
        GetTree().Paused = false;
        this.Hide();
        isOpen = false;
    }
    public void SetBuyInventory(Godot.Collections.Array<string> incomingItems, Godot.Collections.Array<int> incomingPrices)
    {
        buyOverlay.SetList(incomingItems, incomingPrices);
    }
    public void SetSellInventory(Godot.Collections.Array<string> incomingItems, Godot.Collections.Array<int> incomingPrices)
    {
        sellOverlay.SetList(incomingItems, incomingPrices);
    }
}
