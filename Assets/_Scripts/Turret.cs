using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
    public Bullet bulletPrefab = null;// bullet
    public Transform bulletInitialPosition;
    public float interval = 2.0f;// interval
    float timeLeft = 0.0f;
    public float range = 10.0f;// attack range
    public int buildPrice = 1;// price to build the tower
    public float rotationSpeed = 2.0f;// rotation 
    private Vector3 bulletOffset;
    void Awake()
    {
        //bulletInitialPosition = GameObject.FindGameObjectWithTag("BulletSpawnPoint");
        bulletOffset = new Vector3(0.5f, 0.2f, 1f);
        //bulletInitialPosition.up -= -1;
        //Transform cannonPosition =  GameObject.FindGameObjectWithTag("Cannon").transform;
    }

    void Update()
    {
        // shoot next bullet?
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            // find the closest target (if any)
            GameObject target = findClosestTarget();
            setRotation(target);
            if (target != null)
            {
                // is it close enough?
                if (Vector3.Distance(transform.position, target.transform.position) <= range)
                {
                    // spawn bullet
                    GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, bulletInitialPosition.position, bulletInitialPosition.rotation);

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

    void setRotation(GameObject enemy)
    {
        transform.LookAt(enemy.transform);
    }

}