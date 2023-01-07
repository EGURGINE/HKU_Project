using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private Rigidbody rb;


    private RaycastHit hit;
    [SerializeField] private float jumpDistance;
    [SerializeField] private float jumpPower;
    [SerializeField] private bool isJumped = false;
    [SerializeField] private bool isColisionGround = false;
    void Update()
    {
        if (GameManager.Instance.isGameOver == true) return;
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * spd * Time.deltaTime;


        //이동
        transform.Translate(new Vector3(x,0,0));

        

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false)
        {
            SoundManager.Instance.PlaySound(ESoundType.JUMP);

            isJumped = true;
            rb.AddForce(new Vector2(x, jumpPower), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumped = false;
        }
    }
}
