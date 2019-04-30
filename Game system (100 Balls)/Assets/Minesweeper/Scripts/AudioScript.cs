﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip MusicClip;

    public AudioSource MusicSource;


	// Use this for initialization
	void Start () {
        MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Left Click is pressed");
            MusicSource.Play();
    }
}