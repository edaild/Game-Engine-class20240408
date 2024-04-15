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
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn;   

    void Start()
    {
            timeAfterSpawn = 0f;                                //timeterSpawn 0���� �ʱ�ȭ
            spawnRate= Random.Range(spawnRateMin, spawnRateMax);    //spawnRate �ּҿ� �ִ� ���� �� ����
            target = FindObjectOfType<PlayerController>().transform; // PlayerController transform ����
    }
    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn > spawnRate)
        {
            // ������ źȯ �߻� ���� �ð��� 0���� ������
            timeAfterSpawn = 0;

            // źȯ�� ������ �ϰ�, ĳ����(target)�� �ٶ󺸵��� ���� ��ȯ
            GameObject bullet = Instantiate(bulltePrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            // ���� źȯ ���� �ֱ� ��(spawnRate�� �ּ�(0.5��) �ִ�(3.0��) �������� ���� ������ �����۾� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}


