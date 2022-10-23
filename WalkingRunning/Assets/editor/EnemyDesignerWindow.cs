using Types;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow
{
    private Texture2D headerSectionTexture;
    
    // unused
    private Texture2D mageSectionTexture;
    private Texture2D rogueSectionTexture;
    private Texture2D warriorSectionTexture;
    // unused

    private Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    private Color mageSectionColor = new Color(148f / 255f, 0f, 211f / 255f, 1f);
    private Color rogueSectionColor = new Color(162f / 255f, 32f / 255f, 0f, 1f);
    private Color warriorSectionColor = new Color(0f / 255f, 150f / 255f, 120f / 255f, 1f);

    private Rect headerSection;
    private Rect mageSection;
    private Rect rogueSection;
    private Rect warriorSection;

    private GUISkin skin;

    private static MageData mageData;
    private static RogueData rogueData;
    private static WarriorData warriorData;
    
    public static MageData MageInfo
    {
        get { return mageData; }
    }
    
    public static RogueData RogueInfo
    {
        get { return rogueData; }
    }
    
    public static WarriorData WarriorInfo
    {
        get { return warriorData; }
    }
    
    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.titleContent = new GUIContent("Enemy Designer");
        window.Show();
    }

    void OnEnable()
    {
        InitData();
        InitTextures();
        skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");
    }

    static void InitData()
    {
        mageData = (MageData)CreateInstance(typeof(MageData));
        rogueData = (RogueData)CreateInstance(typeof(RogueData));
        warriorData = (WarriorData)CreateInstance(typeof(WarriorData));

    }

    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0,0,headerSectionColor);
        headerSectionTexture.Apply();
        
        mageSectionTexture = new Texture2D(1, 1);
        mageSectionTexture.SetPixel(0,0,mageSectionColor);
        mageSectionTexture.Apply();
        
        rogueSectionTexture = new Texture2D(1, 1);
        rogueSectionTexture.SetPixel(0,0,rogueSectionColor);
        rogueSectionTexture.Apply();
        
        warriorSectionTexture = new Texture2D(1, 1);
        warriorSectionTexture.SetPixel(0,0,warriorSectionColor);
        warriorSectionTexture.Apply();
        
        // other textures are to be implemented here
    }

    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawRogueSettings();
        DrawWarriorSettings();
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;
        
        mageSection.x = 0;
        mageSection.y = headerSection.height;
        mageSection.width = Screen.width / 3f;
        mageSection.height = Screen.width - headerSection.height;
        
        rogueSection.x = Screen.width / 3f;;
        rogueSection.y = headerSection.height;
        rogueSection.width = Screen.width / 3f;
        rogueSection.height = Screen.width - headerSection.height;
        
        warriorSection.x = 2f * Screen.width / 3f;
        warriorSection.y = headerSection.height;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.width - headerSection.height;
        
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Enemy Designer", skin.GetStyle("Header1"));
            
        GUILayout.EndArea();
    }

    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);
        
        GUILayout.Label("Mage");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage Type");
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type");
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }
        
        GUILayout.EndArea();
    }

    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);
        
        GUILayout.Label("Rogue");
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy Type");
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type");
        rogueData.wpnType = (RogueWeaponType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        EditorGUILayout.EndHorizontal();
        
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }
        
        GUILayout.EndArea();
    }

    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);
        
        GUILayout.Label("Warrior");
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class Type");
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type");
        warriorData.wpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        EditorGUILayout.EndHorizontal();
        
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }
        
        GUILayout.EndArea();
    }
}

public class GeneralSettings : EditorWindow
{
    public enum SettingsType
    {
        MAGE,
        ROGUE,
        WARRIOR
    }

    private static SettingsType dataSetting;
    private static GeneralSettings window;

    public static void OpenWindow(SettingsType setting)
    {
        dataSetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.titleContent = new GUIContent("General Settings");
        window.Show();
    }

    private void OnGUI()
    {
        switch (dataSetting)
        {
            case SettingsType.MAGE:
                DrawSettings((CharacterData)EnemyDesignerWindow.MageInfo);
                break;
            case SettingsType.ROGUE:
                DrawSettings((CharacterData)EnemyDesignerWindow.RogueInfo);
                break;
            case SettingsType.WARRIOR:
                DrawSettings((CharacterData)EnemyDesignerWindow.WarriorInfo);
                break;
        }
    }

    void DrawSettings(CharacterData charData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy");
        charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        charData.power = EditorGUILayout.Slider(charData.power, 0, 100);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance");
        charData.critChance = EditorGUILayout.Slider(charData.critChance, 0, charData.power);
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        charData.name = EditorGUILayout.TextField(charData.name);
        EditorGUILayout.EndHorizontal();

        if (charData.prefab == null)
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created.", MessageType.Error);
            
        else if (string.IsNullOrEmpty(charData.name))
            EditorGUILayout.HelpBox("This enemy needs a [Name] before it can be created.", MessageType.Error);
        
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveCharacterData();
            window.Close();
        }
    }

    void SaveCharacterData()
    {
        string prefabPath; // path to the base prefab
        string newPrefabPath = "Assets/prefabs/characters/";
        string dataPath = "Assets/resources/characterData/data/";

        switch (dataSetting)
        {
            case SettingsType.MAGE:
                dataPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                newPrefabPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".prefab";
                
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!magePrefab.GetComponent<Mage>())
                    magePrefab.AddComponent(typeof(Mage));
                magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                break;
            
            case SettingsType.ROGUE:
                dataPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                newPrefabPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".prefab";
                
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!roguePrefab.GetComponent<Rogue>())
                    roguePrefab.AddComponent(typeof(Rogue));
                roguePrefab.GetComponent<Rogue>().rogueData = EnemyDesignerWindow.RogueInfo;
                break;
            
            case SettingsType.WARRIOR:
                dataPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                newPrefabPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".prefab";
                
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!warriorPrefab.GetComponent<Warrior>())
                    warriorPrefab.AddComponent(typeof(Warrior));
                warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.WarriorInfo;
                break;
        }
    }
}
