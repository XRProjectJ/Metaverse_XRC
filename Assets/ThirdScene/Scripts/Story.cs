using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Story : MonoBehaviour
{
    [SerializeField] private Text txtStory;
    [SerializeField] private Button btnNext;
    [SerializeField] private GameObject spawnVirus;
    [SerializeField] private GameObject shouldInvisible;
    [SerializeField] private GameObject finalText;
    [SerializeField] private Text maximum;
    [SerializeField] private Image picture;
    [SerializeField] private string[] imageNames;

    private List<string> story = new List<string>();
    private bool lamdaCondition = false;
    private bool finalAchievement = false;

    public bool finalArrive
    {
        get
        {
            return finalAchievement;
        }
        set
        {
            finalAchievement = value;
            if(finalAchievement == true)
            {
                shouldInvisible.SetActive(false);
                finalText.SetActive(true);
/*                spawnVirus.SetActive(false);
                maximum.gameObject.SetActive(false);
                ReadFile(finalTxtPath);
                StartCoroutine(ReadStory(false));*/
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnVirus.SetActive(false);
        maximum.gameObject.SetActive(false);
        picture.gameObject.SetActive(false);
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(checkStory);
        ReadFile("third_story_start"); // edit
        StartCoroutine(ReadStory(true));
        
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
    private IEnumerator ReadStory(bool first)
    {
        int imgIdx = 0;
        for (int i=0; i <story.Count; i++)
        {
            string tmp = "";
            //tmp += story[i] + "\n";
            int j = i;
            while (true)
            {
                if (i >= story.Count || string.IsNullOrWhiteSpace(story[i]))
                {
                    break;
                }
                if (story[i].Trim().EndsWith("@")) // edit
                {
                    picture.gameObject.SetActive(true);
                    picture.sprite = Resources.Load<Sprite>(imageNames[imgIdx++]); //edit
                    Debug.Log("imagesIdx = " + imgIdx);
                    tmp += story[i].Substring(0, story[i].LastIndexOf('@')) + "\n";
                }
                else
                {
                    tmp += story[i] + "\n";
                }
                i++;
            }
            Debug.Log(tmp);
            txtStory.text = tmp;
            
            
            // 람다식 기억안나면 유튜브 시청: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile 은 true 가 될때 코드 실행을 재개
            yield return new WaitUntil(() => { return lamdaCondition; });
            lamdaCondition = false;

            
        }
        Debug.Log("Read Story");
        
        story.Clear();
        if (first)
        {
            picture.gameObject.SetActive(false);
            shouldInvisible.SetActive(false);
            spawnVirus.SetActive(true);
            maximum.gameObject.SetActive(true);
        }
    }
    private void checkStory()
    {
        lamdaCondition=true;
    }

}
