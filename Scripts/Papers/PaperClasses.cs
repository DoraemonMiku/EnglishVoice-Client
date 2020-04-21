using System.Collections.Generic;

[System.Serializable]
/// <summary>
/// 所有试卷
/// </summary>
public class AllPaper
{
    public int code;
    public string msg;
    public List<ClassPaper> data;
}

[System.Serializable]
/// <summary>
/// 一张试卷
/// </summary>
public class APaper
{
    public int code;
    public string msg;
    public ClassPaper data;
}

[System.Serializable]
/// <summary>
/// 试卷的类
/// </summary>
public class ClassPaper
{
    //头部信息
    public int id;
    public string name;
    public string type;
    public int mode;
    public string config;

    //主要信息
    public string key;
    public string path;
    public string parta_video_name;
    public string parta_text;

    public string partb_video_name;
    public string partb_text_scene;
    public string partb_text_question;
    //ka
    public string partb_audio_anser;
    public string partb_audio_ask;

    public string partb_keyword_question;
    public string partb_keyword_anser;

    public string partc_story;

    public string partc_audio_name;
    public string partc_keyword_story;
}

