using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBye : MonoBehaviour
{
    public float lifespan;

    // Update is called once per frame
    void Update()
    {
        if((lifespan -= Time.deltaTime) <= 0f)
        {
            DestroyAtEnd();
        }
    }

    void DestroyAtEnd()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Pig")
        {
            other.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
    }
}
