using UnityEngine;
using UnityEngine.UI;

public class ThrowError : MonoBehaviour
{
    public GameObject errorUI;
    public Text text;

    public static void BuildError(int error, Text errorNotification)
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
        switch(error)
        {
            case 0:
                errorUI.SetActive(false);
                text.text = "";
                break;
            case 1:
                errorUI.SetActive(true);
                text.text += "\n -Null Reference Exception: An object possably was not assigned in the inspector!" + errorInfo;
                Debug.LogError("Null Reference Exception: An object possably was not assigned in the inspector!" + errorInfo);
                break;
            case 2:
                errorUI.SetActive(true);
                text.text += "\n -Index Out Of Range: A variable is out of bounds of the array!" + errorInfo;
                Debug.LogError("Index Out Of Range: A variable is out of bounds of the array!" + errorInfo);
                break;
            case 3:
                errorUI.SetActive(true);
                text.text += "\n -A variable is out of range! " + errorInfo;
                Debug.LogError("A variable is out of range!" + errorInfo);
                break;
            case 4:
                errorUI.SetActive(true);
                text.text += "\n Congradulations: You Big Brain! You outsmart the computer. An unkown error has occured! " + errorInfo;
                Debug.LogError("Unkown error" + errorInfo);
                break;
            case 5:
                Application.ForceCrash(0);
                break;
        }
    }
}
