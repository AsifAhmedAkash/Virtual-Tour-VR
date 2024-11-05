using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectsToActivateOnInteraction;
    [SerializeField] private GameObject[] ObjectToDeactivateOnExit;
    [SerializeField] private Animator anim;

    //Whats to activate or deactivate on start
    [SerializeField] private GameObject[] activates;
    [SerializeField] private GameObject[] deactivates;

    // Start is called before the first frame update
    void Start()
    {
        //GameEvents.current.onActivateUI += DeactivateThisUI;
        anim = GetComponent<Animator>();
        Cursor.visible = true;


        for (int i = 0; i < activates.Length; i++)
        {
            activates[i].SetActive(true);
        }
        for (int i = 0; i < deactivates.Length; i++)
        {
            deactivates[i].SetActive(false);
        }

        
    }

    private void OnDisable()
    {
        //GameEvents.current.onActivateUI -= DeactivateThisUI;
    }

    public void DontMove()
    {
        //GameEvents.current.DontMove();
    }

    private void DeactivateThisUI()
    {
        if (selfActive)
        {
            for (int i = 0; i < activates.Length; i++)
            {
                activates[i].SetActive(true);
            }
            for (int i = 0; i < deactivates.Length; i++)
            {
                deactivates[i].SetActive(false);
            }
            selfActive = false;
        }
        
    }

    bool selfActive = false;

    public void DeactivateAllOtherUI()
    {
        GameEvents.current.ActivateUI();
        selfActive = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (anim != null)
        {
            anim.SetTrigger("pop");
        }

        if(other.gameObject.tag == "Player")
        {
            for (int i=0; i<ObjectsToActivateOnInteraction.Length; i++) { 
                ObjectsToActivateOnInteraction[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < ObjectToDeactivateOnExit.Length; i++)
            {
                ObjectToDeactivateOnExit[i].SetActive(false);
            }
        }
    }

    
}
