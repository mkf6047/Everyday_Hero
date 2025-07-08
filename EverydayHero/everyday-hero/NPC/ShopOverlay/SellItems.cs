using Godot;
using System;

public partial class SellItems : Node2D
{
    bool isActive = false;
    int selection = 0;
    int numOfItems = 4;

    Godot.Collections.Array<string> options = [];
    Godot.Collections.Array<int> prices = [];
    ItemList sellList;
    ItemList sellPrice;
    Texture2D pointer;

    public bool IsActive { get { return isActive; } set { isActive = value; } }
    public int NumOfItems{ get{ return numOfItems; } set{ numOfItems = value; } }

    public override void _Ready()
    {
        sellList = (ItemList)GetNode("./Inventory");
        sellPrice = (ItemList)GetNode("./SellPrices");
        pointer = GD.Load<Texture2D>("res://Sprites/OverlaySprites/MenuSelector.png");
    }

    public override void _Process(double delta)
    {
        if (isActive)
        {
            if (Input.IsActionJustPressed("up"))
            {
                sellList.SetItemIcon(selection, null);
                selection--;
                if (selection < 0)
                {
                    selection = numOfItems - 1;
                }
                sellList.SetItemIcon(selection, pointer);
            }
            if (Input.IsActionJustPressed("down"))
            {
                sellList.SetItemIcon(selection, null);
                selection++;
                if (selection >= numOfItems)
                {
                    selection = 0;
                }
                sellList.SetItemIcon(selection, pointer);
            }
            if (Input.IsActionJustPressed("Interact"))
            {
                string item = sellList.GetItemText(selection);
                int price = int.Parse(sellPrice.GetItemText(selection));
            }
            if (Input.IsActionJustPressed("cancel"))
            {
                TransactionSelect select = (TransactionSelect)GetNode("../TransactionSelect");
                select.IsActive = true;
                this.isActive = false;
                this.Hide();
            }
        }
    }
    public void SetList(Godot.Collections.Array<string> incomingItems, Godot.Collections.Array<int> incomingPrices)
    {
        options.Clear();
        foreach (string a in incomingItems)
        {
            options.Add(a);
            sellList.AddItem(a);
        }
        foreach (int a in incomingPrices)
        {
            prices.Add(a);
            sellPrice.AddItem(a.ToString());
        }
    }
}
