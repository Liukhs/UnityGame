using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public enum BattleState {START, PLAYERTURN, ENEMYTURN, BUSY, WON, LOST, ENDTURN}
    public BattleState state;
    public BattleState lastState;
    [Header("Spawn Points")]
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;

    [Header("UI Reference")]
    public TMPro.TextMeshProUGUI testoDialogo;
    public GameObject menuMosse;
    public GameObject menuPrincipale;
    public Button[] bottoniMosse;
    public TMPro.TextMeshProUGUI nomePlayer;
    public TMPro.TextMeshProUGUI nomeEnemy;

    [Header("UI barre vita")]
    public Slider playerHB;
    public Slider enemyHB;
    private float playerHpAttuali;
    private float enemyHpAttuali;

    private PokemonData playerPrefab;
    private PokemonData enemyPrefab;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MostraMosse()
    {
        menuPrincipale.SetActive(false);
        menuMosse.SetActive(true);
        state = BattleState.PLAYERTURN;
        
        
    }
    public void OnMossaPremuta(int indiceMossa)
    {
        if(state == BattleState.PLAYERTURN)
        {
            StartCoroutine(SequenzaTurno(indiceMossa)); // Chiama il regista!
        }
    }
    IEnumerator SequenzaTurno(int indiceMossa)
    {
        state = BattleState.BUSY;
        menuMosse.SetActive(false);

        bool playerPrimo = playerPrefab.velocita >= enemyPrefab.velocita ? true : false;

        if (playerPrimo)
        {
            yield return StartCoroutine(PlayerAttacca(indiceMossa));
            if(enemyHpAttuali > 0)
            {
                yield return StartCoroutine(NemicoAttacca());
            }
        }
        else
        {
            yield return StartCoroutine(NemicoAttacca());
            if (playerHpAttuali > 0)
            {
                yield return StartCoroutine(PlayerAttacca(indiceMossa));
            }
        }
        if(playerHpAttuali > 0 && enemyHpAttuali > 0)
        {
            state = BattleState.PLAYERTURN;
            menuPrincipale.SetActive(true);
            testoDialogo.text = "Cosa farà " + playerPrefab.nome + "?";
        }
    }

    public void SetupBattle()
    {
        string playerPokemon = BattleData.Instance.playerPokemon;
        string enemyPokemon = BattleData.Instance.enemyPokemon;

        playerPrefab = Resources.Load<PokemonData>("Pokemons/"+playerPokemon);
        enemyPrefab = Resources.Load<PokemonData>("Pokemons/"+enemyPokemon);

        if(playerPrefab == null || enemyPrefab == null)
        {
            Debug.LogError("Errore: uno dei prefab non è stato trovato in resources/pokemons");
        }
        InizializzaStats();
        SpawnModelli();
        SetupBottoniMosse();
        state = BattleState.START;
        testoDialogo.text = "Cosa vuoi fare?";
    }

    public void InizializzaStats()
    {
        playerHpAttuali = playerPrefab.maxHP;
        enemyHpAttuali = enemyPrefab.maxHP;

        playerHB.maxValue = playerPrefab.maxHP;
        playerHB.value = playerHpAttuali;

        enemyHB.maxValue = enemyPrefab.maxHP;
        enemyHB.value = enemyHpAttuali;
        nomePlayer.text = playerPrefab.nome;
        nomeEnemy.text = enemyPrefab.nome;
    }

    public void SpawnModelli()
    {
        GameObject p = Instantiate(playerPrefab.modelloPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        GameObject e = Instantiate(enemyPrefab.modelloPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
    }

    public void SetupBottoniMosse()
    {
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

    IEnumerator PlayerAttacca(int indiceMossa)
    {

        MossaData mossa = playerPrefab.mosseDisponibili[indiceMossa];
        testoDialogo.text = playerPrefab.nome + " usa "+ mossa.nomeMossa;

        yield return new WaitForSeconds(1.5f);

        int danno = CalcolaDanno(mossa, playerPrefab, enemyPrefab);
        enemyHpAttuali = Mathf.Max(0, enemyHpAttuali - danno);
        enemyHB.value = enemyHpAttuali;


        if(enemyHpAttuali <= 0)
        {
            state = BattleState.WON;
            testoDialogo.text = enemyPrefab.nome + " è stato sconfitto!";
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator NemicoAttacca()
    {
        // IA semplicissima: sceglie una mossa a caso
        int randomMossa = Random.Range(0, enemyPrefab.mosseDisponibili.Count);
        MossaData m = enemyPrefab.mosseDisponibili[randomMossa];

        testoDialogo.text = enemyPrefab.nome + " nemico usa " + m.nomeMossa + "!";
        
        yield return new WaitForSeconds(1.5f);

        int danno = CalcolaDanno(m, enemyPrefab, playerPrefab);
        playerHpAttuali = Mathf.Max(0, playerHpAttuali - danno);
        playerHB.value = playerHpAttuali;


        if (playerHpAttuali <= 0) {
            state = BattleState.LOST;
            testoDialogo.text = playerPrefab.nome + " è esausto... hai perso!";
            yield return new WaitForSeconds(2f);
        } 
    }

    public int CalcolaDanno(MossaData mossa, PokemonData attaccante, PokemonData difensore)
    {
        float attacco;
        float difesa;
        if(mossa.categoria == MossaData.CategoriaMossa.FISICA)
        {
            attacco = attaccante.attacco;
            difesa = difensore.difesa;
        }
        else
        {
            attacco = attaccante.attSpe;
            difesa = difensore.difSpe;
        }

        float dannoBase = ((attacco / difesa) * mossa.potenza * 0.2f) + 2;
        dannoBase *= mossa.tipo == attaccante.tipoPrimario ? 1.5f : 1.0f;
        dannoBase *= mossa.tipo.GetEfficacia(difensore.tipoPrimario);

        float dannoFinale = dannoBase * Random.Range(0.85f, 1.0f);

        return (int) dannoFinale;
    }

}
