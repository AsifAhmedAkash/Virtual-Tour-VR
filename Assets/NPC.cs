using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private Transform Movetransform;
    [SerializeField] private bool tourStart;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject[] UIToEnableOnStay;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("Wave");
    }

    public void TourStart(bool tourEnable)
    {
        tourStart = tourEnable;
        animator.SetFloat("MoveSpeed", .4f);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        if (tourStart) {
            transform.position = Vector3.MoveTowards(transform.position, Movetransform.position, step);
            
        }

        TourStart();
    }

    int i = 0;
    bool stayThereForSomeTimeandDoNothing = false;
    bool ChangeValue = true;
    void TourStart()
    {
        if (transform.position == Movetransform.position)
        {
            if (ChangeValue)
            {
                stayThereForSomeTimeandDoNothing = true;
            }
            
        }

        if (stayThereForSomeTimeandDoNothing)
        {
            animator.SetFloat("MoveSpeed", 0f);
            for (int j = 0; j < UIToEnableOnStay.Length; j++)
            {
                UIToEnableOnStay[j].SetActive(false);
            }

            UIToEnableOnStay[i].SetActive(true);

            i++;

            if(i == UIToEnableOnStay.Length)
            {
                dir = (this.transform.position - Movetransform.position).normalized;
                transform.rotation = Quaternion.LookRotation(dir);
                animator.SetTrigger("Win");
            }


            StartCoroutine(WaitAndStartWalk(5f));
            stayThereForSomeTimeandDoNothing = false;
            ChangeValue = false;
        }

        
    }
    public Vector3 dir;

    private IEnumerator WaitAndStartWalk(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Movetransform = transforms[i];
        dir = (this.transform.position - Movetransform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
        animator.SetFloat("MoveSpeed", .4f);
        ChangeValue = true;
    }
}
