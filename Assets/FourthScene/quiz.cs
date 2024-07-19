using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //���� �г�
    public List<Question> quizList = new List<Question>(); // ���� ���� ���
    public Text quizText; //���� text
    private string uiStr; // �ڸ��� �� ����
    private int quizScore = 0; //����� ��������
    public Text quizScoureText; 
    private int quizNum = 0; // ���� ���� ��ȣ

    public GameObject answerPanel; //�� �г�
    public GameObject IncorrectORCorrectPanel;
    public GameObject IncorrectText;
    public GameObject CorrectText;
    private bool isAnswerCorrect = false;
    private bool nextStep = false;

    public Button[] answerButtons; // ���� ��ư��


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
        StartCoroutine(StartQuiz()); // ��ȭ ���� �ڷ�ƾ ȣ��
        IncorrectORCorrectPanel.SetActive(false);
        answerPanel.SetActive(true);
        foreach (Button btn in answerButtons)
        {
            btn.onClick.AddListener(() => OnAnswerButtonClicked(btn));
        }

    }

    // ���� �ε�
    private void LoadQuestions()
    {
        //���� ����
        quizList.Add(new Question
        {
            questionText = "�������� ��𿡼� ����������?",
            answers = new string[] { "������", "���", "����", "������" },
            correctAnswerIndex = 0
        });
        quizList.Add(new Question
        {
            questionText = "���� �� �������� ������ �ƴ� ����?",
            answers = new string[] { "�ٳ���", "���", "������", "����" },
            correctAnswerIndex = 2
        });
        // ���� �߰� ����
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


    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
