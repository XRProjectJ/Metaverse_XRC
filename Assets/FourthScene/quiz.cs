using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    public GameObject quizPanel; //���� �г�
    public Text quizText; //���� text
    private string uiStr; // �ڸ��� �� ����
    private int quizNum = 0; //�����ȣ ������ �Ǵ� ����
    private int quizScore = 0; //����� ��������

    public GameObject answerPanel; //�� �г�
    public Button answerButton1; // ���� ��ư1public Button answerButton; // ���� ��ư
    public bool quiz1 = false;
    private bool nextStep1 = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartQuiz()); // ��ȭ ���� �ڷ�ƾ ȣ��
        answerPanel.SetActive(false);
        answerButton1.onClick.AddListener(OnAnswerButtonClicked);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartQuiz()
    {
        yield return new WaitUntil(() => nextStep1); // ����ڰ� ��ư�� ���� ������ ���
        // ����1�� ���� ���θ� Ȯ���ϰ� �޽����� ���
        
        if (quiz1)
        {
            Debug.Log("����!");
            uiStr = "�����̾�! �������� ���������� �������.";
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
        nextStep1 = true; // �������� �Ѿ �� �ֵ��� �÷��� ����
    }

    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
