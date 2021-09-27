using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework
{
    public sealed class KeyValue
    {
        /// <summary>
        /// Key For This Data Structure
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// Value For This Data Structure
        /// </summary>
        public string Value { get; private set; }

        public KeyValue(string key, string value)
        {
            if ((value == null) || (key == null))
            {
                throw new NullReferenceException();
            }
            this.Key = key;
            this.Value = value;
        }
    }
}
