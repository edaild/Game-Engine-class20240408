using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulltePrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn;   

    void Start()
    {
            timeAfterSpawn = 0f;                                //timeterSpawn 0으로 초기화
            spawnRate= Random.Range(spawnRateMin, spawnRateMax);    //spawnRate 최소와 최대 사이 값 지정
            target = FindObjectOfType<PlayerController>().transform; // PlayerController transform 적용
    }
    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn > spawnRate)
        {
            // 마지막 탄환 발사 이후 시간을 0을로 돌리고
            timeAfterSpawn = 0;

            // 탄환을 생성함 하고, 캐릭터(target)을 바라보도록 방향 전환
            GameObject bullet = Instantiate(bulltePrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // 다음 탄환 생성 주기 값(spawnRate를 최소(0.5초) 최대(3.0초) 범위에서 랜덤 값으로 결정작업 진행
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}


