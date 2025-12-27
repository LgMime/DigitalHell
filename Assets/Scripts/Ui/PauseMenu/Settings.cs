using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settingsMenu;
    public Slider _volumeSlider;
    public AudioListener audioListener;

    private void Start()
    {
        // При старте игры ставим ползунок в положение текущей громкости
        // AudioListener.volume по умолчанию = 1
        if (_volumeSlider != null)
        {
            _volumeSlider.value = AudioListener.volume;
        }
    }
    

    public void CloseSettings()
    {

        settingsMenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    
}
