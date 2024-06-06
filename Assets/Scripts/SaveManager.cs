using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";
    }

    public void SavePlayerData(PlayerData playerData)
    {
        // Сериализация объекта в JSON
        string json = JsonUtility.ToJson(playerData);

        // Сохранение JSON в файл
        File.WriteAllText(filePath, json);
        Debug.Log("Данные игрока сохранены в " + filePath);
    }

    public PlayerData LoadPlayerData()
    {
        // Проверка наличия файла
        if (File.Exists(filePath))
        {
            // Чтение JSON из файла
            string json = File.ReadAllText(filePath);

            // Десериализация JSON обратно в объект
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Данные игрока загружены из " + filePath);
            return playerData;
        }
        else
        {
            Debug.LogWarning("Файл с данными игрока не найден!");
            return null;
        }
    }
}
