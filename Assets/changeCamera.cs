using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private Camera cam;
    [SerializeField] private int i;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transforms[i].GetComponent<MeshRenderer>().enabled = false;
            i++;
            
            if (i == transforms.Length-1)
            {
                i = 0;
            }
            cam.gameObject.transform.position = transforms[i].position;
            transforms[i].GetComponent<MeshRenderer>().enabled = true;



        }
        */
    }

    void FixedUpdate()
    {
        /*
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hitfront;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(startPos.position, transform.TransformDirection(Vector3.forward), out hitfront, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(startPos.position, transform.TransformDirection(Vector3.forward) * hitfront.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(startPos.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }



        
        RaycastHit hitback;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(endPos.position, transform.TransformDirection(Vector3.back), out hitback, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(endPos.position, transform.TransformDirection(Vector3.back) * hitback.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(endPos.position, transform.TransformDirection(Vector3.back) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        */
    }

    public void SwapButton(int j)
    {
        for (int _i = 0; _i < transforms.Length; _i++)
        {
            transforms[_i].GetComponent<MeshRenderer>().enabled = false;
        }

        cam.gameObject.transform.position = transforms[j].position;
        transforms[j].GetComponent<MeshRenderer>().enabled = true;

    }
}
