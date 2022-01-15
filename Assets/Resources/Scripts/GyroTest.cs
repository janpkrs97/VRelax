using UnityEngine;

public class GyroTest : MonoBehaviour
{
    Gyroscope m_Gyro;

    void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
    }
}