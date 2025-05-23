
using System.Reflection;
using System.Text;


namespace UI
{
    public static class Tools
    {/*
        public static string ToStringProperty<T>(this T obj, string prefix = "")
        {
            StringBuilder sb = new StringBuilder();
            Type t = obj?.GetType() ?? throw new Exception("Obj is NULL");
            foreach (PropertyInfo prop in t.GetProperties())
            {
                if (prop.PropertyType.IsPrimitive
                    || prop.PropertyType == typeof(string)
                    || prop.PropertyType == typeof(DateTime))
                    sb.AppendLine($"{prefix}{prop.Name} = {prop.GetValue(obj)}");
                else
                    sb.Append($"{prefix}{prop.Name} =\n{prop.GetValue(obj).ToStringProperty(prefix + "\t")}");
            }
            return sb.ToString();
        }*/
        public static string ToStringProperty<T>(this T obj, string prefix = "")
        {
            if (obj == null)
                return $"{prefix}null";

            Type type = obj.GetType();
            var sb = new StringBuilder();

            foreach (FieldInfo field in type.GetFields())
            {
                object? value = field.GetValue(obj);
                sb.AppendLine($"{prefix}{field.Name} = {value}");
            }

            return sb.ToString();
        }
    }
}
