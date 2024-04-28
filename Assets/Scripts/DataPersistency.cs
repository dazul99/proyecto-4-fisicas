using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistency : MonoBehaviour
{

    private const string SAVE_FILE_NAME = "/save-file.txt";

    private PlayerController controller;
    private GameManager gameManager;

    private void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private bool HasSavedGame()
    {
        return System.IO.File.Exists(Application.dataPath + SAVE_FILE_NAME);
    }

    public void Save()
    {
        // Obtenemos la información que queremos guardar
        int h = controller.GetLives();
        int r = gameManager.GetRound();
        bool p = controller.GetPower();

        Debug.Log($"health = {h}");
        Debug.Log($"round = {r}");
        Debug.Log($"haspowerup = {p}");

        // Creamos el objeto de guardado
        SaveObject saveObject = new SaveObject
        {
            health = h,
            round = r,
            power = p
        };

        // Jsonificamos el objeto de guardado
        string jsonContent = JsonUtility.ToJson(saveObject);
        Debug.Log(Application.dataPath);

        System.IO.File.WriteAllText(Application.dataPath + SAVE_FILE_NAME,
            jsonContent);
    }

    public void Load()
    {
        if (HasSavedGame())
        {
            string jsonContent = System.IO.File.ReadAllText(Application.dataPath + SAVE_FILE_NAME);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(jsonContent);

            controller.SetLives(saveObject.health);
            controller.SetPower(saveObject.power);
            gameManager.Startgame(saveObject.round);
        }

        else Debug.LogError("NO SAVED GAME");
    }

}
