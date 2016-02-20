using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace dal.SqlServerLibrary
{
    public class SqlImplHelper
    {
        private static string _connectionString = null;
        private static MySqlTransaction _transaction = null;
        private static MySqlConnection _connection = null;

        /*getConnectionString vieja. Se mantiene para referencia.*/
        public static string getConnectionString()
        {
            if (_connectionString == null)
            {
                Services.Utility oUtil = new Services.Utility();
                _connectionString = oUtil.Decrypt(dal.SqlServerLibrary.Properties.Settings.Default.CadenaConexion);
            }

            return _connectionString;
        }

        /*
        public static string getConnectionString()
        {
            return _connectionString;
        }
         */

        public static MySqlTransaction getTransaction()
        {
            try
            {
                if (_transaction == null || _transaction.Connection == null)
                {
                    _connection = new MySqlConnection(getConnectionString());
                    _connection.Open();
                    _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);
                }

                return _transaction;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void commitTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _connection.Close();
                    _connection = null;
                    _transaction = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void rollbackTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _connection.Close();
                    _connection = null;
                    _transaction = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool setConnectionString(string cadenaConexion)
        {
            if (cadenaConexion == null || cadenaConexion == "")
                return false;

            Services.Utility oUtil = new Services.Utility();
            _connectionString = oUtil.Decrypt(cadenaConexion);

            if (_connectionString == null)
                return false;

            return true;
        }

        #region Datarows GettersRows

        public static bool getBoolValue(object drValue, string valueToCompare)
        {
            if (Convert.IsDBNull(drValue))
            {
                return false;
            }
            else
            {
                return drValue.ToString().Trim().Equals(valueToCompare) ? true : false;
            }
        }

        public static DateTime getDateTimeValue(object drValue)
        {
            return Convert.IsDBNull(drValue) ? new DateTime(1, 1, 1) : Convert.ToDateTime(drValue.ToString());
        }

        public static DateTime getMinValueIfNull(object drValue)
        {
            return Convert.IsDBNull(drValue) || drValue.ToString().Length == 0 ? new DateTime(1, 1, 1) : Convert.ToDateTime(drValue.ToString());
        }

        public static DateTime getMaxValueIfNull(object drValue)
        {
            return Convert.IsDBNull(drValue) || drValue.ToString().Length == 0 ? DateTime.MaxValue : Convert.ToDateTime(drValue.ToString());
        }

        public static int getIntValue(object drValue)
        {
            if (Convert.IsDBNull(drValue) || drValue.ToString().Trim().Length == 0)
            {
                return 0;
            }

            return Convert.ToInt32(drValue.ToString().Trim());
        }

        public static long getLongValue(object drValue)
        {
            if (Convert.IsDBNull(drValue) || drValue.ToString().Trim().Length == 0)
            {
                return 0;
            }

            return Convert.ToInt64(drValue.ToString().Trim());
        }

        public static double getDoubleValue(object drValue)
        {
            if (Convert.IsDBNull(drValue) || drValue.ToString().Trim().Length == 0)
            {
                return 0;
            }

            return Convert.ToDouble(drValue.ToString().Trim());
        }

        public static decimal getDecimalValue(object drValue)
        {
            if (Convert.IsDBNull(drValue) || drValue.ToString().Trim().Length == 0)
            {
                return 0;
            }

            return Convert.ToDecimal(drValue.ToString().Trim());
        }

        public static string getStringValue(object drValue)
        {
            return Convert.IsDBNull(drValue) ? "" : drValue.ToString().Trim();
        }

        #endregion

        #region GettersNull

        public static object getNullIfEmpty(string sValue)
        {
            if (sValue == null || sValue.Trim().Length == 0)
            {
                return null;
            }

            return sValue;
        }

        public static object getNullIfNegative(int iValue)
        {
            if (iValue <= 0)
            {
                return null;
            }

            return iValue;
        }

        public static object getNullIfNegative(long iValue)
        {
            if (iValue <= 0)
            {
                return null;
            }

            return iValue;
        }


        public static object getNullIfDateMinValue(DateTime dtValue)
        {
            if (dtValue == DateTime.MinValue)
            {
                return null;
            }

            return dtValue;
        }

        public static object getNullIfDateMaxValue(DateTime dtValue)
        {
            if (dtValue == DateTime.MaxValue)
            {
                return null;
            }

            return dtValue;
        }

        public static string getSifTrue(bool bValue)
        {
            return bValue == true ? "S" : "N";
        }

        public static object getNullIfCero(string value)
        {
            return value == "0" ? null : value;
        }
        
        public static object getNullIfMinus(string value)
        {
            return value == "-1" ? null : value;
        }

        #endregion

        public static string getDefault(string sClave)
        {
            try
            {
                string spCommandText = "SELECT mpls_neg_pkg.Busca_valor_default('" + sClave + "') FROM dual";

                MySqlParameter[] oParams = { };

                return SqlServerLibrary.SqlHelper.ExecuteScalar(getConnectionString(), CommandType.Text, spCommandText, oParams).ToString();
                
            }
            catch (System.Exception ex)
            {
                throw new SqlImplException("Error in getDefault", ex);
            }
        }

    }

}