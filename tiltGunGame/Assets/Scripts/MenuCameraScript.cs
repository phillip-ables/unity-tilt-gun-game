﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour {
    public Transform shopWayPoint;
    public Transform levelWayPoint;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    private void Start()
    {
        startPosition = desiredPosition = transform.localPosition;
        startRotation = desiredRotation = transform.rotation;

        transform.position = new Vector3(0, 3.8f, -3.4f);
        transform.rotation = new Quaternion(0,0,0,0);
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, 0.1f);
        transform.localRotation = Quaternion.Lerp(transform.rotation, desiredRotation, 0.1f);
    }

    public void BackToMainMenu()
    {
        desiredPosition = startPosition;
        desiredRotation = startRotation;
    }

    public void Init()
    {
        MoveToShop();
    }

    public void MoveToShop()
    {
        desiredPosition = shopWayPoint.localPosition;
        desiredRotation = shopWayPoint.localRotation;
    }

    public void MoveToLevel()
    {
        desiredPosition = levelWayPoint.localPosition;
        desiredRotation = levelWayPoint.localRotation;
    }
}
