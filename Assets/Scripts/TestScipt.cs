using UnityEngine;

public class TestScipt : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputReader.MoveEvent += InputReader_MoveEvent;
    }

    private void InputReader_MoveEvent(Vector2 obj)
    {
        Debug.Log(obj + "the movement is working");
    }
    private void OnDisable()
    {
        inputReader.MoveEvent -= InputReader_MoveEvent;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
