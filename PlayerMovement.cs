using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int Speed = 10;
    int JumpHeight = 2;
    bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void MovePlayer()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime * Speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * Speed));
    }
    void Jump()
    {
        if (Grounded == true)
        {
            transform.Translate(new Vector3(0,JumpHeight, 0));
        }
        
    }
    void Sprint()
    {
        Speed = 20;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Grounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Speed = 10;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        MovePlayer();
    }
}
