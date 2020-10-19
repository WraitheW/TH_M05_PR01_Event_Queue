using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    private bool m_IsQuitting;
    public Text text;

    void OnEnable()
    {
        EventBus.StartListening("Fire", Fire);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Fire", Fire);
        }
    }

    void Fire()
    {
        text.text = "Received a fire event : firing cannon!";
        Debug.Log("Received a fire event : firing cannon!");
    }
}
