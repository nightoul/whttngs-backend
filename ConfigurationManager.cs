namespace ExampleAPI;

public class ConfigurationManager : IConfigurationManager
{
    public string EnvExample => GetEnvironmentVariable(EnvironmentVariables.Example);
    
    private static string GetEnvironmentVariable(string key)
    {
        var value = DotNetEnv.Env.GetString(key);
        
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception($"Environment variable '{key}' is not set.");
        }
        return value;
    }
}