using System;

namespace Elmah
{
    using System.Reflection;

    internal static class DeepCloneExtension
    {
        /// <summary> 
        /// Get the deep clone of an object. 
        /// </summary> 
        /// <typeparam name="T">The type of the obj.</typeparam> 
        /// <param name="obj">It is the object used to deep clone.</param> 
        /// <returns>Return the deep clone.</returns> 
        public static T DeepClone<T>(this T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object is null");
            }
            return (T)CloneProcedure(obj);
        }

        /// <summary> 
        /// The method implements deep clone using reflection. 
        /// </summary> 
        /// <param name="obj">It is the object used to deep clone.</param> 
        /// <returns>Return the deep clone.</returns> 
        private static object CloneProcedure(Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            Type type = obj.GetType();

            // If the type of object is the value type, we will always get a new object when  
            // the original object is assigned to another variable. So if the type of the  
            // object is primitive or enum, we just return the object. We will process the  
            // struct type subsequently because the struct type may contain the reference  
            // fields. 
            // If the string variables contain the same chars, they always refer to the same  
            // string in the heap. So if the type of the object is string, we also return the  
            // object. 
            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return obj;
            }
            // If the type of the object is the Array, we use the CreateInstance method to get 
            // a new instance of the array. We also process recursively this method in the  
            // elements of the original array because the type of the element may be the reference  
            // type. 
            else if (type.IsArray)
            {
                Type typeElement = type.Assembly.GetType(type.FullName.Replace("[]", string.Empty));
                var array = obj as Array;
                Array copiedArray = Array.CreateInstance(typeElement, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    // Get the deep clone of the element in the original array and assign the  
                    // clone to the new array. 
                    copiedArray.SetValue(CloneProcedure(array.GetValue(i)), i);

                }
                return copiedArray;
            }
            // If the type of the object is class or struct, it may contain the reference fields,  
            // so we use reflection and process recursively this method in the fields of the object  
            // to get the deep clone of the object.  
            // We use Type.IsValueType method here because there is no way to indicate directly whether  
            // the Type is a struct type. 
            else if (type.IsClass || type.IsValueType)
            {
                object copiedObject = Activator.CreateInstance(obj.GetType());

                // Get all FieldInfo. 
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    object fieldValue = field.GetValue(obj);
                    if (fieldValue != null)
                    {
                        // Get the deep clone of the field in the original object and assign the  
                        // clone to the field in the new object. 
                        field.SetValue(copiedObject, CloneProcedure(fieldValue));
                    }

                }
                return copiedObject;
            }
            else
            {
                throw new ArgumentException("The object is unknown type");
            }
        }
    }
}
