using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private List<GameObject> objects;

    public GameObject Prefab;

    public static GameManager Instance { get { return instance; } }
    public List<GameObject> Objects { get { return objects; } }

    private int TowersEnemy;
    private int TowersAllie;
    public TextMeshProUGUI CoronasAllie;
    public TextMeshProUGUI CoronasEnemy;

    public TextMeshProUGUI temporizador;
    public float timeValue = 180;

    public static GameManager sharedInstance;

    public TextMeshProUGUI username;

    private void Awake()
    {
            if (sharedInstance == null)
            {
                sharedInstance = this;
            }
            else
            {
                Destroy(this);
            }
        
        if (instance != this)
            instance = this;
    }

    void Start()
    {
        ApplyUserOptions();
    }

    private void Update()
    {
        Spawn();

        TowersAllie = FindObjectsOfType<TorresAllie>().Length;
        TowersEnemy = FindObjectsOfType<TorresEnemy>().Length;

        CoronasAllie.text = TowersAllie.ToString();
        CoronasEnemy.text = TowersEnemy.ToString();

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        temporizador.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ApplyUserOptions()
    {
        username.text = DataPersistence.sharedInstance.saveName;
    }

    public static List<GameObject> GetAllEnemies(Vector3 pos, List<GameObject> objects, string tag, float range)
    {
        List<GameObject> sentObjects = new List<GameObject>();

        foreach (GameObject g in objects)
        {
            if(!g.CompareTag(tag) && Vector3.Distance(pos, g.transform.position) <= range)
            {
                sentObjects.Add(g);
            }
        }
        return sentObjects;
    }

    public static List<GameObject> GetAllEnemies(Vector3 pos, List<GameObject> objects, string tag)
    {
        List<GameObject> sentObjects = new List<GameObject>();

        foreach (GameObject g in objects)
        {
            if (!g.CompareTag(tag))
            {
                sentObjects.Add(g);
            }
        }
        return sentObjects;
    }

    public static void RemoveObjectsFromList(GameObject go)
    {
        foreach (GameObject g in Instance.Objects)
        {
            Component component = g.GetComponent(typeof(IDamageable));
            if((component as IDamageable).HitTargets.Contains(go))
            {
                (component as IDamageable).HitTargets.Remove(go);
                if((component as IDamageable).Target == go)
                {
                    (component as IDamageable).Target = null;
                }
            }
        }

        Instance.Objects.Remove(go);
    }

    public static void AddObject(GameObject go)
    {
        Instance.Objects.Add(go);
    }

    public void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Prefab, new Vector3(9,0,5), transform.rotation);
        }
    }


}
