using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private bool triggerActive;
    private float lifetime;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        triggerActive = false;
        lifetime = 2f;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Time.deltaTime * 300f, 0f);
        if(triggerActive)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 30, Space.World);
            lifetime -= Time.deltaTime;
            if (lifetime <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            triggerActive = true;
            levelManager.RemoveFood();
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
