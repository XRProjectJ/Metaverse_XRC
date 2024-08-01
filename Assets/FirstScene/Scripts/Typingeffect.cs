using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TypingEffect : MonoBehaviour
{
    public Text tx; // Text UI ���
    public string filePath; // �ؽ�Ʈ ���� ��� (��: "Assets/Resources/first_story.txt") Resources.Load<TextAsset>("yourfile")
    private string m_text;

    // Start is called before the first frame update
    void Start()
    {
        // �ؽ�Ʈ ���� �б�
        StartCoroutine(ReadTextFromFile("Assets/Resources/first_story.txt"));
    }

    // �ؽ�Ʈ ���� �б� �ڷ�ƾ
    IEnumerator ReadTextFromFile(string path)
    {
        // ���� ��� Ȯ��
        if (File.Exists(path))
        {
            // �ؽ�Ʈ ���� �б�
            m_text = File.ReadAllText(path);
            // Ÿ���� ȿ�� ����
            StartCoroutine(Typing());
        }
        else
        {
            Debug.LogError("�ؽ�Ʈ ������ ã�� �� �����ϴ�: " + path);
        }
        yield return null;
    }

    // Ÿ���� ȿ�� �ڷ�ƾ
    IEnumerator Typing()
    {
        yield return new WaitForSeconds(2f); // ���� �� ���� �ð�

        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i); // �ؽ�Ʈ �κ������� ����
            yield return new WaitForSeconds(0.15f); // Ÿ���� �ӵ�
        }
    }
}