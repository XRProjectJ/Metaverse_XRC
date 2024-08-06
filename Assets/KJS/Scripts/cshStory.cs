using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class cshStory : MonoBehaviour
{ 
    [SerializeField] private Text txtStory;
    [SerializeField] private Button btnNext;
    
    [SerializeField] private GameObject shouldInvisible;
    [SerializeField] private Image picture;
    [SerializeField] private string[] imageNames;

    public GameObject antiSpere;
    public GameObject GameManager;
    public GameObject controllerModel;
    public GameObject rayModel;
    public OVRPlayerController playerController;

    private List<string> story = new List<string>();
    public string fileName;
    private bool lamdaCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        picture.gameObject.SetActive(false);
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(checkStory);
        ReadFile(fileName); // edit
        StartCoroutine(ReadStory());
        Debug.Log("Story Start");
    }
    // 텍스트 파일을 Resources 폴더에서 읽어들이기
    private void ReadFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName); // edit
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
                if (story[i].Trim().EndsWith("@"))
                {
                    picture.gameObject.SetActive(true);
                    picture.sprite = Resources.Load<Sprite>(imageNames[imgIdx++]);
                    Debug.Log("imagesIdx = " + imgIdx);
                    tmp += story[i].Substring(0, story[i].LastIndexOf('@')) + "\n";
                }
                else if (story[i].Trim().EndsWith("#"))
                {
                    antiSpere.SetActive(true);
                    controllerModel.SetActive(false);
                    tmp += story[i].Substring(0, story[i].LastIndexOf('#')) + "\n";
                }
                else if(story[i].Trim().EndsWith("$"))
                {
                    GameManager.SetActive(true);
                    playerController.enabled = true;
                    tmp += story[i].Substring(0, story[i].LastIndexOf('$')) + "\n";
                    goto ExitLoops;
                }
                else if(story[i].Trim().EndsWith("&"))
                {
                    antiSpere.SetActive(false);
                    playerController.enabled = false;
                    controllerModel.SetActive(true);
                    rayModel.SetActive(true);
                    tmp += story[i].Substring(0, story[i].LastIndexOf('&')) + "\n";
                }
                else if(story[i].Trim().EndsWith("%"))
                {
                    tmp += story[i].Substring(0, story[i].LastIndexOf('%')) + "\n";
                    SceneManager.LoadScene("ThirdScene");
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
            picture.gameObject.SetActive(false);

        }

        ExitLoops:
        Debug.Log("Exited both loops");

        Debug.Log("Read Story");
        shouldInvisible.SetActive(false);

    }
    private void checkStory()
    {
        lamdaCondition=true;
    }

}
