using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{

    [Header("Attributes")]

    public float range = 10f;

    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Enemy Object Detection")]

    public Transform target;
    public string enemyTag = "Enemy";

    [Header("Shooting")]

    public Transform partToRotate;

    public GameObject arrowPrefab;
    public Transform firePoint;

    public bool canShoot = false;


    // Start is called before the first frame update
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

        // Target Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            if (canShoot)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

            fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject arrowGameObject = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGameObject.GetComponent<Arrow>();

        if (arrow != null)
            arrow.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
