using Godot;
using System;

public partial class PlayerNameDecider : LineEdit
{
    public bool shiftActive = false;
    public override void _Ready()
    {
        this.Text = "";
    }
    public void AddLetter(string letter)
    {
        if(shiftActive){ this.Text += letter.ToUpper(); shiftActive = !shiftActive; }
        else{ this.Text += letter.ToLower(); }
    }

    public void RemoveLetter()
    {
        if(this.Text == ""){ return; }
        string holder = this.Text;
        holder = holder.Remove(holder.Length - 1);
        this.Text = holder;
    }

    public void FlipShift()
    {
        shiftActive = !shiftActive;
    }
}
