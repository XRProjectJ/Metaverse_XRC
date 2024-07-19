using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizContent : MonoBehaviour
{
    public GameObject quizStartPanel; //문제 시작 패널
    public GameObject quizPanel; //문제 내용 패널
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quizStartPanel.SetActive(true);
        quizPanel.SetActive(false);
    }

    public void SetQuizCanvas()
    {
        quizStartPanel.SetActive(false);
        quizPanel.SetActive(true);
    }


}
