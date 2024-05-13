using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward*speed; // forward 크기가 1일지만 *8을해서 8배가된다.
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
         
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            // 상대방으로 부터  PlayerController 컴포넌트를 가져오는 데 성공했다면
            if(playerController != null )
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Sound();
                playerController.Die();
            }
        }
    }
}
