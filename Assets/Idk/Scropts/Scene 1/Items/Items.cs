using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Items 
{
    private protected String itemName;
    private protected String itemDescription;
    private protected double itemHPChange;
    private protected double itemMPChange;
    private protected double temporaryATKChange;
    private protected double temporaryDEFChange;
    private protected double temporaryHPChange;
    private protected String itemSprite;

    public Items()//default hp pot
    {
        itemName = "Health Potion";
        itemDescription = "Potion that heals a small amount of your health points";
        itemHPChange = 10;
        itemMPChange = 0;
        temporaryATKChange = 0;
        temporaryDEFChange = 0;
        temporaryHPChange = 0;
    }

    public String getItemName()
    {
        return itemName;
    }

    public String getItemDescription()
    {
        return itemDescription;
    }

    public double getItemHPChange()
    {
        return itemHPChange;
    }

    public double getItemMPChange()
    {
        return itemMPChange;
    }

    public double getTemporaryATKChange()
    {
        return temporaryATKChange;
    }

    public double getTemporaryDEFChange()
    {
        return temporaryDEFChange;
    }

    public double getTemporaryHPChange()
    {
        return temporaryHPChange;
    }

    public String getItemSprite()
    {
        return itemSprite;
    }
}

public class HealthPotion : Items
{
    public HealthPotion() : base()
    {
        itemName = "Health Potion";
        itemDescription = "Potion that heals a small amount of your health points";
        itemHPChange = 10;
        itemMPChange = 0;
        temporaryATKChange = 0;
        temporaryDEFChange = 0;
        temporaryHPChange = 0;
    }
}

public class ManaPotion : Items
{
    public ManaPotion() : base()
    {
        itemName = "Mana Potion";
        itemDescription = "Potion that recovers a small amount of magic points(mp)";
        itemHPChange = 0;
        itemMPChange = 10;
        temporaryATKChange = 0;
        temporaryDEFChange = 0;
        temporaryHPChange = 0;
    }
}
