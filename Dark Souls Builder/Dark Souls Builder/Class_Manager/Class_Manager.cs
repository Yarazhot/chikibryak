using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dark_Souls_Builder.Serializers;

namespace Dark_Souls_Builder.Class_Manager
{
    class Class__Manager
    {
        Object[] objects;
        Type[] types;
        int edit_obj_num;
        int edit_prop_num;
        PropertyInfo[] edit_obj_props;

        public Class__Manager()
        {
            Array.Resize(ref objects, 0);
            Assembly assembly = Assembly.Load("Dark Souls Builder");
            types = assembly.GetTypes();
        }

        public int GetEditObjNum()
        {
            return edit_obj_num;
        }

        public int GetEditPropNum()
        {
            return edit_prop_num;
        }


        public int GetObjNum()
        {
            return objects.Length;
        }

        public bool IsPropClass()
        {
            string a = edit_obj_props[edit_prop_num].PropertyType.Name;
            return edit_obj_props[edit_prop_num].PropertyType.IsClass &&
                edit_obj_props[edit_prop_num].PropertyType.Name != "String";
        }

        public string[] GetClasses()
        {
            string[] result = new string[types.Length];
            int j = 0;
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsClass && (!types[i].IsAbstract) && types[i].FullName.Contains("User_Classes"))
                    result[j++] = types[i].Name;
                    //ClassesCB.Items.Add(types[i].Name);
            }
            Array.Resize(ref result, j);
            return result;
        }

        public string[] GetChildClasses()
        {
            string[] result = new string[0];
            for (int i = 0; i < types.Length; i++)
                if (types[i].BaseType == edit_obj_props[edit_prop_num].PropertyType)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = types[i].Name;
                }
            return result;
        }

        private object[] GetChildObjects()
        {
            object[] result = new object[0];
            for (int i = 0; i < objects.Length; i++)
                if (objects[i].GetType().BaseType == edit_obj_props[edit_prop_num].PropertyType)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = objects[i];
                }
            return result;
        }

        public string[] GetChildObjectsTxt()
        {
            object[] children = GetChildObjects();
            string[] result = new string[children.Length];
            for (int i = 0; i < result.Length; i++)
            {
                Type type = children[i].GetType();
                PropertyInfo prop_info = type.GetProperty("name", BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic);
                result[i] = (string)prop_info.GetValue(children[i]);
            }
            return result;
        }

        public object CreateObject(string type_str)
        {
            int obj_len = objects.Length;
            Array.Resize(ref objects, obj_len + 1);
            int i = 0;
            while (type_str != types[i].Name)
                i++;
            objects[obj_len] = Activator.CreateInstance(types[i]);
            return objects[obj_len];
        }
        public string GetName()
        {
            Type type = objects[edit_obj_num].GetType();
            PropertyInfo prop_info = type.GetProperty("name",BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);
            return (string)prop_info.GetValue(objects[edit_obj_num]);
        }

        public string[] GetObjInfoTxt()
        {
            string[] result = new string[edit_obj_props.Length];
            for (int i = 0; i< edit_obj_props.Length; i++)
            {
                result[i] = edit_obj_props[i].Name + " :  ";
                if (edit_obj_props[i].GetValue(objects[edit_obj_num]) != null)
                    if (edit_obj_props[i].PropertyType.IsClass &&
                    edit_obj_props[i].PropertyType.Name != "String")
                    {
                        Type type = objects[edit_obj_num].GetType();
                        PropertyInfo prop_info = type.GetProperty("weapon", BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.Public
                                | BindingFlags.NonPublic);
                        object buf = prop_info.GetValue(objects[edit_obj_num]);
                        type = buf.GetType();
                        prop_info = type.GetProperty("name", BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.Public
                                | BindingFlags.NonPublic);
                        result[i] += (string)prop_info.GetValue(buf);
                    }
                    else
                        result[i] += Convert.ToString(edit_obj_props[i].GetValue(objects[edit_obj_num])) + ";";
                else
                    result[i] += "none;";
            }
            return result;
        }

        public void SetActiveObj(int ind)
        {
            edit_obj_num = ind;
            edit_prop_num = 0;
            GetProps();
        }

        public void SetActiveLastObj()
        {
            edit_obj_num = objects.Length - 1;
            edit_prop_num = 0;
            GetProps();
        }

        public void GetProps()
        {
            Type type = objects[edit_obj_num].GetType();
            edit_obj_props = type.GetProperties(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public);
        }

        public void SetActiveProp(int num)
        {
            edit_prop_num = num;
        }

        public bool SetPropVal(string val, int ind)
        {
            if (edit_obj_props[edit_prop_num].PropertyType.Name == "Int32")
            {
                try
                {
                    if (Convert.ToInt32(val) >= 0)
                    {
                        edit_obj_props[edit_prop_num].SetValue(objects[edit_obj_num],
                            Convert.ToInt32(val));
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            if (edit_obj_props[edit_prop_num].PropertyType.Name == "String")
            {
                edit_obj_props[edit_prop_num].SetValue(objects[edit_obj_num], val);
                return true;
            }
            if (edit_obj_props[edit_prop_num].PropertyType.IsClass &&
                edit_obj_props[edit_prop_num].PropertyType.Name != "String")
            {
                object[] children = GetChildObjects();
                edit_obj_props[edit_prop_num].SetValue(objects[edit_obj_num], children[ind]);
                return true;
                //edit_obj_props[edit_prop_num].SetValue(objects[edit_obj_num], CreateObject(val));
            }
            return false;
        }

        public void DeleteObj()
        {
            PropertyInfo[] buf_props;
            Type type;
            for (int i = 0; i < objects.Length; i++)
            {
                type = objects[i].GetType();
                buf_props = type.GetProperties(BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public);
                for (int j = 0; j < buf_props.Length; j++)
                    if (ReferenceEquals(buf_props[j].GetValue(objects[i]), objects[edit_obj_num]))
                    {
                        buf_props[j].SetValue(objects[i], null);
                    }
            }
            objects[edit_obj_num] = null;
            for (int i = edit_obj_num; i < objects.Length - 1; i++)
            {
                objects[i] = objects[i + 1];
            }
            Array.Resize(ref objects, objects.Length - 1);
            if (edit_obj_num > 0)
                edit_obj_num -= 1;
        }

        //--------------------------------------------------------------------------------------------

        public string[] GetSerialisers()//недоработано ю ноу?
        {
            string[] result = new string[types.Length];
            int j = 0;
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsClass && types[i].FullName.Contains("Serializers"))
                    result[j++] = types[i].Name;
                //ClassesCB.Items.Add(types[i].Name);
            }
            Array.Resize(ref result, j);
            return result;
        }
        //выбираем как сохранять и доставать в зависимости от поля IsTxt (dialog)
        public void SerialiseJson()
        {
            //string MyStr = MyJsonSerializer.SerializeObj(objects[edit_obj_num]);
            //object MyObj = MyJsonSerializer.DeserializeObj(MyStr, types);
            int a = 1;
        }

        private void SaveTxt(string path, string[] text)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < text.Length; i++)
                    sw.WriteLine(text[i]);
            }
        }

        public void Save(string path, string ser_name)
        {
            int i = 0;
            object[] save_objects = DeletExtra();
            while (types[i].Name != ser_name)
                i++;
            if ((bool)types[i].GetField("IsTxt").GetValue(null))
            {
                object[] ps = { save_objects };
                string[] text = (string[])types[i].GetMethod("SerializeArr").Invoke(null, ps);
                SaveTxt(path, text);
            }
            else
            {
                object[] ps = { objects, path};
                types[i].GetMethod("SerializeArr").Invoke(null, ps);
            }
        }

        private string[] LoadTxt(string path)
        {
            string[] result = new string[0];
            using (StreamReader sr = new StreamReader(path))
            {
                string buf;
                while((buf = sr.ReadLine()) != null)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = buf;
                }    
            }
            return result;
        }


        public void Load(string path, string ser_name)
        {
            int i = 0;
            while (types[i].Name != ser_name)
                i++;
            if ((bool)types[i].GetField("IsTxt").GetValue(null))
            {
                string[] objs_txt = LoadTxt(path);
                object[] ps = { objs_txt };
                objects = (object[])types[i].GetMethod("DeserializeArr").Invoke(null, ps);
            }
            else
            {
                object[] ps = { path };
                objects = (object[])types[i].GetMethod("DeserializeArr").Invoke(null, ps);
            }
        }

        private object[] DeletExtra()
        {
            int[] Labels = new int[objects.Length];
            int size = 0;
            for (int i = 0; i < objects.Length; i++)
                Labels[i] = 1;
            for(int i = 0; i < objects.Length; i++)
            {
                PropertyInfo[] props = objects[i].GetType().GetProperties();
                for(int j = 0; j < props.Length; j++)
                {
                    if(props[j].PropertyType.IsClass && props[j].PropertyType.FullName.Contains("User_Classes"))
                    {
                        for(int k = 0; k < objects.Length; k++)
                        {
                            if (ReferenceEquals(props[j].GetValue(objects[i]), objects[k]))
                                Labels[k] = -1;
                        }
                    }
                }
            }
            for (int i = 0; i < objects.Length; i++)
                if (Labels[i] > 0)
                    size++;
            object[] result = new object[size];
            int l = 0;
            for(int i = 0; i < objects.Length; i++)
            {
                if(Labels[i] == 1)
                {
                    result[l] = objects[i];
                    l++;
                }
            }
            return result;
        }
        /*public void LoadFromTxtFile(string file_name)
        {
            using(StreamReader )
        }*/
    }
}