using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private PlayerStats playerInfo;
    [SerializeField]
    private CardStats cardInfo;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text cardName;
    [SerializeField]
    private Text cost;
    [SerializeField]
    private bool canDrag;
    [SerializeField]
    private Vector3 posicion;

    public PlayerStats PlayerInfo
    {
        get { return playerInfo; }
        set { playerInfo = value; }
    }
    public CardStats CardInfo
    {
        get { return cardInfo; }
        set { cardInfo = value; }
    }
    public Image Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public Text CardName
    {
        get { return cardName; }
        set { cardName = value; }
    }
    public Text Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!playerInfo.OnDragging)
        {
            if (canDrag)
            {
                GetComponent<CanvasGroup>().blocksRaycasts = false;
                playerInfo.OnDragging = true;
                playerInfo.SpawnZone = true;
                transform.SetParent(GameFunctions.GetCanvas());
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (playerInfo.OnDragging)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;

        if(go != null)
        {
            if (go == playerInfo.LeftArea && playerInfo.LeftZone)
            {
                SpawnUnit();
            }
            else if (go == playerInfo.RightArea && playerInfo.RightZone)
            {
                SpawnUnit();
            }
        } else
        {
            SpawnUnit();
        }

        transform.SetParent(playerInfo.HandParent);
        playerInfo.OnDragging = false;
        playerInfo.SpawnZone = false;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void SpawnUnit()
    {
        if(playerInfo.GetCurrResource >= cardInfo.Cost)
        {
            playerInfo.PlayersDeck.RemoveHand(cardInfo.Index);
            playerInfo.RemoveResource(cardInfo.Cost);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                //GameFunctions.SpawnUnit(cardInfo.Prefab, playerInfo.UnitTransform, raycastHit.point);
                Instantiate(cardInfo.Prefab, raycastHit.point, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        icon.sprite = cardInfo.Icon;
        cardName.text = cardInfo.Name;
        cost.text = cardInfo.Cost.ToString();
    }

}
