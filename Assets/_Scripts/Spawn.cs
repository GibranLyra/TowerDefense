using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
	public float interval = 3.0f;
	float timeLeft = 0.0f;
	// gameobject to be spawned
	public GameObject monsterType = null;

    public Transform[] waypoints;


    private WayPointController wayPointControllerScript;


    void Awake()
    {
        wayPointControllerScript = (WayPointController)monsterType.GetComponent("WayPointController");
    }

	// Update is called once per frame
	void Update()
	{
		// time to spawn the next one?
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0f)
		{
			// spawn
			GameObject enemy = (GameObject)Instantiate(monsterType, transform.position, Quaternion.identity);

            wayPointControllerScript.waypoints = waypoints;
            //Set enemy route
			// reset time
			timeLeft = interval;
		}
	}

	
}
