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

        while (quizNum < 4) // 설명 텍스트가 더 이상 없을 때까지 반복
        {
            setExplainUI();
            yield return new WaitForSeconds(3f); // 3초 대기
            quizNum++; // 다음 텍스트로 넘어감
        }
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
    public void setExplainUI()
    {

        if (quizNum == 0)
        {
            uiStr = "백혈구가 되어서 면역반응, 식균작용에 대해서 체험해봤지?";
            setText(quizText, uiStr);
        }

        if (quizNum == 1)
        {
            uiStr = "그럼 이제 체험한 내용에 대한 퀴즈를 풀어볼거야";
            setText(quizText, uiStr);
        }

        if (quizNum == 2)
        {
            uiStr = "체험을 집중해서 했다면 다 맞출 수 있는 문제들이니까 잘 풀어봐!";
            setText(quizText, uiStr);
        }

        if (quizNum == 3)
        {
            uiStr = "Q1. 백혈구는 어디서 생성되나요?";
            setText(quizText, uiStr);
            answerPanel.SetActive(true);
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
