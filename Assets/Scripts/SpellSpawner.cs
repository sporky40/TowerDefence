using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    private Vector3 targetPosition;
    private GameObject enemyTarget;
    [SerializeField]
    private float movmentSpeed = 5;
    private  float damage;
    [SerializeField]
    private int TowerType;
    [SerializeField]
    private int TowerLvl;

    private void Start()
    {
        damage = GameManager.instance.TowerTypeListSO.towerTypeList[TowerType].damage[TowerLvl];
    }
    void LateUpdate()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        transform.position += moveDir * movmentSpeed * Time.deltaTime;
        if (Vector3.Distance(targetPosition, transform.position) < 0.1f)
        {

            if (enemyTarget != null)
            {
                enemyTarget.GetComponent<enemy>().DealDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }


        }
    }
    public  void SetSpell(GameObject targetEnemy)
    {
        targetPosition = targetEnemy.transform.position;
        enemyTarget = targetEnemy;
        transform.eulerAngles = new Vector3(0,0,calculateAngleGivenDirection(targetEnemy.transform.position-transform.position)-90);
        

    }

    public  float calculateAngleGivenDirection(Vector3 dir)
    {

        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
