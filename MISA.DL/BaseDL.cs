using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DL
{
    public class BaseDL<MISAEntity> : IBaseDL<MISAEntity>
    {

        protected String _connectionString = "" +
            "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MF64_CukCuk_LeAnhTuan;" +
                "User Id = dev;" +
                "Password= 12345678";


        protected IDbConnection _dbConnection;

        /// <summary>
        /// lay du lieu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetAll()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3.tực hiện lấy tất cả dữ lieu trong db
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{typename}s";
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
        /// <summary>
        /// lay du lieu theo id
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public MISAEntity GetId(Guid entityId)
        {

            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"SELECT * FROM {typename} WHERE {typename}Id = '{entityId.ToString()}'";
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand);
                return entity;
            }
        }
        /// <summary>
        /// lay theo ma kh
        /// </summary>
        /// <param name="entityCode"></param>
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetFind(String entity, int e_pageSize, int e_pageIndex)
        {

            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_{typename}FillterDivPage";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Code", entity);
                dynamicParameters.Add("@Name", entity);
                dynamicParameters.Add("@Phone", entity);
                dynamicParameters.Add("@mPhone", entity);
                dynamicParameters.Add("@m_PageIndex", e_pageIndex);
                dynamicParameters.Add("@m_PageSize", e_pageSize);
                //var sqlCommand = $"SELECT * FROM {typename} WHERE {typename}.EmployeeCode LIKE CONCAT('%', {entity.ToString()}, '%') OR {typename}.FullName LIKE CONCAT('%', {entity.ToString()}, '%') OR {typename}.MobilePhoneNumber LIKE CONCAT('%', {entity.ToString()}, '%') OR {typename}.PhoneNumber LIKE CONCAT('%', {entity.ToString()}, '%') ";
                var entitie = _dbConnection.Query<MISAEntity>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return entitie;
            }
        }

        public IEnumerable<MISAEntity> GetTotal(String entityCode)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_{typename}Fillter";
                DynamicParameters dynamicParameter = new DynamicParameters();
                dynamicParameter.Add("@Code", entityCode);
                dynamicParameter.Add("@Name", entityCode);
                dynamicParameter.Add("@Phone", entityCode);
                dynamicParameter.Add("@mPhone", entityCode);
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, param: dynamicParameter, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        /// <summary>
        /// insert du lieu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(MISAEntity entity)

        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Insert{typename}";
                var rowAffects = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }

        }
        /// <summary>
        /// update du lieu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="entityID"></param>
        /// <returns></returns>
        public int Update(MISAEntity entity, Guid entityID)

        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var typename = typeof(MISAEntity).Name;
                var entityPropetyName = $"{typename}Id";
                var entityPropety = typeof(MISAEntity).GetProperty("EmployeeId");
                if (entityPropety != null)
                {
                    typeof(MISAEntity).GetProperty(entityPropetyName).SetValue(entity, entityID);
                }
                var sqlCommand = $"Proc_Update{typename}";
                var rowAffects = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }

        }

        public int Delete(Guid entityID)

        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var typename = typeof(MISAEntity).Name;
                var sqlCommand = $"DELETE FROM {typename} WHERE {typename}Id = '{entityID.ToString()}'";
                var rowAffects = _dbConnection.Execute(sqlCommand);
                return rowAffects;
            }

        }
    }

}
