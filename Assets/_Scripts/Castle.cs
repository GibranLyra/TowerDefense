using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour
{
    public GUISkin skin = null;

    public static int health = 100;

    void OnGUI()
    {
        GUI.skin = skin;

        // draw castle health
        GUI.Label(new Rect(0, 40, 400, 200), "Castle Health: " + health);
    }

    void Update()
    {
        
        GameObject[] enemies = (GameObject[])GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
            // find all enemies that are close to the castle
            for (int i = 0; i < enemies.Length; ++i)
            {
                float range = Mathf.Max(collider.bounds.size.x, collider.bounds.size.z);
                if (Vector3.Distance(transform.position, enemies[i].transform.position) <= range)
                {
                    // decrease castle health
                    health = health - 1;

                    // destroy teddy
                    Destroy(enemies[i].gameObject);
                }
            }
        }
    }
}
