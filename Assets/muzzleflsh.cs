using UnityEngine;

public class muzzleflsh : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_ParticleSystem;
    [SerializeField]
    private InputReader m_InputReader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        m_InputReader.PrimaryFireEvent += fire; 
    }
    private void OnDisable()
    {
        m_InputReader.PrimaryFireEvent -= fire;
    }
    void fire()
    {
        m_ParticleSystem.Play();
    }
}
