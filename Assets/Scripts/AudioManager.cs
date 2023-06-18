using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxMenu;
    [SerializeField] AudioSource sfxStep;

    public void SfxBtn()
    {
        sfxMenu.Play();
    }

    public void SfxStep()
    {
        sfxStep.Play();
    }

    public void SfxStepStop()
    {
        sfxStep.Stop();
    }
}
