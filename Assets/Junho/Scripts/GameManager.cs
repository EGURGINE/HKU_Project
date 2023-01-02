using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ObserverPattern.ObserverManager ObserverManager;

    public bool isCameraMoving;


    public void SetIsCameraMoving(bool type)
    {
        print("dd");
        isCameraMoving = type;
        ObserverManager.NotifyObservers();
    }
}
