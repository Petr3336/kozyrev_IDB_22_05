using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    public Text Healthbar;
    string BaseText = "Здоровье: ";
    uint health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Healthbar.text = BaseText.ToString() + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollision(uint damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        Healthbar.text = BaseText.ToString() + health.ToString();
    }

}
