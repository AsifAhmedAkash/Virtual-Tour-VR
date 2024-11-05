using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAble : MonoBehaviour, ISwapable
{
    [SerializeField] private Canvas[] canvas;

    public MeshRenderer meshRendererReturn()
    {
        return this.GetComponent<MeshRenderer>();
    }

    public Transform ActivateAbleObj()
    {
        return this.GetComponentInChildren<Transform>();
    }

    public Transform positionReturn()
    {
        return this.transform;
    }

    void Start()
    {
        canvas = this.GetComponentsInChildren<Canvas>();
        foreach (Canvas canva in canvas)
        {
            canva.enabled = false;
        }
        
        
    }
    private IEnumerator coroutine;

    public void DisAbleUI(bool active)
    {

        foreach (Canvas canva in canvas)
        {
            canva.enabled = active;
        }

        /*

        if (active == true)
        {
            coroutine = WaitAndPrint(1.0f);
            StartCoroutine(coroutine);
        }
        else
        {
            foreach (Canvas canva in canvas)
            {
                canva.enabled = active;
            }
        }
        */
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            foreach (Canvas canva in canvas)
            {
                canva.enabled = true;
            }
        }
    }
}
