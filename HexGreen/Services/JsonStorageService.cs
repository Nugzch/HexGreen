
using System.IO;
using System.Text.Json;


namespace HexGreen.Services;

// Класс для считывания настроект
public class JsonStorageService
{
    private const string FilePath = "settings.json";


    public HexGreenSettings LoadSettings()
    {
        if (!File.Exists(FilePath))
        {
            return new HexGreenSettings
            {
                WorkDuration = 25,
                ShortBreakDuration = 5,
                SessionsBeforeLongBreak = 4,
                AutoStartNextSession = false
            };
        }

        var json = File.ReadAllText(FilePath);

        return JsonSerializer.Deserialize<HexGreenSettings>(json)
               ?? new HexGreenSettings();
    }

    public void SaveSettings(HexGreenSettings settings)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(settings, options);

        File.WriteAllText(FilePath, json);
    }
}