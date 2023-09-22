using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string text;
    public string name_display;
    public string path_word;

    public int sentence_type;
    public int word_id;

    public Image[] image;
    public Video[] video;
    public Audio[] audio;
    public AudioEffect[] audio_effect;
    public Gaf[] gaf;

    public SpineSt[] spine;
    public Animation[] animation;
    public Colors color;
    public FilterWord[] filter_word;
    public Phonic[] phonic;
    public ListNotGame[] list_not_game;
}

[System.Serializable]
public class Audio
{
    public string link;
    public string file_path;

    public int id;
    public int duration;
    public int voices_id;

    public SyncTexts[] sync_data;
}

[System.Serializable]
public class SyncTexts
{
    public string w;

    public int e;
    public int s;
    public int te;
    public int ts;
}

[System.Serializable]
public class Video
{

}

[System.Serializable]
public class Image
{

}

[System.Serializable]
public class AudioEffect
{

}

[System.Serializable]
public class Gaf
{

}

[System.Serializable]
public class SpineSt
{

}

[System.Serializable]
public class Animation
{

}

[System.Serializable]
public class Colors
{
    public string text;
    public string highlight;
}

[System.Serializable]
public class FilterWord
{

}

[System.Serializable]
public class Phonic
{

}

[System.Serializable]
public class ListNotGame
{

}
