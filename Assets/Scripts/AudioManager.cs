using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Manager Config")]
    public static AudioManager instance;

    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource laserShot;
    [SerializeField] private AudioSource spaceshipExplosion;
    [SerializeField] private AudioSource meteorShot;
    [SerializeField] private AudioSource bonusPickup;
    [SerializeField] private AudioSource shieldDown;
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource selectButton;
    [SerializeField] private AudioSource startButton;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Handle different Audio Sources
    public void PlayBackgroundMusic() {  backgroundMusic.Play(); }

    public void StopBackgroundMusic() { backgroundMusic.Stop(); }

    public void PauseBackgroundMusic() { backgroundMusic.Pause(); }

    public void UnPauseBackgroundMusic() { backgroundMusic.UnPause(); }

    public void PlayLaserShot() { laserShot.Play(); }

    public void PlaySpaceshipExplosion() { spaceshipExplosion.Play(); }

    public void PlayMeteorShot() {  meteorShot.Play(); }

    public void PlayBonusPickup() {  bonusPickup.Play(); }

    public void StopBonusPickup() { bonusPickup.Stop(); }

    public void PlayShieldDown() {  shieldDown.Play(); }

    public void PlayMenuMusic() {  menuMusic.Play(); }

    public void StopMenuMusic() { menuMusic.Stop(); }

    public void PlaySelectButton() { selectButton.Play(); }

    public void PlayStartButton() { startButton.Play(); }
}
