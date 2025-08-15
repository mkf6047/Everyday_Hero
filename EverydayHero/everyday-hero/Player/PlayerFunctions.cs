using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerFunctions : Node2D
{
    DialougeControl dialouge;
    ShopOverlay shopOverlay;
    int dialougeLine = 0;
    double timer = 0.0;
    List<string> lines;
    string dialougeNameplate;
    bool talking = false;
    bool isShop = false;
    bool isBusy = false;
    Godot.Collections.Array<string> shopItems;
    Godot.Collections.Array<int> shopPrices;

    public bool IsBusy { get { return isBusy; } set { isBusy = value; } }

    public override void _Ready()
    {
        dialouge = (DialougeControl)GetNode("PlayerBody2D/Overlays/DialougeOverlay");
        shopOverlay = (ShopOverlay)GetNode("PlayerBody2D/Overlays/ShopOverlay");
        lines = new List<string>();
        shopItems = new Godot.Collections.Array<string>();
        shopPrices = new Godot.Collections.Array<int>();
    }
    public override void _Process(double delta)
    {
        timer += delta;
        if (talking)
        {
            if (Input.IsActionJustPressed("Interact") && timer > 1.5)
            {
                AdvanceTextbox();
            }
        }
    }

    public void AdvanceTextbox()
    {
        if (lines[dialougeLine] == "")
        {
            EndTextbox();
            if (isShop)
            {
                OpenShop();
            }
            return;
        }
        dialouge.UpdateTextbox(lines[dialougeLine]);
        dialougeLine++;
    }

    public void LoadText(string filepath, bool isShopNPC, string shopInventory)
    {
        GetTree().Paused = true;
        using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Read))
        {
            if (file != null)
            {
                string fileText = file.GetLine();
                dialougeNameplate = fileText;
                while (!file.EofReached())
                {
                    fileText = file.GetLine();
                    lines.Add(fileText);
                }
            }
            else
            {
                return;
            }
        }
        AdvanceTextbox();
        dialouge.UpdateNameplate(dialougeNameplate);
        dialouge.BeginText();
        talking = true; isBusy = true;
        isShop = isShopNPC;
        if (isShop)
        {
            using (var file = FileAccess.Open("res://NPC/ShopInventories/" + shopInventory, FileAccess.ModeFlags.Read))
            {
                if (file != null)
                {
                    shopItems.Clear();
                    string fileText;
                    while (!file.EofReached())
                    {
                        fileText = file.GetLine();
                        shopItems.Add(fileText);
                    }
                }
                else
                {
                    return;
                }
            }
            using (var file = FileAccess.Open("res://NPC/ShopPrices/" + shopInventory, FileAccess.ModeFlags.Read))
            {
                if (file != null)
                {
                    shopPrices.Clear();
                    string fileText;
                    while (!file.EofReached())
                    {
                        fileText = file.GetLine();
                        if (fileText != "")
                        {
                            shopPrices.Add(fileText.ToInt());
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void EndTextbox()
    {
        dialouge.EndText();
        talking = false;
        isBusy = false;
        dialougeLine = 0;
        if (!isShop)
        {
            GetTree().Paused = false;
        }
    }

    public void OpenShop() { shopOverlay.OpenShop(); isBusy = true; SetShop(); }

    public void SetShop()
    {
        shopOverlay.SetBuyInventory(shopItems, shopPrices);
    }
    public void SetSell()
    {
        shopOverlay.SetSellInventory(PlayerStats.Instance.inventory, PlayerStats.Instance.inventoryPrice);
    }
}
