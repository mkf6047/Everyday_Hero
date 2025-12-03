using Godot;
using System;

public partial class BackgroundNoise : Node2D
{
    public static BackgroundNoise Instance {get; private set;}

    AudioStreamPlayer speaker;

    public override void _Ready()
    {
        speaker = (AudioStreamPlayer)GetNode("AudioStreamPlayer");
        Instance = this;
    }

    public void NighttimeMusic()
    {
        AudioStream newStream = ResourceLoader.Load<AudioStream>("res://MusicAndSFX/Music/Everyday Hero - Night Loop.mp3");
        speaker.Stream = newStream;
        speaker.Play();
    }

    public void MainMusic()
    {
        AudioStream newStream = ResourceLoader.Load<AudioStream>("res://MusicAndSFX/Music/Everyday Hero Title Music.mp3");
        speaker.Stream = newStream;
        speaker.Play();
    }
}
