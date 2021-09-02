import mysql from 'mysql2'
import formater from './formater.js'
import Collection from './collection.js'

export default class Connector {
  constructor() {
    this._createConnection();
    this._connection.config.queryFormat = formater;
  }

  _createConnection() {
    this._connection = mysql.createConnection({
      host: process.env.DBHOST,
      port: process.env.DBPORT,
      user: process.env.DBUSER,
      password: process.env.DBPASS,
      database: process.env.DBNAME
    })
  }

  CloseConnection(trying = 0) {
    this._connection.end((error) => {
      if (!error) return;
      if (trying == 10) throw new Error(error);
      return this.CloseConnection(trying++);
    })
  }

  ExecuteReader({query,model}, callback) {
    this._connection.connect((err) => {
      if (err) callback(err, null)

      else {
        this._connection.query(query, model, (error, values, fields) => {
          this.CloseConnection();
          if (error) {
            callback(error, { values, fields });
            return;
          }

          callback(error, new Collection({ values, fields }));
          return;
        })
      }
    })
  }

  ExecuteReaderAsync({ query, model }) {
    return new Promise((resolve, reject) => {
      this.ExecuteReader({ query, model }, (error, result) => {
        if (error) reject(error);
        else resolve(result)
      })
    })
  }
}