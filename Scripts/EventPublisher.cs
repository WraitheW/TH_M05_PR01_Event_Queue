using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPublisher : MonoBehaviour
{

    public Text text;

    void Start()
    {
        Queue<EventBus> ev = new Queue<EventBus>();
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            EventBus.TriggerEvent("Ask");
        }

        if (Input.GetKeyDown("s"))
        {
            EventBus.TriggerEvent("Seek");
        }

        if (Input.GetKeyDown("k"))
        {
            EventBus.TriggerEvent("Knock");
        }

        if (Input.GetKeyDown("f"))
        {
            EventBus.TriggerEvent("Fire");
        }

        if (Input.GetKeyDown("l"))
        {
            EventBus.addToQueue("Launch");
        }

        text.text = "Events in queue: " + EventBus.Instance.eventsInQueue;
    }
}
