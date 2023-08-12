using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace StudentManagerProDAL
{
    /// <summary>
    /// 访问SQLServer数据库的通用类
    /// </summary>
    class SQLHelper
    {

        // 定义连接字符串
        public static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 执行insert、update、delete类型的SQL语句
        /// </summary>
        /// <param name="sql">sql语句或存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="isProcedure">是否是存储过程</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(String sql,SqlParameter[] parameters = null, bool isProcedure = false)
        {
            // 1.创建连接对象
            SqlConnection conn = new SqlConnection(connString);
            // 2.创建Command对象
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }

            if(parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Exception("执行public static int ExecuteNonQuery(String sql,SqlParameter[] parameters = null, bool isProcedure = false)发生异常：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>查询结果</returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw new Exception("执行public static object GetSingleResult(string sql)发生异常：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行一个结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>结果集</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("执行public static SqlDataReader GetReader(string sql)发生异常：" + ex.Message);
            }

        }

        /// <summary>
        /// 执行一条SQL语句，返回包含一个Datable的DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string tableName = null)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                if (tableName != null)
                {
                    da.Fill(ds, tableName);
                }
                else
                {
                    da.Fill(ds);
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("执行public static DataSet GetDataSet(string sql, string tableName= null)发生异常：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 执行多个查询，放到dataset中，用表的名称区分表
        /// </summary>
        /// <param name="dicSql">key：表名，value：sql</param>
        /// <returns></returns>
        public static DataSet GetDataSet(Dictionary<string, string> dicSql)
        {
            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();

                foreach (string tableName in dicSql.Keys)
                {
                    cmd.CommandText = dicSql[tableName];
                    da.Fill(ds, tableName);
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("执行Dictionary<string,string> dicSql发生异常：" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 获取数据库服务器的时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            return Convert.ToDateTime(GetSingleResult("select getdate()"));
        }
    }
}
  