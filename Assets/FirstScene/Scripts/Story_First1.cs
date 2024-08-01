using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Story_First1 : MonoBehaviour
{
    [SerializeField] private Text txtStory;
    [SerializeField] private Button btnNext;
    [SerializeField] private GameObject shouldInvisible;
    [SerializeField] private Image picture;
    [SerializeField] private Sprite[] images;

    private List<string> story = new List<string>();
    private string txtPath = "Assets/FisrtScene/storyText_first.txt";
    private string finalTxtPath = "Assets/FisrtScene/storyText_first.txt";
    private bool lamdaCondition = false;
    private bool finalAchievement = false;

    // Start is called before the first frame update
    void Start()
    {
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(checkStory);
        ReadFile(txtPath);
        StartCoroutine(ReadStory(true));
        
        Debug.Log("Story Start");
    }
    // 텍스트 파일을 파일 위치로 읽어들이기
    private void ReadFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                string[] storyLines = File.ReadAllLines(path);
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
        catch (IOException e)
        {
            Debug.LogError(e.Message);
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
                if (story[i][story[i].Length-1] == '@')
                {
                    picture.gameObject.SetActive(true);
                    picture.sprite = images[imgIdx++];
                    Debug.Log("imagesIdx = " + imgIdx);
                }
                tmp += story[i].TrimEnd('@') + "\n";
                i++;
            }
            Debug.Log(tmp);
            txtStory.text = tmp;
            
            
            // 람다식 기억안나면 유튜브 시청: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile 은 true 가 될때 코드 실행을 재개
            yield return new WaitUntil(() => { return lamdaCondition; });
            lamdaCondition = false;
            if (first)
            {
                picture.gameObject.SetActive(false);
                shouldInvisible.SetActive(false);
            }
            
        }
        Debug.Log("Read Story");
        
        story.Clear();
    }
    private void checkStory()
    {
        lamdaCondition=true;
    }

}
