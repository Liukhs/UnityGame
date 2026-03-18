using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    private bool isOn = false;

    public GameObject menu;
    private int scelteEffettuate;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleComputer()
    {
        isOn = !isOn;
        if (!menu.activeSelf)
        {
            menu.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
            
        }
    }
    
    public void ChiudiMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void SelezionaPokemon(string nome)
    {
        if(scelteEffettuate == 0)
        {
            BattleData.Instance.playerPokemon = nome;
            Debug.Log("Hai scelto: " + nome);
            scelteEffettuate++;
        }else if(scelteEffettuate == 1)
        {
            BattleData.Instance.enemyPokemon = nome;
            Debug.Log("Nemico scelto: " + nome);

            AvviaBattaglia();
        }
    }
    public void AvviaBattaglia()
    {
        if(string.IsNullOrEmpty(BattleData.Instance.playerPokemon) || string.IsNullOrEmpty(BattleData.Instance.enemyPokemon))
        {
            return;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("scenaBattaglia");

    }
}
