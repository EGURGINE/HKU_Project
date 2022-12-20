using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private Rigidbody rb;
    void Update()
    {
        Move(); 
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * spd * Time.deltaTime;
        transform.Translate(new Vector3(x,0,0));
    }
}
