using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReadMe))]
[InitializeOnLoad]
public class ReadMeInspector : Editor
{
    private static float Spacing = 16f;

    protected override void OnHeaderGUI()
    {
        ReadMe Target = (ReadMe)target;

        Init();

        float LogoWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 3f - 20f, Target.Icon.width);

        GUILayout.BeginHorizontal("box");
        {
            GUILayout.Label(Target.Icon, GUILayout.Width(LogoWidth), GUILayout.Height(LogoWidth));
            GUILayout.BeginVertical();
            {
                GUILayout.Label(Target.Title.Replace("\\n", "\n"), TitleStyle);
                GUILayout.Label(Target.Subtitle.Replace("\\n", "\n"), SubtitleStyle);
                GUILayout.Label(Target.Description.Replace("\\n", "\n"), DescriptionStyle);
            }
            GUILayout.EndVertical();
        }

        GUILayout.EndHorizontal();
    }

    public override void OnInspectorGUI()
    {
        ReadMe Target = (ReadMe)target;

        Init();

        foreach (ReadMe.Section Section in Target.Sections)
        {
            float NewSpacing = Spacing;

            if (string.IsNullOrEmpty(Section.Title))
                NewSpacing = 6;

            GUILayout.Space(NewSpacing);

            if (!string.IsNullOrEmpty(Section.Title))
                GUILayout.Label(Section.Title.Replace("\\n", "\n"), HeadingStyle);

            if (!string.IsNullOrEmpty(Section.Description))
                GUILayout.Label(Section.Description.Replace("\\n", "\n"), BodyStyle);

            if (Section.Links != null)
            {
                for (int i = 0; i < Section.Links.Length; i++)
                {
                    if (!string.IsNullOrEmpty(Section.Links[i].Link))
                    {
                        if (LinkLabel(new GUIContent(Section.Links[i].Link)))
                        {
                            Application.OpenURL(Section.Links[i].Url);
                        }
                    }
                }
            }
        }
    }

    private bool Initialized;

    GUIStyle LinkStyle { get { return m_LinkStyle; } }
    [SerializeField] GUIStyle m_LinkStyle;

    GUIStyle TitleStyle { get { return m_TitleStyle; } }
    [SerializeField] GUIStyle m_TitleStyle;

    GUIStyle SubtitleStyle { get { return m_SubtitleStyle; } }
    [SerializeField] GUIStyle m_SubtitleStyle;

    GUIStyle DescriptionStyle { get { return m_DescriptionStyle; } }
    [SerializeField] GUIStyle m_DescriptionStyle;

    GUIStyle HeadingStyle { get { return m_HeadingStyle; } }
    [SerializeField] GUIStyle m_HeadingStyle;

    GUIStyle BodyStyle { get { return m_BodyStyle; } }
    [SerializeField] GUIStyle m_BodyStyle;

    private void Init()
    {
        if (Initialized)
            return;

        m_BodyStyle = new GUIStyle(EditorStyles.label);
        m_BodyStyle.fontSize = 14;
        m_BodyStyle.wordWrap = true;
        m_BodyStyle.richText = true;

        m_TitleStyle = new GUIStyle(m_BodyStyle);
        m_TitleStyle.fontSize = 24;

        m_SubtitleStyle = new GUIStyle(m_BodyStyle);
        m_SubtitleStyle.fontSize = 18;

        m_DescriptionStyle = new GUIStyle(m_BodyStyle);
        m_DescriptionStyle.fontSize = 14;

        m_HeadingStyle = new GUIStyle(m_BodyStyle);
        m_HeadingStyle.fontSize = 18;

        m_LinkStyle = new GUIStyle(m_BodyStyle);
        m_LinkStyle.wordWrap = false;

        m_LinkStyle.normal.textColor = Color.cyan;
        m_LinkStyle.stretchWidth = false;

        Initialized = true;
    }

    private bool LinkLabel(GUIContent label, params GUILayoutOption[] options)
    {
        Rect LabelPosition = GUILayoutUtility.GetRect(label, LinkStyle, options);

        Handles.BeginGUI();
        Handles.color = LinkStyle.normal.textColor;
        Handles.DrawLine(new Vector3(LabelPosition.xMin, LabelPosition.yMax), new Vector3(LabelPosition.xMax, LabelPosition.yMax));
        Handles.color = Color.white;
        Handles.EndGUI();

        EditorGUIUtility.AddCursorRect(LabelPosition, MouseCursor.Link);

        return GUI.Button(LabelPosition, label, LinkStyle);
    }
}