using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    public Light flashLight;
    public float maxCharge = 100;
    public float chargeRate = 1f;
    public float powerUsageRate = 0.5f;
    public float torchAngle = 60;
    public float torchRange = 10;

    [HideInInspector]
    public float charge = 100;
    bool isOn = false;
    bool hasCharge = false;


    public void Awake()
    {
        if (flashLight == null)
        {
            Debug.Log("Found no light component for flash light, please set one.");
        }
    }

    public void ReciveInput(float chargeInput, bool buttonState)
    {
        isOn = buttonState;

        if (chargeInput > 0) //Make sure we can't remove power if the crank is being turned backwards
        {
            charge += (chargeInput * chargeRate) * Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
        }

        flashLight.spotAngle = torchAngle;
        flashLight.range = torchRange;

        ChangeLightState();
    }

    void ChangeLightState()
    {
        flashLight.enabled = isOn;
    }

    void Update()
    {
        hasCharge = (charge > 0);

        if (isOn && hasCharge)
        {
            charge -= powerUsageRate * Time.deltaTime;

            CheckForEnemy();
        }
        else if(!hasCharge)
        {
            isOn = false;
            ChangeLightState();
        }
    }

    void CheckForEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, torchRange);

        foreach (Collider c in cols)
        {
            if (c.tag == "Enemy")
            {
                if ((torchAngle / 2) >= Vector3.Angle(transform.forward, c.gameObject.transform.position - transform.position))
                {
                    Vector3 direction = c.gameObject.transform.position - transform.position;
                    Ray ray = new Ray(flashLight.transform.position, direction);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit, torchRange))
                    {
                        if (hit.collider.tag == "Enemy")
                        {
                            hit.collider.GetComponent<EnemyAI>().Stun();
                        }
                    }
                }
            }
        }
    }
}
