using System;
using System.Data;
using System.Xml;

namespace SistemaPlanificacionOT.Persistence.Common
{
    public interface IDataAccess : IDisposable
    {
        bool AutoConnection
        {
            get;
            set;
        }


        void OpenConnection();

        void CloseConnection();

        void GetDataSet(string sqlQuery, out DataSet result);

        void GetDataSet(string sqlQuery, DataSet result);

        void GetDataTable(string sqlQuery, out DataTable result);

        void GetDataTable(string sqlQuery, DataTable result);

        void GetDataReader(string sqlQuery, out IDataReader result);

        void GetScalarValue(string sqlQuery, out string result);

        void GetXmlReader(string strSqlQuery, out XmlReader xmlReaderResult);

        void ExecuteQuery(string sqlQuery, out int result);

        void BatchUpdate(DataSet dataSetToBeUpdated);

        void BatchUpdate(DataTable dataTableToBeUpdated);

        int MannualBatchUpdate(DataTable dataTableToBeUpdated, IDbCommand insertCommand, IDbCommand updateCommand, IDbCommand deleteCommand);

        IDataParameter CreateParameter(string paramName, DbType paramType, int paramSize, ParameterDirection paramDirection, string sourceColumn);

        IDbCommand CreateCommand(string strQueryOrSp, CommandType commandType);

        void RunStoredProcedure(string procedureName);

        void RunStoredProcedure(string procedureName, IDataParameter[] arrParameter);

        void RunStoredProcedure(string procedureName, out int result);

        void RunStoredProcedure(string procedureName, out IDataReader dataReader);

        void RunStoredProcedure(string procedureName, out DataSet oDataSet);

        void RunStoredProcedure(string procedureName, DataSet oDataSet);

        void RunStoredProcedure(string procedureName, out DataTable oDataTable);

        void RunStoredProcedure(string procedureName, DataTable oDataTable);

        void RunStoredProcedure(string procedureName, out int result, IDataParameter[] parameter);

        void RunStoredProcedure(string procedureName, out int result, IDataParameter[] parameter, int intCommandTimeOut);

        void RunStoredProcedure(string procedureName, out IDataReader dataReader, IDataParameter[] parameter);

        void RunStoredProcedure(string procedureName, out DataSet oDataSet, IDataParameter[] parameter);

        void RunStoredProcedure(string procedureName, DataSet oDataSet, IDataParameter[] parameter);

        void RunStoredProcedure(string procedureName, out DataTable oDataTable, IDataParameter[] parameter);

        void RunStoredProcedure(string procedureName, DataTable oDataTable, IDataParameter[] parameter);

        void RunStoredProcedure(string strProcedureName, out XmlReader xmlReaderResult);

        void RunStoredProcedure(string strProcedureName, out XmlReader xmlReaderResult, IDataParameter[] arrSqlParameter);

        void RunStoredProcedure(string strProcedureName, out object objScalarResult);

        void RunStoredProcedure(string strProcedureName, out object objScalarResult, IDataParameter[] arrSqlParameter);

        void BeginTransaction(IsolationLevel isoLevel);

        void BeginTransaction(string strNameOfTransaction, IsolationLevel objIsoLevel);

        void RollbackTransaction();

        void RollbackTransaction(string strNameOfTransactionOrSavePoint);

        void CommitTransaction();

        void SetSavePoint(string strSavePointName);
    }
}