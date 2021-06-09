
using System.IO;
using LuaInterface;
public class LuaFileUtil : LuaFileUtils
{
    public static LuaFileUtil Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LuaFileUtil();
            }

            return instance;
        }

        protected set
        {
            instance = value;
        }
    }

    protected static LuaFileUtil instance = null;

    public LuaFileUtil()
    {
        instance = this;
    }

    // 此处加载Lua文件
    public override byte[] ReadFile(string fileName)
    {
        string luaName = Path.GetFileNameWithoutExtension(fileName) + ".lua";
        string luaStr = Util.Asset.LoadAsset(typeof(UnityEngine.Object),"lua",luaName).ToString();
        return System.Text.Encoding.UTF8.GetBytes(luaStr);
    }
}
