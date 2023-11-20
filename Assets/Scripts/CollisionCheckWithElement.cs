using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheckWithElement : MonoBehaviour
{
    public GameObject Element;
    public GameObject CheckCollisionElement;

    public GameObject Healthbar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == CheckCollisionElement)
        {
            Healthbar.GetComponent<HealthBehavior>().OnCollision(1);
        }
    }
    /* private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == CheckCollisionElement)
        {
            Debug.Log("CEx");
        }
    } */
    /* private void OnCollisionStay(Collision collision) {
        if (collision.gameObject == CheckCollisionElement)
        {
            Debug.Log("CS");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TE");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TEx");
    } */

}
