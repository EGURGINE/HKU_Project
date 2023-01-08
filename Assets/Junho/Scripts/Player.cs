using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private RaycastHit hit;
    [SerializeField] private float jumpPower;
    [SerializeField] private bool isJumped = false;
    void Update()
    {
        if (GameManager.Instance.isGameOver == true) return;
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * spd * Time.deltaTime;

        if (x > 0) spriteRenderer.flipX = false;
        else if(x < 0) spriteRenderer.flipX = true;

        //이동
        transform.Translate(new Vector3(x,0,0));

        

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false)
        {
            SoundManager.Instance.PlaySound(ESoundType.JUMP);

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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumped = true;
        }
    }
}
