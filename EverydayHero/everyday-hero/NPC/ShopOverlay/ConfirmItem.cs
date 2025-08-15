using Godot;
using System;

public partial class ConfirmItem : Node2D
{
    public bool buySell = true; //true for buy, false for sell
    bool isActive = false;
    int selection = 0;
    double timer = 0.0;

    ItemList yesNo;
    ItemList item;
    ItemList price;

    public bool IsActive { get { return isActive; } set { isActive = value; } }

    public override void _Ready()
    {
        yesNo = (ItemList)GetNode("Yes-No");
        item = (ItemList)GetNode("Item");
        price = (ItemList)GetNode("Price");
        yesNo.Select(selection);
        this.Hide();
    }
    public override void _Process(double delta)
    {
        if (isActive)
        {
            timer += delta;
            if (Input.IsActionJustPressed("left") || Input.IsActionJustPressed("right"))
            {
                if (selection == 0) { selection = 1; } else { selection = 0; }
                yesNo.Select(selection);
            }
            if (Input.IsActionJustPressed("Interact") && timer > 0.5)
            {
                timer = 0.0;
                string choice = yesNo.GetItemText(selection);
                if (choice == "Yes")
                {
                    string itemGet = item.GetItemText(0);
                    int priceGet = price.GetItemText(0).ToInt();
                    if (buySell)
                    {
                        PlayerStats.Instance.Coins -= priceGet;
                        PlayerStats.Instance.inventory.Add(itemGet);
                        this.isActive = false;
                        BuyItems parent = (BuyItems)GetParent();
                        parent.IsActive = true;
                        this.Hide();
                    }
                    else
                    {
                        PlayerStats.Instance.Coins += priceGet;
                        PlayerStats.Instance.inventory.Remove(itemGet);
                        this.isActive = false;
                        SellItems parent = (SellItems)GetParent();
                        parent.IsActive = true;
                        this.Hide();
                    }
                }
                else
                {
                    this.Hide();
                    this.isActive = false;
                    if (buySell)
                    {
                        BuyItems parent = (BuyItems)GetParent();
                        parent.IsActive = true;
                    }
                    else
                    {
                        SellItems parent = (SellItems)GetParent();
                        parent.IsActive = true;
                    }
                }
            }
        }
        else if (timer > 1.0)
        {
            timer = 0.0;
        }
    }
    public void SetItem(string incomingItem)
    {
        item.SetItemText(0, incomingItem);
    }
    public void SetPrice(string incomingPrice)
    {
        price.SetItemText(0, incomingPrice);
    }
    public void BecomeActive()
    {
        this.isActive = true;
        this.Show();
    }
}
