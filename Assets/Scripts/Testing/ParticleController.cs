using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public KeyCode triggerKey;
    public GameObject particleObject;

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
            //GetComponent<ParticleSystem>().Play();
            particleObject.SetActive(true);
            particleObject.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(triggerKey))
        {
            //GetComponent<ParticleSystem>().Stop();
            particleObject.GetComponent<ParticleSystem>().Stop();
            particleObject.SetActive(false);
        }
    }

    public void ToggleParticle(bool isOn)
    {
        if (isOn)
        {
            //particleObject.SetActive(true);
            particleObject.GetComponent<ParticleSystem>().Play();
            particleObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            particleObject.GetComponent<ParticleSystem>().Stop();
            //particleObject.SetActive(false);
            particleObject.GetComponent<Collider>().enabled = true;
        }
    }
}
