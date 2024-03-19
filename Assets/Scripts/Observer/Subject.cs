using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public static List<IObserver> Observers = new();

    public static void Register(IObserver observer)
    {
        Observers.Add(observer);
    }

    public static void UnRegister(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public static void Notify(string key)
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify(key);
        }
    }
}
