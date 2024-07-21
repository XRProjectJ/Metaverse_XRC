using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //문제 패널
    public List<Question> quizList = new List<Question>(); // 퀴즈 문제 목록
    public Text quizText; //문제 text
    public Image quizImage; //문제 Image
    private string uiStr; // 자막에 들어갈 내용
    private int quizScore = 0; //사용자 퀴즈점수
    public Text quizScoureText; 
    private int quizNum = 0; // 현재 퀴즈 번호

    public GameObject answerPanel; //답 패널
    public GameObject IncorrectORCorrectPanel;
    public GameObject IncorrectText;
    public GameObject CorrectText;
    private bool isAnswerCorrect = false;
    private bool nextStep = false;

    public Button[] answerButtons; // 정답 버튼들


    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
        public Sprite questionImage;
        public bool isOXQuestion; // OX 퀴즈 여부
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadQuestions();
        quizScoureText.text = $"{quizScore}/{quizList.Count}";
        StartCoroutine(StartQuiz()); // 대화 시작 코루틴 호출
        IncorrectORCorrectPanel.SetActive(false);
        answerPanel.SetActive(true);
        foreach (Button btn in answerButtons)
        {
            btn.onClick.AddListener(() => OnAnswerButtonClicked(btn));
        }

    }

    // 문제 로드
    private void LoadQuestions()
    {
        //퀴즈 문제
        quizList.Add(new Question
        {
            questionText = "백혈구는 어디에서 만들어질까요?",
            answers = new string[] { "가슴샘", "갑상샘", "비장", "림프절" },
            correctAnswerIndex = 0,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "백혈구의 수명은 평균 12-20일이다.",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 0,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "다음 중 백혈구의 종류가 아닌 것은?",
            answers = new string[] { "호중구", "단핵구", "적혈구", "림프구" },
            correctAnswerIndex = 2,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "백혈구의 역할이 아닌 것을 고르시오.",
            answers = new string[] { "면역 반응", "산소 운반", "세균 제거", "바이러스 제거" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "백혈구는 바이러스만 제거한다 (O/X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "백혈구는 [   ]방식으로 바이러스를 제거한다. 빈칸에 들어갈 말은?",
            answers = new string[] { "반사 반응", "향균 작용", "박멸 작용", "식균 작용" },
            correctAnswerIndex = 3,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "백혈구는 모두 하얀색이다(O,X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "면역반응은 백혈구만 참여하는 반응이다(O,X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "항원-항체 반응의 설명으로 옳지 않은 것은?",
            answers = new string[] { "항체는 특정 항원에 결합한다", "항체는 여러 항원에 결합할 수 있다", "항원은 면역 반응을 유발할 수 있다", "항체는 면역 반응의 일부이다" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = false
        });
    }



    IEnumerator StartQuiz()
    {
        while (quizNum < quizList.Count)
        {
            DisplayQuestion(quizNum);
            yield return new WaitUntil(() => nextStep);
            DisplayResult();
            yield return new WaitForSeconds(2f);
            IncorrectORCorrectPanel.SetActive(false);
            nextStep = false;
            quizNum++;
        }

        EndQuiz();
    }

    private void DisplayQuestion(int index)
    {
        Question q = quizList[index];
        quizText.text = q.questionText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(i < q.answers.Length);
            if (i < q.answers.Length)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = q.answers[i];
            }
        }
    }

    private void DisplayResult()
    {
        IncorrectORCorrectPanel.SetActive(true);
        if (isAnswerCorrect)
        {
            CorrectText.SetActive(true);
            IncorrectText.SetActive(false);
            quizScore++;
        }
        else
        {
            CorrectText.SetActive(false);
            IncorrectText.SetActive(true);
        }
        quizScoureText.text = $"{quizScore}/{quizList.Count}";
    }

    public void OnAnswerButtonClicked(Button btn)
    {
        int index = System.Array.IndexOf(answerButtons, btn);
        isAnswerCorrect = (index == quizList[quizNum].correctAnswerIndex);
        nextStep = true;
    }

    private void EndQuiz()
    {
        quizScoureText.text = $"최종 점수 : {quizScore}/{quizList.Count}";
        answerPanel.SetActive(false);

        if (quizScore >= quizList.Count * 0.8f)
        {
            quizText.text = $"훌륭해요! 이번 수업 주제인 백혈구에 대해서 잘 이해했어요!";
        }
        else if (quizScore >= quizList.Count * 0.5f)
        {
            quizText.text = $"잘했어요!\n 틀린 문제에 대해서 복습하면서 완벽히 이해해보길 추천해요.";
        }
        else
        {
            quizText.text = $"다음에 더 잘할 수 있어요!\n 프로그램을 다시 실행하면서 천천히 학습해봐요.";
        }



    }


    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
