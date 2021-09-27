using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.ConnectDataBase
{

    public interface ICreateProcedureable
    {
        eCRUDBase GetCRUDBase();
        string GetTableName();
        string GetName(eCRUDBase crud, string tableName);
    }
}
