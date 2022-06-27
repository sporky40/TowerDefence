using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    private Image upgrateButtonImage;
    public static GameObject currentBase;

    
    public void UpgradeTower()
    {
        currentBase.GetComponent<BuildTower>().UpgradeTower();
        gameObject.SetActive(false);
       


    }

    public void ChangeButtonImage(int TowerTypeIndex, int TowerLvlIndex)
    {   if(TowerTypeIndex !=-1)
        {
            upgrateButtonImage.sprite = GameManager.instance.TowerTypeListSO.towerTypeList[TowerTypeIndex].spriteList[TowerLvlIndex];
        }
        else
        {
            upgrateButtonImage.sprite = null;
        }
    }

    public void SellTower()
    {
        currentBase.GetComponent<BuildTower>().SellTower();
        gameObject.SetActive(false);
    }


}
