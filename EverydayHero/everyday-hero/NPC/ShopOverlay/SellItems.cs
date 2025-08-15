using Godot;
using System;

public partial class SellItems : Node2D
{
    bool isActive = false;
    int selection = 0;
    int numOfItems = 3;
    double timer = 0.0;

    TransactionSelect transactionSelect;
    ConfirmItem confirm;
    Godot.Collections.Array<string> options = [];
    Godot.Collections.Array<int> prices = [];
    ItemList sellList;
    ItemList sellPrice;
    Texture2D pointer;

    public bool IsActive { get { return isActive; } set { isActive = value; } }
    public int NumOfItems{ get{ return numOfItems; } set{ numOfItems = value; } }

    public override void _Ready()
    {
        transactionSelect = (TransactionSelect)GetNode("../TransactionSelect");
        sellList = (ItemList)GetNode("./Inventory");
        sellPrice = (ItemList)GetNode("./SellPrices");
        confirm = (ConfirmItem)GetNode("ConfirmItem");
        confirm.buySell = false;
        pointer = GD.Load<Texture2D>("res://Sprites/OverlaySprites/MenuSelector.png");
        this.Hide();
    }

    public override void _Process(double delta)
    {
        if (isActive)
        {
            timer += delta;
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
                confirm.SetItem(sellList.GetItemText(selection));
                confirm.SetPrice(sellPrice.GetItemText(selection));
                confirm.BecomeActive();
                this.isActive = false;
            }
            if (Input.IsActionJustPressed("cancel") && (timer > 0.5))
            {
                transactionSelect.IsActive = true;
                transactionSelect.inSubmenu = false;
                this.isActive = false;
                this.Hide();
            }
        }
        else if (timer > 1.0)
        {
            timer = 0.0;
        }
    }
    public void SetList(Godot.Collections.Array<string> incomingItems, Godot.Collections.Array<int> incomingPrices)
    {
        options.Clear();
        sellList.Clear();
        sellPrice.Clear();
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
        numOfItems = options.Count;
        sellList.SetItemIcon(0, pointer);
        sellList.Select(0);
        sellList.EnsureCurrentIsVisible();
        sellPrice.Select(0);
        sellPrice.EnsureCurrentIsVisible();
    }
}
