﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTriggerEnd : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject Trigger;

    // Start is called before the first frame update
    void Start()
    {
        UIObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIObject.SetActive(true);
        }
    }


}
