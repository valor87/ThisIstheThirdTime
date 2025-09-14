using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Ports;
public class TestingArduino : MonoBehaviour
{
   SerialPort data_stream = new SerialPort("COM6", 19200);
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data_stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string recivedstring = data_stream.ReadLine();
        int positionchange = int.Parse(recivedstring);

        Debug.Log(recivedstring);

        Vector2 pos = transform.position;

        pos.x = positionchange - 5;
        transform.position = pos;
    }
}
