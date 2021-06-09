public class Singleton<T> where T : new()
{
    /// <summary>
    /// 单例实体
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            
            }
            return _instance;
        }
    }
    private static T _instance;
}