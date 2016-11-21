using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using AMUtils;
using System.Linq;
using System;

public static class PlayerProfile
{

    public static bool isCuttedVersion;

    public static int CurrentConroller
    {
        get
        {
            if (!PlayerPrefs.HasKey("CurrentConroller"))
            {
                PlayerPrefs.SetInt("CurrentConroller", 0);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("CurrentConroller");
        }
        set
        {
            PlayerPrefs.SetInt("CurrentConroller", value);
            PlayerPrefs.Save();
        }
    }

   

    public static int PersLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("PersLevel"))
            {
                PlayerPrefs.SetInt("PersLevel", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("PersLevel");
        }
        set
        {
            PlayerPrefs.SetInt("PersLevel", value);
            PlayerPrefs.Save();
        }
    }

    public static int FirstVisitGame
    {
        get
        {
            if (!PlayerPrefs.HasKey("FirstVisitGame"))
            {
                PlayerPrefs.SetInt("FirstVisitGame", 0);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("FirstVisitGame");
        }
        set
        {
            PlayerPrefs.SetInt("FirstVisitGame", value);
            PlayerPrefs.Save();
        }
    }

    public static int experience
    {
        get
        {
            if (!PlayerPrefs.HasKey("experience"))
            {
                PlayerPrefs.SetInt("experience", 0);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("experience");
        }
        set
        {
            PlayerPrefs.SetInt("experience", value);
            PlayerPrefs.Save();
        }
    }


    public static int currentTheme
    {
        get
        {
            if (PlayerPrefs.GetInt("currentTheme") == 0)
            {
                PlayerPrefs.SetInt("currentTheme", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("currentTheme");
        }
        set
        {
            PlayerPrefs.SetInt("currentTheme", value);
            PlayerPrefs.Save();
        }
    }

    public static int currentLevel
    {
        get
        {
            if (PlayerPrefs.GetInt("currentLevel") == 0)
            {
                PlayerPrefs.SetInt("currentLevel", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("currentLevel");
        }
        set
        {
            PlayerPrefs.SetInt("currentLevel", value);
            PlayerPrefs.Save();
        }
    }

    public static int AllMatch
    {
        get
        {
            if (PlayerPrefs.GetInt("AllMatch") == 0)
            {
                PlayerPrefs.SetInt("AllMatch", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("AllMatch");
        }
        set
        {
            PlayerPrefs.SetInt("AllMatch", value);
            PlayerPrefs.Save();
        }
    }

    public static int TotalWin
    {
        get
        {
            if (PlayerPrefs.GetInt("TotalWin") == 0)
            {
                PlayerPrefs.SetInt("TotalWin", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("TotalWin");
        }
        set
        {
            PlayerPrefs.SetInt("TotalWin", value);
            PlayerPrefs.Save();
        }
    }

    public static int TotalKilled
    {
        get
        {
            if (PlayerPrefs.GetInt("TotalKilled") == 0)
            {
                PlayerPrefs.SetInt("TotalKilled", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("TotalKilled");
        }
        set
        {
            PlayerPrefs.SetInt("TotalKilled", value);
            PlayerPrefs.Save();
        }
    }

    public static int unlockedLevel
    {
        get
        {
            return PlayerPrefs.GetInt("unlockedLevel");
        }
        set
        {
            PlayerPrefs.SetInt("unlockedLevel", value);
            PlayerPrefs.Save();
        }
    }

    public static int firstgamelaunch
    {
        get
        {
            if (PlayerPrefs.GetInt("firstgamelaunch") == 0)
            {
                PlayerPrefs.SetInt("firstgamelaunch", 1);
                PlayerPrefs.Save();
            }
            return PlayerPrefs.GetInt("firstgamelaunch");
        }
        set
        {
            PlayerPrefs.SetInt("firstgamelaunch", value);
            PlayerPrefs.Save();
        }
    }

    public static bool getIsLevelOpened(int theme, int level)
    {
        string keyName = string.Format("isLevelOpened_{0}_{1}", theme, level);
        if (!PlayerPrefs.HasKey(keyName))
        {
            if (theme == 1 && level == 1)
            {
                PlayerPrefs.SetInt(keyName, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyName, 0);
            }
            PlayerPrefs.Save();
        }
        return (PlayerPrefs.GetInt(keyName) == 1 ? true : false);
    }

    public static void setIsLevelOpened(int theme, int level, bool value)
    {
        string keyName = string.Format("isLevelOpened_{0}_{1}", theme, level);
        PlayerPrefs.SetInt(keyName, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool getIsLevelPassed(int theme, int level)
    {
        string keyName = string.Format("isLevelPassed_{0}_{1}", theme, level);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return (PlayerPrefs.GetInt(keyName) == 1 ? true : false);
    }

    public static void setIsLevelPassed(int theme, int level, bool value)
    {
        string keyName = string.Format("isLevelPassed_{0}_{1}", theme, level);
        PlayerPrefs.SetInt(keyName, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    //LevelUpPoint
    public static int getLevelUpPoint(int point)
    {
        string keyName = string.Format("LevelUp_{0}", point);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setLevelUpPoint(int point, int value)
    {
        string keyName = string.Format("LevelUp_{0}", point);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getStars(int theme, int level)
    {
        string keyName = string.Format("stars_{0}_{1}", theme, level);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setStars(int theme, int level, int value)
    {
        string keyName = string.Format("stars_{0}_{1}", theme, level);
        if (value > getStars(theme, level))
        {
            PlayerPrefs.SetInt(keyName, value);
            PlayerPrefs.Save();
        }
    }



    public static int getItems(int itemID, int type)
    {
        string keyName = string.Format("item_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setItems(int itemID, int type, int value)
    {
        string keyName = string.Format("item_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getBoost(int boostID)
    {
        string keyName = string.Format("boost_{0}", boostID);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setBoost(int boostID, int value)
    {
        string keyName = string.Format("boost_{0}", boostID);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getRagdoll(int ragdollID)
    {
        string keyName = string.Format("ragdoll_{0}", ragdollID);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setRagdoll(int ragdollID, int value)
    {
        string keyName = string.Format("ragdoll_{0}", ragdollID);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getLevels(int themeID, int levelID)
    {
        string keyName = string.Format("level_{0}_{1}", themeID, levelID);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setLevels(int themeID, int levelID, int value)
    {
        string keyName = string.Format("level_{0}_{1}", themeID, levelID);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }


    public static int getEquipment(int itemID, int type)
    {
        string keyName = string.Format("equipment_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setEquipment(int itemID, int type, int value)
    {
        string keyName = string.Format("item_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }


    public static int getUpgrade(int itemID, int type)
    {
        string keyName = string.Format("upgrade_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setUpgrade(int itemID, int type, int value)
    {
        string keyName = string.Format("upgrade_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getUpgradeArmor(int itemID, int type)
    {
        string keyName = string.Format("upgradeArmor_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setUpgradeArmor(int itemID, int type, int value)
    {
        string keyName = string.Format("upgradeArmor_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getUpgradeDeff(int itemID, int type)
    {
        string keyName = string.Format("upgradeDeff_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setUpgradeDeff(int itemID, int type, int value)
    {
        string keyName = string.Format("upgradeDeff_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getUpgradeSpeed(int itemID, int type)
    {
        string keyName = string.Format("upgradeSpeed_{0}_{1}", itemID, type);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setUpgradeSpeed(int itemID, int type, int value)
    {
        string keyName = string.Format("upgradeSpeed_{0}_{1}", itemID, type);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static string getQuality(int itemID)
    {
        string keyName = string.Format("quality_{0}", itemID);

        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetString(keyName, "common");
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetString(keyName);
    }

    public static void setQuality(int itemID, string value)
    {
        string keyName = string.Format("quality_{0}", itemID);
        PlayerPrefs.SetString(keyName, value);
        PlayerPrefs.Save();
    }


    public static void SaveJson(string value)
    {
        string keyName = string.Format("SaveJson");
        PlayerPrefs.SetString(keyName, value);
        PlayerPrefs.Save();
    }

    public static void SaveRagdollPlayer(string value)
    {
        string keyName = string.Format("SaveRagdollPlayer");
        PlayerPrefs.SetString(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getExperience(int pers, int lvlCount)
    {
        string keyName = string.Format("xp_{0}_{1}", pers, lvlCount);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setExperience(int pers, int lvlCount, int value)
    {
        string keyName = string.Format("xp_{0}_{1}", pers, lvlCount);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }

    public static int getScore(int theme, int level)
    {
        string keyName = string.Format("score_{0}_{1}", theme, level);
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
            PlayerPrefs.Save();
        }
        return PlayerPrefs.GetInt(keyName);
    }

    public static void setScore(int theme, int level, int value)
    {
        string keyName = string.Format("score_{0}_{1}", theme, level);
        PlayerPrefs.SetInt(keyName, value);
        PlayerPrefs.Save();
    }



    //private static MyLevelsInfo _allLevels = null;

    /*public static MyLevelsInfo allLevels
    {
        get
        {
            if (_allLevels == null)
            {
                _allLevels = new MyLevelsInfo("xml/levels");
            }
            return _allLevels;
        }
    }*/

    /*public static bool isBannerDisabled
    {
        get
        { 
            if (AMConfigsParser.AMBuildParamsInside.payment == "pro")
                PlayerPrefs.SetInt("isBannerDisabled", 1);
            return (PlayerPrefs.GetInt("isBannerDisabled") != 0);
        }
        set
        {
            if (value)
            {
                AMEvents.Ad.Banner.DisableAd();
                PlayerPrefs.SetInt("isBannerDisabled", 1);
            }
            else
            {
                PlayerPrefs.SetInt("isBannerDisabled", 0);
            }
            PlayerPrefs.Save();
        }
    }*/

    public static bool isInappDisabled
    {
        get
        { 
            return (PlayerPrefs.GetInt("isInappDisabled") != 0);
        }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt("isInappDisabled", 1);
            }
            else
            {
                PlayerPrefs.SetInt("isInappDisabled", 0);
            }
            PlayerPrefs.Save();
        }
    }

}
