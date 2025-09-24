using System.IO;
using UnityEngine;

public static class SaveManager
{
    /// <summary>
    /// Json形式でデータをセーブする関数
    /// </summary>
    /// <typeparam name="T">セーブするデータの型</typeparam>
    /// <param name="fileName">セーブするファイルの名前</param>
    /// <param name="saveData">セーブするデータ</param>
    public static void SaveDataJson<T>(string fileName, T saveData)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName);
        //var filePath = Application.persistentDataPath + $"/{fileName}";
        //これらは同じ

        File.WriteAllText(filePath, JsonUtility.ToJson(saveData));

        Debug.Log($"{filePath}に保存");
    }

    /// <summary>
    /// Json形式でデータをロードする関数
    /// </summary>
    /// <typeparam name="T">ロードするデータの型</typeparam>
    /// <param name="fileName">ロードするファイルの名前</param>
    /// <returns></returns>
    public static T LoadDataJson<T>(string fileName)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var loaded = JsonUtility.FromJson<T>(json);
            Debug.Log("データをロードできました");
            return loaded;
        }
        else
        {
            Debug.Log("ファイルが見つかりませんでした");
            return default;
        }
    }
}
