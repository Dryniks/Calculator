using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    /// <summary>
    /// Сохраанение данных
    /// </summary>
    public static class Storage
    {
        private static string DataPath => Application.persistentDataPath;

        private static readonly Encryptor Encryptor = new();
        private static readonly Dictionary<string, object> Lockers = new();

        private static readonly JsonSerializerSettings Settings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.Objects
        };

        /// <summary>
        /// Считать данные
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="token">Токен отмеены</param>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <returns>Данные</returns>
        public static async Task<T> Load<T>(string fileName, CancellationToken token) where T : class
        {
            var path = $"{DataPath}/{fileName}";

            return await Task.Run(() =>
            {
                try
                {
                    if (!Lockers.ContainsKey(path))
                        Lockers[path] = new object();

                    lock (Lockers[path])
                    {
                        if (!File.Exists(path))
                            return null;

                        var str = Encryptor.Decrypt(File.ReadAllText(path));
                        return JsonConvert.DeserializeObject<T>(str, Settings);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError("Error Load: " + path + "; Message: " + ex.Message);
                    return null;
                }
            }, token);
        }

        /// <summary>
        /// Сохранить данные
        /// </summary>
        /// <param name="source">Данные</param>
        /// <param name="fileName">Имя файла</param>
        /// <param name="token">Токен закрытия</param>
        /// <typeparam name="T">Тип данных</typeparam>
        public static async Task Save<T>(T source, string fileName, CancellationToken token) where T : class
        {
            var path = $"{DataPath}/{fileName}";

            await Task.Run(() =>
            {
                try
                {
                    if (!Lockers.ContainsKey(path))
                        Lockers[path] = new object();
                    lock (Lockers[path])
                    {
                        var json = JsonConvert.SerializeObject(source, Settings);
                        if (json.Length <= 0)
                            return;

                        var str = Encryptor.Encrypt(json);
                        if (str.Length <= 0)
                            return;

                        var directoryName = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directoryName))
                            Directory.CreateDirectory(directoryName);

                        File.WriteAllText(path, str);
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError("Error Save : " + path + "; Message " + ex.Message);
                }
            }, token);
        }

        /// <summary>
        /// Очистить сохранку
        /// </summary>
#if UNITY_EDITOR
        [UnityEditor.MenuItem("Game/Data/Clear all data", false, 1)]
#endif
        public static void ClearAll()
        {
            PlayerPrefs.DeleteAll();

            var files = Directory.GetFiles(DataPath);
            foreach (var file in files)
                File.Delete(file);

            var directories = Directory.GetDirectories(DataPath);
            foreach (var directory in directories)
                Directory.Delete(directory, true);


#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}