using UnityEngine;
using System.Collections;

public class FusePickUp : MonoBehaviour {

    GameManager _gameManager;

    public AudioClip pickUpClip;

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameManager.lightManager.AddFuse();
            float destroyTimer = (pickUpClip != null) ? pickUpClip.length : 0;
            Destroy(gameObject, destroyTimer);
        }
    }
}
