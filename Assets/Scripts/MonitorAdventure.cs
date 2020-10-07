using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MonitorAdventure : MonoBehaviour
{
    bool loaded = false;
    bool started = false;
    
    private enum States
    {
        loading,
        loaded,
        started,
        spelVinden,
        inGame,
        lonelyLodge,
        junkJunction,
        jJWait,
        lLStorm,
        lLHide,
        ending1,
        ending2
    }

    private States currentState = States.loading;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCor(StartupAnimation());
    }

    void OnUserInput(string input)
    {
        bool didCommand = false;
        switch (currentState)
        {
            case States.loading:
                didCommand = true; //als loading geen error message
                break;
                
            case States.loaded:
                if (input == "START")
                {
                    StartCor(StartFunc());
                    didCommand = true;
                }
                break;
            
            case States.started:
                if (input == "1337")
                {
                    StartCor(Secret1337());
                    didCommand = true;
                } else if (input == "Quit")
                {
                    StartCor(QuitFortnite());
                    didCommand = true;
                } else if (input == "Play")
                {
                    StartCor(FindingGame());
                    didCommand = true;
                }
                break;
            
            case States.spelVinden:
                if (input == "Yes")
                {
                    StartCor(YesJoinGame());
                    didCommand = true;
                }else if (input == "No")
                {
                    StartCor(NoDontJoinGame());
                    didCommand = true;
                }
                break;
            
            case States.inGame:
                if (input == "Tilted Towers")
                {
                    StartCor(TiltedTowers());
                    didCommand = true;
                }else if (input == "Lonely Lodge")
                {
                    StartCor(LonelyLodge());
                    didCommand = true;
                }else if (input == "Paradise Palms")
                {
                    StartCor(ParadisePalms());
                    didCommand = true;
                }else if (input == "Pleasant Park")
                {
                    StartCor(PleasantPark());
                    didCommand = true;
                }else if (input == "Junk Junction")
                {
                    StartCor(JunkJunction());
                    didCommand = true;
                }
                break;
            
            case States.junkJunction:
                if (input == "Wait")
                {
                    StartCor(JJWait());
                    didCommand = true;
                }else if (input == "Move")
                {
                    StartCor(JJMove());
                    didCommand = true;
                }
                break;
            
            case States.jJWait:
                if (input == "Jump")
                {
                    StartCor(JJJump());
                    didCommand = true;
                }else if (input == "Snipe")
                {
                    StartCor(JJSnipe());
                    didCommand = true;
                }
                break;
                
            case States.lonelyLodge:
                if (input == "Stay")
                {
                    StartCor(LLStay());
                    didCommand = true;
                }else if (input == "Run")
                {
                    StartCor(LLRun());
                    didCommand = true;
                }
                break;
            
            case States.lLStorm:
                if (input == "Hide")
                {
                    StartCor(LLHide());
                    didCommand = true;
                }else if (input == "Aggresive")
                {
                    StartCor(LLAggresive());
                    didCommand = true;
                }
                break;
            
            case States.lLHide:
                if (input == "Scar")
                {
                    StartCor(LLScar());
                    didCommand = true;
                }else if (input == "Build")
                {
                    StartCor(LLBuild());
                    didCommand = true;
                }
                break;
            
            case States.ending1:
                break;
            case States.ending2:
                break;
            
            default:
                WriteL("Wat? hoe kom je hier?");
                break;
        }

        if (input == "Restart")
        {
            ClearS();
            currentState = States.loading;
            StartCor(StartupAnimation());
        }
        else if (!didCommand) //als je geen commando invult
        {
            WriteL("Unknown command.");
        }
    }

    IEnumerator LLScar()
    {
        WriteL("Je schiet...");
        
        yield return new WaitForSeconds(1.5f);
        
        WriteL("Je hebt gewonnen");
        
        yield return new WaitForSeconds(.5f);
        
        currentState = States.ending2;
    }

    IEnumerator LLBuild()
    {
        WriteL("Je bouwt omhoog");
        
        yield return new WaitForSeconds(1.5f);
        
        WriteL("De andere speler maakt de\nonderkant kapot en je valt");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Je bent dood");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator LLHide()
    {
        WriteL("Er is nog een andere over");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Scar / Build");

        currentState = States.lLHide;
    }
    IEnumerator LLAggresive()
    {
        WriteL("Je speelt aggresief");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Te aggresief");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Je bent dood");
        
        yield return new WaitForSeconds(.5f);
        RestartGame();
    }
    IEnumerator LLRun()
    {
        WriteL("Je rent naar het midden van de storm");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Verstop je in een bos of\nspeel aggresief");
        WriteL("");
        WriteL("Hide / Aggresive");

        currentState = States.lLStorm;
    }
    IEnumerator LLStay()
    {
        WriteL("Je blijft zoeken naar legendaries");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Je bent dood gegaan in de storm");
        
        yield return new WaitForSeconds(1f);
        
        RestartGame();
    }
    IEnumerator JJJump()
    {
        WriteL("Je springt omlaag");
        
        yield return new WaitForSeconds(1.5f);
        
        WriteL("Je bent dood");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator JJSnipe()
    {
        WriteL("Je schiet...");
        
        yield return new WaitForSeconds(1.5f);
        
        WriteL("Je hebt gewonnen");
        
        yield return new WaitForSeconds(.5f);
        
        currentState = States.ending1;
        RestartGame();
    }
    IEnumerator JJWait()
    {
        WriteL("Je bouwt omhoog");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Er is maar een speler over en die kan je niet vinden");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Jump / Snipe ?");

        currentState = States.jJWait;
    }
    IEnumerator JJMove()
    {
        WriteL("Je verandert van plek");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Je loopt de storm in en gaat dood");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator TiltedTowers()
    {
        WriteL("Je land in Tilted Towers");
        
        yield return new WaitForSeconds(.5f);
        
        for(int i = 0; i < 16; i++)
        {
            int option = Mathf.RoundToInt(Random.Range(0, 4));

            if (option == 0)
            {
                WriteL("Pew");
            }else if (option == 1)
            {
                WriteL("Paf");
            }else if (option == 2)
            {
                WriteL("Poef");
            }else if (option == 3)
            {
                WriteL("Boem");
            }else if (option == 4)
            {
                WriteL("Pief");
            }
            yield return new WaitForSeconds(.2f);
        }
        
        yield return new WaitForSeconds(.5f);
        
        ClearS();
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Je bent dood");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator LonelyLodge()
    {
        WriteL("Je bent in Lonely Lodge");

        yield return new WaitForSeconds(1f);
        
        WriteL("De storm gaat weg, wat doe je?");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Stay / Run");

        currentState = States.lonelyLodge;
    }
    IEnumerator ParadisePalms()
    {
        WriteL("Paradise Palms is niet een paradise");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Je bent uit de lucht geschoten");
        
        yield return new WaitForSeconds(1f);
        
        RestartGame();
    }
    IEnumerator PleasantPark()
    {
        WriteL("Pleasant Park is niet zo pleasant");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("Je bent uit de lucht geschoten");
        
        yield return new WaitForSeconds(1f);
        
        RestartGame();
    }
    IEnumerator JunkJunction()
    {
        WriteL("Je bent in Junk Junction");
        
        yield return new WaitForSeconds(1f);
        
        WriteL("De storm gaat naar jouw toe, wat doe je?");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Wait / Move");
        
        currentState = States.junkJunction;
    }
    IEnumerator NoDontJoinGame()
    {
        WriteL("Geen fortnite dan");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator YesJoinGame()
    {
        WriteL("Drop where?");
        
        yield return new WaitForSeconds(.5f);
        WriteL("");
        
        yield return new WaitForSeconds(.1f);
        
        WriteL("Tilted Towers");
        
        yield return new WaitForSeconds(.1f);
        
        WriteL("Lonely Lodge");
        
        yield return new WaitForSeconds(.1f);
        
        WriteL("Paradise Palms");
        
        yield return new WaitForSeconds(.1f);
        
        WriteL("Pleasant Park");
        
        yield return new WaitForSeconds(.1f);
        
        WriteL("Junk Junction");

        currentState = States.inGame;
    }
    IEnumerator FindingGame()
    {
        WriteL("Finding game...");
        
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 13; i++) //13 wow eng
        {
            if (i % 3 == 0)
            {
                WriteL("Finding game.");
            }else if (i % 3 == 1)
            {
                WriteL("Finding game..");
            }else if (i % 3 == 2)
            {
                WriteL("Finding game...");
            }

            yield return new WaitForSeconds(.2f);
        }
        
        WriteL("Found game");
        WriteL("Join? Yes/No");

        currentState = States.spelVinden;
    }
    IEnumerator QuitFortnite()
    {
        WriteL("Geen fortnite dan");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    IEnumerator Secret1337()
    {
        WriteL("STOP");
        
        yield return new WaitForSeconds(.5f);
        
        Application.Quit();
        RestartGame(); //voor het geval dat het niet quit
    }
    IEnumerator StartFunc()
    {
        WriteL("Je start fortnite op");
        
        yield return new WaitForSeconds(.5f);
        
        WriteL("Play of Quit?");
        
        currentState = States.started;
    }

    IEnumerator ExitGame()
    {
        WriteL("Exit");
        
        yield return new WaitForSeconds(.5f);
        
        RestartGame();
    }
    void RestartGame()
    {
        WriteL("");
        WriteL("Type 'Restart' to restart");
    }
    void ShowMainMenu()
    {
        ClearS();
        WriteL("Welcome $USER$ bij fortnite");
        WriteL("Type START om te beginnen");
    }

    // Kortere versies
    void WriteL(string line)
    {
        Terminal.WriteLine(line);
    }
    void ClearS()
    {
        Terminal.ClearScreen();
    }
    void StartCor(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

    //startup load "animation"
    IEnumerator StartupAnimation()
    {
        WriteL("Starting");

        yield return new WaitForSeconds(1f);

        WriteL("Loading");

        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < 13; i++) //13 wow eng
        {
            if (i % 3 == 0)
            {
                ClearS();
                WriteL("Loading.");
            }
            else if (i % 4 == 1)
            {
                ClearS();
                WriteL("Loading..");
            }
            else if (i % 4 == 2)
            {
                ClearS();
                WriteL("Loading...");
            }

            yield return new WaitForSeconds(.25f);
        }

        WriteL("Fortnite");

        yield return new WaitForSeconds(1f);

        currentState = States.loaded;
        ShowMainMenu();
    }
}
