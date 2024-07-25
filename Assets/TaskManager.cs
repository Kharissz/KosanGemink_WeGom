using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public string[] Tasks;
    public TextMeshProUGUI teks;
    public int CurrentTask = 0;
    // Start is called before the first frame update
    void Start()
    {
        teks.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTask()
    {
        teks.text = Tasks[0];
    }

    public void NextTask()
    {
        if(CurrentTask > Tasks.Length)
        {
            teks.text = string.Empty;
        } 
        else
        {
            CurrentTask+=1;
            teks.text = Tasks[CurrentTask];
        }
 
    }
}
