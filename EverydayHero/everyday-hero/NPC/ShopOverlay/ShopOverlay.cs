using Godot;
using System;

public partial class ShopOverlay : Control
{
    bool isOpen = false;
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("cancel"))
        {
            CloseShop();
        }
    }
    public virtual void OpenShop()
    {
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
}
