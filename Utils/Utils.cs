using System.Reflection;

namespace Utils
{
    public class UtilFunctions
    {
        public static void SetDefaultIfEmpty(object obj, object objDefault) {
            PropertyInfo[] propertiesObj = obj.GetType().GetProperties();
            PropertyInfo[] propertiesObjDefault = objDefault.GetType().GetProperties(); 
            for (int i = 0; i < propertiesObj.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(propertiesObj[i].GetValue(obj)?.ToString()))
                {
                    propertiesObj[i].SetValue(obj, propertiesObjDefault[i].GetValue(objDefault));
                }
                else
                {
                    propertiesObj[i].SetValue(obj, propertiesObj[i].GetValue(obj));
                }
            }
        }
    }
}