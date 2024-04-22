using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���� ���� ǥ��
    public Text timeText;       //���� �ð� ǥ��
    public Text recordText;     // �ְ� ��� ǥ��

    private float surviveTime; //���� �ð�
    private bool isGameover;    // ���ӿ��� ����

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }


    void Update()
    {
        // ���� ������ �ƴ� ����
        if(!isGameover)
        { 
                // ���� �ð� ����
                surviveTime += Time.deltaTime;
            //������ ���� �ð��� tiemTesxt �ؽ�Ʈ ������Ʈ�� �̿��� ǥ�� 
            timeText.text = "time : " + (int)surviveTime;
        }
        else
        {
            gameoverText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene("20240408");
            }
        }
    }

    public void EndGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���� ���� �ؽ�Ʈ ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������

        float bestTime = PlayerPrefs.GetFloat("BestTime");


        // �������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�

        if(surviveTime > bestTime) 
        {
            // �ְ� ��� ���� ���� ���� �ð� �������� ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int) bestTime;

    }

}
