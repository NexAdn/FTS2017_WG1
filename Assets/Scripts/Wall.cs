using UnityEngine;

public class Wall : MonoBehaviour
{
    public int HealthLevel = 4;

    public void OnTriggerEnter(Collider collider)
    {
       if (collider.tag == "Axe")
       {
            var axeRigidbody = collider.gameObject.GetComponent<Rigidbody>();

            Damage(axeRigidbody.velocity.magnitude);
       }
    }

    private void Damage(float axeSpeed)
    {
        if (HealthLevel > 1)
        {
            if (axeSpeed >= 0f)
            {
                Debug.Log("Damage " + axeSpeed);

                HealthLevel -= 1;
                Debug.Log(HealthLevel);

                GetComponent<MeshRenderer>().material = Resources.Load("breakableWall_" + HealthLevel) as Material;
            }    
        } else
        {
            gameObject.SetActive(false);
        }
    }
}
