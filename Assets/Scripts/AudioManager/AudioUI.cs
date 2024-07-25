using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public void ToogleMusic()
    {
        AudioManager.Instance.ToogleMusic();
    }

    public void ToogleSfx()
    {
        AudioManager.Instance.ToogleSfx();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SfxVolume()
    {
        AudioManager.Instance.SfxVolume(_sfxSlider.value);
    }
}
