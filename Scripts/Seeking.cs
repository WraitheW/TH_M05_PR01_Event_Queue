using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seeking : MonoBehaviour
{
    private bool m_IsQuitting;
    public Text text;

    void OnEnable()
    {
        EventBus.StartListening("Seek", Seek);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Seek", Seek);
        }
    }

    void Seek()
    {
        text.text = "Received a seek event : Seek and you will find";
        Debug.Log("Received a seek event : Seek and you will find");
    }
}
