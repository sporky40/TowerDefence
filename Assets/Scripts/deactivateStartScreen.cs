using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateStartScreen : MonoBehaviour
{

    [SerializeField]
    private GameObject startScrene;

    public void DeactivateStartScreen()
    {
        startScrene.SetActive(false);
    }
}
