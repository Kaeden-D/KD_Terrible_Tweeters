using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] string next_level_name;

    private Monster[] monsters;

    void OnEnable()
    {
        monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MonstersAreAllDead())
        {
            GoToNextLevel();
        }

    }

    private void GoToNextLevel()
    {

        Debug.Log("Go to " + next_level_name);
        SceneManager.LoadScene(next_level_name);

    }

    private bool MonstersAreAllDead()
    {

        foreach (Monster monster in monsters)
        {

            if (monster.gameObject.activeSelf)
            {

                return false;

            }

        }

        return true;

    }

}
