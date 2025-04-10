using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public event Action ThingHappended;

    public void DoThing()
    {
        ThingHappended?.Invoke();
    }
}
public class Observer : MonoBehaviour
{
    [SerializeField] Subject subjectToObserve;

    void OnThinghappened()
    {
        //이벤트에 응답하는 로직
        Debug.Log("Observer Responds");
    }

    void Awake()
    {
        if(subjectToObserve != null)
        {
            subjectToObserve.ThingHappended += OnThinghappened;
        }   
    }

    void OnDestroy()
    {
        if(subjectToObserve != null)
        {
            subjectToObserve.ThingHappended -= OnThinghappened; //구독취소 안 하면 Observer가 사라질 때 에러
        }
    }
}
