using Godot;
using System;
using System.Diagnostics;

public partial class TransactionSelect : Node2D
{
    bool isActive = false;
    int selection = 0;
    int numOfItems = 4;

    Godot.Collections.Array options = ["Buy","Sell","Talk","Cancel"];
    ItemList actionList;
    Texture2D pointer;

    public bool IsActive { get { return isActive; } set { isActive = value; } }
    public int NumOfItems{ get{ return numOfItems; } set{ numOfItems = value; } }
    public override void _Ready()
    {
        actionList = (ItemList)GetNode("./Options");
        pointer = GD.Load<Texture2D>("res://Sprites/OverlaySprites/MenuSelector.png");
    }

    public override void _Process(double delta)
    {
        if (isActive)
        {
            if (Input.IsActionJustPressed("up"))
            {
                actionList.SetItemIcon(selection, null);
                selection--;
                if (selection < 0)
                {
                    selection = numOfItems - 1;
                }
                actionList.SetItemIcon(selection, pointer);
            }
            if (Input.IsActionJustPressed("down"))
            {
                actionList.SetItemIcon(selection, null);
                selection++;
                if (selection >= numOfItems)
                {
                    selection = 0;
                }
                actionList.SetItemIcon(selection, pointer);
            }
            if (Input.IsActionJustPressed("Interact"))
            {
                switch (selection)
                {
                    case 0:
                        BuyItems buyList = (BuyItems)GetNode("../Buy");
                        buyList.IsActive = true;
                        this.isActive = false;
                        buyList.Show();
                        break;
                    case 1:
                        SellItems sellList = (SellItems)GetNode("../Sell");
                        sellList.IsActive = true;
                        this.isActive = false;
                        sellList.Show();
                        break;
                    case 2:
                        break;
                    case 3:
                    default:
                        ShopOverlay overlay = (ShopOverlay)GetParent();
                        overlay.CloseShop();
                        break;
                }
            }
            if (Input.IsActionJustPressed("cancel"))
            {
                ShopOverlay overlay = (ShopOverlay)GetParent();
                overlay.CloseShop();
            }
        }
    }
}
