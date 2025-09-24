using System.IO;
using UnityEngine;

public static class SaveManager
{
    /// <summary>
    /// Json�`���Ńf�[�^���Z�[�u����֐�
    /// </summary>
    /// <typeparam name="T">�Z�[�u����f�[�^�̌^</typeparam>
    /// <param name="fileName">�Z�[�u����t�@�C���̖��O</param>
    /// <param name="saveData">�Z�[�u����f�[�^</param>
    public static void SaveDataJson<T>(string fileName, T saveData)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName);
        //var filePath = Application.persistentDataPath + $"/{fileName}";
        //�����͓���

        File.WriteAllText(filePath, JsonUtility.ToJson(saveData));

        Debug.Log($"{filePath}�ɕۑ�");
    }

    /// <summary>
    /// Json�`���Ńf�[�^�����[�h����֐�
    /// </summary>
    /// <typeparam name="T">���[�h����f�[�^�̌^</typeparam>
    /// <param name="fileName">���[�h����t�@�C���̖��O</param>
    /// <returns></returns>
    public static T LoadDataJson<T>(string fileName)
    {
        var filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
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
