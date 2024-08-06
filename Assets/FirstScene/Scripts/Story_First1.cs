using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Story_First1 : MonoBehaviour
{
    [SerializeField] private Text txtStory;
    [SerializeField] private Button btnNext;
    [SerializeField] public Button btnFinal;
    [SerializeField] private GameObject shouldInvisible;
    [SerializeField] private Image picture; 
    [SerializeField] private string[] imageNames; // edit

    private List<string> story = new List<string>();
    private bool lamdaCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(checkStory);
        ReadFile("first_story"); // edit
        StartCoroutine(ReadStory(true));
        btnNext.gameObject.SetActive(true);

        Debug.Log("Story Start");

        if (btnFinal != null)
        {
            
            btnFinal.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("btnFinal is not assigned in the Inspector.");
        }
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
            
            
            // ���ٽ� ���ȳ��� ��Ʃ�� ��û: https://www.youtube.com/watch?v=HNDhlODVV4Q 
            // WaitUntile �� true �� �ɶ� �ڵ� ������ �簳
            yield return new WaitUntil(() => { return lamdaCondition; });
            lamdaCondition = false;

            
        }
        Debug.Log("Read Story");

        changeFInal();

        story.Clear();
        picture.gameObject.SetActive(false);
        shouldInvisible.SetActive(false);

    }
    private void checkStory()
    {
        lamdaCondition=true;
    }

    void changeFInal()
    {
        if (btnFinal != null)
        {
            btnFinal.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("btnFinal is not assigned in the Inspector.");
        }

        if (btnNext != null)
        {
            btnNext.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("btnNext is not assigned in the Inspector.");
        }
    }
}
