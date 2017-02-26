using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReportProblem.Business
{
    public class SP_Processing
    {
        //class SPCode
        //{

        //}

#if EmulateDeriveParameters    class MySqlCmdBuilder {        static SqlTypeMap _sqlTypeMap = null;        class SqlTypeMap : DictionaryBase {            public SqlDbType this[string key]              { get { return (SqlDbType)Dictionary[key]; }}            public void Add(string key, SqlDbType value)                { Dictionary.Add(key, value); }        }         //static helper class - don't allow instantiation        private MySqlCmdBuilder() {}             public static void DeriveParameters(SqlCommand cmd)        {            EnsureTypeMap();             //cmd.Parameters[0] will always hold             //the sproc return value            SqlParameter prmRet =                 new SqlParameter("@RETURN_VALUE", SqlDbType.Int);            prmRet.Direction = ParameterDirection.ReturnValue;            cmd.Parameters.Add(prmRet);             string qrySProc =                 "SELECT parameter_name as name"                    + ", data_type as xtype"                    + ", cast(isnull(character_maximum_length, " +                                        "numeric_scale) as int) as prec"                    + ", case when parameter_mode like '%out%' " +                                        "then 1 else 0 end as isoutparam"                + " FROM INFORMATION_SCHEMA.PARAMETERS"                + " WHERE specific_name = '" + cmd.CommandText + "'"                + " ORDER BY ordinal_position";             //query SQL-server for given sproc's parameter info            DataTable dt = new DataTable();             new SqlDataAdapter(qrySProc, cmd.Connection).Fill(dt);            foreach (DataRow dr in dt.Rows)            {                SqlParameter prm = new SqlParameter(                        (string)dr[0],               //dr["name"]                         _sqlTypeMap[(string)dr[1]],  //dr["xtype"]                        (int)dr[2]);                 //dr["prec"]                if ((int)dr[3] == 1)                 //isoutparam?                    prm.Direction = ParameterDirection.Output;                cmd.Parameters.Add(prm);            }        }         static void EnsureTypeMap()        {            if (_sqlTypeMap == null) {                _sqlTypeMap = new SqlTypeMap();                _sqlTypeMap.Add("bit",          SqlDbType.Bit);                _sqlTypeMap.Add("int",          SqlDbType.Int);                _sqlTypeMap.Add("smallint",     SqlDbType.SmallInt);                _sqlTypeMap.Add("tinyint",      SqlDbType.TinyInt);                _sqlTypeMap.Add("datetime",     SqlDbType.DateTime);                _sqlTypeMap.Add("smalldatetime",SqlDbType.SmallDateTime);                _sqlTypeMap.Add("char",         SqlDbType.Char);                _sqlTypeMap.Add("varchar",      SqlDbType.VarChar);                _sqlTypeMap.Add("nchar",        SqlDbType.NChar);                _sqlTypeMap.Add("nvarchar",     SqlDbType.NVarChar);                //add more here if SqlTypeMap[...] throws an exception            }        }    }#endif

        public class MySqlConn
        {
            SqlConnection _dbConn;
            SProcList _sprocs;  //sproc parameter info cache
            SqlParameterCollection _lastParams; //used by Param()

        /// <summary>
            /// vnmsrv601_FinalAssy
        /// </summary>
        /// <param name="database"></param>
            public MySqlConn(string database)
            {
                if (database == "vnmsrv601_FFCPACKING") database = @"Server=10.84.10.67\SIPLACE_2008R2EX;Database=FFCPacking;user id=sa;password=Siplace.1; Trusted_Connection=False";
                if (database == "vnmsrv601_FinalAssy") database = @"Server=10.84.10.67\SIPLACE_2008R2EX;Database=FinalAssy;user id=sa;password=Siplace.1; Trusted_Connection=False";
                if (database == "vnmsrv601_PTR") database = @"Server=10.84.10.67\SIPLACE_2008R2EX;Database=PTR;user id=sa;password=Siplace.1; Trusted_Connection=False";
                //if (database == "vnmsrvacs_ACSEE") database = "";
                    //do nothing

                _dbConn = new SqlConnection(database);
                _sprocs = new SProcList(this);
            }
          

            void Open()
            { if (_dbConn.State != ConnectionState.Open) _dbConn.Open(); }
            void Close()
            { if (_dbConn.State == ConnectionState.Open) _dbConn.Close(); }

            SqlCommand NewSProc(string procName)
            {
                SqlCommand cmd = new SqlCommand(procName, _dbConn);
                cmd.CommandType = CommandType.StoredProcedure;

#if EmulateDeriveParameters   //see below for our                               //own DeriveParameters            MySqlCmdBuilder.DeriveParameters(cmd);#else
                Open();
                SqlCommandBuilder.DeriveParameters(cmd);
                //SQL treats OUT params as REF params 
                //(thus requiring those parameters to be passed in)
                //if that's what you really want, remove 
                //the next three lines
                foreach (SqlParameter prm in cmd.Parameters)
                    if (prm.Direction == ParameterDirection.InputOutput)
                        //make param a true OUT param
                        prm.Direction = ParameterDirection.Output;
#endif

                return cmd;
            }

            SqlCommand FillParams(string procName,
                                    params object[] vals)
            {
                //get cached info (or cache if first call)
                SqlCommand cmd = _sprocs[procName];

                //fill parameter values for stored procedure call
                int i = 0;
                foreach (SqlParameter prm in cmd.Parameters)
                {
                    //we got info for ALL the params - only 
                    //fill the INPUT params
                    if (prm.Direction == ParameterDirection.Input
                     || prm.Direction == ParameterDirection.InputOutput)
                        prm.Value = vals[i++];
                }
                //make sure the right number of parameters was passed
                Debug.Assert(i == (vals == null ? 0 : vals.Length));

                //for subsequent calls to Param()
                _lastParams = cmd.Parameters;
                return cmd;
            }

            //handy routine if you are in control of the input.
            //but if user input, vulnerable to sql injection attack
            public DataRowCollection QueryRows(string strQry)
            {
                DataTable dt = new DataTable();
                new SqlDataAdapter(strQry, _dbConn).Fill(dt);
                return dt.Rows;
            }

            public int ExecSProc(string procName,
                                  params object[] vals)
            {
                int retVal = -1;  //some error code

                try
                {
                    Open();
                    FillParams(procName, vals).ExecuteNonQuery();
                    retVal = (int)_lastParams[0].Value;
                }
                //any special handling for SQL-generated error here
                //catch (System.Data.SqlClient.SqlException esql) {}
                catch (System.Exception e)
                {
                    //handle error
                }
                finally
                {
                    Close();
                }
                return retVal;
            }

            public DataSet ExecSProcDS(string procName,
                                         params object[] vals)
            {
                DataSet ds = new DataSet();

                try
                {
                    Open();
                    new SqlDataAdapter(
                          FillParams(procName, vals)).Fill(ds);
                }
                finally
                {
                    Close();
                }
                return ds;
            }

            //get parameter from most recent ExecSProc
            public object Param(string param)
            {
                return _lastParams[param].Value;
            }

            class SProcList : System.Collections.DictionaryBase
            {
                MySqlConn _db;
                public SProcList(MySqlConn db)
                { _db = db; }

                public SqlCommand this[string name]
                {
                    get
                    {      //read-only, "install on demand"
                        if (!Dictionary.Contains(name))
                            Dictionary.Add(name, _db.NewSProc(name));
                        return (SqlCommand)Dictionary[name];
                    }
                }
            }
        }

    }
}
