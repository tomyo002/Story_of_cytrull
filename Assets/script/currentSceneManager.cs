

using UnityEngine;

public class currentSceneManager : MonoBehaviour
{

    public int coinspickedupcount;
    public int levelToUnlock;
    public static currentSceneManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de currentSceneManager dans la scene");
            return;
        }
        instance =this;
    }
    public void vallevel(int valeur)
    {
        levelToUnlock = valeur;
    }
}
