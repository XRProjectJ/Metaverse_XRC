using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //문제 패널
    public List<Question> quizList = new List<Question>(); // 퀴즈 문제 목록
    public Text quizText; //문제 text
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
            answers = new string[] { "가슴샘", "골수", "비장", "림프절" },
            correctAnswerIndex = 0
        });
        quizList.Add(new Question
        {
            questionText = "다음 중 백혈구의 종류가 아닌 것은?",
            answers = new string[] { "바나나", "사과", "오렌지", "포도" },
            correctAnswerIndex = 2
        });
        // 퀴즈 추가 예정
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
            answerButtons[i].GetComponentInChildren<Text>().text = q.answers[i];
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
        quizScoureText.text = $"{quizScore}/{quizList.Count}";
        answerPanel.SetActive(false);
    }


    // Text의 내용을 변경
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
