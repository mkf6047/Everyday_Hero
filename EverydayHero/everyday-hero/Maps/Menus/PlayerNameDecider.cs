using Godot;
using System;

public partial class PlayerNameDecider : LineEdit
{
    bool shiftActive = false;
    public void AddLetter(string letter)
    {
        if(shiftActive){ this.Text += letter.ToUpper(); }
        else{ this.Text += letter.ToLower(); }
    }

    public void RemoveLetter()
    {
        string holder = this.Text;
        holder = holder.Remove(holder.Length - 1);
        this.Text = holder;
    }

    public void FlipShift()
    {
        shiftActive = !shiftActive;
    }
}
