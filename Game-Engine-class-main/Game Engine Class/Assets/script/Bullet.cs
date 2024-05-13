using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward*speed; // forward ũ�Ⱑ 1������ *8���ؼ� 8�谡�ȴ�.
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
         
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();
            // �������� ����  PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if(playerController != null )
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Sound();
                playerController.Die();
            }
        }
    }
}
