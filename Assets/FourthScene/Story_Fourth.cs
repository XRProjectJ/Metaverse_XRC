using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Story_Fourth : MonoBehaviour
{
    [SerializeField] private Text txtStory;
    [SerializeField] private Button btnNext;
    [SerializeField] private GameObject shouldInvisible;
    [SerializeField] private GameObject QuizPanel;
    
    private List<string> story = new List<string>();
    private bool lamdaCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        QuizPanel.gameObject.SetActive(false);
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(checkStory);
        ReadFile("fourth_story_start"); // edit
        StartCoroutine(ReadStory());
        Debug.Log("Story Start");
    }

    // 텍스트 파일을 Resources 폴더에서 읽어들이기
    private void ReadFile(string fileName) // edit
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if (textAsset != null)
        {
            string[] storyLines = textAsset.text.Split('\n');
            for (int i = 0; i < storyLines.Length; i++)
            {
                story.Add(storyLines[i]);
            }
        }
        else
        {
            Debug.Log("파일 읽기 실패");
        }
    }

    private IEnumerator ReadStory()
    {
        for(int i=0; i <story.Count; i++)
        {
            txtStory.text = story[i];
            // 람다식 기억안나면 유튜브 시청: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile 은 true 가 될때 코드 실행을 재개
            yield return new WaitUntil(() => { return lamdaCondition; });
            lamdaCondition = false;
            
        }
        Debug.Log("Read Story");
        shouldInvisible.SetActive(false);
        QuizPanel.gameObject.SetActive(true);
    }

    private void checkStory()
    {
        lamdaCondition=true;
    }

}
