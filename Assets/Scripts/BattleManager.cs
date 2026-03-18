using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;

    [Header("UI Reference")]
    public TMPro.TextMeshProUGUI testoDialogo;
    public GameObject menuMosse;
    public GameObject menuPrincipale;
    public Button[] bottoniMosse;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPokemons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPokemons()
    {
        string playerPokemon = BattleData.Instance.playerPokemon;
        string enemyPokemon = BattleData.Instance.enemyPokemon;

        PokemonData playerPrefab = Resources.Load<PokemonData>("Pokemons/"+playerPokemon);
        PokemonData enemyPrefab = Resources.Load<PokemonData>("Pokemons/"+enemyPokemon);

        if(playerPrefab != null && enemyPrefab != null)
        {
            GameObject p = Instantiate(playerPrefab.modelloPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);

            GameObject e = Instantiate(enemyPrefab.modelloPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);

            Debug.Log("Battaglia iniziata tra " + playerPokemon + " e " + enemyPokemon);

            for(int i = 0; i<bottoniMosse.Length; i++)
            {
                if(i < playerPrefab.mosseDisponibili.Count)
                {
                    bottoniMosse[i].gameObject.SetActive(true);
                    bottoniMosse[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playerPrefab.mosseDisponibili[i].nomeMossa;
                }
                else
                {
                    bottoniMosse[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("Errore: uno dei prefab non è stato trovato in resources/pokemons");
        }

    }

    public void MostraMosse()
    {
        menuPrincipale.SetActive(false);
        menuMosse.SetActive(true);
    }
}
