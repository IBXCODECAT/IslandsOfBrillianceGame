using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThrowError : MonoBehaviour
{
    public GameObject errorUI;
    public TextMeshProUGUI text;

    public void BuildError(int error, Text errorNotification)
    {
        switch (error)
        {
            case 0:
                errorNotification.text = "";
                break;
            case 1:
                errorNotification.text += "\n- Space already occupied";
                break;
            case 2:
                errorNotification.text += "\n- Slope too steep";
                break;
            case 3:
                errorNotification.text += "\n -Exceeds limits of the building area";
                break;
            case 4:
                errorNotification.text += "\n -";
                break;
        }
    }

    public void Error(int error, string errorInfo)
    {
        text.text = "";

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        switch(error)
        {
            case 0:
                errorUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                text.text = "";
                break;
            case 1:
                errorUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text += " -Null Reference Exception: An object possably was not assigned in the inspector! \n" + errorInfo;
                Debug.LogError("Null Reference Exception: An object possably was not assigned in the inspector!" + errorInfo);
                break;
            case 2:
                errorUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text += "-Index Out Of Range: A variable is out of bounds of the array! \n" + errorInfo;
                Debug.LogError("Index Out Of Range: A variable is out of bounds of the array!" + errorInfo);
                break;
            case 3:
                errorUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text += "-A variable is out of range! \n" + errorInfo;
                Debug.LogError("A variable is out of range!" + errorInfo);
                break;
            case 4:
                errorUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.text += "\n Congradulations: You Big Brain! You outsmart the computer. An unkown error has occured! \n " + errorInfo;
                Debug.LogError("Unkown error" + errorInfo);
                break;
            case 5:
                UnityEngine.Diagnostics.Utils.ForceCrash(0);
                break;
        }
    }

    public void CopyTextToClipboard()
    {
        CopyText.CopyString(text.text);
    }

    public void ClosePopup()
    {
        errorUI.SetActive(false);
    }
}
