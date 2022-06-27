using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyWheel : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {


        if (eventData.button == PointerEventData.InputButton.Left)
        {

            if (GameManager.instance.isWheelThreeActive )
            {
                GameManager.instance.wheelThree.SetActive(false);
                GameManager.instance.isWheelThreeActive = false;

            }

            if(GameManager.instance.isWeelTwoActive)
            {
                GameManager.instance.wheelTwo.SetActive(false);
                GameManager.instance.isWeelTwoActive = false;
            }
            
        }
    }
}
