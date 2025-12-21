using Godot;
using System;

public partial class BackgroundNoise : Node2D
{
    public static BackgroundNoise Instance {get; private set;}
    //for background music
    AudioStreamPlayer musicSpeaker;

    //for sound effects
    AudioStreamPlayer scribbleOutput, crumpleOutput, shuffleOutput;
    bool isPlaying = false;
    double timer = 0.0;
    float masterVolumeValue = 50.0f;

    public override void _Ready()
    {
        musicSpeaker = (AudioStreamPlayer)GetNode("MusicStreamPlayer");
        scribbleOutput = (AudioStreamPlayer)GetNode("ScribbleSoundEffect");
        crumpleOutput = (AudioStreamPlayer)GetNode("PaperCrumpleSFX");
        shuffleOutput = (AudioStreamPlayer)GetNode("PaperShuffleSFX");
        Hide();
        Instance = this;
    }

    public override void _Process(double delta)     //SFX processing
    {
        if(Input.IsActionJustPressed("Interact") || Input.IsActionJustPressed("cancel") || Input.IsActionJustPressed("mouse_click"))
        {
            timer = 0.0;
            scribbleOutput.Play();
            isPlaying = true;
        }
        if (isPlaying)
        {
            timer += delta;
            if(timer > 0.5)
            {
                scribbleOutput.Stop();
            }
        }
    }

    public void NighttimeMusic()
    {
        AudioStream newStream = ResourceLoader.Load<AudioStream>("res://MusicAndSFX/Music/Everyday Hero - Night Loop.mp3");
        musicSpeaker.Stream = newStream;
        musicSpeaker.Play();
    }

    public void MainMusic()
    {
        AudioStream newStream = ResourceLoader.Load<AudioStream>("res://MusicAndSFX/Music/Everyday Hero Title Music.mp3");
        musicSpeaker.Stream = newStream;
        musicSpeaker.Play();
    }

    public void PaperCrumple()
    {
        crumpleOutput.Play();
    }

    public void PaperShuffle()
    {
        shuffleOutput.Play();
    }

    public void SetMusicValue(float newVal)
    {
        musicSpeaker.VolumeLinear = newVal / 100.0f * (masterVolumeValue / 100.0f);
    }

    public void SetSFXValue(float newVal)
    {
        scribbleOutput.VolumeLinear = newVal / 100.0f * (masterVolumeValue / 100.0f);
        crumpleOutput.VolumeLinear = newVal / 100.0f * (masterVolumeValue / 100.0f);
        shuffleOutput.VolumeLinear = newVal / 100.0f * (masterVolumeValue / 100.0f);
    }
    public void SetMasterVolume(float newVal)
    {
        masterVolumeValue = newVal;
        SetSFXValue(scribbleOutput.VolumeLinear * 100.0f);
        SetMusicValue(musicSpeaker.VolumeLinear * 100.0f);
    }
}
