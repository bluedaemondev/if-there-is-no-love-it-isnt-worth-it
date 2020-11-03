using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNarrativeOnEnter : MonoBehaviour
{
    public List<string> dialogsOverride;
    public NarrativeTextDialog dialog;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
            panel.SetActive(true);
            dialog.currentIdx = 0;
            dialog.dialogs = dialogsOverride;
        //}
        
    }
}
