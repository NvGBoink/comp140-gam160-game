using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    GameManager _gameManager;

    public List<AudioClip> scareSounds = new List<AudioClip>();

    void Awake()
    {
        _gameManager = GeneralMethods.GetGameManager();
    }

    public void PlayJumpScareSound()
    {
        if (scareSounds.Count > 0)
        {
            int rnd = Random.Range(0, scareSounds.Count);
            SpawnAudioSource(scareSounds[rnd], Vector3.zero, false);
        }
        else
        {
            Debug.Log("Could not find any jump scare sounds");
        }
    }

    public void SpawnAudioSource(AudioClip clip, Vector3 pos, bool is3D)
    {
        GameObject newObject = new GameObject(clip.name + " Source");
        newObject.transform.position = pos;

        AudioSource aS = newObject.AddComponent<AudioSource>();
        aS.playOnAwake = false;
        aS.loop = false;
        aS.spatialBlend = is3D ? 1 : 0;
        aS.clip = clip;

        aS.Play();

        Destroy(newObject, clip.length);
    }
}
