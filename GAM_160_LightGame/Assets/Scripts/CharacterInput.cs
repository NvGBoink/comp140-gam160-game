using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class CharacterInput : MonoBehaviour {

    public KeyCode sneakKey = KeyCode.LeftShift;
    public KeyCode flashLightKey = KeyCode.Mouse0;

    CharacterMotor charMotor;
    MouseRotation mouseRotation;
    FlashLight flashLight;

    SerialPort sp = new SerialPort("COM3", 9600);
    float prevFrameCrankValue = 0;
    float chargeInput = 0;
    bool toggleLight = false;
    bool isCranking = false;

    void Awake()
    {
        charMotor = GetComponent<CharacterMotor>();
        mouseRotation = GetComponent<MouseRotation>();
        flashLight = GetComponent<FlashLight>();
    }

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        if (charMotor != null)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            bool isSneaking = Input.GetKey(sneakKey);

            charMotor.ReciveInput(hor, ver, isSneaking);
        }

        if (mouseRotation != null)
        {
            float hor = Input.GetAxis("Mouse X");
            float ver = Input.GetAxis("Mouse Y");

            mouseRotation.ReciveInput(hor, ver);
        }

        if (flashLight != null)
        {
            chargeInput = isCranking ? 0.1f : 0;

            flashLight.ReciveInput(chargeInput, toggleLight);
        }

        //Ardunio
        if (sp.IsOpen)
        {
            string inputData = "";

            try
            {
                inputData = sp.ReadLine();
            }
            catch (System.Exception)
            {

            }

            if (inputData == "")
                return;

            //Debug.Log(inputData);

            char iD = inputData[0];
            float newValue = float.Parse(inputData.Substring(1));

            switch (iD)
            {
                case 'C':
                    isCranking = (newValue != prevFrameCrankValue);
                    Debug.Log(newValue);
                    prevFrameCrankValue = newValue;
                    break;
                case 'B':
                    toggleLight = (newValue == 1) ? true : false;
                    break;
            }
        }
    }
}
