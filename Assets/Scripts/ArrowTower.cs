using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : MonoBehaviour
{
    public List<GameObject> enemies;
    private GameObject currentTarget;
    private float timer;
    private float fireRate;
    public int towerLvl;
    public int towerType;
    [SerializeField]
    private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
       
        fireRate = GameManager.instance.TowerTypeListSO.towerTypeList[towerType].fireRate[towerLvl];
        
       
        
    }
   

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="enemy")
        { 
            
            enemies.Add(collision.gameObject);
            currentTarget = enemies[0];
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count != 0)
        { 
            if(timer<0)
            {  if(currentTarget != null)
                {
                    GameObject temp;
                    temp = Instantiate(projectile, transform);
                    temp.GetComponent<ArrowSpawn>().SetArrow(currentTarget);
                    timer = fireRate;
                }
                
            }
            timer -= Time.deltaTime;
            
        }
    }
}
