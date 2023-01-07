using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ObstacleVowel : MonoBehaviour
{
    public enum EObstacle
    {
        Obstacle2,
        Obstacle3,
        Obstacle4,
        Obstacle6,
        ObstacleRange2,
        ObstacleRange6,
    }
    public EObstacle eObstacle;
    [SerializeField] GameObject obstacle2;
    [SerializeField] GameObject obstacleStop;

    void Start()
    {
        switch (eObstacle)
        {
            case EObstacle.Obstacle4:
                transform.DOLocalMoveX(4, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (eObstacle)
            {
                case EObstacle.ObstacleRange2:
                    obstacle2.transform.DOLocalMoveY(0.52f, 0.5f).SetEase(Ease.Linear);
                    break;

                case EObstacle.ObstacleRange6:
                    obstacleStop.transform.DOLocalMoveY(15, 0.5f).SetEase(Ease.Linear);
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            switch (eObstacle)
            {
                case EObstacle.Obstacle2:
                    Die();
                    break;

                case EObstacle.Obstacle3:
                    Die();
                    break;

                case EObstacle.Obstacle4:
                    Die();
                    break;

                case EObstacle.Obstacle6:
                    Die();
                    break;
            }
        }
    }

    void Die()
    {
        Debug.Log("Die");
        GameManager.Instance.isGameOver = true;
        StartCoroutine(ReLoadScene());
    }

    IEnumerator ReLoadScene()
    {
        yield return new WaitForSeconds(1f);
        print("load");

        DOTween.KillAll();
        SceneManager.LoadScene("Game 1");
    }
}
