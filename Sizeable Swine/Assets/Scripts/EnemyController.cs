using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    private float currentHealth;
    private LevelManager levelManager;
    public CapsuleCollider[] colliders;
    public Rigidbody[] rigidbodies;
    private Rigidbody myRigidbody;
    private CharacterController character;
    public float walkSpeed;
    public bool isHam;
    public GameObject ham;
    private GameObject projectile;
    public float maxInterval;
    private float hamInterval;
    public GameObject hamSpawn;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        colliders = GetComponentsInChildren<CapsuleCollider>();
        rigidbodies = GetComponentsInChildren<Rigidbody>().Where(go => go.gameObject != this.gameObject).Cast<Rigidbody>().ToArray();
        myRigidbody = GetComponent<Rigidbody>();
        character = FindObjectOfType<CharacterController>();
        maxInterval *= 2; //time scale is doubled for some reason so need to double interval for time to actually be correct
        hamInterval = maxInterval / 2;
    }

    public void TakeDamage()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        for(int i = 0; i < colliders.Length; i ++)
        {
            colliders[i].enabled = true;
            rigidbodies[i].isKinematic = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            float maxDistance = GetComponent<SphereCollider>().radius * transform.localScale.x;
            Vector3 direction = Vector3.Normalize(other.gameObject.transform.position - transform.position) * maxDistance;
            LayerMask layerMask = LayerMask.GetMask("Terrain", "Player");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.Ignore))
            {
                if(hit.collider == character)
                {
                    GetComponent<Animator>().enabled = true;
                    transform.rotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.LookRotation(direction), 180 * Time.deltaTime);
                    myRigidbody.velocity = transform.forward * walkSpeed + Physics.gravity;
                    if(isHam)
                    {
                        hamInterval -= Time.deltaTime;
                        if(hamInterval <= 0)
                        {
                            projectile = (GameObject)Instantiate(ham, hamSpawn.transform.position, hamSpawn.transform.rotation);
                            hamInterval = maxInterval;
                        }
                    }
                }
                else
                {
                    myRigidbody.velocity = new Vector3(0, 0, 0);
                    gameObject.GetComponent<Animator>().enabled = false;
                }
            }
            else
            {
                myRigidbody.velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
