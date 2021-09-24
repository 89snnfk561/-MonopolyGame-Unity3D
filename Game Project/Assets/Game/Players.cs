using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Players : MonoBehaviour
{
    [Header("Player")] 
    public List<Transform> PlayerList = new List<Transform>();
    public List<Transform> player = new List<Transform>();
    public PlayerState[] playerStates;
    [Space]

    [Header("Boss")]
    public Transform TBoss;
    public Boss boss;

    [Space]

    [Header("Camera")]
    public List<Transform> TCPs = new List<Transform>();
    public Transform MainCamera;
    public Transform DICECamera;
    public Transform MAPCamera;
    public Route currentRoute;
    int[] routePosition;

    [Space]

    [Header("Text&UI")]
    public List<Button> Buttons = new List<Button>();
    public Transform Panel;
    public Text[] texts;
    public Canvas BlockCanvas;

    [Space]

    [Header("Var")]
    int steps;
    bool isMoving;
    int current = 0;
    int next = 0;
    int dead_count = 0;
    bool Endturn = true;

    string[] PlayerName =
    {
        "忒修斯",
        "阿里阿德涅",
        "代達洛斯",
        "伊卡洛斯"
    };

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9
     };


    private void Start()
    {
        playerStates = new PlayerState[GameData.PlayerCount];
        routePosition = new int[GameData.PlayerCount];
        

        for (int i = 0; i < GameData.PlayerCount; i++)
        {
            playerStates[i] = PlayerState.finish;
            routePosition[i] = 0;
            
        }

        

        for (int i = GameData.PlayerCount; i < PlayerList.Count; i++)
        {
            PlayerList[i].gameObject.SetActive(false);
        }

    }
    private void Update()
    {
        Player playerdata = player[current].GetComponent<Player>();
        if (Endturn)
        {

            

            Endturn = false;

            next += 1;
            next %= GameData.PlayerCount;

            while (playerStates[next] == PlayerState.dead)
            {
                next += 1;
                next %= GameData.PlayerCount;
            }
            
            playerStates[current] = PlayerState.start;
        }


        playerdata = player[current].GetComponent<Player>();
        Buttons[2].Select();

        Buttons[0].onClick.AddListener(Roll);
        Buttons[1].onClick.AddListener(EndTurn);
        

        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && !isMoving && playerStates[current] == PlayerState.start && playerdata.GetStop() <= 0)
            {
                Cheat(i+1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            foreach (Text T in texts)
            {
                T.gameObject.SetActive(true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            
            foreach (Text T in texts)
            {
                T.gameObject.SetActive(false);
            }
        }
        if(playerdata.GetStop() > 0)
        {
            Buttons[0].gameObject.SetActive(false);
            Buttons[1].gameObject.SetActive(true);
        }

        if (GameData.DiceRollEnd && !isMoving && playerStates[current] == PlayerState.start && playerdata.GetStop() <= 0)
        {
            MainCamera.gameObject.SetActive(true);
            GameData.DiceRollEnd = false;
            steps = GameData.steps;
            Debug.Log("Dice Rolled " + steps);
            StartCoroutine(Move());
        }

        
    }

    private void LateUpdate()
    {
        UpdateUI();
        
    }
    IEnumerator Wait(int n)
    {
        yield return new WaitForSeconds(n);
    }
    IEnumerator Move()
    {
        Player playerdata = player[current].GetComponent<Player>();
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        yield return new WaitForSeconds(1);
        while (steps > 0)
        {
            if(routePosition[current] == 0 && GameData.turn > GameData.PlayerCount)
            {
                currentRoute.childNodeList[routePosition[current]].SendMessage("pass", playerdata);
            }

            if (!playerdata.IsWalk())
            {
                playerdata.Walk();
            }
            routePosition[current]++;
            routePosition[current] %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition[current]].position;

            Vector3 vec = new Vector3(nextPos.x, PlayerList[current].position.y, nextPos.z);
            

            while (MoveToNextNode(nextPos)) { yield return null; }

            
            yield return new WaitForSeconds(0.1f);
            steps--;
        }
        if(steps == 0)
        {
            playerdata.Stop();
            playerStates[current] = PlayerState.finish;

            //格子效果
            
            currentRoute.childNodeList[routePosition[current]].SendMessage("calculate", playerdata);
            BlockCanvas.gameObject.SetActive(true);

            while (GameData.isPause)
            {
                yield return new WaitForSeconds(1);
            }

            if(GameData.BlockEffectNum == 6)
            {
                boss.AckAttack();
                yield return new WaitForSeconds(1);
                TBoss.transform.position = player[current].position + player[current].forward * 20f;
                TBoss.transform.LookAt(player[current].position);
                boss.Stop();
                boss.AckRoar();
                yield return new WaitForSeconds(4);
                boss.Stop();
                yield return new WaitForSeconds(2);
                boss.Back();
            }
            




            if (playerdata.GetHP() <= 0)
            {

                playerStates[current] = PlayerState.dead;
                playerdata.Dead();
                yield return new WaitForSeconds(5);
                dead_count++;
                if (dead_count >= GameData.PlayerCount)
                {
                    GameEnd();
                }
            }



            if (GameData.BossHP <= 0) 
            {
                GameData.Victory = true;
                GameEnd();
            }
            
            Buttons[1].gameObject.SetActive(true);
        }

        isMoving = false;
        
    }
    
    void Roll()
    {
        if (Buttons[0] && !isMoving && playerStates[current] == PlayerState.start)
        {
            DICECamera.gameObject.SetActive(true);
            MainCamera.gameObject.SetActive(false);
            GameData.DiceRollStart = true;
            Buttons[0].gameObject.SetActive(false);
        }
    }
    void Cheat(int n)
    {
        if (Buttons[0] && !isMoving && playerStates[current] == PlayerState.start)
        {
            GameData.steps = n;
            steps = n;
            Buttons[0].gameObject.SetActive(false);
            Debug.Log("cheating steps " + steps);
            StartCoroutine(Move());
        }
    }
    void EndTurn()
    {
        Player playerdata = player[current].GetComponent<Player>();
        if (Endturn == false)
        {
            playerdata = player[current].GetComponent<Player>();

            if (playerdata.GetToxic() > 0)
            {
                int NewHP = playerdata.GetHP() - 50;
                if (NewHP < 1) NewHP = 1;
                playerdata.SetHP(NewHP);
            }
            if (playerdata.GetToxic() > 0 || playerdata.GetStop() > 0)
            {
                playerdata.SetKeep(playerdata.GetToxic() - 1, playerdata.GetStop() - 1);
            }
            GameData.turn = GameData.turn + 1;
            Debug.Log(GameData.turn);
        }
        TCPs[current].gameObject.SetActive(false);
        TCPs[next].gameObject.SetActive(true);
        current = next;

        Buttons[0].gameObject.SetActive(true);
        Buttons[1].gameObject.SetActive(false);
        
        Endturn = true;
        GameData.BlockEffectDescription = "";
        GameData.BlockEffect = "";
    }

    void UpdateUI()
    {
        Player playerdata = player[current].GetComponent<Player>();
        texts[0].text = "Now Playing P" + (current+1) +"\n\n";
        texts[0].text += "Name: " + playerdata.Name() + "\n";
        texts[0].text += "       " + playerdata.GetHP() + " / 1000\n";
        texts[0].text += "       " + playerdata.GetATK() +"\n";
        texts[0].text += "       " + playerdata.Getmoney() +"\n";


        texts[1].text = "Block No. " + (routePosition[current]) + "\n";
        texts[1].text += "Type: " + GameData.BlockEffect + "\n\n\n";
        texts[1].text += GameData.BlockEffectDescription + "\n\n";

        int UIcount = 0;
        for (int i = 0; i < GameData.PlayerCount; i++)
        {
            if(routePosition[current] == routePosition[i] && i != current)
            {
                texts[1].text += "P"+ (i+1) + ",  ";
                UIcount++;
            }
        }
        if(UIcount > 0)
        {
            texts[1].text += "\n on the same block.\n";
        }


    }
    bool MoveToNextNode(Vector3 goal)
    {
        PlayerList[current].LookAt(goal);
        return goal != (PlayerList[current].position = Vector3.MoveTowards(PlayerList[current].position, goal, GameData.speed * Time.deltaTime));
    }

    void GameEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    
}
