﻿using KikShowAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace KikShowAPI.DAL
{
    public class BaseDAL
    {
        private string _connectionString = Config.DBConnection;

        public DataTable GetDataTable(string storedProcedure, List<SqlParameter> prm)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (prm != null)
                        cmd.Parameters.AddRange(prm.ToArray());
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public Task<DataTable> GetDataTableAsync(string storedProcedure, List<SqlParameter> prm)
        {
            return Task.Run(() =>
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (prm != null)
                            cmd.Parameters.AddRange(prm.ToArray());
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            });
        }

        public static int ExecuteQuery(string connectionstring, string storedProcedure, List<SqlParameter> prm)
        {
            using (var con = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand(storedProcedure, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(prm.ToArray());
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string connectionstring, string query)
        {
            using (var con = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteScalar();
                }
            }
        }

        public async static Task<int> ExecuteQueryAsync(string connectionstring, string storedProcedure, List<SqlParameter> prm)
        {
            using (var con = new SqlConnection(connectionstring))
            {
                using (var cmd = new SqlCommand(storedProcedure, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(prm.ToArray());
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}