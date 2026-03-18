using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private float offsetZ = 5f;
    private float offsetY = 2.5f;
    private float sensitivity = 500f;
    private float xRotation = 18.0f;
    private float yRotation;

    public GameObject player;
    public float horizontalMouse;
    public float verticalMouse;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 targetPoint = player.transform.position + Vector3.up * offsetY;
        transform.position = targetPoint - (Quaternion.Euler(xRotation, yRotation, 0) * Vector3.forward * offsetZ);
        transform.position = new Vector3(player.transform.position.x, 5, player.transform.position.z - offsetZ);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        horizontalMouse = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; 
        verticalMouse = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        yRotation += horizontalMouse;
        xRotation -= verticalMouse;

        xRotation = Mathf.Clamp(xRotation, -30f, 60f);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0); 

        // QUI LA MODIFICA: Invece di sottrarre dalla posizione del player (piedi),
        // sottraiamo dalla posizione del player + l'altezza (testa/centro)
        Vector3 targetPoint = player.transform.position + Vector3.up * offsetY;
        Vector3 position = targetPoint - (rotation * Vector3.forward * offsetZ);
        
        transform.rotation = rotation;
        transform.position = position;
        
    }
}
