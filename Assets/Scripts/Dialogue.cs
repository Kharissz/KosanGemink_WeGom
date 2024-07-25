using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;
using UnityEngine.Events;



public class Dialogue : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject box;
    public TextMeshProUGUI chara;
    public TextMeshProUGUI textComponent;
    // [SerializeField] private GameObject buttonUI;
    private GameObject player;
    public string nama;
    public string[] lines;
    public float textSpeed;
    private bool dial;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        chara.text = nama;
        textComponent.text = string.Empty;
        
        player = GameObject.FindGameObjectWithTag("Player");

        StartDialogue();
        // control = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            // StartDialogue();
            // comm = false;
        }
        if(Input.GetMouseButtonDown(0) && dial)
        {
            if(textComponent.text == lines[index])
            {NextLine();}
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }        
    }

    public void StartDialogue()
   {
        box.SetActive(true);
        dial = true;
        index = 0;
        StartCoroutine(TypeLine());
        // control.constraints = RigidbodyConstraints.FreezeAll;
   }

   public void EndDialogue()
   {
        box.SetActive(false);
        dial = false;
        textComponent.text = string.Empty;
        // control.constraints = RigidbodyConstraints.None;
        StopCoroutine(TypeLine());

        if(taskManager!=null)
        {
            taskManager.StartTask();
        }
   }

   void NextLine()
   {
        if(index < lines.Length -1 )
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        else
        {
            Debug.Log("Dialog Berakhir");
            EndDialogue();            
        }
   }

   void OnEnable()
   {
        // StartDialogue();
   }

   void OnTriggerEnter(Collider coll)
   {
        if(coll.CompareTag("Player"))
        {
            // buttonUI.SetActive(true);
            // comm = true;
            StartDialogue();
        }
   }

    void OnTriggerExit(Collider coll)
   {
        if(coll.CompareTag("Player"))
        {
            // comm = false;
            // buttonUI.SetActive(false);
        }
   }

   IEnumerator TypeLine()
   {
    // Type each character 1 by 1
    foreach(char c in lines[index].ToCharArray())
    {
        textComponent.text+=c;
        yield return new WaitForSeconds(textSpeed);
    }
   }
}
