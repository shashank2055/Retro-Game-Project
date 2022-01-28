using UnityEngine;
using UnityEngine.UI; 

public class VolumeControl : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; 
    void Start()
    {
        if (!PlayerPrefs.HasKey("AudioClip"))   
        {
            PlayerPrefs.SetFloat("AudioClip", 1);   
            Load();              
        }
        else                  
        {
            Load();            
        }
    }

    public void ChangeVolume()       
    {
        AudioListener.volume = volumeSlider.value;      
        Save();             
    }                        

    private void Load()       
    {
        volumeSlider.value = PlayerPrefs.GetFloat("AudioClip");   
    }                          

    private void Save()       
    {
        PlayerPrefs.SetFloat("AudioClip", volumeSlider.value);    
    }                
}
