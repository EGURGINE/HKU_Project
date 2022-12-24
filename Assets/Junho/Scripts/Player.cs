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
    private bool isJumped = false;
    void Update()
    {
        Move();

        if (isJumped == true) return;
        JumpCheck();
    }

    private void JumpCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * jumpDistance, Color.blue);
        if (Physics.Raycast(transform.position, Vector2.down, out hit, jumpDistance))
        {
            if (hit.collider.CompareTag("Ground") && isJumped == false)
                isJumped = false;
        }
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * spd * Time.deltaTime;
        transform.Translate(new Vector3(x,0,0));
        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false)
        {
            isJumped = true;
            rb.AddForce(new Vector2(x * 0.9f , jumpPower), ForceMode.Impulse);
        }
    }   

}
