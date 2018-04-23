﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSpeedControl2 : MonoBehaviour {

    [SerializeField] float gameSpeed = 1;
    [SerializeField] Text tutorialText;
    [SerializeField] string tutorialString;

    Rigidbody2D rgb;

    bool isStop = false;
    [SerializeField] bool canControlAfterDestroy;

    void Start()
    {
        rgb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        tutorialText.text = tutorialString;
        tutorialText.text = tutorialText.text.Replace("\\n", "\n");
        rgb.isKinematic = true;
        Time.timeScale = gameSpeed;
        isStop = true;
    }


    void Update()
    {
        if (isStop && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            tutorialText.text = "";
            World.Instance.SetControl(canControlAfterDestroy);
            rgb.isKinematic = false;
            Destroy(gameObject);
        }
    }

}
