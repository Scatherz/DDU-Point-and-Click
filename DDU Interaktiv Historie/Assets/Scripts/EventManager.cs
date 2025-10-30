using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioSource soundEffectAudioSource;
    public Image jumpscareImage;
    public List<Light> lights;
    public List<AudioClip> audioClips;
    public int maxNumberOfEvents;
    int currentNumberOfEvents;
    public float timeBetweenEvents;
    public bool screenLightsOn = true;
    public bool roomLightsOn = true;
    public bool tired = false;

    void Start()
    {
        backgroundAudioSource.Play();
        StartCoroutine(Event());
        TurnOffLampLight();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Jumpscare());
        }
    }

    public IEnumerator Event()
    {
        currentNumberOfEvents++;

        int randomNr = Random.Range(0, 3);

        switch (randomNr)
        {
            case 0:
                TurnOffScreenLights();
                break;
            case 1:
                TurnOffLampLight();
                break;
            case 2:
                BeTired();
                break;
        };


        yield return new WaitForSeconds(timeBetweenEvents);
        
        if(currentNumberOfEvents < maxNumberOfEvents)
        {
            StartCoroutine(Event());
        }
    }

    public IEnumerator Jumpscare()
    {
        backgroundAudioSource.Stop();
        soundEffectAudioSource.volume = 0.75f;
        foreach (Light light in lights)
        {
            light.gameObject.SetActive(false);
        }

        soundEffectAudioSource.PlayOneShot(audioClips[3]);

        yield return new WaitForSeconds(3);

        soundEffectAudioSource.volume = 1;
        soundEffectAudioSource.PlayOneShot(audioClips[5]);
        jumpscareImage.gameObject.SetActive(true);
    }

    public void TurnOffScreenLights()
    {
        Debug.Log("TurnOffScreenLight");
        screenLightsOn = false;
        foreach (Light light in lights)
        {
            if (light.gameObject.CompareTag("ScreenLight"))
            {
                light.gameObject.SetActive(false);
            }
        }

        soundEffectAudioSource.PlayOneShot(audioClips[0]);
    }

    public void TurnOnScreenLights()
    {
        Debug.Log("TurnOnScreenLight");
        screenLightsOn = true;
        foreach (Light light in lights)
        {
            if (light.gameObject.CompareTag("ScreenLight"))
            {
                light.gameObject.SetActive(true);
            }
        }

        soundEffectAudioSource.PlayOneShot(audioClips[1]);
    }

    public void TurnOffLampLight()
    {
        Debug.Log("TurnOffLampLight");
        roomLightsOn = false;
        foreach (Light light in lights)
        {
            if (light.gameObject.CompareTag("RoomLight"))
            {
                light.gameObject.SetActive(false);
            }
        }

        soundEffectAudioSource.PlayOneShot(audioClips[4]);
    }

    public void TurnOnLampLight()
    {
        Debug.Log("TurnOnLampLight");
        roomLightsOn = true;
        foreach (Light light in lights)
        {
            if (light.gameObject.CompareTag("RoomLight"))
            {
                light.gameObject.SetActive(true);
            }
        }

        soundEffectAudioSource.PlayOneShot(audioClips[4]);
    }
    
    public void BeTired()
    {
        Debug.Log("BeTired");
        soundEffectAudioSource.PlayOneShot(audioClips[6]);
        tired = true;
    }

    public void DrinkCoffee()
    {
        tired = false;
        soundEffectAudioSource.PlayOneShot(audioClips[2]);
    }
}
