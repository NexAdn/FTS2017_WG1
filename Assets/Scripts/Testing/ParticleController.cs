using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public KeyCode triggerKey;

    // Use this for initialization
    void Start()
    {
        //emitter = EmittingObject.GetComponent<ParticleSystem>();
        //EmittingObject.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(triggerKey))
        {
            GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(triggerKey))
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
