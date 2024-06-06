using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SaveManager saveManager;

    void Start()
    {
        saveManager = GetComponent<SaveManager>();
        
        if (saveManager == null)
        {
            saveManager = gameObject.AddComponent<SaveManager>();
        }
        
        // Пример использования
        SaveExample();
        LoadExample();
    }

    void SaveExample()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerName = "PlayerOne";

        saveManager.SavePlayerData(playerData);

        Debug.Log("Данные игрока сохранены.");
    }

    void LoadExample()
    {
        PlayerData playerData = saveManager.LoadPlayerData();

        if (playerData != null)
        {
            Debug.Log("Данные игрока загружены:");
            Debug.Log("Имя: " + playerData.playerName);

        }
        else
        {
            Debug.Log("Не удалось загрузить данные игрока.");
        }
    }
}
