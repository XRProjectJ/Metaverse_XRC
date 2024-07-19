using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //문제 패널
    public Text quizText; //문제 text
    private string uiStr; // 자막에 들어갈 내용
    private int quizNum = 0; //퀴즈번호 기준이 되는 변수
    private int quizScore = 0; //사용자 퀴즈점수

    public GameObject answerPanel; //답 패널
    public Button answerButton1; // 정답 버튼1public Button answerButton; // 정답 버튼
    public bool quiz1 = false;
    private bool nextStep1 = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartQuiz()); // 대화 시작 코루틴 호출
        answerPanel.SetActive(false);
        answerButton1.onClick.AddListener(OnAnswerButtonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartQuiz()
    {
        yield return new WaitUntil(() => nextStep1); // 사용자가 버튼을 누를 때까지 대기
        // 퀴즈1의 정답 여부를 확인하고 메시지를 출력
        
        if (quiz1)
        {
            Debug.Log("정답!");
            uiStr = "정답이야! 백혈구는 가슴샘에서 만들어져.";
            setText(quizText, uiStr);
            quizScore++;
        }

    }

    public void answer1()
    {
        quiz1 = true;
    }
    public void OnAnswerButtonClicked()
    {
        answer1();
        nextStep1 = true; // 다음으로 넘어갈 수 있도록 플래그 설정
    }

    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
