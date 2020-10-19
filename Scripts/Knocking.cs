using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knocking : MonoBehaviour
{
    private bool m_IsQuitting;
    public Text text;

    void OnEnable()
    {
        EventBus.StartListening("Knock", Knock);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Knock", Knock);
        }
    }

    void Knock()
    {
        text.text = "Received a knock event : Knock and the door will be opened to you";
        Debug.Log("Received a knock event : Knock and the door will be opened to you");
    }
}
