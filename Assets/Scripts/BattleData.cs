using UnityEngine;

public class BattleData : MonoBehaviour
{
    public static BattleData Instance;

    public string playerPokemon;
    public string enemyPokemon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
