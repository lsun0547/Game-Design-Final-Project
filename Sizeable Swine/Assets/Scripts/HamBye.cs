using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamBye : MonoBehaviour
{
    public float lifespan;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10, Space.Self);
        if((lifespan -= Time.deltaTime) <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Pig" && other.gameObject.tag != "Food")
        {
            Destroy(gameObject);
        }
    }
}
