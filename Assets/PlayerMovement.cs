using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform forwardpos;
    // Start is called before the first frame update
    void Start()
    {
        //GameEvents.current.onDontMove += DontMove;
    }

    private void OnDisable()
    {
        //GameEvents.current.onDontMove -= DontMove;
    }

    public bool dontMove = false;

    public void DontMove()
    {
        dontMove = true;
    }

    bool moveCommand = false;
    [SerializeField] private Vector3 _forwardVecPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            moveCommand = true;
            _forwardVecPos = new Vector3(forwardpos.position.x, this.transform.position.y, forwardpos.position.z);
        }

        if (!dontMove)
        {
            if (moveCommand)
            {
                
                var step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _forwardVecPos, step);
                //dontMove = true;
            }
        }
    }
}
