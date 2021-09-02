import { FieldPacket, RowDataPacket, OkPacket, ResultSetHeader } from 'mysql2'

class Collection {
  FieldsResult(): FieldPacket[];
  ToArray (): any[];
  Filter(callback: (value: number, value: any, values: any[]) => boolean): Collection;
  Map(callback: (value: number, value: any, values: any[]) => any): Collection;
  Where(callback: (value: number, value: any, values: any[]) => any): Collection;
  Sort(callback: (value: number, value: any, values: any[]) => number): Collection;
  First(): any;
  Last(): any;
  Search(callback: (value: number, value: any, values: any[]) => any): any;
  Count(): number;
}

interface QueryExecute {
  query: string;
  model?: object;
}

class Connector {
  ExecuteReader(argument: QueryExecute, callback: (error?: any, result?: Collection) => any): any;
  ExecuteReaderAsync(argument: QueryExecute): Promise<Collection>;
  ExecuteCommand <T extends RowDataPacket[][] | RowDataPacket[] | OkPacket | OkPacket[] | ResultSetHeader>(argument: QueryExecute, callback: (error?: any, result?: T) => any);
  ExecuteCommand <T extends RowDataPacket[][] | RowDataPacket[] | OkPacket | OkPacket[] | ResultSetHeader>(argument: QueryExecute): Promise<T>;
}

export default Connector;