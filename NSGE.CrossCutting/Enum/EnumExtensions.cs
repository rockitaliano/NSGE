using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.CrossCutting.CustomException;
using System.Reflection;
using System;

namespace NSGE.CrosCutting.Enum
{
    public static class EnumExtensions
    {
        public static string EnumDescription(this System.Enum value)
        {
            return value.ToString();
        }
       
        public static string EnumValue(this System.Enum value)
        {
            return value.ToString();
        }
        //public static T GetEnum<T>(this string value)
        //{
        //    try
        //    {
        //        return (T)System.Enum.Parse(typeof(T), value, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NSGECustomException("", ex.Message);
        //    }
            
        //}

        public static T GetEnum<T>(this string value, string attributeName = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O valor não pode ser nulo ou vazio.", nameof(value));
            }

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Não foi possível converter '{value}' para o tipo enum {typeof(T).FullName}.");
            }

            var enumType = typeof(T);
            var enumValues = System.Enum.GetValues(enumType);

            foreach (var enumValue in enumValues)
            {
                var memberInfo = enumType.GetMember(enumValue.ToString()).FirstOrDefault();
                if (memberInfo != null)
                {
                    var textAttribute = memberInfo.GetCustomAttribute<EnumTextAttribute>();
                    var valueAttribute = memberInfo.GetCustomAttribute<EnumValueAttribute>();

                    if ((textAttribute != null && textAttribute.EnumText.ToString() == enumValue.ToString()) ||
                        (valueAttribute != null && valueAttribute.EnumValue.ToString() == enumValue.ToString()))
                    {
                        return (T)enumValue;
                    }
                }
            }

            throw new ArgumentException($"Não foi possível encontrar um valor correspondente para '{value}' no tipo enum {typeof(T).FullName}.");
        }

        public static IEnumerable<SelectListItem> List(Type type, string selectedItem)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("O tipo fornecido deve ser uma enumeração.");
            }

            var options = new List<SelectListItem>();
            foreach (var enumValue in System.Enum.GetValues(type))
            {
                var value = enumValue.ToString();
                var label = enumValue.ToString();
                var listItem = new SelectListItem
                {
                    Value = value,
                    Text = label,
                    Selected = (value == selectedItem)
                };
                options.Add(listItem);
            }

            return options;
        }

        public static string GetEnumText(this System.Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attributes = fieldInfo.GetCustomAttributes(typeof(EnumTextAttribute), false) as EnumTextAttribute[];

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].EnumText;
                }
            }

            return value.ToString(); // Retorna o nome do enum caso não encontre o atributo EnumText.
        }

        public static string GetEnumValue(this System.Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            MemberInfo[] memberInfo = enumType.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var enumValueAttribute = memberInfo[0]
                    .GetCustomAttributes(typeof(EnumValueAttribute), false)
                    .FirstOrDefault() as EnumValueAttribute;

                if (enumValueAttribute != null)
                {
                    return enumValueAttribute.EnumValue;
                }
            }

            return null;
        }

        public static SelectList ToSelectList<TEnum>(this TEnum obj) 
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(System.Enum.GetValues(typeof(TEnum)).OfType<System.Enum>().Select(x => new SelectListItem
            {
                Text = System.Enum.GetName(typeof(TEnum), x),
                Value = Convert.ToInt32(x).ToString()
            }), "Value", "Text");
        }

        public static SelectList ToSelectList2<TEnum>(this TEnum? selectedValue)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("O tipo fornecido não é um enum.");
            }

            var values = System.Enum.GetValues(typeof(TEnum))
                             .Cast<TEnum>()
                             .Select(e => new SelectListItem
                             {
                                 Value = Convert.ChangeType(e, typeof(int)).ToString(),
                                 Text = e.ToString(),
                                 Selected = selectedValue.HasValue && e.Equals(selectedValue.Value)
                             });

            return new SelectList(values, "Value", "Text");
        }

        public static T GetEnumValue<T>(T? tipoEnum) where T : struct, System.Enum
        {
            if (tipoEnum.HasValue)
            {
                return tipoEnum.Value;
            }
            else
            {
                // Pode decidir retornar um valor padrão ou levantar uma exceção,
                // dependendo do seu requisito. Neste exemplo, retorna o primeiro valor do enum.
                return System.Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault();
            }
        }

        public static string GetEnumTextByValue(string value)
        {
            foreach (var field in typeof(TipoStatusEnum).GetFields())
            {
                var enumValueAttribute = field.GetCustomAttribute<EnumValueAttribute>();
                if (enumValueAttribute != null && enumValueAttribute.EnumValue == value)
                {
                    var enumTextAttribute = field.GetCustomAttribute<EnumTextAttribute>();
                    if (enumTextAttribute != null)
                    {
                        return enumTextAttribute.EnumText;
                    }
                }
            }
            throw new ArgumentException($"Enum text not found for value '{value}'.");
        }



        //[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        //public class EnumTextAttribute : Attribute
        //{
        //    public EnumTextAttribute(string text)
        //    {
        //        Text = text;
        //    }
        //    public string Text { get; }
        //}

        public static string GetEnumText<T>(this T enumValue) where T : struct
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            EnumTextAttribute[] attributes = (EnumTextAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumTextAttribute), true);
            
            return attributes.Length > 0 ? attributes[0].EnumText : enumValue.ToString();
        }

        public static string GetEnumValue<T>(this T enumValue) where T : struct
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            EnumValueAttribute[] attributes = (EnumValueAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumValueAttribute), false);
            return attributes.Length > 0 ? attributes[0].EnumValue : enumValue.ToString();
        }

    }
}
