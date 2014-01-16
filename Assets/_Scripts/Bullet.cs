using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    // fly speed
    public float speed;
    public float damage;
    // destination set by Tower when creating the bullet
    Transform destination;

    // Update is called once per frame
    void Update()
    {
        // destroy bullet if destination does not exist anymore
        if (destination == null)
        {
            Destroy(gameObject);
            return;
        }

        calculateDestination();        

        // reached?
        if (transform.position.Equals(destination.position))
        {
            destination.collider.SendMessage("Damage", new HealthEvent(gameObject, damage), SendMessageOptions.DontRequireReceiver);            
            Destroy(gameObject);
        }
    }

    public void setDestination(Transform v)
    {
        destination = v;
    }

    void calculateDestination()
    {
        // fly towards the destination
        float stepSize = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, destination.position, stepSize);
    }

}