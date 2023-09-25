using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Page
{ 
    public string highlight_color;
    public string normal_color;
    public string box_type;

    public int line_height;
    public int fontsize;

    public PageImage[] image;
    public Texts[] text;
    public BackgroudImg bg_img;
}

[System.Serializable]
public class PageImage 
{
    public string position;
    public string contentsize;
    public string type;
    public string sequence;
    public string animation_type;

    public int star_order;
    public int z_order;
    public int animation_order;
    public int word_id;
    
    public bool touchable;
    public bool animation_reset;
    public bool repeat_animation;
    
    public Touch[] touch;
}

[System.Serializable]
public class Texts 
{
    public string boundingbox;

    public int word_id;

    public ConfigImage[] config_image;
    public ConfigAudio[] config_audio;
}

[System.Serializable]
public class BackgroudImg 
{
    
}

[System.Serializable]
public class ConfigImage
{
    
}

[System.Serializable]
public class ConfigAudio
{
    
}

[System.Serializable]
public class Touch 
{
    public string star_position;
    public string boundingbox;
    public string[] vertices;
}