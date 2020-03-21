using System;
using UnityEngine;

public class Turrent : MonoBehaviour
{

    private Transform target;
    public Transform PartToRotate;
    public float range = 15f;
    public float turnSpeed = 10f ;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;

    public Transform firePoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {

            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation , lookRotation , Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountDown <= 0f){

        shoot();
        fireCountDown = 1/fireRate ;

        }
        fireCountDown -= Time.deltaTime ;

    }

     void shoot()
    {
      GameObject bulletGo= (GameObject) Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);

      Bullet bullet = bulletGo.GetComponent<Bullet>();
      if(bullet!=null)
       bullet.seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
