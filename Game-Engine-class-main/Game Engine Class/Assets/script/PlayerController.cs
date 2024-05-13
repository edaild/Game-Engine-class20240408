using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float speed = 8f;

    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
       playerRigidBody = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
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

    public void Sound()
    {
        playerAudio.Play();
    }

    public void Die() // ���� ������Ʈ�� ��Ȱ��ȭ �ȴ�.
    {
   
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManger Ÿ���� ������Ʈ�� ã�� ��������
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        //������ GameManger ������Ʈ�� EndGame() �޼�Ʈ�� ã�Ƽ� ����
        gameManager.EndGame();
    }
}
