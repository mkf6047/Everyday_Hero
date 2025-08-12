using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerFunctions : Node2D
{
    DialougeControl dialouge;
    ShopOverlay shopOverlay;
    int dialougeLine = 0;
    List<string> lines;
    string dialougeNameplate;
    bool talking = false;
    bool isShop = false;
    Godot.Collections.Array<string> shopItems;
    Godot.Collections.Array<int> shopPrices;

    public override void _Ready()
    {
        dialouge = (DialougeControl)GetNode("Overlays/DialougeOverlay");
        shopOverlay = (ShopOverlay)GetNode("Overlays/ShopOverlay");
    }
    public override void _Process(double delta)
    {
        if (talking)
        {
            if (Input.IsActionJustPressed("Interact"))
            {
                AdvanceTextbox();
            }
        }
    }

    public void AdvanceTextbox()
    {
        if (dialougeLine >= lines.Count)
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
        using (var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Read))
        {
            if (file != null)
            {
                string fileText = file.GetAsText();
                int split = fileText.IndexOf('^');
                dialougeNameplate = fileText.Substr(0, split + 1);
                fileText.Remove(0, split + 1);
                while ((split = fileText.IndexOf('^')) > 0)
                {
                    lines.Add(fileText.Substr(0, split + 1));
                    fileText.Remove(0, split + 1);
                }
                lines.Add(fileText);
            }
            else
            {
                return;
            }
        }
        AdvanceTextbox();
        dialouge.UpdateNameplate(dialougeNameplate);
        dialouge.BeginText();
        talking = true;
        isShop = isShopNPC;
        if (isShop)
        {
            using (var file = FileAccess.Open(shopInventory, FileAccess.ModeFlags.Read))
            {
                if (file != null)
                {
                    shopItems.Clear();
                    string fileText;
                    int split;
                    while (!file.EofReached())
                    {
                        fileText = file.GetLine();
                        split = fileText.IndexOf('^');
                        shopItems.Add(fileText.Substr(0, split + 1));
                        fileText.Remove(0, split + 1);
                        shopPrices.Add(int.Parse(fileText));
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
    }

    public void OpenShop() { shopOverlay.OpenShop(); }

    public void SetShop()
    {
        shopOverlay.SetBuyInventory(shopItems, shopPrices);
    }
}
