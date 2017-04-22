using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


namespace Netaphous.Utilities
{
    public class EventManager : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> eventDictionary;

        private static EventManager eventManager;

        public static EventManager instance
        {
            get
            {
                if (eventManager == null)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }

                return eventManager;
            }
        }

        void Awake()
        {
            if (eventManager != null)
            {
                Destroy(this);
            }
            else
            {
                eventManager = this;
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
            DontDestroyOnLoad(eventManager);
        }


        void Init()
        {
            DontDestroyOnLoad(instance);
        }

        private static UnityEvent thisEvent;
        public static void StartListening(string eventName, UnityAction listener)
        {
            thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (eventManager == null) return;
            thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(string eventName)
        {
            thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}