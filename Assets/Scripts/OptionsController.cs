using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else {
            Debug.LogWarning("No Music Player found.. did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
