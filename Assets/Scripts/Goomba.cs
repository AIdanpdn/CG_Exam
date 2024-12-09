using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    [SerializeField] GameObject spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Enter");
            bool isFrozen = true;

            if (isFrozen == true)
            {
                rb.constraints = RigidbodyConstraints.None;
                isFrozen = false;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                isFrozen = true;
            }
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.back * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            this.transform.position = spawnPoint.transform.position;
        }
    }

}
