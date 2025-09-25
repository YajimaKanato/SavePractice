using System.IO;
using UnityEngine;

public static class SaveManager
{
    const string JSON = ".json";

    /// <summary>
    /// Json�`���Ńf�[�^���Z�[�u����֐�
    /// </summary>
    /// <typeparam name="T">�Z�[�u����f�[�^�̌^</typeparam>
    /// <param name="fileName">�Z�[�u����t�@�C���̖��O</param>
    /// <param name="saveData">�Z�[�u����f�[�^</param>
    public static void SaveDataPrefs<T>(string fileName, T saveData)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);
        //var filePath = Application.persistentDataPath + $"/{fileName}";
        //�����͓���

        PlayerPrefs.SetString(filePath, JsonUtility.ToJson(saveData));

        Debug.Log($"{filePath}�ɕۑ�");
    }

    /// <summary>
    /// Json�`���Ńf�[�^�����[�h����֐�
    /// </summary>
    /// <typeparam name="T">���[�h����f�[�^�̌^</typeparam>
    /// <param name="fileName">���[�h����t�@�C���̖��O</param>
    /// <returns></returns>
    public static T LoadDataPrefs<T>(string fileName)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName + JSON);

        if (PlayerPrefs.HasKey(filePath))
        {
            var json = PlayerPrefs.GetString(filePath);
            var loaded = JsonUtility.FromJson<T>(json);
            Debug.Log("�f�[�^�����[�h�ł��܂���");
            return loaded;
        }
        else
        {
            Debug.Log("�t�@�C����������܂���ł���");
            return default;
        }
    }
}
