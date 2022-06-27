using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TowerSO")]
public class TowerSO : ScriptableObject
{
    #region public.
    public List<GameObject> towerLvlList;
    public List<int> price;
    public List<float> fireRate;
    public List<Sprite> spriteList;
    public List<float> damage;
    #endregion
}
