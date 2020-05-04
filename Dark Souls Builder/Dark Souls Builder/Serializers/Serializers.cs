using System;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Souls_Builder.Serializers
{
    class MyJsonSerializer
    {
        public static bool IsTxt = true;
        private static string SerializeObj(object obj)
        { 
            string result = obj.GetType().Name + ";" +JsonSerializer.Serialize(obj, obj.GetType());
            return result;
        }
        private static object DeserializeObj(string str, Type[] types)
        {
            string type_name = "";
            int i = 0;
            while (str[i] != ';')
            {
                type_name += str[i];
                i++;
            }
            str = str.Substring(i + 1);
            i = 0;
            while (type_name != types[i].Name)
                i++;
            object result = JsonSerializer.Deserialize(str, types[i]);
            return result;
        }
        public static string[] SerializeArr(object[] objs) 
        {
            string[] result = new string[objs.Length];
            for (int i = 0; i < objs.Length; i++)
                result[i] = SerializeObj(objs[i]);
            return result;
        }
        public static object[] DeserializeArr(string[] strs)
        {
            Assembly assembly = Assembly.Load("Dark Souls Builder");
            Type[] types = assembly.GetTypes();
            object[] result = new object[strs.Length];
            for (int i = 0; i < strs.Length; i++)
                result[i] = DeserializeObj(strs[i], types);
            return result;
        }
    }

    class MyBinSerializer
    {
        public static bool IsTxt = false;
        public static void SerializeArr(object[] objs, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, objs);
            }
        }
        public static object[] DeserializeArr(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            object[] result = null;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                result = (object[])bf.Deserialize(fs);
            }
            return result;
        }
    }

    class MySerializer
    {
        public static bool IsTxt = true;
        private static string SerializeObj(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            string result = "{[" + type.Name + "]";
            for (int i = 0; i < props.Length; i++)
            {
                result += "\"" + props[i].Name + "\"" +":";
                if (props[i].PropertyType.IsClass)
                {
                    if (props[i].PropertyType.Name == "String")
                    {
                        result += "\"";
                        string buf = (string)props[i].GetValue(obj);
                        for (int j = 0; j < buf.Length; j++)
                            if (buf[j] == ',')
                                result += '.';
                            else if (buf[j] == '{')
                                result += '[';
                            else if (buf[j] == '}')
                                result += ']';
                            else
                                result += buf[j];
                        result += "\"";
                    }
                    else
                        result += SerializeObj(props[i].GetValue(obj));
                }
                else
                    result += props[i].GetValue(obj);
                result += ",";
            }
            //result = result.Substring(0, result.Length - 1);
            result += "}";
            return result;
        }

        public static string[] SerializeArr(object[] objs)
        {
            string[] result = new string[objs.Length];
            for (int i = 0; i < objs.Length; i++)
                result[i] = SerializeObj(objs[i]);
            return result;
        }

        private static object CreateObj(string name)
        {
            Assembly assembly = Assembly.Load("Dark Souls Builder");
            Type[] types = assembly.GetTypes();
            int i = 0;
            while (types[i].Name != name)
                i++;
            object result = Activator.CreateInstance(types[i]);
            return result;
        }

        private static PropertyInfo GetProp(string str, PropertyInfo[] props)
        {
            string buf = "";
            int i = 1;
            while (str[i] != '"')
            {
                buf += str[i];
                i++;
            }
            i = 0;
            while (props[i].Name != buf)
                i++;
            return props[i];
        }

        private static object GetPropVal(string str, Type prop_type)
        {
            object result = null;
            int i = 0;
            while (str[i] != ':')
                i++;
            i++;
            string buf = "";
            while (i < str.Length)
                buf += str[i++];
            if (prop_type.IsClass)
            {
                if (prop_type.Name == "String")
                {
                    result = buf.Substring(1, buf.Length - 2);
                }
                else
                {
                    result = DeserializeObj(buf);
                }
            }
            else
            {
                result = Convert.ToInt32(buf);
            }
            return result;
        }

        private static string GetSubStr(ref int ind, string str)
        {
            if (str[ind] == '}')
                return null;
            int left = ind;
            while (str[ind] != ':')
                ind++;
            ind++;
            if (str[ind] !='{')
            {
                while (str[ind] != ',')
                    ind++;
            }
            else
            {
                int i = -1;
                while(i != 0)
                {
                    ind++;
                    if (str[ind] == '{')
                        i--;
                    if (str[ind] == '}')
                        i++;
                }
                ind++;
            }
            ind++;
            return str.Substring(left, ind - left - 1);
        }

        private static object DeserializeObj(string str)
        {
            string buf = "";
            int i = 2;
            while (str[i] != ']')
            {
                buf += str[i];
                i++;
            }
            i++;
            object result = CreateObj(buf);
            PropertyInfo[] props = result.GetType().GetProperties();
            while ((buf = GetSubStr(ref i, str)) != null)
            {
                //buf = buf.Substring(0, buf.Length - 1);
                PropertyInfo buf_prop = GetProp(buf, props);
                buf_prop.SetValue(result,GetPropVal(buf, buf_prop.PropertyType));
            }
            return result;
        }

        public static object[] DeserializeArr(string[] strs)
        {
            object[] result = new object[strs.Length];
            for (int i = 0; i < strs.Length; i++)
                result[i] = DeserializeObj(strs[i]);
            for (int i = 0; i < result.Length; i++)
            {
                PropertyInfo[] props = result[i].GetType().GetProperties();
                for (int j = 0; j < props.Length; j++)
                    if (props[j].PropertyType.IsClass && props[j].PropertyType.FullName.Contains("User_Classes"))
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[result.Length - 1] = props[j].GetValue(result[i]);
                    }
            }
            for (int i = 0; i < result.Length - 1; i++)
                for (int j = i + 1; j < result.Length; j++)
                    if (ReferenceEquals(result[i], result[j]))
                    {
                        for (int k = j; k < result.Length - 1; k++)
                            result[k] = result[k + 1];
                        Array.Resize(ref result, result.Length - 1);
                    }
            return result;
        }
    }
}
