using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] buttonPress;
    public AudioClip[] buttonRelease;
    public AudioClip[] mousePress;
    public AudioClip radarHum;
    public AudioClip lightOn;
    public AudioClip radarSave;
    public AudioClip[] saveMessage;

    public AudioSource mySource;
    public AudioSource secondSource;

    public float buttonVolume;
    public float radarVolume;
    public float lightVolume;
    public float saveVolume;
    public float mouseVolume;
    public float saveMessageVolume;
    public float endSoundVolume;

    public AudioClip endSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEndSound() {
        mySource.volume = endSoundVolume;
        mySource.clip = endSound;
        mySource.Play();
    }

    public void PlayButtonPress()
    {
        int randSound = Random.Range(0, buttonPress.Length);
        mySource.volume = buttonVolume;
        mySource.clip = buttonPress[randSound];
        mySource.Play();
    }

    public void PlayButtonRelease()
    {
        int randSound = Random.Range(0, buttonRelease.Length);
        mySource.volume = buttonVolume;
        mySource.clip = buttonRelease[randSound];
        mySource.Play();
    }

    public void PlayRadar()
    {
        mySource.volume = radarVolume;
        mySource.clip = radarHum;
        mySource.Play();
    }

    public void PlayLight()
    {
        mySource.volume = lightVolume;
        mySource.clip = lightOn;
        mySource.Play();
    }

    public void PlaySave()
    {
        secondSource.volume = saveVolume;
        secondSource.clip = radarSave;
        secondSource.Play();
    }

    public void PlayMouse()
    {
        int randClip = Random.Range(0, mousePress.Length);
        secondSource.volume = mouseVolume;
        secondSource.clip = mousePress[randClip];
        secondSource.Play();
    }

    public void SaveMessage()
    {
        int randClip = Random.Range(0, saveMessage.Length);
        mySource.volume = saveMessageVolume;
        mySource.clip = saveMessage[randClip];
        mySource.Play();
    }

    public void StopSource()
    {
        mySource.Stop();
    }

    public IEnumerator FadeSource()
    {
        float currentTime = 0;
        float start = mySource.volume;
        while(currentTime < 5f)
        {
            currentTime += Time.deltaTime;
            mySource.volume = Mathf.Lerp(start, 0, currentTime);
            if(mySource.volume <= 0)
            {
                yield break;
            }
            yield return null;
        }
        yield break;
    }

}