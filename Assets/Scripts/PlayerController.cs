using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float runningSpeed = 10.0f;
    private float xBound = 24.0f;
    private float zBound = 23.0f;
    private Rigidbody playerRd;
    public Transform mainCamera;
    private Animator playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRd = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
        ConstrainPlayerPos();
        
    }

    //Moves the player based on input
    void MovePlayer()
    {
        //Prendiamo gli assi orizzontale e verticale per muovere il personaggio   
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //Creiamo le variabili che prendono la direzione della camera
        Vector3 camForward = mainCamera.forward;
        Vector3 camRight = mainCamera.right;

        //appiattiamo il vettore delle due camere(in modo che il personaggio non possa andare verso l'alto guardando in alto) e normalizziamo
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        
        //creiamo la direzione in cui si dovrà muovere il personaggio usando la rotazione della camera e creando il vettore che ci guiderà
        Vector3 moveDirection = (camForward * verticalInput) + (camRight * horizontalInput);

        //aggiungiamo la forza di movimento del giocatore utilizzando il vettore appena creato e lo moltiplichiamo per la velocità del personaggio
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRd.AddForce(moveDirection * runningSpeed);
            playerAnim.SetFloat("Speed_f", 1f);
        }
        else
        {
            playerRd.AddForce(moveDirection * speed);
            playerAnim.SetFloat("Speed_f", 0.5f);
        }
        
        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0f);
        }
        
    }
    //Impedisci al giocatore di cadere dal piano
    void ConstrainPlayerPos()
    {
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }
}
