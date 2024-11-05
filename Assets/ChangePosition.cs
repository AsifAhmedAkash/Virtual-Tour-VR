using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePosition : MonoBehaviour
{
    [SerializeField] private Transform[] AllPositions;
    [SerializeField] private CameraMove CameraMove;
    [SerializeField] private int CurrentPositionNo;

    [SerializeField] private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        List<string> options = new List<string>();

        // Loop through the AllPositions array and add each Transform's name
        foreach (Transform position in AllPositions)
        {
            options.Add(position.name); // You can use other properties if needed, e.g., position.ToString()
        }

        // Add the options to the dropdown
        dropdown.AddOptions(options);


        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });
    }

    void DropDownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        ChangeCamPosition(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamPosition(int i)
    {
        CameraMove.ChangePosition(AllPositions[i]);
    }

    public void GoPreviousPosition()
    {
        CurrentPositionNo = getCurrentPositionNumber();
        if(CurrentPositionNo != 0)
        {
            CurrentPositionNo--;
        }
        CameraMove.ChangePosition(AllPositions[CurrentPositionNo]);
    }
    public void GoNextPosition()
    {
        CurrentPositionNo = getCurrentPositionNumber();
        if (CurrentPositionNo != (AllPositions.Length-1))
        {
            CurrentPositionNo++;
        }
        CameraMove.ChangePosition(AllPositions[CurrentPositionNo]);
    }

    private int getCurrentPositionNumber()
    {
        for(int i = 0; i < AllPositions.Length; i++)
        {
            if (AllPositions[i].GetComponentInChildren<Canvas>().isActiveAndEnabled)
            {
                return i;
            }
        }
        return 0;
    }

}
