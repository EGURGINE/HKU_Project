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
        Move();

        if (isJumped == false || isColisionGround == true) return;
        JumpCheck();
    }

    private void JumpCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * jumpDistance, Color.blue);
        if (Physics.Raycast(transform.position, Vector2.down, out hit, jumpDistance))
        {
            if (hit.collider.CompareTag("Ground"))
                isJumped = false;
        }
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * spd * Time.deltaTime;
        transform.Translate(new Vector3(x,0,0));
        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false && isColisionGround == true)
        {
            SoundManager.Instance.PlaySound(ESoundType.JUMP);

            isJumped = true;
            rb.AddForce(new Vector2(x * 0.9f , jumpPower), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isColisionGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isColisionGround = false;
        }
    }

}
