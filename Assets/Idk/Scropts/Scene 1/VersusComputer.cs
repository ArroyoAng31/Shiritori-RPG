using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersusComputer
{
    string word;
    char randChar;
    bool runOnce = false; // To show the start only once per enemy
    bool enterPressed = false; //Its to stop the while check loop from running without a word lol
    bool infiLoop = true;
    bool pTurn = true; //To change atk/def turns
    bool pauseCR = true; //To keep coroutines from running until player action

    //Was in the versus Method***************************************
    BotDifficultyFormula defeatCheck = new BotDifficultyFormula();
    System.Random rand = new System.Random();
    bool gameOver = false; //moved this into versusComp
    bool check = false; //used to check available usage of word && ALSO USED TO keep comp parts from looping when user input needs to be looped           
    int score = 0;
    int difficulty = 0;
    int playerWordSize;
    int compWordSize;
    double compHealth = 0;
    int compDamageTaken;
    double playerHealth = 10.0;
    double playerMP = 0.0;
    int playerDamageTaken;
    //********************************************************
    PlayerClass playerClass = new PlayerClass();
    ClassInUse classCheck = new ClassInUse();
    private string currentClassUsed;

    EnemyTypes enemy = new EnemyTypes();
    RandomEnemy randomizeEnemy = new RandomEnemy();
    SkillRequirementCheck skillChecks = new SkillRequirementCheck();
    //**************************************************************************************************


    public void WordReceived(string j) //Method to recieve typed word//Used in ShiritoriRpg
    {
        word = j;
    }


    public IEnumerator versus(DictionaryEx.DictionaryUse sm, Player player, MonoBehaviour mono) //MonoBehaviour to be able to use Coroutine
    {
        //PlayerClass and skills being called (should place into own class lol)
        currentClassUsed = PlayerPrefs.GetString("SelectedClass", "Swordsman");
        playerClass = classCheck.PlayerClassUsed(currentClassUsed);
        playerHealth = playerClass.getHealthValue();
        playerMP = playerClass.getMPValue();
        skillChecks.PassiveOrActive(playerClass);

        while (infiLoop)
        {

            score = player.getScore(); //set score to the player's score

            if (!runOnce)
            {
                CompText.FindObjectOfType<CompText>().startTxt(score);

                randChar = (char)(97 + rand.Next(26));

                enemy = randomizeEnemy.RandomEnemyChoosen(score);
                compHealth = enemy.getEnemyHealthValue();
                Debug.Log(enemy.getEnemyName());

                UpperBoxText.FindObjectOfType<UpperBoxText>().InitializingNames(playerClass.getClassName(), enemy.getEnemyName());
                UpperBoxText.FindObjectOfType<UpperBoxText>().HealthVisual(playerHealth, compHealth, playerClass.getHealthValue(), enemy.getEnemyHealthValue());
                UpperBoxText.FindObjectOfType<UpperBoxText>().CallingImages(playerClass.getclassSprite(), enemy.getEnemySprite());
                UpperBoxText.FindObjectOfType<UpperBoxText>().MPVisual(playerMP, playerClass.getMPValue());

                runOnce = true;
                gameOver = false;
                pTurn = true;
            }

            while (!gameOver)
            {
                if (pTurn)//player turn start
                {
                    pauseCR = true;
                    skillChecks.UsableSkill(playerClass, playerMP);
                    mono.StartCoroutine(playerTurn(sm, player));
                    while (pauseCR)
                    {
                        yield return null;
                    }
                    pTurn = false;
                    yield return null;
                }

                else if (!pTurn)//computer turn start
                {
                    pauseCR = true;
                    skillChecks.UsableSkill(playerClass, playerMP);
                    mono.StartCoroutine(computerTurn(sm, player));
                    while (pauseCR)
                    {
                        yield return null;
                    }
                    pTurn = true;
                    yield return null;
                }

                yield return null;
            }
            //return gameOver;
        }
    }

    //PLAYERTURN********************************************************************************************************************************
    IEnumerator playerTurn(DictionaryEx.DictionaryUse sm, Player player) //Guess Its gotta be a Co-Routine
    {
        difficulty = defeatCheck.Difficulty(score);
        while (!check)
        {

            CompText.FindObjectOfType<CompText>().playerTurnTxt(difficulty, randChar);

            while (!enterPressed)
            {

                if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && (word != null && word != ""))
                {
                    enterPressed = true;
                }
                yield return null;
            }

            while (!check && enterPressed)// if the word being used hasnt checked out && The user pressed enter to confirm their word
            {
                if (word.Equals("I_quit"))
                {
                    gameOver = true;
                    CompText.FindObjectOfType<CompText>().playerTurnNoWords();
                    check = true;
                    yield break;
                }
                else if (word[0] != randChar)
                {
                    CompText.FindObjectOfType<CompText>().playerWordNotStartChar(randChar);
                    enterPressed = false;
                    yield return null;
                }

                if (!word.Equals("I_quit"))
                    check = sm.check(word.ToLower()); //Checking to see if word exists

                if (!check && !word.Equals("I_quit")) //if word doesnt exist
                {
                    CompText.FindObjectOfType<CompText>().wordNoExistTxt(randChar);
                    enterPressed = false;
                    yield return null;
                }
            }
        }

        if (gameOver)
        {
            yield break;//return true;
        }

        if (check) //if wordPassed then continue on
        {
            playerWordSize = word.Length;
            randChar = word[playerWordSize - 1];

            Debug.Log("");
            Debug.Log("\t\t\t\tComputer's Turn : ");
            Debug.Log("");
            Debug.Log("\t\t\tStarting Letter : " + randChar);
            Debug.Log("\t\t\tWord : ? ");

            word = sm.randomWord(randChar, difficulty); //FIX send difficulty here

            if (word.Equals("I_quit"))
            {
                //gameOver = true; //Might not want this anymore to loop playing against computer
                Debug.Log("");
                Debug.Log("\t\t\tComputer Has Ran Out Of Words!");
                Debug.Log("\t\t\tPlayer Wins!");
                player.setScore(++score);
            }
            else
            {
                Debug.Log("\t\t\t" + word);
                compWordSize = word.Length;
                compDamageTaken = playerWordSize - compWordSize;
                if (compDamageTaken <= 0)
                    compDamageTaken = 0;

                compHealth = compHealth - compDamageTaken;
                Debug.Log("\t\t\tComputer has " + compHealth + " points left");
                randChar = word[compWordSize - 1];

                UpperBoxText.FindObjectOfType<UpperBoxText>().HealthVisual(playerHealth, compHealth, playerClass.getHealthValue(), enemy.getEnemyHealthValue());
            }

            if (compHealth <= 0)
            {
                Debug.Log("Computer ran out of points");
                Debug.Log(player.getName() + " Wins!!!!!!");
                Debug.Log("");
                player.setScore(++score);

                enterPressed = false;
                runOnce = false;
                gameOver = true;
                yield return null;//return gameOver;
            }
            enterPressed = false; //gotta reset this too for accepted word
            check = false; //reset check; Uneeded? Cause of do-while... Apparently maybe actually necessary b/c of I_quit loop       
        }
        pauseCR = false;
    }
    //PLAYERTURNEND********************************************************************************************************************************


    //COMPUTERTURN*********************************************************************************************************************************
    IEnumerator computerTurn(DictionaryEx.DictionaryUse sm, Player player)
    {   //Computer's Turn to attack/ User Defends

        difficulty = defeatCheck.Difficulty(score);

        //Computer's Attack Turn
        Debug.Log("");
        Debug.Log("\t\t\t\tComputer's Turn : ");
        Debug.Log("");
        Debug.Log("\t\t\tStarting Letter : " + randChar);
        Debug.Log("\t\t\tWord : ? ");

        word = sm.randomWord(randChar, difficulty); //random attack word for computer

        if (word.Equals("I_quit"))
        {
            Debug.Log("");
            Debug.Log("\t\t\tComputer Has Ran Out Of Words!");
            Debug.Log("\t\t\tPlayer Wins!");
            player.setScore(++score);
        }
        else
        {
            Debug.Log("\t\t\t" + word);
            compWordSize = word.Length;
            randChar = word[compWordSize - 1];
        }

        //Player's Defense Turn
        while (!check)
        {
            CompText.FindObjectOfType<CompText>().playerTurnTxt(difficulty, randChar);

            while (!enterPressed)
            {

                if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && (word != null && word != ""))
                {
                    enterPressed = true;
                }
                yield return null;
            }

            while (!check && enterPressed)// if the word being used hasnt checked out && The user pressed enter to confirm their word
            {
                if (word.Equals("I_quit"))
                {
                    gameOver = true;
                    Debug.Log("");
                    Debug.Log("\t\t\tPlayer Has Run Out Of Words!");
                    Debug.Log("\t\t\tComputer Wins!");
                    check = true;
                    yield break;
                }
                else if (word[0] != randChar)
                {
                    Debug.Log("Word does not start with " + randChar);
                    enterPressed = false;
                    yield return null;
                }

                if (!word.Equals("I_quit"))
                    check = sm.check(word.ToLower()); //Checking to see if word exists

                if (!check && !word.Equals("I_quit")) //if word doesnt exist
                {
                    CompText.FindObjectOfType<CompText>().wordNoExistTxt(randChar);

                    enterPressed = false;
                    yield return null;
                }
            }

            if (gameOver)
            {
                yield break;
            }
        }

        if (check) //if wordPassed then continue on to RPG calculations
        {
            Debug.Log("\t\t\t" + word);
            playerWordSize = word.Length;
            playerDamageTaken = compWordSize - playerWordSize;
            if (playerDamageTaken <= 0)
                playerDamageTaken = 0;

            playerHealth = playerHealth - playerDamageTaken;
            Debug.Log("\t\t\tPlayer has " + playerHealth + " points left");
            randChar = word[playerWordSize - 1];

            UpperBoxText.FindObjectOfType<UpperBoxText>().HealthVisual(playerHealth, compHealth, playerClass.getHealthValue(), enemy.getEnemyHealthValue());

            if (playerHealth <= 0)
            {
                Debug.Log("Player ran out of points");
                Debug.Log(player.getName() + " Loss!!!!!!");
                Debug.Log("");
                Debug.Log("Ending score is " + score);

                //Gotta do something to show end Screen here I guess
                enterPressed = false;
                runOnce = false;
                gameOver = true;
                yield break;//return gameOver;
            }
            enterPressed = false; //gotta reset this too for accepted word
            check = false; //reset check; Uneeded? Cause of do-while... Apparently maybe actually necessary b/c of I_quit loop       
        }

        enterPressed = false; //gotta reset this too for accepted word
        check = false; //reset check; Uneeded? Cause of do-while... Apparently maybe actually necessary b/c of I_quit loop       
        pauseCR = false; //unpause coroutine
    }
    //COMPTURNEND********************************************************************************************************************************
}
