using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;
    private Queue<string> eventQueue;
    public int eventsInQueue;
    private bool queueCondition = false;

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
        if (Instance.eventQueue == null)
        {
            Instance.eventQueue = new Queue<string>();
        }
    }

    public static void addToQueue(string eventName)
    {
        Instance.eventQueue.Enqueue(eventName);
        Instance.eventsInQueue++;
    }

    public IEnumerator runEvents()
    {
        yield return new WaitForSeconds(2);

        while (eventsInQueue > 0)
        {
            TriggerEvent(Instance.eventQueue.Dequeue());
            Instance.eventsInQueue--;
            yield return new WaitForSeconds(2);
        }
        queueCondition = false;
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    void Update()
    {
        if (queueCondition == false && eventsInQueue > 0)
        {
            StartCoroutine("runEvents");
            queueCondition = true;
        }
    }
}
