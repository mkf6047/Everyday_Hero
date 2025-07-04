using Godot;
using System;

public partial class BuyItems : Node2D
{
    bool isActive = false;
    int selection = 0;
    int numOfItems = 4;

    Godot.Collections.Array<string> options = [];
    Godot.Collections.Array<int> prices = [];

    public bool IsActive{ get{ return isActive; } set { isActive = value; } }
    public int NumOfItems{ get{ return numOfItems; } set{ numOfItems = value; } }
    public override void _Process(double delta)
    {
        if (isActive)
        {
            if (Input.IsActionJustPressed("up"))
            {
                selection--;
                if (selection < 0)
                {
                    selection = numOfItems - 1;
                }
            }
            if (Input.IsActionJustPressed("down"))
            {
                selection++;
                if (selection >= numOfItems)
                {
                    selection = 0;
                }
            }
            if (Input.IsActionJustPressed("Interact"))
            {
                
            }
        }
    }
    public void SetList(Godot.Collections.Array<string> incomingItems, Godot.Collections.Array<int> incomingPrices)
    {
        options.Clear();
        foreach (string a in incomingItems)
        {
            options.Add(a);
        }
        foreach (int a in incomingPrices)
        {
            prices.Add(a);
        }
    }
}
