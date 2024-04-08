using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
       playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidBody.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidBody.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.AddForce(speed, 0,0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.AddForce(-speed, 0, 0);
        }   
        */
        
        float xinput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xinput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidBody.velocity = newVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "feld1")
        {
            
            print("필드 1 입니다.");
        }
    }


    public void Die() // 게임 오브젝트가 비활성화 된다.
    {
        gameObject.SetActive(false);
    }
}
