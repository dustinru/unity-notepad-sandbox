using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject theText;
    public GameObject thePanel;
    public GameObject adPanel;

    // Notepad buttons
    public void clearText()
    {
        theText.GetComponent<InputField>().text = "";
    }

    public void cancelButton()
    {
        thePanel.SetActive(false);
    }

    public void closeButton()
    {
        thePanel.SetActive(true);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void adPanelOpen()
    {
        adPanel.SetActive(true);
    }

    public void adPanelClose()
    {
        adPanel.SetActive(false);
    }
}
