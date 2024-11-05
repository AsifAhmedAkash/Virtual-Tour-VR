using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1000;
    public GameObject mover;

    public MeshRenderer ActiveMesh;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointer down");
    }

    private void Start()
    {
        mover = this.gameObject;
        //mover.transform.localRotation = Quaternion.Euler(turn.y, -turn.x, 0);
        turn = new Vector2(mover.transform.localRotation.x, mover.transform.localRotation.y);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("pressed");
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;

            mover.transform.localRotation = Quaternion.Euler(turn.y, -turn.x, 0);
            //transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

            deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            mover.transform.Translate(deltaMove);
        }

        if (CanMove)
        {
            moveWithLerp();
        }
    }

    //initial position
    Vector3 InitialPosition;
    Vector3 FinalPosition;

    private float journeyLength;
    private float startTime;
    [SerializeField] private bool CanMove = false;
    [SerializeField] private Transform NewPos;

    [SerializeField] private GameObject priviousTransform;
    [SerializeField] private GameObject LaterTransform;

    public void ChangePosition(Transform _newPos)
    {
        InitialPosition = ActiveMesh.GetComponent<Transform>().position;
        FinalPosition = _newPos.position;

        NewPos = _newPos;
        
        mover = this.gameObject;

        priviousTransform = ActiveMesh.gameObject;
        SwapUI(priviousTransform, false);
        LaterTransform = _newPos.gameObject;
        SwapUI(LaterTransform, true);

        //mover.transform.position = newPos.position;

        //Debug.Log("initial pos " + InitialPosition + " final " + FinalPosition);


        //mover.transform.localRotation = Quaternion.Euler(turn.y, -turn.x, 0);
        //turn = new Vector2(mover.transform.localRotation.x, mover.transform.localRotation.y);
        //turn = new Vector2(mover.transform.localRotation.x, mover.transform.localRotation.y);

        journeyLength = Vector3.Distance(InitialPosition, FinalPosition);
        startTime = Time.time;

        CanMove = true;
    }

    public float minDistance = 9f;
    private float InitialSpeed;
    
    private void SwapUI(GameObject obj, bool activestate)
    {
        obj.GetComponent<SwapAble>().DisAbleUI(activestate);
    }

    void moveWithLerp()
    {
        if(Vector3.Distance(mover.transform.position, InitialPosition) > minDistance)
        {
            //ChildTransform = NewPos.GetComponentInChildren<SwapAble>().ActivateAbleObj().gameObject;
            //ChildTransform.SetActive(false);
            /*
            if(ActiveMesh.transform.GetComponentInChildren<Canvas>() != null)
            {
                ActiveMesh.transform.GetComponentInChildren<Canvas>().enabled = false;
            }
            */
            //priviousTransform = NewPos.transform;
            ActiveMesh.enabled = false;
            ActiveMesh = NewPos.GetComponent<MeshRenderer>();
            ActiveMesh.enabled = true;
            
            //InitialSpeed = speed;
            speed = 10000f;
        }

        if (Vector3.Distance(mover.transform.position, FinalPosition) < minDistance)
        {
            ActiveMesh.enabled = false;
            ActiveMesh = NewPos.GetComponent<MeshRenderer>();
            ActiveMesh.enabled = true;

            /*
            Debug.Log(ActiveMesh.transform.GetComponentInChildren<Canvas>());
            if (ActiveMesh.transform.GetComponentInChildren<Canvas>() != null)
            {
                ActiveMesh.transform.GetComponentInChildren<Canvas>().enabled = true;
            }
            */

            speed = 1000f;

            
            
            //ChildTransform = NewPos.GetComponentInChildren<SwapAble>().ActivateAbleObj().gameObject;
            //ChildTransform.SetActive(true);
        }

        Debug.Log("moving with lerp");
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        mover.transform.position = Vector3.Lerp(InitialPosition, FinalPosition, fractionOfJourney);

        if(transform.position == FinalPosition)
        {
            CanMove = false;
            speed = 1000f;
        }


        
    }
}
