using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainCameraMove : MonoBehaviour
{
    [SerializeField] private Image filled;
    [SerializeField] private Transform target;
    private Vector3 myTransform = new Vector3(0, 1, -10);

    [SerializeField] private bool isCameraMoving = false;
    private bool isUPBtn = false;
    private float cnt = 8;
    private float CNT
    {
        get { return cnt; }
        set
        {

            cnt = value;
            filled.fillAmount = cnt / coolTime;
        }
    }
    [SerializeField] private float coolTime;
    private void Update()
    {
        CNT += Time.deltaTime;
        if (cnt > coolTime)
        {
            CameraMove();
        }

        //카메라가 플레이어 따라가기
        if (isCameraMoving)
        {
            int upBtnCheck;
            upBtnCheck = isUPBtn ? 1 : -1;
            transform.DOMove(target.position + new Vector3(0, 6 * upBtnCheck, -10), 0.5f);
            transform.DORotate(new Vector3(10 * upBtnCheck, 0, 0), 0.5f);
        }
        else
        {
            transform.DOMove(target.transform.position + myTransform, 0.3f);
            transform.DORotate(Vector3.zero, 0.3f);
        }
    }
    private IEnumerator ResetCameraMove()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.SetIsCameraMoving(false);
        Camera.main.orthographic = true;
        isCameraMoving = false;
    }
    private void CameraMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUPBtn = true;
            CNT = 0;
            GameManager.Instance.SetIsCameraMoving(true);
            Camera.main.orthographic = false;
            isCameraMoving = true;
            transform.DORotate(new Vector3(10, 0, 0), 0.5f).OnComplete(() =>
           {
               StartCoroutine(ResetCameraMove());
           });
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isUPBtn = false;
            CNT = 0;
            GameManager.Instance.SetIsCameraMoving(true);
            Camera.main.orthographic = false;
            isCameraMoving = true;
            transform.DORotate(new Vector3(-6, 0, 0), 0.5f).OnComplete(() =>
            {
                StartCoroutine(ResetCameraMove());
            });
        }
    }
}
