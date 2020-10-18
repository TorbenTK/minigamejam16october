using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource Sound;

    // Start is called before the first frame update
    private void Start()
    {
        Sound.Play();
    }
}