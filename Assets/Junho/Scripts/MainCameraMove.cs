using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 myTransform = new Vector3(0, 1, -10);

    private void Update()
    {
        CameraMove();
        CameraCheck();
    }

    private void CameraMove()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float y = Input.GetAxis("VerticalArrow");
            Camera.main.orthographic = false;
            transform.DOMove(target.position + new Vector3(0, y * 6, -10), 0.5f);
            transform.DORotate(new Vector3(10 * y, 0, 0), 0.5f);
        }
        else
        {
            Camera.main.orthographic = true;
            transform.DOMove(target.transform.position + myTransform , 0.3f);
            transform.DORotate(Vector3.zero , 0.3f);

        }
    }
    private void CameraCheck()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameManager.Instance.SetIsCameraMoving(true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            GameManager.Instance.SetIsCameraMoving(false);

        }
    }
}
