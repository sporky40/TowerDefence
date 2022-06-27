using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuildTower : MonoBehaviour, IPointerDownHandler
{
    #region Public.


    public int TowerType;
    public int TowerLVl = 0;

    #endregion
    #region Private.
    private bool isWeelThreeActive = true;
    private GameObject currentTower;
    
    
    
    #endregion

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left && isWeelThreeActive)
        {
            
            if(GameManager.instance.isWeelTwoActive)
            {
                GameManager.instance.wheelTwo.SetActive(false);
                GameManager.instance.isWeelTwoActive = false;
            }

             GameManager.instance.wheelThree.transform.position=transform.position;
             GameManager.instance.wheelThree.SetActive(true);
             GameManager.instance.isWheelThreeActive = true;
             BaseMenu.currentBase = gameObject;
            

        }
        else
        {
            if(GameManager.instance.isWheelThreeActive)
            {
                GameManager.instance.wheelThree.SetActive(false);
                GameManager.instance.isWheelThreeActive = false;
            }

            if (GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList.Count > TowerLVl + 1)
            {
                GameManager.instance.wheelTwo.GetComponent<UpgradeMenu>().ChangeButtonImage(TowerType, TowerLVl + 1);
            }
            else
            {
                GameManager.instance.wheelTwo.GetComponent<UpgradeMenu>().ChangeButtonImage(-1, TowerLVl + 1);
            }
            GameManager.instance.wheelTwo.transform.position = transform.position;
            GameManager.instance.wheelTwo.SetActive(true);
            GameManager.instance.isWeelTwoActive = true;
            UpgradeMenu.currentBase = gameObject;
        }
    }
    public void BuildArrowTower()
    {
        TowerType = 0;
        if (GameManager.instance.Coins >= GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl])
        {
            currentTower = Instantiate(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl], transform);
            GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerLvl = TowerLVl;
            GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerType = TowerType;
            GameManager.instance.UpdateCoinsAfterBuild(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl]);
            currentTower.transform.position = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y + .5f, currentTower.transform.position.z);
            isWeelThreeActive = false;
        }

    }
    public void BuildMageTower()
    {
        TowerType = 1;
        if (GameManager.instance.Coins >= GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl])
        {
            currentTower = Instantiate(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl], transform);
            GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<MageTower>().towerLvl = TowerLVl;
            GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<MageTower>().towerType = TowerType;
            GameManager.instance.UpdateCoinsAfterBuild(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl]);
            currentTower.transform.position = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y + 0.5f, currentTower.transform.position.z);
            isWeelThreeActive = false;
        }

    }

    public void BuildCannonTower()
    {
        TowerType = 2;
        if (GameManager.instance.Coins >= GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl])
        {
            currentTower = Instantiate(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl], transform);
            currentTower.transform.position = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y + .5f, currentTower.transform.position.z);
            isWeelThreeActive = false;
        }


    }
    public void UpgradeTower()
    {
        if(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList.Count>TowerLVl+1 && GameManager.instance.Coins >= GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl+1])
        {
            TowerLVl++;
            Destroy(currentTower);
            GameManager.instance.UpdateCoinsAfterBuild(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[TowerLVl]);
            currentTower = Instantiate(GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl], transform);
            currentTower.transform.position = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y + .5f, currentTower.transform.position.z);
            if (TowerType == 0)
            {
                GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerLvl = TowerLVl;
                GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerType = TowerType;
            }
            else if (TowerType == 1)
            {
               
                GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<MageTower>().towerLvl = TowerLVl;
                GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<MageTower>().towerType = TowerType;
            }
          /*  else
            {
                //GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerLvl = TowerLVl;
                //GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].towerLvlList[TowerLVl].GetComponent<ArrowTower>().towerType = TowerType;
            }*/
          
        }
        
       
    }

    public void SellTower()
    {
        int temp = 0;
        for(int i = 0;i<=TowerLVl;i++)
        {
            temp += GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].price[i];
        }
        temp /= 2;
        GameManager.instance.UpdateCoins(temp);
        TowerLVl = 0;
        isWeelThreeActive = true;
        Destroy(currentTower);
    }
}
