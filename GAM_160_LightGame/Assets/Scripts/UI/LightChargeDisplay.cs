using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightChargeDisplay : MonoBehaviour {

    public Image chargeBar;

    GameManager _gameManager;
    FlashLight lightComponent;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    void Start()
    {
        lightComponent = _gameManager.playerManager.playerWorldReferance.GetComponent<FlashLight>();
    }

    void Update()
    {
        chargeBar.fillAmount = lightComponent.charge / lightComponent.maxCharge;
    }
}
