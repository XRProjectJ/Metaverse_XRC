using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizContent : MonoBehaviour
{
    public GameObject quizStartPanel; //���� ���� �г�
    public GameObject quizPanel; //���� ���� �г�
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
