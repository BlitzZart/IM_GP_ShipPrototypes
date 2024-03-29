﻿using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

    public KeyCode key;
    private Ship ship;

    private Rigidbody2D body;
    private GameObject afterBurner;
    private AudioSource audio;

    // Use this for initialization
    void Start() {
        body = GetComponent<Rigidbody2D>();
        ship = GetComponentInParent<Ship>();
        afterBurner = transform.GetChild(0).gameObject;
        afterBurner.SetActive(false);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(key)) {
            body.AddForce(transform.rotation * Vector3.up * ship.thrusterPower);
            afterBurner.SetActive(true);
        }
        else {
            afterBurner.SetActive(false);
        }

        if (Effects.Instance.effectsActive) {
            if (Input.GetKeyDown(key)) {
                audio.Play();
                CameraShake.Instance.StartPermaShake(0.13f);
            }
            else if (Input.GetKeyUp(key)) {
                audio.Stop();
                CameraShake.Instance.StopPermaShake();
            }
        }
    }
}