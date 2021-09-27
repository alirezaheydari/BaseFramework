using System;
using BaseFramework.Error;

namespace BaseFramework
{
    public static class ExtentionsMethods
    {
        #region :object
        /// <summary>
        /// تبدیل میکنه به رشته بدون توجه به نال بودن
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringDBNull(this object value)
        {
            if (value != null)
                return value.ToString();
            return string.Empty;
        }
        /// <summary>
        /// تبدیل میکنه به عدد صحیح بدون توجه به نال بودن
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this object value)
        {
            int Result;
            if (int.TryParse(value.ToStringDBNull(), out Result))
                return Result;
            return 0;
        }
        /// <summary>
        /// آیا مقدارش نال یا رشته اون خالی یا نال هست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object value)
        {
            if (value == null || value.ToStringDBNull().Equals(string.Empty))
                return true;
            return false;
        }
        /// <summary>
        /// آیا مقدارش نال هست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull(this object value)
        {
            if (value == null)
                return true;
            return false;
        }
        /// <summary>
        /// آیا مقدارش نال نیست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object value)
        {
            return !value.IsNull();
        }
        public static string RepetitousError(this object value,string fieldName,eLanguagePack languagePack)
        {
            string Result;
            MessError.GetMess(1000, languagePack, out Result, fieldName);
            return Result.ToStringDBNull();
        }
        public static int CreateFirstMyHashCode(this object input)
        {
            const int b = 378551;
            int a = 63689;
            int hash = 0;
            // If it overflows then just wrap around
            unchecked
            {
                if (input != null)
                {
                    hash = 54421;
                    hash = a * b + hash * a + input.GetHashCode();
                }
            }
            return hash;
        }
        #endregion

        #region :string
        /// <summary>
        /// آیا خالی هست بدون در نظر گرفتن اسپیس اول و آخر
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmptyTrim(this string value)
        {
            return IsEmpty(value.Trim());
        }
        /// <summary>
        /// آیا خالی نیست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string value)
        {
            return !IsEmpty(value);
        }
        /// <summary>
        /// آیا خالی نیست بدون در نظر گرفتن اسپیس اول و آخر
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotEmptyTrim(this string value)
        {
            return !IsEmptyTrim(value);
        }
        /// <summary>
        /// آیا رشته خالی هست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            if (value.Equals(string.Empty))
                return true;
            return false;
        }
        /// <summary>
        /// آیا رشته نال یا خالی هست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }
        /// <summary>
        /// تبدیل میکنه به عدد اعشاری
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            double Result;
            if (value.IsNotNull())
                if (double.TryParse(value, out Result))
                    return Result;
            return 0;
        }
        /// <summary>
        /// آیا قابل تبدیل به زمان هست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string value)
        {
            DateTime Result;
            return DateTime.TryParse(value.ToStringDBNull(), out Result);
        }
        /// <summary>
        /// آیا قابل تبدیل به زمان نیست
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotDateTime(this string value)
        {
            return !value.IsDateTime();
        }
        /// <summary>
        /// آیا شماره تلن است یا خیر
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(this string value)
        {
            return (value.IsNotNull() && value.Length.Equals(11) && value.StartsWith("0"));
        }
        #endregion

        #region :int
        /// <summary>
        /// آیا بین دو مقدار عددی صحیح است برابر نباشد با بیشترین عدد یا کمترین عدد
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">مقدار کمتر</param>
        /// <param name="maxValue">مقدار بیشتر</param>
        /// <returns></returns>
        public static bool IsBetweenNotEqualsMinAndMax(this int value,int minValue,int maxValue)
        {
            if (value > minValue && value < maxValue)
                return true;
            return false;
        }

        /// <summary>
        /// آیا بین دو مقدار عددی صحیح است برابر نباشد با بیشترین عدد ولی برابر باشد با کمترین عدد
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">مقدار کمتر</param>
        /// <param name="maxValue">مقدار بیشتر</param>
        /// <returns></returns>
        public static bool IsBetWeenEqualsMin(this int value, int minValue, int maxValue)
        {
            if (value.Equals(minValue))
                return true;
            return value.IsBetweenNotEqualsMinAndMax(minValue, maxValue);
        }

        /// <summary>
        /// آیا بین دو مقدار عددی صحیح است برابر باشد با بیشترین عدد ولی برابر نباشد با کمترین عدد
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">مقدار کمتر</param>
        /// <param name="maxValue">مقدار بیشتر</param>
        /// <returns></returns>
        public static bool IsBetWeenEqualsMax(this int value, int minValue, int maxValue)
        {
            if (value.Equals(maxValue))
                return true;
            return value.IsBetweenNotEqualsMinAndMax(minValue, maxValue);
        }

        /// <summary>
        /// آیا بین دو مقدار عددی صحیح است برابر باشد با بیشترین عدد یا کمترین عدد
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">مقدار کمتر</param>
        /// <param name="maxValue">مقدار بیشتر</param>
        /// <returns></returns>
        public static bool IsBetWeenEqualsMaxOrMin(this int value, int minValue, int maxValue)
        {
            if (value.Equals(maxValue) || value.Equals(maxValue))
                return true;
            return value.IsBetweenNotEqualsMinAndMax(minValue, maxValue);
        }

        /// <summary>
        /// آیا بین دو مقدار عددی صحیح نیست برابر نباشد با بیشترین عدد یا کمترین عدد
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue">مقدار کمتر</param>
        /// <param name="maxValue">مقدار بیشتر</param>
        /// <returns></returns>
        public static bool IsNotBetWeenNotEqualsMinAndMax(this int value, int minValue, int maxValue)
        {
            return !value.IsBetweenNotEqualsMinAndMax(minValue, maxValue);
        }

        public static bool IsNotBetWeenEqualsMin(this int value, int minValue, int maxValue)
        {
            return !value.IsBetWeenEqualsMin(minValue, maxValue);
        }

        public static bool IsNotBetWeenEqualsMax(this int value, int minValue, int maxValue)
        {
            return !value.IsBetWeenEqualsMax(minValue, maxValue);
        }

        public static bool IsNotBetWeenEqualsMaxOrMin(this int value, int minValue, int maxValue)
        {
            return !value.IsNotBetWeenEqualsMaxOrMin(minValue, maxValue);
        }
        /// <summary>
        /// آیا عدد مثبت است
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositive(this int value)
        {
            return value > 0;
        }
        /// <summary>
        /// آیا عدد منفی است
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNegetive(this int value)
        {
            return !value.IsPositive();
        }
        public static int GetHashCodeInternal(this int key1)
        {
            unchecked
            {
                var num = 0x7e53a269;
                num = (-1521134295 * num) + key1;
                num += (num << 10);
                num ^= (num >> 6);

                return num;
            }
        }
        #endregion 
    }
}
