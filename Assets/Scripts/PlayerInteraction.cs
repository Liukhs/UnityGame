using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private float sphereRadius = 2.0f;
    public LayerMask interactableLayer;
    public GameObject visualHint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.forward;
        Vector3 origin = (transform.position + Vector3.up) - (direction * 2.0f);
        RaycastHit hit;
        float totalDistance = interactionDistance + 2.0f;
        

        if(Physics.SphereCast(origin, sphereRadius, direction, out hit, totalDistance, interactableLayer))
        {
            Computer scriptComputer = hit.collider.GetComponent<Computer>();

            if(scriptComputer != null)
            {
                if(visualHint != null)
                {
                    visualHint.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    scriptComputer.ToggleComputer();
                }
            }
           
        } else
            {
                if(visualHint != null)
                {
                    visualHint.SetActive(false);
                }
            }
        Debug.DrawRay(origin, direction * interactionDistance, Color.cyan);
        
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Vector3 origin = transform.position + Vector3.up;
        Vector3 direction = Camera.main.transform.forward;
        
        // Disegna una linea e una sfera alla fine per capire l'area di contatto
        Gizmos.DrawRay(origin, direction * interactionDistance);
        Gizmos.DrawWireSphere(origin + direction * interactionDistance, sphereRadius);
    }
}
