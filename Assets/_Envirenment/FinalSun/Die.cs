﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

    [SerializeField] Animator player, bat;

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player")  {
            player.SetTrigger("Die");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            bat = GameObject.FindGameObjectWithTag("Bat").GetComponentInChildren<Animator>();
            StartCoroutine("BatRush");


        }

        if(other.tag == "Bat") {
            bat.SetTrigger("Die");
		}

    }

	IEnumerator BatRush() {
        yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("Bat").GetComponent<Rigidbody2D>().isKinematic = false;
	}
}
