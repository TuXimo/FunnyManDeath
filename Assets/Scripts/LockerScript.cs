using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LockerScript : MonoBehaviour
{
    [SerializeField] TMP_Text[] numberTexts = new TMP_Text[4];
    [SerializeField] string codePassword = "1986";


    public void SumNumber(int slot)
    {
        if (IsAcerted()) return;
        int val0 = int.Parse(numberTexts[slot].text);
        
        if (Int32.Parse(numberTexts[slot].text) == 9)
        {
            numberTexts[slot].text = "0";
        }
        
        else numberTexts[slot].text = (val0 + 1).ToString();

        IsAcerted();
    }
    public void RestNumber(int slot)
    {
        if (IsAcerted()) return;
        int val0 = int.Parse(numberTexts[slot].text);
        
        if (int.Parse(numberTexts[slot].text) == 0)
        {
            numberTexts[slot].text = "9";
        }
        
        else numberTexts[slot].text = (val0 - 1).ToString();
        IsAcerted();
    }
    public bool IsAcerted()
    {
        var currentLockCode = "";
        
        for (var i = 0; i < 4; i++)
        {
            currentLockCode += numberTexts[i].text;
        }
        
        return currentLockCode == codePassword;
    }

    public void GetBackLockButton(GameObject currentLock)
    {
        if (IsAcerted())
        {
            closedChests.SetActive(false);
            lockpad.SetActive(false);
            openedChest.SetActive(true);
            backGroundChest.SetActive(true);
            
            piñonFijo.SetActive(true);
            calendario.SetActive(false);
            
        }

        gameObject.SetActive(false);       
    }

    [Space]
    [SerializeField] private GameObject closedChests;
    [SerializeField] private GameObject lockpad;
    [SerializeField] private GameObject openedChest;
    
    [Space]
    [SerializeField] private GameObject backGroundChest;
    [SerializeField] private GameObject piñonFijo;
    [SerializeField] private GameObject calendario;
    
}
