using System;
using UnityEngine;

public class ReadMe : ScriptableObject
{
    public Texture2D Icon;
    public string Title;
    public string Subtitle;
    public string Description;
    public Section[] Sections;

    [Serializable]
    public class Section
    {
        [Serializable]
        public class ExtraLink 
        {
            public string Link;
            public string Url;
        }

        public string Title, Description;
        public ExtraLink[] Links;
    }
}