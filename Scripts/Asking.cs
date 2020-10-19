using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asking : MonoBehaviour
{
    private bool m_IsQuitting;
    public Text text;

    void OnEnable()
    {
        EventBus.StartListening("Ask", Ask);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Ask", Ask);
        }
    }

    void Ask()
    {
        text.text = "Received an ask event : Ask and it will be given to you";
        Debug.Log("Received an ask event : Ask and it will be given to you");
    }
}
