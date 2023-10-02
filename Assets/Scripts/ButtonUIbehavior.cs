using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUIbehavior : MonoBehaviour
{

    public Button yourButton;
    public GameObject toggleObject;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(ChangeObjectState);
    }

    void ChangeObjectState(){
                toggleObject.SetActive(!toggleObject.activeSelf);    }

    void ClickLog()
    {
        Debug.Log("Click");
    }
}
