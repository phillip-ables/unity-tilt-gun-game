using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour {
    public Transform shopWayPoint;
    public Transform levelWayPoint;

    private ManagerScript manager;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    private void Start()
    {
        startPosition = desiredPosition = transform.localPosition;
        startRotation = desiredRotation = transform.localRotation;

        transform.localPosition = new Vector3(0, 3.8f, -3.4f);
        transform.localRotation = new Quaternion(0,0,0,0);

        manager = FindObjectOfType<ManagerScript>();
    }

    private void Update()
    {
        float x = manager.GetPlayerInput().x;

        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition + new Vector3(0, x, 0) * 0.01f, 0.1f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, 0.1f);
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
