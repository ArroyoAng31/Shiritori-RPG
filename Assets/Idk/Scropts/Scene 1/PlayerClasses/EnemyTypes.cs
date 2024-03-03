using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTypes
{
    private protected String enemyName { get; set; }
    private protected String enemyDescription { get; set; }
    private protected double healthValue { get; set; }
    private protected double attackPwr { get; set; }
    private protected double defensePwr { get; set; }
    private protected String enemySprite { get; set; }

    public EnemyTypes() //default class
    {
        enemyName = "Slime";
        enemyDescription = "A blob like enemy with weak attack power but able to take plenty of hits";
        healthValue = 30;
        attackPwr = 1;
        defensePwr = 1.2;
    }
    public String getEnemyName()
    {
        return enemyName;
    }

    public String getEnemyDescription()
    {
        return enemyDescription;
    }

    public double getEnemyHealthValue()
    {
        return healthValue;
    }

    public double getEnemyAttackPwr()
    {
        return attackPwr;
    }

    public double getEnemyDefensePwr()
    {
        return defensePwr;
    }

    public String getEnemySprite()
    {
        return enemySprite;
    }
}

public class Slime: EnemyTypes
{
    public Slime(): base()
    {
        enemyName = "Slime";
        enemyDescription = "A blob like enemy with weak attack power but able to take plenty of hits";
        healthValue = 30;
        attackPwr = 1;
        defensePwr = 1.2;
        enemySprite = @"Slime.PNG";
    }
}

public class Goblin: EnemyTypes
{
    public Goblin(): base()
    {
        enemyName = "Goblin";
        enemyDescription = "Humanoid enemy weak attack power and weak health, but uses tools to compensate its lack of damage";
        healthValue = 15;
        attackPwr = 1.2;
        defensePwr = 1;
        enemySprite = @"Goblin.PNG";
    }
}

public class Boss: EnemyTypes
{
    public Boss(): base()
    {
        enemyName = "Boss";
        enemyDescription = "It's a boss";
        healthValue = 40;
        attackPwr = 1.5;
        defensePwr = 1;
        enemySprite = @"Reee.PNG";
    }
}
