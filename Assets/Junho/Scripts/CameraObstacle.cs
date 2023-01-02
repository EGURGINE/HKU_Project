using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class CameraObstacle : MonoBehaviour, ObserverPattern.IObserver
{
    [SerializeField] private float value;

    private void Start()
    {
        GameManager.Instance.ObserverManager.ResisterObserver(this);
    }


    public void MoveObj()
    {
        if (GameManager.Instance.isCameraMoving == true)
        {
            transform.DOMoveZ(value, 0.5f);
        }
        else
        {
            transform.DOMoveZ(0, 0.5f);
        }
    }
}
