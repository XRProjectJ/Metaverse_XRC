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

    // �ؽ�Ʈ ������ Resources �������� �о���̱�
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
            Debug.Log("���� �б� ����");
        }
    }

    private IEnumerator ReadStory()
    {
        for(int i=0; i <story.Count; i++)
        {
            txtStory.text = story[i];
            // ���ٽ� ���ȳ��� ��Ʃ�� ��û: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile �� true �� �ɶ� �ڵ� ������ �簳
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
