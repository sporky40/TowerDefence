using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    
    [SerializeField]
    private GameObject basicEnemy;
    [SerializeField]
    private float rateOfSpawn;
    [SerializeField]
    private int[] wave;
    private int m = 0;
    [SerializeField]
    private int secondPerWave;



    private void Start()
    {
        int temp = 0;
        for(int i = 0; i < wave.Length;i++)
        {
            temp += wave[i];
        }
        GameManager.instance.AddNumberOfEnemies(temp);

        StartCoroutine(ExampleCoroutine());
    }

  
    IEnumerator ExampleCoroutine()
    {for (int i = 0; i < wave.Length; i++) 
        {
            while (m < wave[i])
            {
                Instantiate(basicEnemy,transform.position,Quaternion.identity);
                m++;
                yield return new WaitForSeconds(rateOfSpawn); 
            }
            m = 0;
            yield return new WaitForSeconds(secondPerWave);
        }        
    }
}
 