using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class paths : MonoBehaviour
{
    public static paths pathing;
    [SerializeField]
     List<points> ListOfPointLists;
    void Start()
    {
        if (pathing != null && pathing != this)
        {
            Destroy(this);
        }
        else
        {
            pathing = this;
        }
    }
    public List<Transform> generatePath()
    {
        List<Transform> selectedPath = new List<Transform>();
       


        foreach (points point in ListOfPointLists)
        {
            selectedPath.Add(point.pathsList[Random.Range(0, point.pathsList.Length)]);
        }
        return selectedPath;
    }
}

[System.Serializable]
public struct points
{
    public Transform[] pathsList;
}
