using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{       
    //Con esto creamos todas las variables para hacer la funcion del player, del mazo, las zona enemiga y de la barra de elixir
    [SerializeField]
    private Deck playersDeck;

    [SerializeField]
    private List<Image> resources;

    [SerializeField]
    private int score;

    [SerializeField]
    private float currResource;

    [SerializeField]
    private Text textCurrResource;

    [SerializeField]
    private Text textMaxResource;

    [SerializeField]
    private Text textScore;

    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private Transform handParent;

    [SerializeField]
    private Card nextCard;

    [SerializeField]
    private bool onDragging;

    [SerializeField]
    private Transform unitTransform;

    [SerializeField]
    private bool spawnZone;

    [SerializeField]
    private GameObject rightArea;

    [SerializeField]
    private GameObject leftArea;

    [SerializeField]
    private bool rightZone;

    [SerializeField]
    private bool leftZone;


    public Transform UnitTransform
    {
        get { return unitTransform; }
        set { unitTransform = value; }
    }

    public bool OnDragging
    {
        get { return onDragging; }
        set { onDragging = value; }
    }

    public Deck PlayersDeck
    {
        get { return playersDeck; }
    }

    public List<Image> Resources
    {
        get { return resources; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public Text TextCurrResource
    {
        get { return textCurrResource; }
    }

    public Text TextMaxResource
    {
        get { return textMaxResource; }
    }

    public Text TextScore
    {
        get { return textScore; }
    }

    public float CurrResource
    {
        get
        {
            return currResource;
        }
        set
        {
            currResource = value;
        }
    }   

    public int GetCurrResource
    {
        get
        {
            return (int)currResource; 
        }
    }

    public bool SpawnZone
    {
        get { return spawnZone; }
        set { spawnZone = value; }
    }

    public GameObject RightArea
    {
        get { return rightArea; }
        set { rightArea = value; }
    }
    public GameObject LeftArea
    {
        get { return leftArea; }
        set { leftArea = value; }
    }

    public bool RightZone
    {
        get { return rightZone; }
        set { rightZone = value; }
    }

    public bool LeftZone
    {
        get { return leftZone; }
        set { leftZone = value; }
    }
    public Transform HandParent
    {
        get { return handParent; }
        set { HandParent = value; }
    }

    private void Start()
    {
        playersDeck.Start();
    }

    private void Update()
    {
        //Barra de elixir funcionamineto
        if(GetCurrResource < GameConstants.RESOURCE_MAX + 1)
        {
            resources[GetCurrResource].fillAmount = currResource - GetCurrResource;
            currResource += Time.deltaTime * GameConstants.RESOURCE_SPEED;
        }


        if (spawnZone)
        {
            leftArea.SetActive(!leftZone ? true : false);
            rightArea.SetActive(!rightZone ? true : false);
        } 
        else
        {
            leftArea.SetActive(false);
            rightArea.SetActive(false);
        }

        UpdateText();
        UpdateDeck();
    }

    void UpdateText()
    {
        textCurrResource.text = GetCurrResource.ToString();
        textMaxResource.text = (GameConstants.RESOURCE_MAX + 1).ToString();
        textScore.text = score.ToString();
    }
    
    //Esto hace que se actualice en todo momento los valores que le hemos asignado en la carta a nuestro mazo
    void UpdateDeck()
    { 
        if(playersDeck.Hand.Count < GameConstants.MAX_HAND_SIZE)
        {
            CardStats cs = playersDeck.DrawCard();
            GameObject go = Instantiate(cardPrefab, handParent);
            Card c = go.GetComponent<Card>();
            c.PlayerInfo = this;
            c.CardInfo = cs;
        }

        nextCard.CardInfo = playersDeck.NextCard;
        nextCard.PlayerInfo = this;
    }

    public void RemoveResource(int cost)
    {
        //Esto hace, que si lanzamos una carta al juego, que remueva el coste de elixir de esa carta a la barra de elixir
        currResource -= cost;
        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].fillAmount = 0;
            if (i <= GetCurrResource)
            {
                resources[i].fillAmount = 1;
            }
        }
    }
  }
