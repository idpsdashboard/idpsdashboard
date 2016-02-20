using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using IDPSDashboard.Business;
using IDPSDashboard.Model;

namespace IDPSWatcher.libIDPSWatcher
{
    public class libIDPSWatcherImpl
    {
        public DataSet getIDPSSignaturesCategory(int idpsId)
        {
            ids auxIDPS = new ids();
            idsBus oIDPSBus = new idsBus();
            DataSet dtsResult = new DataSet();
            string sqlQuery;

            auxIDPS = oIDPSBus.idsGetById(idpsId);

            if (auxIDPS != null)
            {
                switch (auxIDPS.IdsId)
                { 
                    case 1: //ossec
                        sqlQuery= "SELECT   cat_id as SignatureCategoryId,    "
                                  + "       cat_name as SignatureCategoryName "
                                  + " FROM  Category                          "
                                  + " ORDER by cat_id;                        ";

                        dtsResult= ExecQueryMySQL(auxIDPS.DatabaseHost,
                                                             auxIDPS.DatabaseName,
                                                             auxIDPS.DatabaseUser,
                                                             auxIDPS.DatabasePass,
                                                             sqlQuery);
                    break;
                    case 2: //snort
                    case 3: //suricata
                        sqlQuery= "SELECT   sig_class_id   as SignatureCategoryId,    "
                                  + "       sig_class_name as SignatureCategoryName   "
                                  + " FROM  sig_class                                 "
                                  + " ORDER by sig_class_id;                          ";

                        dtsResult= ExecQueryMySQL(auxIDPS.DatabaseHost,
                                                             auxIDPS.DatabaseName,
                                                             auxIDPS.DatabaseUser,
                                                             auxIDPS.DatabasePass,
                                                             sqlQuery);
                    break;
                    case 4: //bro
                        //TODO
                    break;              
                }
            }

            return dtsResult;
        }
        
        public DataTable getIDPSData()
        {
            DataSet dtsResult   = new DataSet();
            DataTable dttResult = new DataTable();

            dttResult.Columns.Add(new DataColumn("IDPSId", System.Type.GetType("System.Int32")));
            dttResult.Columns.Add(new DataColumn("EventsAlarmId", System.Type.GetType("System.Int32")));
            dttResult.Columns.Add(new DataColumn("IDPSEventId", System.Type.GetType("System.Int32")));
            dttResult.Columns.Add(new DataColumn("datetime   ", System.Type.GetType("System.String")));
            dttResult.Columns.Add(new DataColumn("description", System.Type.GetType("System.String")));
            dttResult.Columns.Add(new DataColumn("source     ", System.Type.GetType("System.String")));

            List<eventsalarm> lstEventsAlarm = new List<eventsalarm>();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();

            ids auxIDPS = new ids();
            idsBus oIDPSBus = new idsBus();

            lstEventsAlarm = oEventsAlarm.eventsalarmGetAll();

            if (lstEventsAlarm.Count > 0)
            {
                foreach (eventsalarm row in lstEventsAlarm)
                {
                    switch (row.IdsId)
                    { 
                        case 1: //ossec
                            auxIDPS  = oIDPSBus.idsGetById(row.IdsId);
                            dtsResult= requestOSSECEvents( auxIDPS.DatabaseHost,
                                                           auxIDPS.DatabaseName,
                                                           auxIDPS.DatabaseUser,
                                                           auxIDPS.DatabasePass,
                                                           row.IdsSignatureCategoryId);

                            if (dtsResult.Tables[0].Rows.Count > 0)
                            { 
                                foreach(DataRow rowResult in dtsResult.Tables[0].Rows)
                                {                                   
                                    dttResult.Rows.Add(row.IdsId,
                                                       row.EventsAlarmId,
                                                       Convert.ToInt32(rowResult[0].ToString()),
                                                       rowResult[1].ToString(),
                                                       rowResult[2].ToString(),
                                                       rowResult[3].ToString());
                                }
                            }
                                                               
                        break;
                        case 2: //snort
                        case 3: //suricata
                            auxIDPS  = oIDPSBus.idsGetById(row.IdsId);
                            dtsResult= requestbarnyard2Events(auxIDPS.DatabaseHost,
                                                              auxIDPS.DatabaseName,
                                                              auxIDPS.DatabaseUser,
                                                              auxIDPS.DatabasePass,
                                                              row.IdsSignatureCategoryId);

                            if (dtsResult.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rowResult in dtsResult.Tables[0].Rows)
                                {
                                    dttResult.Rows.Add(row.IdsId,
                                                       row.EventsAlarmId,
                                                       Convert.ToInt32(rowResult[0].ToString()),
                                                       rowResult[1].ToString(),
                                                       rowResult[2].ToString(),
                                                       rowResult[3].ToString());
                                }
                            }
                        break;

                        case 4: //bro
                            auxIDPS = oIDPSBus.idsGetById(row.IdsId);
                            dtsResult = requestBroEvents(auxIDPS.DatabaseHost,
                                                         auxIDPS.DatabaseName,
                                                         auxIDPS.DatabaseUser,
                                                         auxIDPS.DatabasePass,
                                                         row.IdsSignatureCategoryId);

                            if (dtsResult.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rowResult in dtsResult.Tables[0].Rows)
                                {
                                    dttResult.Rows.Add(row.IdsId,
                                                       row.EventsAlarmId,
                                                       Convert.ToInt32(rowResult[0].ToString()),
                                                       rowResult[1].ToString(),
                                                       rowResult[2].ToString(),
                                                       rowResult[3].ToString());
                                }
                            }
                        break;
                    }
                }
            }
            return dttResult;
        }

        private DataSet requestOSSECEvents(string dbhost, string dbname, string user, string pass, int signatureCategoryId)
        {
            DataSet dtsResult = new DataSet();
            string sqlQuery = "";
            sqlQuery = "   SELECT alert.id as IDPSEventId, "
                       + " data.timestamp,                 "
                       + " signature.description,          "
                       + " alert.src_ip as source          "
                       + " FROM alert                      "
                       + " LEFT JOIN data                  "
                       + " ON alert.id = data.id           "
                       + " LEFT JOIN signature             "  
		               + " ON signature.rule_id = alert.rule_id                  "
                       + " LEFT JOIN signature_category_mapping                  "
                       + " ON signature_category_mapping.rule_id = alert.rule_id "
                       + " WHERE signature_category_mapping.cat_id=              " + signatureCategoryId + ";";

            dtsResult = ExecQueryMySQL(dbhost, dbname, user, pass, sqlQuery);
            return dtsResult;
        }

        private DataSet requestbarnyard2Events(string dbhost, string dbname, string user, string pass, int signatureCategoryId)
        {
            DataSet dtsResult = new DataSet();
            string sqlQuery = "";
            sqlQuery =  " SELECT event.cid as IDPSEventId,  "
                      + " event.timestamp,                  "
                      + " signature.sig_name as description,"
                      + " iphdr.ip_src as source          "
                      + " FROM event                        "
                      + " LEFT JOIN signature               "
                      + "       ON event.signature = signature.sig_id "
                      + " LEFT JOIN sig_class                         "
                      + "       ON  signature.sig_class_id = sig_class.sig_class_id "
                      + " LEFT JOIN iphdr                             "
                      + "       ON  iphdr.sid = event.sid             "
                      + "  WHERE sig_class.sig_class_id =             " + signatureCategoryId + ";";

            dtsResult = ExecQueryMySQL(dbhost, dbname, user, pass, sqlQuery);
            return dtsResult;
        }

        private DataSet requestBroEvents(string dbhost, string dbname, string user, string pass, int signatureCategoryId)
        {
            return new DataSet();        
        }
       
        private static int ExecNoQueryMySQL(string dbhost, string dbname, string user, string pass, string query)
        {
            MySqlConnection cnnMySQL;
            string myStringConnection = "server=" + dbhost + ";uid=" + user + ";pwd=" + pass + ";database=" + dbname +";";
            cnnMySQL = new MySqlConnection(myStringConnection);
            MySqlCommand cmd = new MySqlCommand(query, cnnMySQL);

            try
            {
                cnnMySQL.Open();
                int result = cmd.ExecuteNonQuery();
                cnnMySQL.Close();
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        private static int ExecNoQuerySQLite(string dbhost, string dbname, string user, string pass, string query)
        {
            return 1;
        }

        private static DataSet ExecQueryMySQL(string dbhost, string dbname, string user, string pass, string query)
        {
            MySqlConnection cnnMySQL;
            string myStringConnection = "server=" + dbhost + ";uid=" + user + ";pwd=" + pass + ";database=" + dbname + ";";
            cnnMySQL = new MySqlConnection(myStringConnection);

            try
            { 
                MySqlCommand cmd = new MySqlCommand(query, cnnMySQL);
                MySqlDataAdapter dta = new MySqlDataAdapter(cmd);
                DataSet dts = new DataSet();
                cnnMySQL.Open();
                dta.Fill(dts);
                cnnMySQL.Close();
                return dts;            
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        private static DataSet ExecQuerySQLite(string dbhost, string dbname, string user, string pass, string query)
        {
            return new DataSet();
        }
    }
}
