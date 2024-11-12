using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private EventType EventStatus;

    // ќбъ€вление состо€ний событий
    public enum EventType
    {
        None,
        Battle,
        PointOfInterest
    }

    public enum InterestsType
    {
        // “ипы точек интереса
    }
    // ѕроверка на существование экземпл€ра EventManager
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // ќбъ€вить выбранное событие
    public void TriggerEvent(EventType eventType)
    {
        switch (eventType)
        {
            case EventType.Battle:
                EventStatus = EventType.Battle;
                StartBattle();
                break;
            case EventType.PointOfInterest:
                EventStatus = EventType.PointOfInterest;
                ShowPointOfInterest();
                break;
        }
    }
    private static T GetRandomEnumValue<T>()
    {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(random.Next(values.Length));
    }
    // ќбъ€вить случайное событие
    public void TriggerRandomEvent()
    {
        TriggerEvent(GetRandomEnumValue<EventType>());
    }
    private void StartBattle()
    {
        // –еализаци€ сражени€
    }
    private void ShowPointOfInterest()
    {
        // –еализаци€ точки интереса
    }
    public void CloseEvent()
    {
        EventStatus = EventType.None;
    }
}
