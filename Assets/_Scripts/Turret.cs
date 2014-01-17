using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
    public Bullet bulletPrefab = null;// bullet
    public Vector3 bulletInitialPosition;
    public float interval = 2.0f;// interval
    float timeLeft = 0.0f;
    public float range = 10.0f;// attack range
    public int buildPrice = 1;// price to build the tower
    public float rotationSpeed = 2.0f;// rotation 

    void Awake()
    {
        
    }

    void Update()
    {
        // shoot next bullet?
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            // find the closest target (if any)
            GameObject target = findClosestTarget();
            if (target != null)
            {
                // is it close enough?
                if (Vector3.Distance(transform.position, target.transform.position) <= range)
                {
                    // spawn bullet
                    GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, GameObject.Find("BulletSpawnPoint").transform.position, Quaternion.identity);

                    // get access to bullet component
                    Bullet b = g.GetComponent<Bullet>();

                    // set destination        
                    b.setDestination(target.transform);

                    // reset time
                    timeLeft = interval;
                }
            }
        }
    }

    GameObject findClosestTarget()
    {
        GameObject closest = null;
        Vector3 pos = transform.position;

        // find all Enemies
        GameObject[] enemies = (GameObject[])GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
            if (enemies.Length > 0)
            {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i)
                {
                    float cur = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);

                    if (cur < old)
                    {
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }
}