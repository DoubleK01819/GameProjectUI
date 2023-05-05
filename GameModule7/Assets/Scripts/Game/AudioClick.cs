using UnityEngine;

public class AudioClick : MonoBehaviour
{
    [SerializeField] AudioSource m_Source;
    [SerializeField] private AudioClip clickButton;

    public void Audio()
    { 
        m_Source.PlayOneShot(clickButton);
    }
}
