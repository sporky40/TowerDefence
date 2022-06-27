using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> selectedPath;
    int currWayPoint = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private Transform healthBar;
    [SerializeField]
    private GameObject blood;
    [SerializeField]
    private int Value;


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        selectedPath = paths.pathing.generatePath();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        agent.SetDestination(selectedPath[0].position);
        
        
    }
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)//distance between the enemy and destination  
        {
            if (currWayPoint < selectedPath.Count)//after reaching destination it finds the next destination
            {
                agent.SetDestination(selectedPath[currWayPoint].position);
                currWayPoint++;
            }
            else if (currWayPoint == selectedPath.Count)//will run when the last destination is reached
            {

                //  gameManager.updateLifePoints(-1);

                GameManager.instance.enemyList.Remove(gameObject.GetComponent<animationEnemy>());
                GameManager.instance.UpdateLifePoints();
                GameManager.instance.UpdateNumberOfEnemis();
                Destroy(gameObject);
                
            }
        }

        //flips the sprite left and right acoring to the velocity
        if (agent.velocity.x >= 0.05f)
        {
            spriteRenderer.flipX = false;
          //  rendererr.transform.localScale = new Vector3(0.1956f, 0.1797f, 1f);
        }
        else if (agent.velocity.x <= -0.05f)
        {
            spriteRenderer.flipX = true;
            // rendererr.transform.localScale = new Vector3(-0.1956f, 0.1797f, 1f);
        }
    }

     public void DealDamage(float dmg)
    {
        health -= dmg;
        healthBar.localScale -= new Vector3(dmg/100, 0,0);
        
        
        if (health<=0)
        {
            Instantiate(blood, transform.position,Quaternion.identity);
            gameObject.GetComponent<animationEnemy>().RemoveEnemy();
            GameManager.instance.UpdateNumberOfEnemis();
            GameManager.instance.UpdateCoins(Value);
            Destroy(gameObject);

        }
    }
}
