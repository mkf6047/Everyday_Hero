using Godot;
using System;

public partial class BuyItems : Node2D
{
    bool isActive = false;
    int selection = 0;
    int numOfItems = 4;
    double timer = 0.0;

    TransactionSelect transactionSelect;
    ConfirmItem confirm;
    Godot.Collections.Array<string> options = [];
    Godot.Collections.Array<int> prices = [];
    ItemList buyList;
    ItemList buyPrice;
    Texture2D pointer;

    public bool IsActive{ get{ return isActive; } set { isActive = value; } }
    public int NumOfItems{ get{ return numOfItems; } set{ numOfItems = value; } }

    public override void _Ready()
    {
        transactionSelect = (TransactionSelect)GetNode("../TransactionSelect");
        buyList = (ItemList)GetNode("./ItemsSold");
        buyPrice = (ItemList)GetNode("./BuyPrices");
        confirm = (ConfirmItem)GetNode("ConfirmItem");
        pointer = GD.Load<Texture2D>("res://Sprites/OverlaySprites/MenuSelector.png");
        buyList.GetVScrollBar().Modulate = new Color(0,0,0,0);
        buyPrice.GetVScrollBar().Modulate = new Color(0,0,0,0);
        this.Hide();
    }

    public override void _Process(double delta)
    {
        if (isActive)
        {
            timer += delta;
            if (Input.IsActionJustPressed("up"))
            {
                buyList.SetItemIcon(selection, null);
                selection--;
                if (selection < 0)
                {
                    selection = numOfItems - 1;
                }
                buyList.SetItemIcon(selection, pointer);
                buyList.Select(selection);
                buyList.EnsureCurrentIsVisible();
                buyPrice.Select(selection);
                buyPrice.EnsureCurrentIsVisible();
            }
            if (Input.IsActionJustPressed("down"))
            {
                buyList.SetItemIcon(selection, null);
                selection++;
                if (selection >= numOfItems)
                {
                    selection = 0;
                }
                buyList.SetItemIcon(selection, pointer);
                buyList.Select(selection);
                buyList.EnsureCurrentIsVisible();
                buyPrice.Select(selection);
                buyPrice.EnsureCurrentIsVisible();
            }
            if (Input.IsActionJustPressed("Interact"))
            {
                confirm.SetItem(buyList.GetItemText(selection));
                confirm.SetPrice(buyPrice.GetItemText(selection));
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
        prices.Clear();
        buyList.Clear();
        buyPrice.Clear();
        foreach (string a in incomingItems)
        {
            if (!(a == ""))
            {
                options.Add(a);
                buyList.AddItem(a);
            }
        }
        foreach (int a in incomingPrices)
        {
            prices.Add(a);
            buyPrice.AddItem(a.ToString());
        }
        numOfItems = options.Count;
        buyList.SetItemIcon(0, pointer);
        buyList.Select(0);
        buyList.EnsureCurrentIsVisible();
        buyPrice.Select(0);
        buyPrice.EnsureCurrentIsVisible();
    }
}
