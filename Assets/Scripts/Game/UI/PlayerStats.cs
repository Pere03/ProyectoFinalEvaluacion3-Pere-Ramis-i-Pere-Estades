using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{       
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

        UpdateText();
        UpdateDeck();
    }

    void UpdateText()
    {
        textCurrResource.text = GetCurrResource.ToString();
        textMaxResource.text = (GameConstants.RESOURCE_MAX + 1).ToString();
        textScore.text = score.ToString();
    }
    
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
