using UnityEngine;
using System.Collections;
using UnityEditor;

public class OptionEditor
{
    [MenuItem("Lily/Option/Create new option")]
    public static void CreateAsset()
    {
        var asset = ScriptableObject.CreateInstance<OptionScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/Options/OptionNewScriptableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Lily/Load/00_SplashScreen")]
    static void OpenMainScene()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/00_SplashScreen.unity");
    }

    [MenuItem("Lily/Load/01_Menu")]
    static void OpenMainMenu()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/01_Menu.unity");
    }

    [MenuItem("Lily/Load/02_Appartement")]
    static void OpenAppartement()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/02_Appartement.unity");
    }

    [MenuItem("Lily/Load/03_Runaway")]
    static void OpenRunaway()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/03_Runaway.unity");
    }

    [MenuItem("Lily/Load/04_Library")]
    static void OpenLibrary()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/04_Library.unity");
    }

    [MenuItem("Lily/Load/05_Hotel")]
    static void OpenHotel()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/05_Hotel.unity");
    }

    [MenuItem("Lily/Load/06_TransitionBalcony")]
    static void OpenTransitionBalcony()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/06_TransitionBalcony.unity");
    }

    [MenuItem("Lily/Load/07_DeadManAppartement")]
    static void OpenDeadManAppartement()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/07_DeadManAppartement.unity");
    }

    [MenuItem("Lily/Load/08_Lighthouse")]
    static void OpenLighthouse()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/08_Lighthouse.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/00_ToMenu")]
    static void OpenToMenu()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/00_ToMenu.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/01_MenuAppart")]
    static void OpenMenuAppart()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/01_MenuAppart.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/02_AppartRunaway")]
    static void OpenAppartRunaway()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/02_AppartRunaway.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/03_RunAwayLibrary")]
    static void OpenRunAwayLibrary()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/03_RunAwayLibrary.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/04_LibraryHotel")]
    static void OpenLibraryHotel()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/04_LibraryHotel.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/05_HotelBalcony")]
    static void OpenHotelBalcony()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/05_HotelBalcony.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/06_BalconyDeadMan")]
    static void OpenBalconyDeadMan()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/06_BalconyDeadMan.unity");
    }

    [MenuItem("Lily/LoadTransitionScene/07_DeadManLighthouse")]
    static void OpenDeadManLighthouse()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/Production/TmpScenes/07_DeadManLighthouse.unity");
    }

    [MenuItem("Lily/Clear PlayerPrefs")]
    static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
