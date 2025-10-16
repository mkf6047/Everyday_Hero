using Godot;
using System;

public partial class ClosePartyInfo : Button
{
	Control parent;
	public override void _Ready()
	{
		parent = (Control)GetParent();
		this.Pressed += Clicked;
	}

	public void Clicked()
	{
		parent.Hide();
	}

}
