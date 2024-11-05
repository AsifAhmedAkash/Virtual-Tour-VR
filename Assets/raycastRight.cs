using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastRight : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform rightObj;

    [SerializeField] private CameraMove cameraMove;
    // Start is called before the first frame update
    void Start()
    {
        cameraMove = GetComponentInParent<CameraMove>();
    }

    private void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hitfront;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(startPos.position, transform.TransformDirection(Vector3.right), out hitfront, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(startPos.position, transform.TransformDirection(Vector3.right) * hitfront.distance, Color.yellow);
            Debug.Log("Did Hit");
            rightObj = hitfront.rigidbody.transform;
        }
        else
        {
            Debug.DrawRay(startPos.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit");
            rightObj = null;
        }


    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            /*
            MeshRenderer Tempmesh = transform.parent.GetComponentInParent<CameraMove>().ActiveMesh;
            Tempmesh.enabled = false;
            Tempmesh = rightObj.GetComponent<MeshRenderer>();
            Tempmesh.enabled = true;
            this.transform.parent.position = rightObj.position;
            */

            if(rightObj != null)
            {
                cameraMove.ChangePosition(rightObj);
            }
            
        }

    }
}
