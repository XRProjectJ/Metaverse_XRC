using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TypingEffect : MonoBehaviour
{
    public Text tx; // Text UI 요소
    public string filePath; // 텍스트 파일 경로 (예: "Assets/Resources/first_story.txt") Resources.Load<TextAsset>("yourfile")
    private string m_text;

    // Start is called before the first frame update
    void Start()
    {
        // 텍스트 파일 읽기
        StartCoroutine(ReadTextFromFile("Assets/Resources/first_story.txt"));
    }

    // 텍스트 파일 읽기 코루틴
    IEnumerator ReadTextFromFile(string path)
    {
        // 파일 경로 확인
        if (File.Exists(path))
        {
            // 텍스트 파일 읽기
            m_text = File.ReadAllText(path);
            // 타이핑 효과 시작
            StartCoroutine(Typing());
        }
        else
        {
            Debug.LogError("텍스트 파일을 찾을 수 없습니다: " + path);
        }
        yield return null;
    }

    // 타이핑 효과 코루틴
    IEnumerator Typing()
    {
        yield return new WaitForSeconds(2f); // 시작 전 지연 시간

        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i); // 텍스트 부분적으로 설정
            yield return new WaitForSeconds(0.15f); // 타이핑 속도
        }
    }
}