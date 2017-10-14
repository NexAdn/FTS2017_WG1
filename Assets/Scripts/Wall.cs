using UnityEngine;

public class Wall : MonoBehaviour
{
    public int HealthLevel = 3;
    public GameObject WallParticles;
    public void OnTriggerEnter(Collider collider)
    {
       if (collider.tag == "Axe")
       {
            Damage(collider.gameObject.GetComponent<Axe>().speed);
       }
    }

    private void Damage(float axeSpeed)
    {
        Debug.Log(axeSpeed);

        if (HealthLevel > 1)
        {
            if (axeSpeed >= 0.02f)
            {
                HealthLevel -= 1;

                GetComponent<MeshRenderer>().material = Resources.Load("breakableWall_" + HealthLevel) as Material;
            }    
        }
        else
        {
            gameObject.SetActive(false);
            WallParticles.GetComponent<ParticleSystem>().Play();
           
        }
    }
    
} 
