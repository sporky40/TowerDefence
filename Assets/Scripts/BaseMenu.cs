using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BaseMenu : MonoBehaviour, IPointerDownHandler
{
    public static GameObject currentBase;

    public void OnPointerDown(PointerEventData eventData)
    { 
        
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           

        }
    }

    public void BuildArrowTower()
    {
        currentBase.GetComponent<BuildTower>().BuildArrowTower();
        gameObject.SetActive(false);
    }

    public void BuildMageTower()
    {
        currentBase.GetComponent<BuildTower>().BuildMageTower();
        gameObject.SetActive(false);
    }

    public void BuildCannonTower()
    {
        currentBase.GetComponent<BuildTower>().BuildCannonTower();
        gameObject.SetActive(false);
    }
}

