using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public AudioSource AudioSource1;
    public AudioSource AudioSource2;
    public AudioClip AuWin;
    public AudioClip AuLose;

    public GameObject TorreR_E;
    public GameObject TorreR_A;

    public GameObject TorreD_E;
    public GameObject TorreD_A;

    public GameObject TorreI_E;
    public GameObject TorreI_A;


    private void Awake()
    {
        
        if (instance != this)
            instance = this;
    }

    void Start()
    {
        AudioSource1 = Camera.main.GetComponent<AudioSource>();
        AudioSource2 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Con esto cuenta el nº de Torres aliadas y enemigas del campo
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

        //Si el tiempo es 0 y el numero de torres aliadas es mayor a las enemigas, pues pasa a la pantalla de victoria
        if (timeValue == 0 && TowersAllie > TowersEnemy)
        {
            SceneManager.LoadSceneAsync(5);
        } else
        {
            //Si el tiempo es 0 y el numero de torres enemigas es mayor a las aliadas, pues pasa a la pantalla de game over
            if (timeValue == 0 && TowersAllie < TowersEnemy)
            {
                SceneManager.LoadSceneAsync(4);
            }
        }

        //Si  el numero de torres enemigas es menor o igual a 0 , pues pasa a la pantalla de victoria
        if (TowersEnemy <= 0)
        {
           SceneManager.LoadSceneAsync(5);
        }

        //Si  el numero de torres aliadas es menor o igual a 0 , pues pasa a la pantalla de game over
        if (TowersAllie <= 0)
        {
            SceneManager.LoadSceneAsync(4);
        }

        //Si el tiempo es 0 y el numero de torres enemigas es igual a las aliadas, pues pasa a la pantalla de empate
        if (timeValue == 0 && TowersAllie == TowersEnemy)
        {
           SceneManager.LoadSceneAsync(6);
        }
    }

    //Esto es un temporizador
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

    //Con esto adquiere una lista de enemigos y los guarda
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

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public static void AddObject(GameObject go)
    {
        Instance.Objects.Add(go);
    }
}
