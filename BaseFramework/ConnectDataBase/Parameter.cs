using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BaseFramework.ConnectDataBase
{
    public class Parameter
    {
        public string Name;
        public string Value;
        public SqlDbType Type { get; set; }
        public int Size { get; set; }
        public Parameter(string name, string value, SqlDbType type)
        {
            Init(name, value, type);
            if (SqlDbType.NVarChar.Equals(type))
                Size = 30;

        }
        public Parameter(string name, string value, SqlDbType type, int size)
        {
            Init(name, value, type);
            if (SqlDbType.NVarChar.Equals(type))
                Size = size;

        }
        /// <summary>
        /// ایجاد یک پارامتر 
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="value">مقدار</param>
        /// <param name="type">نوع</param>
        private void Init(string name, string value, SqlDbType type)
        {
            Name = name.ToStringDBNull();
            Value = value.ToStringDBNull();
            Type = type;
        }
    }
}
