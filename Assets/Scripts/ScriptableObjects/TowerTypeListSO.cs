using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="TowerTypeListSO")]
public class TowerTypeListSO : ScriptableObject
{
    #region public.
    public List<TowerSO> towerTypeList;
    #endregion
}
