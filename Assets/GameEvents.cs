using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    
    public static GameEvents current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public event Action onActivateUI;

    public void ActivateUI()
    {
        if(onActivateUI != null) 
            onActivateUI();
    }

    public event Action onDontMove;
    public void DontMove()
    {
        if(onDontMove != null) 
            onDontMove();
    }
    
}
