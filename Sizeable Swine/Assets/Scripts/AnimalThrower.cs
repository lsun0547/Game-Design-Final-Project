using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalThrower : MonoBehaviour
{
    public GameObject animalPrefab;
    private Camera theCamera;
    public float animalImpulse;
    private GameObject theAnimal;
    public bool canThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        theCamera = Camera.main;
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canThrow)
        {
            ThrowAnimal();
        }
    }

    void ThrowAnimal()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            theAnimal = (GameObject)Instantiate(animalPrefab, theCamera.transform.position + theCamera.transform.forward, theCamera.transform.rotation);

            theAnimal.GetComponent<Rigidbody>().AddForce(theCamera.transform.forward * animalImpulse, ForceMode.Impulse);
        }
    }
}