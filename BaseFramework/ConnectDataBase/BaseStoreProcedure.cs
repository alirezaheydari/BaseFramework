using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BaseFramework.ConnectDataBase
{
    public static class BaseStoreProcedure
    {
        #region :Static Method

        /// <summary>
        ///_SP را انجام میدهد
        /// </summary>
        /// <param name="parametrs">ورودی های SP</param>
        /// <param name="storeProcedureName">نام SP</param>
        /// <param name="connectionString">کانکشن استرینگ</param>
        /// <param name="lastMessage">آخرین پیغام خطا</param>
        /// <returns>آیا درست انجام شد</returns>
        public static bool Doing(List<Parameter> parametrs, string storeProcedureName, string connectionString,out string lastMessage)
        {

            try
            {
                using (SqlConnection Connection = new SqlConnection())
                {
                    lastMessage = string.Empty;
                    Connection.ConnectionString = connectionString;
                    using (SqlCommand Command = new SqlCommand())
                    {
                        Command.Connection = Connection ?? null;
                        Command.CommandText = storeProcedureName ?? "";
                        Command.CommandType = CommandType.StoredProcedure;
                        foreach (Parameter p in parametrs)
                        {
                            Command.Parameters.Add(p.Name, p.Type, p.Size);
                            Command.Parameters[p.Name].Value = p.Value;
                        }
                        Command.Parameters.Add("@Result", SqlDbType.NVarChar, 30).Direction = ParameterDirection.ReturnValue;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Command.Connection.Close();
                        lastMessage = Command.Parameters["@Result"].Value.ToStringDBNull();
                        return lastMessage.IsNullOrEmpty() ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                lastMessage = ex.Message;
                return false;
            }
        }
        /// <summary>
        ///_SP را انجام میدهد
        /// </summary>
        /// <param name="parameters">ورودی های SP</param>
        /// <param name="storeProcedure">کلاسی  که اینترفیس مقابل را ارث برد ICreateProcedureable</param>
        /// <param name="connectionString">کلاسی  که اینترفیس مقابل را ارث برد IConnectionStringable</param>
        /// <param name="lastMessage">آخرین پیغام خطا</param>
        /// <returns>آیا درست انجام شد</returns>
        public static bool Doing(List<Parameter> parameters,ICreateProcedureable storeProcedure,IConnectionStringable connectionString, out string lastMessage)
        {
            return Doing(parameters, storeProcedure.GetName(storeProcedure.GetCRUDBase(), storeProcedure.GetTableName()), connectionString.GetConnectionString(), out lastMessage);
        }
        /// <summary>
        /// SP با خروجی مستقیم 
        /// </summary>
        /// <param name="parametrs">ورودی های SP</param>
        /// <param name="storeProcedureName">نام SP</param>
        /// <param name="connectionString">کانکشن استرینگ</param>
        /// <param name="lastMessage">آخرین پیغام خطا</param>
        /// <returns>آیا درست انجام شد</returns>
        public static object Getting(List<Parameter> parametrs, string storeProcedureName, string connectionString, out string lastMessage)
        {

            try
            {
                using (SqlConnection Connection = new SqlConnection())
                {
                    lastMessage = string.Empty;
                    Connection.ConnectionString = connectionString;
                    using (SqlCommand Command = new SqlCommand())
                    {
                        Command.Connection = Connection ?? null;
                        Command.CommandText = storeProcedureName ?? "";
                        Command.CommandType = CommandType.StoredProcedure;
                        foreach (Parameter p in parametrs)
                        {
                            Command.Parameters.Add(p.Name, p.Type, p.Size);
                            Command.Parameters[p.Name].Value = p.Value;
                        }
                        Command.Parameters.Add("@Result", SqlDbType.NVarChar, 30).Direction = ParameterDirection.ReturnValue;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        object Result = Command.ExecuteScalar();
                        Command.Connection.Close();
                        lastMessage = Command.Parameters["@Result"].Value.ToStringDBNull();
                        if (lastMessage.IsNotNullOrEmpty() && Result.IsNotNull())
                        {
                            return Result;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                lastMessage = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// SP با خروجی مستقیم 
        /// </summary>
        /// <param name="parameters">ورودی های SP</param>
        /// <param name="storeProcedure">کلاسی  که اینترفیس مقابل را ارث برد ICreateProcedureable</param>
        /// <param name="connectionString">کلاسی  که اینترفیس مقابل را ارث برد IConnectionStringable</param>
        /// <param name="lastMessage">آخرین پیغام خطا</param>
        /// <returns>آیا درست انجام شد</returns>
        public static object Getting(List<Parameter> parameters, ICreateProcedureable storeProcedure, IConnectionStringable connectionString, out string lastMessage)
        {
            return Getting(parameters, storeProcedure.GetName(storeProcedure.GetCRUDBase(), storeProcedure.GetTableName()), connectionString.GetConnectionString(), out lastMessage);
        }

        public static System.Collections.IEnumerator GetTypes(List<Parameter> parametrs, string storeProcedureName, string connectionString, out string lastMessage)
        {

            try
            {
                using (SqlConnection Connection = new SqlConnection())
                {
                    lastMessage = string.Empty;
                    Connection.ConnectionString = connectionString;
                    using (SqlCommand Command = new SqlCommand())
                    {
                        Command.Connection = Connection ?? null;
                        Command.CommandText = storeProcedureName ?? "";
                        Command.CommandType = CommandType.StoredProcedure;
                        foreach (Parameter p in parametrs)
                        {
                            Command.Parameters.Add(p.Name, p.Type, p.Size);
                            Command.Parameters[p.Name].Value = p.Value;
                        }
                        Command.Parameters.Add("@Result", SqlDbType.NVarChar, 30).Direction = ParameterDirection.ReturnValue;
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        SqlDataReader dataReader = Command.ExecuteReader();
                        System.Collections.IEnumerator Result = dataReader.GetEnumerator();
                        Command.Connection.Close();
                        lastMessage = Command.Parameters["@Result"].Value.ToStringDBNull();
                        if (lastMessage.IsNotNullOrEmpty() && Result.IsNotNull())
                        {
                            return Result;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                lastMessage = ex.Message;
                return null;
            }
        }
        #endregion


    }
}
