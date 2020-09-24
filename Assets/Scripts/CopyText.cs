using System;
using UnityEngine;

public static class CopyText
{
    public static void CopyString(String text)
    {
        GUIUtility.systemCopyBuffer = text;
    }
}
