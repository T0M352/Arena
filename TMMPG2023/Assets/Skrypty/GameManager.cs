using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RectTransform hitpointBar1;
    public RectTransform hitpointBar2;
    public RectTransform staminaBar1;
    public RectTransform staminaBar2;
    public RectTransform UltBar1;
    public RectTransform UltBar2;
    public Image UltSprite1;
    public Image UltSprite2;

    public List<Sprite> ultSprites;

    public PlayerOne player; 
    public PlayerOne player2;
    public static Transform transformP1;
    public static Transform transformP2;
    public static Vector3 posP1;
    public static Vector3 posP2;

    public static int ClassP1 = 0;
    public static int ClassP2 = 0;

    public PlayerOne P1Knight;
    public PlayerOne P1Barb;
    public PlayerOne P1Thief;
    public PlayerOne P1Mage;
    public PlayerOne P2Knight;
    public PlayerOne P2Barb;
    public PlayerOne P2Thief;
    public PlayerOne P2Mage;

    public static int PlayerOneLives = 3;
    public static int PlayerTwoLives = 3;

    public static bool respawnPlayerOne = false;
    public static bool respawnPlayerTwo = false;

    public GameObject[] lives;

    public Text deathText;
    public GameObject deathMenu;

    public static Vector2 fireballDir;

    public GameObject holeP1;
    public GameObject holeP2;
    public static int dungeonMode = 0;

    public Camera mainCamera;
    public Camera mainCamera2;
    public Camera dungCamera1;
    public Camera dungCamera2;

    public GameObject screenSplitter;

    public Transform respawnDungModeP1;
    public Transform respawnDungModeP2;

    public Transform respawnPostDungModeP1;
    public Transform respawnPostDungModeP2;

    public static int diamondsP1 = 0;
    public static int diamondsP2 = 0;
    public GameObject diamondShowP1;
    public GameObject diamondShowP2;
    public Text diamondAmountP1;
    public Text diamondAmountP2;

    public GameObject floatingText;
    public GameObject KnightUltPS;

    public Transform ULTBarbarian1;
    public Transform ULTBarbarian2;

    public static int controlSettings = 0;
    public static int PlayerChoose = 0;
    public static int escMenu = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dungCamera1.enabled = false;
        dungCamera2.enabled = false;
        if (ClassP1 == 1)
        {
            var Player = GameObject.Instantiate(P1Knight);
            Player.name = P1Knight.name;
            player = Player;
            UltSprite1.sprite = ultSprites[0];

        }
        else if( ClassP1 == 2)
        {

            var Player = GameObject.Instantiate(P1Barb);
            Player.name = P1Barb.name;
            player = Player;
            UltSprite1.sprite = ultSprites[1];
        }

        else if (ClassP1 == 3)
        {

            var Player = GameObject.Instantiate(P1Thief);
            Player.name = P1Thief.name;
            player = Player;
            UltSprite1.sprite = ultSprites[2];
        }

        else if (ClassP1 == 4)
        {

            var Player = GameObject.Instantiate(P1Mage);
            Player.name = P1Mage.name;
            player = Player;
            UltSprite1.sprite = ultSprites[3];
        }

        if (ClassP2 == 1)
        {
            var Player = GameObject.Instantiate(P2Knight);
            Player.name = P2Knight.name;
            player2 = Player;
           UltSprite2.sprite = ultSprites[0];
        }
        else if (ClassP2 == 2)
        {
            var Player = GameObject.Instantiate(P2Barb);
            Player.name = P2Barb.name;
            player2 = Player;
            UltSprite2.sprite = ultSprites[1];
        }
        else if (ClassP2 == 3)
        {

            var Player = GameObject.Instantiate(P2Thief);
            Player.name = P2Thief.name;
            player2 = Player;
            UltSprite2.sprite = ultSprites[2];
        }

        else if (ClassP2 == 4)
        {

            var Player = GameObject.Instantiate(P2Mage);
            Player.name = P2Mage.name;
            player2 = Player;
            UltSprite2.sprite = ultSprites[3];
        }

    }


    //pasek zdrowia
    public void OnHitpointChange()
    {
        float skala = (float)player.hitPoint / player.maxHitPoint;
        hitpointBar1.localScale = new Vector3(skala, 1, 1);
        float skala2 = (float)player2.hitPoint / player2.maxHitPoint;
        hitpointBar2.localScale = new Vector3(skala2, 1, 1);
    }

    private void FixedUpdate()
    {


        if (player != null && player2 != null)
        {
            posP1 = player.transform.position;
            posP2 = player2.transform.position;
            transformP1 = player.transform;
            transformP2 = player2.transform;
        }
        else
        {
            posP1 = Vector3.zero;
            posP2 = Vector3.zero;
            transformP1 = transform;
            transformP2 = transform;
        }


        if (dungeonMode == 2)
        {
            screenSplitter.SetActive(true);
            mainCamera.enabled = false;
            dungCamera1.enabled = true;
            dungCamera2.enabled = true;
        }

        if (dungeonMode == 3)
        {
            screenSplitter.SetActive(false);
            dungCamera1.enabled = false;
            dungCamera2.enabled = false;
            mainCamera2.enabled = true;
        }
    }

    private void Update()
    {


        

        float skala = (float)player.stamina / player.maxStamina;
        staminaBar1.localScale = new Vector3(skala, 1, 1);
        float skala2 = (float)player2.stamina / player2.maxStamina; 
        staminaBar2.localScale = new Vector3(skala2, 1, 1);

        float skala3 = (float)player.ultTimer / 100f; 
        UltBar1.localScale = new Vector3(1, skala3, 1);
        float skala4 = (float)player2.ultTimer / 100f; 
        UltBar2.localScale = new Vector3(1, skala4, 1);

        float skala5 = (float)player.hitPoint / player.maxHitPoint;
        hitpointBar1.localScale = new Vector3(skala5, 1, 1);
        float skala6 = (float)player2.hitPoint / player2.maxHitPoint;
        hitpointBar2.localScale = new Vector3(skala6, 1, 1);



        if (PlayerOneLives == 0)
        {
            escMenu = 2;
            deathMenu.SetActive(true);
            deathText.text = "Gracz 2 wygrywa";
        }else if (PlayerOneLives == -1)
        {
            escMenu = 2;
            deathMenu.SetActive(true);
            deathText.text = "Gracz 2 wygrywa";
        }


        if (PlayerTwoLives == 0)
        {
            escMenu = 2;
            deathMenu.SetActive(true);
            deathText.text = "Gracz 1 wygrywa";
        }
        else if (PlayerTwoLives == -1)
        {
            escMenu = 2;
            deathMenu.SetActive(true);
            deathText.text = "Gracz 1 wygrywa";
        }

        diamondAmountP1.text = diamondsP1.ToString();
        diamondAmountP2.text = diamondsP2.ToString();
        if (dungeonMode == 2)
        {
            diamondShowP1.SetActive(true);
            diamondShowP2.SetActive(true);
        }
        else
        {
            diamondShowP1.SetActive(false);
            diamondShowP2.SetActive(false);
        }

        if(escMenu == 0)
        {
            deathMenu.SetActive(false);
        }
        else if(escMenu == 1)
        {
            deathMenu.SetActive(true);
            deathText.text = "Czy chcesz powrocic do menu?";
        }

    }

    void LateUpdate()
    {
        if (respawnPlayerOne == true)
        {
            respawnPlayerOne = false;
            Respawn(1);
        }

        if (respawnPlayerTwo == true)
        {
            respawnPlayerTwo = false;
            Respawn(2);
        }

        if ((PlayerOneLives < 3 || PlayerTwoLives < 3) && dungeonMode == 0)
        {
            Vector3 pos1 = player.gameObject.transform.position - new Vector3(0, 0.15f);
            Instantiate(holeP1, pos1, Quaternion.identity);
            Vector3 pos2 = player2.gameObject.transform.position - new Vector3(0, 0.15f);
            Instantiate(holeP2, pos2, Quaternion.identity);
            dungeonMode = 1;
        }
    }

    public void classP1(int clas)
    {
        ClassP1 = clas;
    }
    public void classP2(int clas)
    {
        ClassP2 = clas;
    }

    private void Respawn(int n) 
    {
        
        if (n == 1)
        {
            PlayerOneLives -= 1;
            if (ClassP1 == 1)
            {
                
                var Player = GameObject.Instantiate(P1Knight);
                Player.name = P1Knight.name;
                player = Player;
                UltSprite1.sprite = ultSprites[0];
                if (dungeonMode == 2)
                    player.transform.position = respawnDungModeP1.position;
                if (dungeonMode == 3)
                    player.transform.position = respawnPostDungModeP1.position;

            }
            else if (ClassP1 == 2)
            {

                var Player = GameObject.Instantiate(P1Barb);
                Player.name = P1Barb.name;
                player = Player;
                UltSprite1.sprite = ultSprites[1];
                if (dungeonMode == 2)
                    player.transform.position = respawnDungModeP1.position;
                if (dungeonMode == 3)
                    player.transform.position = respawnPostDungModeP1.position;
            }
            else if (ClassP1 == 3)
            {

                var Player = GameObject.Instantiate(P1Thief);
                Player.name = P1Thief.name;
                player = Player;
                UltSprite1.sprite = ultSprites[2];
                if (dungeonMode == 2)
                    player.transform.position = respawnDungModeP1.position;
                if (dungeonMode == 3)
                    player.transform.position = respawnPostDungModeP1.position;
            }

            else if (ClassP1 == 4)
            {

                var Player = GameObject.Instantiate(P1Mage);
                Player.name = P1Mage.name;
                player = Player;
                UltSprite1.sprite = ultSprites[3];
                if (dungeonMode == 2)
                    player.transform.position = respawnDungModeP1.position;
                if (dungeonMode == 3)
                    player.transform.position = respawnPostDungModeP1.position;
            }
        }
        else if (n == 2) 
        {
            PlayerTwoLives -= 1;
            if (ClassP2 == 1)
            {
                var Player = GameObject.Instantiate(P2Knight);
                Player.name = P2Knight.name;
                player2 = Player;
                UltSprite2.sprite = ultSprites[0];
                if (dungeonMode == 2)
                    player2.transform.position = respawnDungModeP2.position;
                if (dungeonMode == 3)
                    player2.transform.position = respawnPostDungModeP2.position;
            }
            else if (ClassP2 == 2)
            {
                var Player = GameObject.Instantiate(P2Barb);
                Player.name = P2Barb.name;
                player2 = Player;
                UltSprite2.sprite = ultSprites[1];
                if (dungeonMode == 2)
                    player2.transform.position = respawnDungModeP2.position;
                if (dungeonMode == 3)
                    player2.transform.position = respawnPostDungModeP2.position;
            }
            else if (ClassP2 == 3)
            {

                var Player = GameObject.Instantiate(P2Thief);
                Player.name = P2Thief.name;
                player2 = Player;
                UltSprite2.sprite = ultSprites[2];
                if (dungeonMode == 2)
                    player2.transform.position = respawnDungModeP2.position;
                if (dungeonMode == 3)
                    player2.transform.position = respawnPostDungModeP2.position;
            }

            else if (ClassP2 == 4)
            {

                var Player = GameObject.Instantiate(P2Mage);
                Player.name = P2Mage.name;
                player2 = Player;
                UltSprite2.sprite = ultSprites[3];
                if (dungeonMode == 2)
                    player2.transform.position = respawnDungModeP2.position;
                if (dungeonMode == 3)
                    player2.transform.position = respawnPostDungModeP2.position;
            }
        }
        removeLives();
    }

    private void removeLives()
    {
        if(PlayerOneLives == 2)
        {
            Destroy(lives[0]);
        }else if(PlayerOneLives == 1)
        {
            Destroy(lives[1]);
        }else if (PlayerOneLives == 0)
        {
            Destroy(lives[2]);
        }

        if (PlayerTwoLives == 2)
        {
            Destroy(lives[3]);
        }
        else if (PlayerTwoLives == 1)
        {
            Destroy(lives[4]);
        }
        else if (PlayerTwoLives == 0)
        {
            Destroy(lives[5]);
        }
    }

    public void ShowText(Vector3 position, string text)
    {
        var Text = Instantiate(floatingText, position, Quaternion.identity);
        Text.SendMessage("enterText", text);
    }

}
