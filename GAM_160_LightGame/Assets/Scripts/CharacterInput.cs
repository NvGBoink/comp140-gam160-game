using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class CharacterInput : MonoBehaviour {

    public KeyCode sneakKey = KeyCode.LeftShift;

    CharacterMotor charMotor;
    MouseRotation mouseRotation;
    FlashLight flashLight;

    //Find the ardunio if it is on communication port 3, if it's not this needs to be changed
    SerialPort sp = new SerialPort("COM3", 9600); 

    float deadZone = 0.5f; //Dead zone stops input for being picked up from the analog stick if it's either side of 512
    float chargeInput = 0;
    float crankValue = 0;
    float prevFrameCrankValue = 0; //Previous frame value is used to check if the value is different from the previous frame
    float horInput = 0, verInput = 0;
    bool isCranking = false;
    bool toggleLight = false;


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
            float hor = 0;
            float ver = 0;

            float horDiff = horInput - 507;
            if (horInput > 507f + deadZone || horInput < 507f - deadZone) //Dead zone
            {
                hor = horDiff / 507;
            }

            float verDiff = verInput - 514;
            if (verInput > 514f + deadZone || verInput < 514f - deadZone) //Dead zone
            {
                ver = verDiff / 514;
            }

            mouseRotation.ReciveInput(-hor, -ver);
        }

        if (flashLight != null)
        {
            isCranking = (crankValue != prevFrameCrankValue);
            chargeInput = isCranking ? 5f : 0;
            crankValue = prevFrameCrankValue;

            flashLight.ReciveInput(chargeInput, toggleLight);
        }

        //Ardunio
        if (sp.IsOpen) //Is the port open ?
        {
            string inputData = ""; 

            try
            {
                inputData = sp.ReadLine(); //Store the line
            }
            catch (System.Exception)
            {

            }

            if (inputData == "") // If no line was found we can not continue
                return;

            char iD = inputData[0]; //Get the first character from the line, this is the tag and will tell us what to use the data for
            float newValue = float.Parse(inputData.Substring(1)); //Remove the tag

            switch (iD)
            {
                case 'C':
                    crankValue = newValue;
                    break;
                case 'B':
                    toggleLight = (newValue == 1) ? true : false;
                    break;
                case 'H':
                    horInput = newValue;
                    break;
                case 'V':
                    verInput = newValue;
                    break;
            }
        }
    }
}
