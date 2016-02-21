using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace de_server.App_Config
{
    public class DataTableSerializer
    {
        public static string SerializeToJson(DataTable dt)
        {
            return JsonConvert.SerializeObject(dt, Formatting.None);
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
             DataTable dtReturn = new DataTable();
             PropertyInfo[] oProps = null;

             if (varlist == null) return dtReturn;

             foreach (T rec in varlist)
             {
                 if (oProps == null)
                  {
                       oProps = ((Type)rec.GetType()).GetProperties();
                       foreach (PropertyInfo pi in oProps)
                       {
                            Type colType = pi.PropertyType;

                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()      
                            ==typeof(Nullable<>)))
                             {
                                 colType = colType.GetGenericArguments()[0];
                             }

                            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                       }
                  }

                  DataRow dr = dtReturn.NewRow();

                  foreach (PropertyInfo pi in oProps)
                  {
                       dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
                       (rec,null);
                  }

                  dtReturn.Rows.Add(dr);
             }
             return dtReturn;
        }

    }
}