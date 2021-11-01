using MySql.Data.MySqlClient;
using System;

namespace RecorteDeCoração.Connection
{
    public class DbConnection
    {
        public MySqlConnection clientConnection;

        public MySqlConnection ClienteConnection
        {
            get { return this.clientConnection; }
        }

        public DbConnection()
        {
            this.clientConnection = new MySqlConnection(DbConfiguration.Init().ConnectionString());
        }

        public void Open()
        {
            this.clientConnection.Open();
        }

        public void Close()
        {
            if (this.clientConnection.State == System.Data.ConnectionState.Open)
                this.clientConnection.Close();
        }

        //public MySqlCommand PrepareCommand(string sql, MySqlParameter[] parameters = null)
        //{
        //    MySqlCommand command = new MySqlCommand(sql, this.clientConnection);

        //    if (parameters != null)
        //    {
        //        foreach (MySqlParameter parameter in parameters)
        //        {
        //            if (parameter == null) continue;
        //            command.Parameters.Add(parameter);
        //        }
        //    }

        //    return command;
        //}

        //public MySqlCommand ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        //{
        //    MySqlCommand command = this.PrepareCommand(sql, parameters); ;
        //    command.ExecuteNonQuery();
        //    return command;
        //}

        //public MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] parameters)
        //{
        //    MySqlCommand command = this.PrepareCommand(sql, parameters); ;
        //    return command.ExecuteReader();
        //}

        //public long ExecuteScalar(string sql, params MySqlParameter[] parameters) {
        //    MySqlCommand command = this.PrepareCommand(sql, parameters);

        //    command.ExecuteScalar();
        //    return command.LastInsertedId;
        //}

        public bool IsNull(MySqlDataReader reader, string field) {
            return DBNull.Value.Equals(reader[field]);
        }

        public bool IsNotNull(MySqlDataReader reader, string field) {
            return !this.IsNull(reader, field);
        }

        public int ReadInt(MySqlDataReader reader, string field)
        {
            if (this.IsNull(reader, field)) return 0;

            return reader.GetInt32(field);
        }

        public string ReadString(MySqlDataReader reader, string field)
        {
            if (this.IsNull(reader, field)) return "";

            return reader.GetString(field);
        }

        public DateTime ReadDateTime(MySqlDataReader reader, string field)
        {
            if (this.IsNull(reader, field)) return DateTime.Now;

            return reader.GetDateTime(field);
        }
    }
}
