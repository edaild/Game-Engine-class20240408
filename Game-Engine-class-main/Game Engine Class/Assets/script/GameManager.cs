using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임 오버 표시
    public Text timeText;       //생존 시간 표시
    public Text recordText;     // 최고 기록 표시

    private float surviveTime; //생존 시간
    private bool isGameover;    // 게임오버 상태

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }


    void Update()
    {
        // 게임 오버가 아닌 동안
        if(!isGameover)
        { 
                // 생존 시간 갱신
                surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 tiemTesxt 텍스트 컴퍼턴트를 이용해 표시 
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
        // 현제 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임 오버 텍스트 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전가지의 최고 기록 가져오기

        float bestTime = PlayerPrefs.GetFloat("BestTime");


        // 이전까의 최고 기록보다 현재 생존 시간이 더 크다며

        if(surviveTime > bestTime) 
        {
            // 최고 기록 값을 현재 생존 시간 값ㅇ으로 변경
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int) bestTime;

    }

}
