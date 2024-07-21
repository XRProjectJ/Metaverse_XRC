using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //���� �г�
    public List<Question> quizList = new List<Question>(); // ���� ���� ���
    public Text quizText; //���� text
    public Image quizImage; //���� Image
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
        public Sprite questionImage;
        public bool isOXQuestion; // OX ���� ����
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
            answers = new string[] { "������", "�����", "����", "������" },
            correctAnswerIndex = 0,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "�������� ������ ��� 12-20���̴�.",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 0,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "���� �� �������� ������ �ƴ� ����?",
            answers = new string[] { "ȣ�߱�", "���ٱ�", "������", "������" },
            correctAnswerIndex = 2,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "�������� ������ �ƴ� ���� ���ÿ�.",
            answers = new string[] { "�鿪 ����", "��� ���", "���� ����", "���̷��� ����" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "�������� ���̷����� �����Ѵ� (O/X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "�������� [   ]������� ���̷����� �����Ѵ�. ��ĭ�� �� ����?",
            answers = new string[] { "�ݻ� ����", "��� �ۿ�", "�ڸ� �ۿ�", "�ı� �ۿ�" },
            correctAnswerIndex = 3,
            questionImage = null,
            isOXQuestion = false
        });
        quizList.Add(new Question
        {
            questionText = "�������� ��� �Ͼ���̴�(O,X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "�鿪������ �������� �����ϴ� �����̴�(O,X)",
            answers = new string[] { "O", "X" },
            correctAnswerIndex = 1,
            questionImage = null,
            isOXQuestion = true
        });
        quizList.Add(new Question
        {
            questionText = "�׿�-��ü ������ �������� ���� ���� ����?",
            answers = new string[] { "��ü�� Ư�� �׿��� �����Ѵ�", "��ü�� ���� �׿��� ������ �� �ִ�", "�׿��� �鿪 ������ ������ �� �ִ�", "��ü�� �鿪 ������ �Ϻ��̴�" },
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
        quizScoureText.text = $"���� ���� : {quizScore}/{quizList.Count}";
        answerPanel.SetActive(false);

        if (quizScore >= quizList.Count * 0.8f)
        {
            quizText.text = $"�Ǹ��ؿ�! �̹� ���� ������ �������� ���ؼ� �� �����߾��!";
        }
        else if (quizScore >= quizList.Count * 0.5f)
        {
            quizText.text = $"���߾��!\n Ʋ�� ������ ���ؼ� �����ϸ鼭 �Ϻ��� �����غ��� ��õ�ؿ�.";
        }
        else
        {
            quizText.text = $"������ �� ���� �� �־��!\n ���α׷��� �ٽ� �����ϸ鼭 õõ�� �н��غ���.";
        }



    }


    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
