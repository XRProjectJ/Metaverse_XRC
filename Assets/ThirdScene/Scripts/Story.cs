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
    [SerializeField] private Sprite[] images;

    private List<string> story = new List<string>();
    private string txtPath = "Assets/ThirdScene/storyText.txt";
    private string finalTxtPath = "Assets/ThirdScene/finalStoryText.txt";
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
        ReadFile(txtPath);
        StartCoroutine(ReadStory(true));
        
        Debug.Log("Story Start");
    }
    // �ؽ�Ʈ ������ ���� ��ġ�� �о���̱�
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
                Debug.Log("���� �б� ����");
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
            
            
            // ���ٽ� ���ȳ��� ��Ʃ�� ��û: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile �� true �� �ɶ� �ڵ� ������ �簳
            yield return new WaitUntil(() => { return lamdaCondition; });
            lamdaCondition = false;
            if (first)
            {
                picture.gameObject.SetActive(false);
                shouldInvisible.SetActive(false);
                spawnVirus.SetActive(true);
                maximum.gameObject.SetActive(true);
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
