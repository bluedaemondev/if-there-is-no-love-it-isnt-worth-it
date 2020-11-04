using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class NarrativeTextDialog : MonoBehaviour
{
    public List<string> dialogs;
    public int currentIdx = 0;
    
    private float timeStringConstruction = 0f;
    private TextMeshProUGUI textObject;
    public bool resetScene;


    // Start is called before the first frame update
    void Start()
    {
        this.textObject = this.GetComponent<TextMeshProUGUI>();
        
        if(dialogs != null)
            textObject.text = dialogs[0];


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentIdx < dialogs.Count - 1)
        {
            textObject.text = dialogs[++this.currentIdx];
        }
        else if (Input.GetMouseButtonDown(0) && resetScene )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //else if (!resetScene)
        //{
        //    GameObject.FindGameObjectWithTag("NarrativePanel").SetActive(false);
        //}

    }
}
