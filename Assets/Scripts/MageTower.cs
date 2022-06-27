using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies;
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
        if (collision.tag == "enemy")
        {

            enemies.Add(collision.gameObject);
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            enemies.Remove(collision.gameObject);
            
        }
    }

    void Update()
    {
       
       

        if (enemies.Count != 0)
        {
            if (timer < 0)
            {
                if(enemies.Count>=3)
                {
                    for(int i = 0;i<3;i++)
                    {
                        GameObject temp;
                        temp=Instantiate(projectile, transform);
                        temp.GetComponent<SpellSpawner>().SetSpell(enemies[i]);
                        timer = fireRate;
                    }
                }
                else
                {
                    for(int i = 0;i< enemies.Count;i++)
                    {
                        GameObject temp;
                        temp = Instantiate(projectile, transform);
                        temp.GetComponent<SpellSpawner>().SetSpell(enemies[i]);
                        timer = fireRate;
                    }
                }
               
            }
            timer -= Time.deltaTime;

        }
    }
}
