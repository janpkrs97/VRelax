using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject GyroControl;
    private Quaternion rot;
    private Quaternion adjustrot;

    private void Start()
    {
        GyroControl = new GameObject("Gyro Control");
        GyroControl.transform.position = transform.position;
        transform.SetParent(GyroControl.transform);
        gyroEnabled = EnableGyro();
        adjustrot = Quaternion.Euler(90f, 0f, 0f) * Quaternion.Inverse(gyro.attitude);
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            GyroControl.transform.rotation = Quaternion.Euler(90f, -90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    public void ResetView()
    {
        adjustrot = Quaternion.Euler(90f, 0f, 0f) * Quaternion.Inverse(gyro.attitude);
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            if (Input.touchCount == 3)
            {
                adjustrot = Quaternion.Euler(90f, 0f, 0f) * Quaternion.Inverse(gyro.attitude);
            }
            transform.localRotation = adjustrot * gyro.attitude * rot;
        }
    }
}
