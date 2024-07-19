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

        while (quizNum < 4) // ���� �ؽ�Ʈ�� �� �̻� ���� ������ �ݺ�
        {
            setExplainUI();
            yield return new WaitForSeconds(3f); // 3�� ���
            quizNum++; // ���� �ؽ�Ʈ�� �Ѿ
        }
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
    public void setExplainUI()
    {

        if (quizNum == 0)
        {
            uiStr = "�������� �Ǿ �鿪����, �ı��ۿ뿡 ���ؼ� ü���غ���?";
            setText(quizText, uiStr);
        }

        if (quizNum == 1)
        {
            uiStr = "�׷� ���� ü���� ���뿡 ���� ��� Ǯ��ž�";
            setText(quizText, uiStr);
        }

        if (quizNum == 2)
        {
            uiStr = "ü���� �����ؼ� �ߴٸ� �� ���� �� �ִ� �������̴ϱ� �� Ǯ���!";
            setText(quizText, uiStr);
        }

        if (quizNum == 3)
        {
            uiStr = "Q1. �������� ��� �����ǳ���?";
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
        nextStep1 = true; // �������� �Ѿ �� �ֵ��� �÷��� ����
    }

    // Text�� ������ ����
    private void setText(Text text, string str)
    {
        text.text = str;
    }
}
